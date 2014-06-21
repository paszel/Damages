using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsMaster.Helpers.Paging
{
    public class PagingArgs
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
    }
}