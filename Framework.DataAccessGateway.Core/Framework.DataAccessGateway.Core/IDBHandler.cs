using System;
using System.Collections.Generic;
using System.Data;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Interface IDBHandler
    /// </summary>
    public interface IDBHandler : IDisposable
    {
        
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        string ConnectionString { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        new void Dispose();
      

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <value>The database connection.</value>
        IDbConnection DBConnection { get; }

        /// <summary>
        /// Gets the database transaction.
        /// </summary>
        /// <value>The database transaction.</value>
        IDbTransaction DBTransaction { get; }
    

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>IDbTransaction.</returns>
        IDbTransaction BeginTransaction();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <param name="isolationLevel">The isolation level.</param>
        /// <returns>IDbTransaction.</returns>
        IDbTransaction BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Ends the transaction.
        /// </summary>
        void EndTransaction();

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, CommandType commandType);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, DBHandlerParameter[] parameters, CommandType commandType);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, object model, CommandType commandType);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>System.Object.</returns>
        object ExecuteScalar(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        void ExecuteNonQuery(string queryString, CommandType commandType);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        void ExecuteNonQuery(string queryString, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        void ExecuteNonQuery(string queryString, object model, CommandType commandType);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        void ExecuteNonQuery(string queryString, DBHandlerParameter[] parameters, CommandType commandType);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        void ExecuteNonQuery(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        void ExecuteNonQuery(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction);       

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, object model, CommandType commandType, CommandBehavior commandBehavior = CommandBehavior.CloseConnection);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default);

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <param name="commandBehavior">The command behavior.</param>
        /// <returns>IDataReader.</returns>
        IDataReader ExecuteReader(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction, CommandBehavior commandBehavior = CommandBehavior.Default);

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
        IDataReader ExecuteReader(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction, out IDbCommand dbCommand, CommandBehavior commandBehavior = CommandBehavior.Default);

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
        IDataReader ExecuteReader(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction, out IDbCommand dbCommand, CommandBehavior commandBehavior = CommandBehavior.Default);       
        

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, CommandType commandType);


        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType);


        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType);


        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction);


        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        IList<T> ExecuteQuery<T>(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction);

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, CommandType commandType) where T : class, IDBHandlerMultipleResults, new();

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new();

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType) where T : class, IDBHandlerMultipleResults, new();

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, object model, CommandType commandType) where T : class, IDBHandlerMultipleResults, new();

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="model">The model.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, object model, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new();

        /// <summary>
        /// Executes multiple queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryString">The query string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="queryTransaction">The query transaction.</param>
        /// <returns>IDBHandlerMultipleResults.</returns>
        IDBHandlerMultipleResults ExecuteMultiple<T>(string queryString, DBHandlerParameter[] parameters, CommandType commandType, IDbTransaction queryTransaction) where T : class, IDBHandlerMultipleResults, new();

    }
}