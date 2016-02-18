using Framework.DataAccessGateway.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Framework.AssetLibrary.Types;

namespace UnitTesting
{
    [TestClass]
    public class UnitTestOther
    {   
        private DataTable mockDataTable = new DataTable();

        private DataTable existingMockTable = new DataTable();

        public UnitTestOther()
        {
            List<DataModel> mockDataList = new List<DataModel>();

            for (int count = 0; count < 100; count++)
            {
                mockDataList.Add(DataScafold);
            }

            mockDataTable = mockDataList.ToDataTable();

            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            existingMockTable = dbHandler.ExecuteQuery<DataModel>("Select * from Data", CommandType.Text).ToDataTable();

        }

        private string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            }
        }

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
                model.SmallDateTime = DateTime.Now;
                model.DateTimeOffset = DateTime.Now;               
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

        private DataTable DataScaffoldTable
        {
            get
            {
                return mockDataTable;
            }
        }

        [TestMethod]
        public void UserDefinedDataTableTypeInsert()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                SomeModel someModel = new SomeModel();

                someModel.StructuredData = DataScaffoldTable;

                dbHandler.ExecuteNonQuery("UserDefinedDataTableTypeInsert", someModel, CommandType.StoredProcedure);

            }
            catch(Exception ex)
            {
                Assert.Fail("UserDefinedDataType failed: " + ex.Message);
            }
        }

        [TestMethod]
        public void UserDefinedDataTableTypeUpdate()
        {
            IDBHandler dbHandler = new DBHandler(ConnectionString, DBHandlerType.DbHandlerMSSQL);

            try
            {
                dbHandler.ExecuteNonQuery("UserDefinedDataTableTypeUpdate", new { StructuredData = existingMockTable }, CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                Assert.Fail("UserDefinedDataType failed: " + ex.Message);
            }
        }
    }

    public class SomeModel
    {
        public DataTable StructuredData { get; set; }
    }
}
