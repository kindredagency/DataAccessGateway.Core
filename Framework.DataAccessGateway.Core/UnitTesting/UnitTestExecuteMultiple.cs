using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.DataAccessGateway.Core;
using System.Configuration;
using System.Text;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestExecuteMultiple
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }   

        [TestMethod]
        public void ExecuteMultiple()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel,SubTableModel>>("select * from Data; Select * from SubTable", System.Data.CommandType.Text);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();

            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteMultiple failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteMultipleWithParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel, SubTableModel>>("select * from Data where BigInt = @BigInt; select * from SubTable", new { BigInt = 1 }, System.Data.CommandType.Text);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteMultiple with parameters failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteMultipleAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel, SubTableModel>>("select * from Data; Select * from SubTable", System.Data.CommandType.Text, transaction);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Assert.Fail("ExecuteMultiple and transaction failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteMultipleWithParametersAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel, SubTableModel>>("select * from Data where BigInt = @BigInt; Select * from SubTable", new { BigInt = 1 }, System.Data.CommandType.Text, transaction);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteMultiple with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }

        [TestMethod]
        public void ExecuteMultipleWithParametersWithOutputAndReturnParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);           

            try
            {
                InputModel inputModel = new InputModel();

                inputModel.BigInt = 1;

                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel, SubTableModel>>("MultipleQueryWithOutputAndReturnParameters", inputModel, System.Data.CommandType.StoredProcedure);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();

                Assert.IsNotNull(inputModel.ID);
                Assert.AreEqual(123, inputModel.ReturnValue);
                
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteMultiple with parameters and transaction failed: " + ex.Message);                
            }
        }

        [TestMethod]
        public void ExecuteMultipleWithParametersAndTransactionsWithOutputAndReturnParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                InputModel inputModel = new InputModel();

                inputModel.BigInt = 1;

                var result = dbHandler.ExecuteMultiple<DBHandlerMultipleResults<DataModel, SubTableModel>>("MultipleQueryWithOutputAndReturnParameters", inputModel, System.Data.CommandType.StoredProcedure, transaction);

                var dataModels = result.Get<DataModel>();
                var subTableModels = result.Get<SubTableModel>();                

                Assert.IsNotNull(inputModel.ID);
                Assert.AreEqual(123, inputModel.ReturnValue);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteMultiple with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }

        public class InputModel
        {
            [DBHandlerProperty(System.Data.ParameterDirection.Output)]
            public Guid ID { get; set; }

            public long BigInt { get; set; }

            [DBHandlerProperty(System.Data.ParameterDirection.ReturnValue)]
            public int ReturnValue { get; set; }
        }

    }
}
