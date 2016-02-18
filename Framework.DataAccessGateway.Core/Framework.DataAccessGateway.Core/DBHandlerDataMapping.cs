using System;
using System.Data;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Class DBHandlerDataTypeMapping.
    /// </summary>
    public class DBHandlerDataMapping
    {
        /// <summary>
        /// The mappings
        /// </summary>
        public static DataMap[] Mappings = new DataMap[] {


            new DataMap {
                CSDataTypeName = "int", CSDataType = typeof(int), SqlDataType = SqlDbType.Int,  DBHandlerDataType = DBHandlerDataType.Int, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "int?", CSDataType = typeof(int?), SqlDataType = SqlDbType.Int,  DBHandlerDataType = DBHandlerDataType.Int, IsDefault = true
            },


            new DataMap {
                CSDataTypeName = "long", CSDataType = typeof(long), SqlDataType = SqlDbType.BigInt,  DBHandlerDataType = DBHandlerDataType.BigInt, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "long?", CSDataType = typeof(long?), SqlDataType = SqlDbType.BigInt,  DBHandlerDataType = DBHandlerDataType.BigInt, IsDefault = true
            },


            new DataMap {
                CSDataTypeName = "byte", CSDataType = typeof(byte), SqlDataType = SqlDbType.TinyInt,  DBHandlerDataType = DBHandlerDataType.TinyInt, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "byte?", CSDataType = typeof(byte?), SqlDataType = SqlDbType.TinyInt,  DBHandlerDataType = DBHandlerDataType.TinyInt, IsDefault = true
            },

            new DataMap {
                CSDataTypeName = "byte[]", CSDataType = typeof(byte[]), SqlDataType = SqlDbType.VarBinary,  DBHandlerDataType = DBHandlerDataType.VarBinary, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "byte[]", CSDataType = typeof(byte[]), SqlDataType = SqlDbType.Binary,  DBHandlerDataType = DBHandlerDataType.Binary, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "byte[]",  CSDataType = typeof(byte[]), SqlDataType = SqlDbType.Image,  DBHandlerDataType = DBHandlerDataType.Image, IsDefault = false
            },           


            new DataMap {
                CSDataTypeName = "bool", CSDataType = typeof(bool), SqlDataType = SqlDbType.Bit,  DBHandlerDataType = DBHandlerDataType.Bit, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "bool?", CSDataType = typeof(bool?), SqlDataType = SqlDbType.Bit,  DBHandlerDataType = DBHandlerDataType.Bit, IsDefault = true
            },



            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.VarChar,  DBHandlerDataType = DBHandlerDataType.VarChar, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.Char,  DBHandlerDataType = DBHandlerDataType.Char, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.NChar,  DBHandlerDataType = DBHandlerDataType.NChar, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.Text, DBHandlerDataType = DBHandlerDataType.Text, IsDefault = false
            },          
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.NText,  DBHandlerDataType = DBHandlerDataType.NText, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.NVarChar,  DBHandlerDataType = DBHandlerDataType.NVarChar, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "string", CSDataType = typeof(string), SqlDataType = SqlDbType.Xml,  DBHandlerDataType = DBHandlerDataType.Xml, IsDefault = false
            },


            new DataMap {
                CSDataTypeName = "DateTime", CSDataType = typeof(DateTime), SqlDataType = SqlDbType.DateTime,  DBHandlerDataType = DBHandlerDataType.DateTime, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "DateTime", CSDataType = typeof(DateTime), SqlDataType = SqlDbType.Date,  DBHandlerDataType = DBHandlerDataType.Date, IsDefault = false
            },           
            new DataMap {
                CSDataTypeName = "DateTime", CSDataType = typeof(DateTime), SqlDataType = SqlDbType.SmallDateTime,  DBHandlerDataType = DBHandlerDataType.SmallDateTime, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "DateTime", CSDataType = typeof(DateTime), SqlDataType = SqlDbType.DateTime2,  DBHandlerDataType = DBHandlerDataType.DateTime2, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "DateTime", CSDataType = typeof(DateTime), SqlDataType = SqlDbType.Timestamp,  DBHandlerDataType = DBHandlerDataType.TimeStamp, IsDefault = false
            },

            new DataMap {
                CSDataTypeName = "DateTime?", CSDataType = typeof(DateTime?), SqlDataType = SqlDbType.DateTime,  DBHandlerDataType = DBHandlerDataType.DateTime, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "DateTime?", CSDataType = typeof(DateTime?), SqlDataType = SqlDbType.Date,  DBHandlerDataType = DBHandlerDataType.Date, IsDefault = false
            },           
            new DataMap {
                CSDataTypeName = "DateTime?", CSDataType = typeof(DateTime?), SqlDataType = SqlDbType.SmallDateTime,  DBHandlerDataType = DBHandlerDataType.SmallDateTime, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "DateTime?", CSDataType = typeof(DateTime?), SqlDataType = SqlDbType.DateTime2,  DBHandlerDataType = DBHandlerDataType.DateTime2, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "DateTime?", CSDataType = typeof(DateTime?), SqlDataType = SqlDbType.Timestamp,  DBHandlerDataType = DBHandlerDataType.TimeStamp, IsDefault = false
            },

            new DataMap {
                CSDataTypeName = "DateTimeOffset", CSDataType = typeof(DateTimeOffset), SqlDataType = SqlDbType.DateTimeOffset,  DBHandlerDataType = DBHandlerDataType.DateTimeOffset, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "DateTimeOffset?", CSDataType = typeof(DateTimeOffset?), SqlDataType = SqlDbType.DateTimeOffset,  DBHandlerDataType = DBHandlerDataType.DateTimeOffset, IsDefault = true
            },


            new DataMap {
                CSDataTypeName = "decimal", CSDataType = typeof(decimal), SqlDataType = SqlDbType.Decimal,  DBHandlerDataType = DBHandlerDataType.Decimal, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "decimal", CSDataType = typeof(decimal), SqlDataType = SqlDbType.Money,  DBHandlerDataType = DBHandlerDataType.Money, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "decimal", CSDataType = typeof(decimal), SqlDataType = SqlDbType.SmallMoney, DBHandlerDataType = DBHandlerDataType.SmallMoney, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "decimal?", CSDataType = typeof(decimal?), SqlDataType = SqlDbType.Decimal,  DBHandlerDataType = DBHandlerDataType.Decimal, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "decimal?", CSDataType = typeof(decimal?), SqlDataType = SqlDbType.Money,  DBHandlerDataType = DBHandlerDataType.Money, IsDefault = false
            },
            new DataMap {
                CSDataTypeName = "decimal?", CSDataType = typeof(decimal?), SqlDataType = SqlDbType.SmallMoney, DBHandlerDataType = DBHandlerDataType.SmallMoney, IsDefault = false
            },          


            new DataMap {
                CSDataTypeName = "double", CSDataType = typeof(double), SqlDataType = SqlDbType.Float,  DBHandlerDataType = DBHandlerDataType.Float, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "double?", CSDataType = typeof(double?), SqlDataType = SqlDbType.Float,  DBHandlerDataType = DBHandlerDataType.Float, IsDefault = true
            },


            new DataMap {
                CSDataTypeName = "float", CSDataType = typeof(float), SqlDataType = SqlDbType.Real,  DBHandlerDataType = DBHandlerDataType.Real, IsDefault = true
            },
            new DataMap {
                CSDataTypeName = "float?", CSDataType = typeof(float?), SqlDataType = SqlDbType.Real,  DBHandlerDataType = DBHandlerDataType.Real, IsDefault = true
            },                 

           
            new DataMap {
                CSDataTypeName = "Guid", CSDataType = typeof(Guid), SqlDataType = SqlDbType.UniqueIdentifier,  DBHandlerDataType = DBHandlerDataType.UniqueIdentifier, IsDefault = true
            },  

            new DataMap {
                CSDataTypeName = "DataTable", CSDataType = typeof(DataTable), SqlDataType = SqlDbType.Structured,  DBHandlerDataType = DBHandlerDataType.Structured, IsDefault = true
            },

            new DataMap {
                CSDataTypeName = "Object", CSDataType = typeof(object), SqlDataType = SqlDbType.Variant,  DBHandlerDataType = DBHandlerDataType.Variant, IsDefault = true
            }           
        };
    }
}
