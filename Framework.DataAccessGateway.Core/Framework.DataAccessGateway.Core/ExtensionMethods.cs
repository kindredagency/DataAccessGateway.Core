using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Class ExtensionMethods.
    /// </summary>
    internal static class ExtensionMethods
    {
        /// <summary>
        /// To the type of the database handler data.
        /// </summary>
        /// <param name="csDataType">Type of the cs data.</param>
        /// <returns>DBHandlerDataType.</returns>
        public static DBHandlerDataType ToDBHandlerDataType(this Type csDataType)
        {
            try
            {
                return DBHandlerDataMapping.Mappings.Where(c => c.CSDataType == csDataType).Where(c => c.IsDefault == true).FirstOrDefault().DBHandlerDataType;
            }
            catch
            {
                throw new DBHandlerMappingNotFoundException(csDataType);
            }            
        }

        /// <summary>
        /// To the SQL parameters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SqlParameter[].</returns>
        public static SqlParameter[] ToSqlParameters(this DBHandlerParameter[] value)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            if (value.Length > 0)
            {
                for (var intParamCount = 0; intParamCount < value.Length; intParamCount++)
                {
                    sqlParameters.Add(value[intParamCount].ToSqlParameter());
                }
            }

            return sqlParameters.ToArray();
        }

        /// <summary>
        /// To the SQL parameter.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SqlParameter.</returns>
        public static SqlParameter ToSqlParameter(this DBHandlerParameter value)
        {
            var sqlParameter = new SqlParameter();

            sqlParameter.ParameterName = value.ParameterName;
            sqlParameter.SqlDbType = (SqlDbType)Enum.Parse(typeof(SqlDbType), value.DBHandlerDataType.ToString());
            sqlParameter.Value = value.Value;
            sqlParameter.Direction = value.Direction;

            return sqlParameter;
        }

        /// <summary>
        /// To the database handler parameter parameters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>DBHandlerParameter[].</returns>
        public static DBHandlerParameter[] ToDBHandlerParameters(this object value)
        {
            List<DBHandlerParameter> parameters = new List<DBHandlerParameter>();

            foreach (var property in value.GetType().GetProperties().Where(c => c.CanRead == true))
            {
                try
                {
                    DBHandlerParameter parameter = new DBHandlerParameter(property.Name, property.PropertyType.ToDBHandlerDataType(), property.GetValue(value, null));

                    var dbHandlerPropertyDescriptionAttribute = property.GetCustomAttributes(typeof(DBHandlerProperty), false).Cast<DBHandlerProperty>().FirstOrDefault();

                    if (dbHandlerPropertyDescriptionAttribute != null)
                    {
                        if(dbHandlerPropertyDescriptionAttribute.DBHandlerDataType != null)
                            parameter.DBHandlerDataType = dbHandlerPropertyDescriptionAttribute.DBHandlerDataType.Value;

                        if (dbHandlerPropertyDescriptionAttribute.Direction != null)
                            parameter.Direction = dbHandlerPropertyDescriptionAttribute.Direction.Value;
                    }

                    parameters.Add(parameter);
                }
                catch (DBHandlerMappingNotFoundException ex)
                {
                    throw new DBHandlerParameterMappingException(property, ex);
                }                         
            }

            return parameters.ToArray();            
        }

        /// <summary>
        /// To the database handler parameters.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="parameters">The parameters.</param>
        public static void ToDBHandlerParameters(this IDataParameterCollection value, DBHandlerParameter[] parameters)
        {
            for (int count = 0; count < value.Count; count++)
            {
                IDataParameter sqlParameter = (IDataParameter)value[count];

                if ((sqlParameter.Direction == ParameterDirection.Output) || (sqlParameter.Direction == ParameterDirection.InputOutput) || (sqlParameter.Direction == ParameterDirection.ReturnValue))
                {
                    var dbParameter = parameters.FirstOrDefault(c => c.ParameterName == sqlParameter.ParameterName);

                    if (dbParameter != null)
                        dbParameter.Value = sqlParameter.Value;
                }
            }            
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="model">The model.</param>
        public static void ToModel(this DBHandlerParameter[] value, object model)
        {
            var properties = model.GetType().GetProperties();

            foreach (DBHandlerParameter dbHandlerParameter in value)
            {
                var property = properties.FirstOrDefault(c => c.Name == dbHandlerParameter.ParameterName);

                if ((property != null) && (property.CanWrite))
                {
                    property.SetValue(model, dbHandlerParameter.Value);
                }
            }
        }
    }
}