using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Framework.DataAccessGateway.Core
{
    public class DBHandlerMultipleResults<T1, T2> : DBHandlerMultipleResultsBase
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();
            IList<T11> T11List = source.GetResult<T11>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
            Data.Add(T11List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();
            IList<T11> T11List = source.GetResult<T11>().ToList();
            IList<T12> T12List = source.GetResult<T12>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
            Data.Add(T11List);
            Data.Add(T12List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();
            IList<T11> T11List = source.GetResult<T11>().ToList();
            IList<T12> T12List = source.GetResult<T12>().ToList();
            IList<T13> T13List = source.GetResult<T13>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
            Data.Add(T11List);
            Data.Add(T12List);
            Data.Add(T13List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();
            IList<T11> T11List = source.GetResult<T11>().ToList();
            IList<T12> T12List = source.GetResult<T12>().ToList();
            IList<T13> T13List = source.GetResult<T13>().ToList();
            IList<T14> T14List = source.GetResult<T14>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
            Data.Add(T11List);
            Data.Add(T12List);
            Data.Add(T13List);
            Data.Add(T14List);
        }
    }

    public class DBHandlerMultipleResults<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> : DBHandlerMultipleResultsBase, IDBHandlerMultipleResults
    {
        internal override void Fill(IMultipleResults source)
        {
            IList<T1> T1List = source.GetResult<T1>().ToList();
            IList<T2> T2List = source.GetResult<T2>().ToList();
            IList<T3> T3List = source.GetResult<T3>().ToList();
            IList<T4> T4List = source.GetResult<T4>().ToList();
            IList<T5> T5List = source.GetResult<T5>().ToList();
            IList<T6> T6List = source.GetResult<T6>().ToList();
            IList<T7> T7List = source.GetResult<T7>().ToList();
            IList<T8> T8List = source.GetResult<T8>().ToList();
            IList<T9> T9List = source.GetResult<T9>().ToList();
            IList<T10> T10List = source.GetResult<T10>().ToList();
            IList<T11> T11List = source.GetResult<T11>().ToList();
            IList<T12> T12List = source.GetResult<T12>().ToList();
            IList<T13> T13List = source.GetResult<T13>().ToList();
            IList<T14> T14List = source.GetResult<T14>().ToList();
            IList<T15> T15List = source.GetResult<T15>().ToList();

            Data.Add(T1List);
            Data.Add(T2List);
            Data.Add(T3List);
            Data.Add(T4List);
            Data.Add(T5List);
            Data.Add(T6List);
            Data.Add(T7List);
            Data.Add(T8List);
            Data.Add(T9List);
            Data.Add(T10List);
            Data.Add(T11List);
            Data.Add(T12List);
            Data.Add(T13List);
            Data.Add(T14List);
            Data.Add(T15List);
        }
    }

}
