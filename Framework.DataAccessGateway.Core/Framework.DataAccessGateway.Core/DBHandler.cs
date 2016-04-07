using System.Collections.Generic;
using System.Data;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Class DBHandler.
    /// </summary>
    public class DBHandler : IDBHandler 
    {       
        private readonly IDBHandler _independentDbHandler;    

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandler"/> class.
        /// </summary>
        /// <param name="dbHandler">The database handler.</param>
        public DBHandler(IDBHandler dbHandler)
        {
            _independentDbHandler = dbHandler;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandler"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="dbHandlerType">Type of the database handler.</param>
        public DBHandler(string connectionString, DBHandlerType dbHandlerType)
        {
            switch (dbHandlerType)
            {
                case DBHandlerType.DbHandlerMSSQL:
                    _independentDbHandler = new DBHandlerMSSQL(connectionString);
                    break;
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return _independentDbHandler.ConnectionString; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _independentDbHandler.Dispose();
        }

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <value>The database connection.</value>
        public IDbConnection DBConnection
        {
            get { return _independentDbHandler.DBConnection; }
        }

        /// <summary>
        /// Gets the database transaction.
        /// </summary>
        /// <value>The database transaction.</value>
        public IDbTransaction DBTransaction
        {
            get { return _independentDbHandler.DBTransaction; }
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>IDbTransaction.</returns>
        public IDbTransaction BeginTransaction()
        {
            return _independentDbHandler.BeginTransaction();
        }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>IDbTransaction.</returns>
        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return _independentDbHandler.BeginTransaction(isolationLevel);
        }

        /// <summary>
        /// Ends the transaction.
        /// </summary>
        public void EndTransaction()
        {
            _independentDbHandler.EndTransaction();
        }   

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        public object ExecuteScalar(string queryString, CommandType commandType)
        {
            return _independentDbHandler.ExecuteScalar(queryString, commandType);
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
            return _independentDbHandler.ExecuteScalar(queryString, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteScalar(queryString, parameters, commandType);
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
            return _independentDbHandler.ExecuteScalar(queryString, parameters, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteScalar(queryString, model, commandType);
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
            return _independentDbHandler.ExecuteScalar(queryString, model, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, CommandType commandType)
        {
            _independentDbHandler.ExecuteNonQuery(queryString, commandType);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        public void ExecuteNonQuery(string queryString, CommandType commandType, IDbTransaction queryTransaction)
        {
            _independentDbHandler.ExecuteNonQuery(queryString, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, DBHandlerParameter[] parameters, CommandType commandType)
        {
            _independentDbHandler.ExecuteNonQuery(queryString, parameters, commandType);
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
            _independentDbHandler.ExecuteNonQuery(queryString, parameters, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        public void ExecuteNonQuery(string queryString, object model, CommandType commandType)
        {
            _independentDbHandler.ExecuteNonQuery(queryString, model, commandType);
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
            _independentDbHandler.ExecuteNonQuery(queryString, model, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteReader(queryString, commandType);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            return _independentDbHandler.ExecuteReader(queryString, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteReader(queryString, parameters, commandType);
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
            return _independentDbHandler.ExecuteReader(queryString, parameters, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteReader(queryString, parameters, commandType, queryTransaction, out dbCommand, commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, object model, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection)
        {
            return _independentDbHandler.ExecuteReader(queryString, model, commandType, commandBehavior);
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        public IDataReader ExecuteReader(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default)
        {
            return _independentDbHandler.ExecuteReader(queryString, model, commandType, queryTransaction, commandBehavior);
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
            return _independentDbHandler.ExecuteReader(queryString, model, commandType, queryTransaction, out dbCommand, commandBehavior);
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
            return _independentDbHandler.ExecuteQuery<T>(queryString, commandType);
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
            return _independentDbHandler.ExecuteQuery<T>(queryString, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteQuery<T>(queryString, parameters, commandType);
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
            return _independentDbHandler.ExecuteQuery<T>(queryString, parameters, commandType, queryTransaction);
        }
       

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType)
        {
            return _independentDbHandler.ExecuteQuery<T>(queryString, model, commandType);
        }

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction)
        {
            return _independentDbHandler.ExecuteQuery<T>(queryString, model, commandType, queryTransaction);
        }

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        public IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, CommandType commandType) where T : class, IDBHandlerMultipleResults, new()
        {
            return _independentDbHandler.ExecuteMultiple<T>(queryString, commandType);
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
            return _independentDbHandler.ExecuteMultiple<T>(queryString, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteMultiple<T>(queryString, parameters, commandType);
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
            return _independentDbHandler.ExecuteMultiple<T>(queryString, model, commandType);
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
            return _independentDbHandler.ExecuteMultiple<T>(queryString, model, commandType, queryTransaction);
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
            return _independentDbHandler.ExecuteMultiple<T>(queryString, parameters, commandType, queryTransaction);
        }
    }
}