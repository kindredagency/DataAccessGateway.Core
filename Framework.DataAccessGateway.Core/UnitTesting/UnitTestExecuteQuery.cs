using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.DataAccessGateway.Core;
using System.Configuration;
using System.Text;
using System.Linq;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestExecuteQuery
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }   

        [TestMethod]
        public void ExecuteQuery()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteQuery<DataModel>("select * from Data", System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteQuery failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteQueryWithParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteQuery<DataModel>("select * from Data where BigInt = @BigInt", new { BigInt = 1 }, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteQuery with parameters failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteQueryAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteQuery<DataModel>("select * from Data", System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Assert.Fail("ExecuteQuery and transaction failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteQueryWithParametersAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteQuery<DataModel>("select * from Data where BigInt = @BigInt", new { BigInt = 1 }, System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteQuery with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void ExecuteQueryWithParametersWithOutputAndReturnParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);          

            try
            {
               var result1 =  dbHandler.ExecuteQuery<DataModel>("Select Top 1 * from Data", System.Data.CommandType.Text).FirstOrDefault();

                if (result1 != null)
                {
                    InputModel inputModel = new InputModel();

                    inputModel.Data_Id = result1.Id;
                }               
                
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteQuery with parameters and transaction failed: " + ex.Message);                
            }
        }

        [TestMethod]
        public void ExecuteQueryWithParametersAndTransactionWithOutputAndReturnParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result1 = dbHandler.ExecuteQuery<DataModel>("Select Top 1 * from Data", System.Data.CommandType.Text, transaction).FirstOrDefault();

                if (result1 != null)
                {
                    InputModel inputModel = new InputModel();

                    inputModel.Data_Id = result1.Id;
                }              

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteQuery with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }

        public class InputModel
        {            
            public Guid Data_Id { get; set; }

            [DBHandlerProperty(System.Data.ParameterDirection.Output)]
            public int UserID { get; set; }

            [DBHandlerProperty(System.Data.ParameterDirection.ReturnValue)]
            public int ReturnValue { get; set; }
        }
    }
}
