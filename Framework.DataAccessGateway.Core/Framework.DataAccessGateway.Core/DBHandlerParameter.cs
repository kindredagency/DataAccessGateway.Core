using System.Data;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    ///     Parameter Type which is used with DBHandler
    ///     Similar to SQLParameter and ODBCParameter present in the .Net Library.
    /// </summary>
    public class DBHandlerParameter
    {
        #region Properties

        /// <summary>
        ///     Parameter Name
        /// </summary>
        public string ParameterName { get; set; }

        /// <summary>
        ///     Data Type of the parameter.
        /// </summary>
        public DBHandlerDataType DBHandlerDataType { get; set; }

        /// <summary>
        ///     Get Set Value of the parameter.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public ParameterDirection Direction { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        ///     DB Handler Constructor
        /// </summary>
        public DBHandlerParameter()
        {
            // Empty Constructor
        }

        /// <summary>
        ///     DB Handler Constructor
        /// </summary>
        /// <param name="parameterName">Parameter Name eg: @Name</param>
        public DBHandlerParameter(string parameterName)
        {
            ParameterName = parameterName;
            Direction = ParameterDirection.Input;
        }

        /// <summary>
        ///     DB Handler Constructor
        /// </summary>
        /// <param name="parameterName">Parameter Name eg: @Name</param>
        /// <param name="parameterValue">Parameter Value</param>
        public DBHandlerParameter(string parameterName, object parameterValue)
        {
            ParameterName = parameterName;
            Value = parameterValue;
            Direction = ParameterDirection.Input;
        }

        /// <summary>
        ///     DB Handler Constructor
        /// </summary>
        /// <param name="parameterName">Parameter Name eg: @Name</param>
        /// <param name="dalDBType">Variable Type</param>
        public DBHandlerParameter(string parameterName, DBHandlerDataType dalDBType)
        {
            ParameterName = parameterName;
            DBHandlerDataType = dalDBType;
            Direction = ParameterDirection.Input;
        }

        /// <summary>
        ///     DB Handler Constructor
        /// </summary>
        /// <param name="parameterName">Parameter Name eg: @Name</param>
        /// <param name="dalDBType">Variable Type</param>
        /// <param name="parameterValue">Parameter Value</param>
        public DBHandlerParameter(string parameterName, DBHandlerDataType dalDBType, object parameterValue)
        {
            ParameterName = parameterName;
            DBHandlerDataType = dalDBType;
            Value = parameterValue;
            Direction = ParameterDirection.Input;
        }

        #endregion Constructors
    }
}