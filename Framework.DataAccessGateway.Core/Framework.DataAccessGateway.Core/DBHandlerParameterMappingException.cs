using System;
using System.Reflection;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    ///     Summary description for DBHandlerException.
    /// </summary>
    [Serializable]
    internal sealed class DBHandlerParameterMappingException : Exception
    {

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        /// <value>The message.</value>
        public new string Message
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="T:System.Exception" /> instance that caused the current exception.
        /// </summary>
        /// <value>The inner exception.</value>
        public new DBHandlerMappingNotFoundException InnerException
        {
            get;
            private set;
        }


        /// <summary>
        /// Gets the property information.
        /// </summary>
        /// <value>The property information.</value>
        public PropertyInfo PropertyInfo
        {
            get;
            private set;
        }

        #region Constructor Definitions       

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerParameterMappingException"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="innerException">The inner exception.</param>
        public DBHandlerParameterMappingException(PropertyInfo propertyInfo, DBHandlerMappingNotFoundException innerException) 
        {
            PropertyInfo = propertyInfo;
            InnerException = innerException;
            Message = propertyInfo.Name + " has a data type of " + innerException.Type.Name + " which cannot be mapped";
        }       

        #endregion Constructor Definitions
    }
}