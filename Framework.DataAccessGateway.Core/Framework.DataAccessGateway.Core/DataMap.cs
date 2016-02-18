using System;
using System.Data;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    /// Class DataMap.
    /// </summary>
    public class DataMap
    {
        /// <summary>
        /// Gets or sets the name of the cs type.
        /// </summary>
        /// <value>The name of the cs type.</value>
        public string CSDataTypeName { get; set; }

        /// <summary>
        /// Gets or sets the type of the cs data.
        /// </summary>
        /// <value>The type of the cs data.</value>
        public Type CSDataType { get; set; }

        /// <summary>
        /// Gets or sets the type of the SQL data.
        /// </summary>
        /// <value>The type of the SQL data.</value>
        public SqlDbType SqlDataType { get; set; }

        /// <summary>
        /// Gets or sets the type of the database handler data.
        /// </summary>
        /// <value>The type of the database handler data.</value>
        public DBHandlerDataType DBHandlerDataType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value><c>true</c> if this instance is default; otherwise, <c>false</c>.</value>
        public bool IsDefault { get; set; }

    }
}
