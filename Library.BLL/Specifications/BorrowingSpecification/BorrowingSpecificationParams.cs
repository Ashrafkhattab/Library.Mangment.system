using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Specifications.BorrowingSpecification
{
    internal class BorrowingSpecificationParams
    {
        private const int MaxPagesize = 10;
        private int pagesize = 5;
        public int Pagesize
        {
            get { return pagesize; }
            set { pagesize = value > MaxPagesize ? MaxPagesize : value; }
        }
        public int PageIndex = 1;

        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value.ToUpper(); }
        }
    }
}
