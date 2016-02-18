using System;

namespace Framework.DataAccessGateway.Core
{
    /// <summary>
    ///     Summary description for DBHandlerException.
    /// </summary>
    [Serializable]
    internal sealed class DBHandlerMappingNotFoundException : System.Exception
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
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type
        {
            get;
            private set;
        }

        #region Constructor Definitions       

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerMappingNotFoundException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public DBHandlerMappingNotFoundException(Type type) 
        {
            Type = type;
            Message = type.FullName + " cannot be found or matched with DBHandlerDataMapping.Mappings";
        }       

        #endregion Constructor Definitions
    }
}