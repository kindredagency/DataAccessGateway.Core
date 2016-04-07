using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Class DBHandlerMSSQL.
    /// </summary>
    internal class DBHandlerMSSQL : IDBHandler
    {    
        private readonly SqlConnection _connection;
        private readonly DataContext _dataContext;

        /// <summary>
        /// Opens the connection.
        /// </summary>
        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        private void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                try
                {
                    _connection.Close();
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerMSSQL"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DBHandlerMSSQL(string connectionString)
        {
            DBTransaction = null;

            try
            {
                _connection = new SqlConnection(connectionString);
                _dataContext = new DataContext(_connection) { ObjectTrackingEnabled = false };

                ConnectionString = connectionString;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _connection.Dispose();
        }   
       
    
        /// <summary>
        /// Gets the database transaction.
        /// </summary>
        /// <value>The database transaction.</value>
        public IDbTransaction DBTransaction { get; private set; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <value>The database connection.</value>
        public IDbConnection DBConnection
        {
            get { return _connection; }
        }
 
        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>IDbTransaction.</returns>
        public IDbTransaction BeginTransaction()
        {
            OpenConnection();
            SqlTransaction transaction = null;
            try
            {
                transaction = _connection.BeginTransaction();
                DBTransaction = transaction;
            }
            catch
            {
                CloseConnection();
                throw;
            }

            return transaction;
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>IDbTransaction.</returns>
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            OpenConnection();
            SqlTransaction trans = null;
            try
            {
                trans = _connection.BeginTransaction(isolationLevel);
                DBTransaction = trans;
            }
            catch
            {
                CloseConnection();
                throw;
            }

            return trans;
        }

        /// <summary>
        /// Ends the transaction.
        /// </summary>
        public void EndTransaction()
        {
            CloseConnection();
        }    

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, CommandType commandType)
        {
            if((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteScalar(queryString, null, commandType, DBTransaction);

            return ExecuteScalar(queryString, null, commandType, null);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, CommandType commandType, IDbTransaction queryTransaction)
        {
            return ExecuteScalar(queryString, null, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, DBHandlerParameter[] parameters, CommandType commandType)
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteScalar(queryString, parameters, commandType, DBTransaction);

            return ExecuteScalar(queryString, parameters, commandType, null);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, object model, CommandType commandType)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            object retVal = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
            {
                retVal = ExecuteScalar(queryString, parameters, commandType, DBTransaction);
            }
            else
            {
                retVal = ExecuteScalar(queryString, parameters, commandType, null);
            }

            parameters.ToModel(model);

            return retVal;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            var retVal = ExecuteScalar(queryString, parameters, commandType, queryTransaction);

            parameters.ToModel(model);

            return retVal;
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction)
        {
            SqlCommand queryCommand = null;
            object returnValue = null;

            try
            {
                queryCommand = new SqlCommand(queryString, _connection);

                if (queryTransaction != null)
                {
                    queryCommand.Transaction = (SqlTransaction)queryTransaction;
                }

                queryCommand.CommandType = commandType;

                if(parameters != null)
                    queryCommand.Parameters.AddRange(parameters.ToSqlParameters());

                OpenConnection();

                returnValue = queryCommand.ExecuteScalar();

                if (parameters != null)
                    queryCommand.Parameters.ToDBHandlerParameters(parameters);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (queryTransaction == null)
                    CloseConnection();

                if (queryCommand != null)
                    queryCommand.Dispose();
            }

            return returnValue;
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, CommandType commandType)
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
            {
                ExecuteNonQuery(queryString, null, commandType, DBTransaction);
            }
            else
            {
                ExecuteNonQuery(queryString, null, commandType, null);
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        public void ExecuteNonQuery(string queryString, CommandType commandType, IDbTransaction queryTransaction)
        {
            ExecuteNonQuery(queryString, null, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, DBHandlerParameter[] parameters, CommandType commandType)
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
            {
                ExecuteNonQuery(queryString, parameters, commandType, DBTransaction);
            }
            else
            {
                ExecuteNonQuery(queryString, parameters, commandType, null);
            }
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, object model, CommandType commandType)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            ExecuteNonQuery(queryString, parameters, commandType);

            parameters.ToModel(model);           
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        public void ExecuteNonQuery(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            ExecuteNonQuery(queryString, parameters, commandType, queryTransaction);

            parameters.ToModel(model);           
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        public void ExecuteNonQuery(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction)
        {
            SqlCommand queryCommand = null;            

            try
            {
                queryCommand = new SqlCommand(queryString, _connection);

                if (queryTransaction != null)
                {
                    queryCommand.Transaction = (SqlTransaction)queryTransaction;
                }

                queryCommand.CommandType = commandType;

                if(parameters != null)
                    queryCommand.Parameters.AddRange(parameters.ToSqlParameters());

                OpenConnection();

                queryCommand.ExecuteNonQuery();

                if (parameters != null)
                    queryCommand.Parameters.ToDBHandlerParameters(parameters);

            }
            catch
            {
                throw;
            }
            finally
            {
                if (queryTransaction == null)
                    CloseConnection();

                if (queryCommand != null)
                    queryCommand.Dispose();
            }            
        }        

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection)
        {
            IDbCommand dbCommand = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteReader(queryString, null, commandType, DBTransaction, out dbCommand, commandBehavior);

            return ExecuteReader(queryString, null, commandType, null, out dbCommand,  commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public IDataReader ExecuteReader(string queryString, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            IDbCommand dbCommand = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteReader(queryString, null, commandType, DBTransaction, out dbCommand, commandBehavior);

            return ExecuteReader(queryString, null, commandType, null, out dbCommand, commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>System.Data.IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, object model, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection)
        {
            IDbCommand dbCommand = null;

            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteReader(queryString, parameters, commandType, DBTransaction, out dbCommand, commandBehavior);

            return ExecuteReader(queryString, parameters, commandType, null, out dbCommand, commandBehavior);
        }       

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection)
        {
            IDbCommand dbCommand = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteReader(queryString, parameters, commandType, DBTransaction, out dbCommand, commandBehavior);

            return ExecuteReader(queryString, parameters, commandType, null, out dbCommand, commandBehavior);
        }
       

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            IDbCommand dbCommand = null;

            return ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, commandBehavior);            
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>System.Data.IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            IDbCommand dbCommand = null;

            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            return ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="dbCommand">The database command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction, out IDbCommand dbCommand, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            return ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="dbCommand">The database command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction, out IDbCommand dbCommand, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            SqlCommand queryCommand = null;
            SqlDataReader dataReader = null;

            try
            {
                queryCommand = new SqlCommand(queryString, _connection);

                if (queryTransaction != null)
                {
                    queryCommand.Transaction = (SqlTransaction)queryTransaction;
                }

                queryCommand.CommandType = commandType;

                if(parameters != null)
                    queryCommand.Parameters.AddRange(parameters.ToSqlParameters());

                OpenConnection();

                dataReader = queryCommand.ExecuteReader(commandBehavior);

                dbCommand = queryCommand;
            }
            catch
            {
                throw;
            }

            return dataReader;
        }        

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, CommandType commandType)
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteQuery<T>(queryString, null, commandType, DBTransaction);

            return ExecuteQuery<T>(queryString, null, commandType, null);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, CommandType commandType, IDbTransaction queryTransaction)
        {
            return ExecuteQuery<T>(queryString, null, commandType, queryTransaction);
        }      

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType)
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteQuery<T>(queryString, parameters, commandType, DBTransaction);

            return ExecuteQuery<T>(queryString, parameters, commandType, null);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Collections.Generic.IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            IList<T> retVal = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
            {
                retVal = ExecuteQuery<T>(queryString, parameters, commandType, DBTransaction);
            }
            else
            {
                retVal = ExecuteQuery<T>(queryString, parameters, commandType, null);
            }

            parameters.ToModel(model);

            return retVal;
        }       

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Collections.Generic.IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction)
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            var retVal = ExecuteQuery<T>(queryString, parameters, commandType, queryTransaction);

            parameters.ToModel(model);

            return retVal;
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction)
        {
            IDbCommand dbCommand = null;
            IDataReader reader = null;

            if(queryTransaction != null)
                reader = ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, CommandBehavior.Default);
            else
                reader = ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, CommandBehavior.CloseConnection);

            var retVal = _dataContext.Translate<T>(reader as DbDataReader).ToList();

            dbCommand.Parameters.ToDBHandlerParameters(parameters);

            return retVal;         
        }

        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, CommandType commandType) where T : class, IDBHandlerMultipleResults, new()
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteMultiple<T>(queryString, null, commandType, DBTransaction);

            return ExecuteMultiple<T>(queryString, null, commandType, null);
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new()
        {
            return ExecuteMultiple<T>(queryString, null, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType) where T : class, IDBHandlerMultipleResults, new()
        {
            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
                return ExecuteMultiple<T>(queryString, parameters, commandType, DBTransaction);

            return ExecuteMultiple<T>(queryString, parameters, commandType, null);
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, object model, CommandType commandType) where T : class, IDBHandlerMultipleResults, new()
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            IDBHandlerMultipleResults retVal = null;

            if ((DBTransaction != null) && (DBTransaction.Connection.State == ConnectionState.Open))
            {
                retVal = ExecuteMultiple<T>(queryString, parameters, commandType, DBTransaction);
            }
            else
            {
                retVal = ExecuteMultiple<T>(queryString, parameters, commandType, null);
            }

            parameters.ToModel(model);

            return retVal;
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new()
        {
            DBHandlerParameter[] parameters = model.ToDBHandlerParameters();

            var retVal = ExecuteMultiple<T>(queryString, parameters, commandType, queryTransaction);

            parameters.ToModel(model);

            return retVal;
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new()
        {
            IDbCommand dbCommand = null;
            IDataReader reader = null;

            if (queryTransaction != null)
                reader = ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, CommandBehavior.Default);
            else
                reader = ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, CommandBehavior.CloseConnection);

            DBHandlerMultipleResultsBase dbHandlerMultipleResults = new T() as DBHandlerMultipleResultsBase;

            dbHandlerMultipleResults.Fill(_dataContext.Translate(reader as DbDataReader));

            dbCommand.Parameters.ToDBHandlerParameters(parameters);

            return dbHandlerMultipleResults;
        }
    }
}