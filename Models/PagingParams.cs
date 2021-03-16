using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Golden_Leaf_Back_End.Models
{
    public class PagingParams
    {
        public int PageNo { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
