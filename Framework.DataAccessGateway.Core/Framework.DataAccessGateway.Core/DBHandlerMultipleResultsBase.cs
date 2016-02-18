using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Framework.DataAccessGateway.Core
{
    public abstract class DBHandlerMultipleResultsBase : IDBHandlerMultipleResults, IDisposable
    {
        protected List<object> Data { get; private set; }

        public DBHandlerMultipleResultsBase()
        {
            Data = new List<object>();
        }

        public void Dispose()
        {
            Data = null;
        }

        public IEnumerable<TElement> Get<TElement>()
        {
            var retVal = Data.Where(c => c.GetType() == typeof(List<TElement>)).FirstOrDefault() as IList<TElement>;

            return retVal.AsEnumerable();
        }

        internal abstract void Fill(IMultipleResults source);
    }
}
