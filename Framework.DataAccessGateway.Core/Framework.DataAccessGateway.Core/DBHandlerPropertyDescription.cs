using System;
using System.Data;

namespace Framework.DataAccessGateway.Core
{
    [AttributeUsage(System.AttributeTargets.Property)]
    public class DBHandlerProperty : Attribute
    {
        /// <summary>
        /// Gets the type of the database data.
        /// </summary>
        /// <value>The type of the database data.</value>
        public DBHandlerDataType? DBHandlerDataType { get; private set; }

        /// <summary>
        /// Gets the direction.
        /// </summary>
        /// <value>The direction.</value>
        public ParameterDirection? Direction { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is identity.
        /// </summary>
        /// <value><c>true</c> if this instance is identity; otherwise, <c>false</c>.</value>
        public bool IsIdentity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="dbDataType">Type of the database data.</param>
        public DBHandlerProperty(DBHandlerDataType dbDataType)
        {
            DBHandlerDataType = dbDataType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="dbHandlerDataType">Type of the database handler data.</param>
        /// <param name="direction">The direction.</param>
        public DBHandlerProperty(DBHandlerDataType dbHandlerDataType, ParameterDirection direction)
        {
            DBHandlerDataType = dbHandlerDataType;
            Direction = direction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public DBHandlerProperty(ParameterDirection direction)
        {   
            Direction = direction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="isIdentity">if set to <c>true</c> [is identity].</param>
        public DBHandlerProperty(bool isIdentity)
        {
            IsIdentity = isIdentity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="dbDataType">Type of the database data.</param>
        /// <param name="isIdentity">if set to <c>true</c> [is identity].</param>
        public DBHandlerProperty(DBHandlerDataType dbDataType, bool isIdentity)
        {
            DBHandlerDataType = dbDataType;
            IsIdentity = isIdentity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="dbHandlerDataType">Type of the database handler data.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="isIdentity">if set to <c>true</c> [is identity].</param>
        public DBHandlerProperty(DBHandlerDataType dbHandlerDataType, ParameterDirection direction, bool isIdentity)
        {
            DBHandlerDataType = dbHandlerDataType;
            Direction = direction;
            IsIdentity = isIdentity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBHandlerProperty"/> class.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <param name="isIdentity">if set to <c>true</c> [is identity].</param>
        public DBHandlerProperty(ParameterDirection direction, bool isIdentity)
        {
            Direction = direction;
            IsIdentity = isIdentity;
        }
    }
}
