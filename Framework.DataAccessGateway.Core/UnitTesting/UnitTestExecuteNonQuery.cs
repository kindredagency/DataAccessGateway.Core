using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.DataAccessGateway.Core;
using System.Configuration;
using System.Text;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestExecuteNonQuery
    {
        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }

        private string sqlData = @" INSERT INTO [Data]
                                ([Id], [BigInt], [Binary], [Bit], [Char], [Date], [DateTime], [DateTime2], [Decimal], [Float], [Image], [Int], [Money], [NChar], [NText], [NVarChar], [Real], [SmallDateTime], [SmallMoney],
                                [Text], [VarBinary], [VarChar], [DateTimeOffset] )
                                VALUES ( @Id, @BigInt, @Binary, @Bit, @Char, @Date, @DateTime, @DateTime2, @Decimal, @Float,
                                @Image,  @Int,  @Money, @NChar,  @NText, @NVarChar, @Real, @SmallDateTime, @SmallMoney, @Text,
                                @VarBinary, @VarChar, @DateTimeOffset)";

        private string sqlSubTable = @" INSERT INTO [SubTable] ([Data_Id]) VALUES (@Data_Id)";

        private DataModel DataScafold
        {
            get
            {
                var model = new DataModel();

                model.Id = Guid.NewGuid();
                model.BigInt = 1;
                model.Binary = Encoding.ASCII.GetBytes("This is a test");
                model.Bit = true;
                model.Char = "test";
                model.Date = DateTime.Now;
                model.DateTime = DateTime.Now;
                model.DateTime2 = DateTime.Now;
                model.DateTimeOffset = DateTime.Now;
                model.SmallDateTime = DateTime.Now;
                model.Decimal = 2.20m;
                model.Float = 2.2f;
                model.Image = Encoding.ASCII.GetBytes("This is a test");
                model.Int = 1;
                model.Money = 2.20m;
                model.NChar = "test";
                model.NText = "test";
                model.NVarChar = "test";
                model.Real = 2.2f;
                model.SmallMoney = 4.40m;
                model.Text = "test";
                model.VarBinary = Encoding.ASCII.GetBytes("This is a test");
                model.VarChar = "test";

                return model;
            }
        }

        private SubTableModel SubTableScafold
        {
            get
            {
                var model = new SubTableModel();

                return model;
            }
        }

        [TestMethod]
        public void ExecuteNonQuery()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                dbHandler.ExecuteNonQuery("select * from Data", System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteNonQuery failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteNonQueryWithParameters()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                dbHandler.ExecuteNonQuery(sqlData, DataScafold, System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteNonQuery with parameters failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteNonQueryAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            {
                dbHandler.ExecuteNonQuery("select * from Data", System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                Assert.Fail("ExecuteNonQuery and transaction failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void ExecuteNonQueryWithParametersAndTransaction()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            var transaction = dbHandler.BeginTransaction();

            try
            { 
                var data = DataScafold;

                dbHandler.ExecuteNonQuery(sqlData, data, System.Data.CommandType.Text, transaction);

                var subTable = SubTableScafold;

                subTable.Data_ID = data.Id;

                dbHandler.ExecuteNonQuery(sqlSubTable, subTable, System.Data.CommandType.Text, transaction);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                Assert.Fail("ExecuteNonQuery with parameters and transaction failed: " + ex.Message);

                transaction.Rollback();
            }
        }
    }
}
