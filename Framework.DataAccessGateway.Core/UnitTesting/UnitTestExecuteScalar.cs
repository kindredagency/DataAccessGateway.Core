using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.DataAccessGateway.Core;
using System.Configuration;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestExecuteScalar
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }

        [TestMethod]
        public void ExecuteScalar()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteScalar("select count(Id) from Data", System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteScalar failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteScalarWithParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                var result = dbHandler.ExecuteScalar("select count(Id) from Data where BigInt = @BigInt", new { BigInt = 1 }, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteScalar with parameters failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteScalarAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteScalar("select count(Id) from Data", System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Assert.Fail("ExecuteScalar and transaction failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteScalarWithParametersAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                var result = dbHandler.ExecuteScalar("select count(Id) from Data where BigInt = @BigInt", new { BigInt = 1 }, System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteScalar with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }
    }
}
