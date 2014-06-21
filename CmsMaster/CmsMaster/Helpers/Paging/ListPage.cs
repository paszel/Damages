using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsMaster.Helpers.Paging
{
    public class ListPage<T, P> where P : PagingArgs
    {
        public P PagingArgs { get; set; }

        public IEnumerable<T> Items { get; set; }
    }

}