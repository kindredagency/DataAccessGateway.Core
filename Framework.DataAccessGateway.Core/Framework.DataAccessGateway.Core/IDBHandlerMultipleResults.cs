using System.Collections.Generic;

namespace Framework.DataAccessGateway.Core
{
    public interface IDBHandlerMultipleResults
    {
        IEnumerable<TElement> Get<TElement>();
    }
}
