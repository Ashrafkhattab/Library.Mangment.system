using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;

namespace Library.BLL.Specifications.BookSpecification
{
    public class BookSpecifications : BaseSpcifications<Book>
    {
        public BookSpecifications(BookSpecParams specParams) : base(b=>
            (string.IsNullOrEmpty(specParams.Search) || b.NormalizTitle.Contains(specParams.Search) ))
        {
            orderBy(b => b.Title);

            ApplyPagination((specParams.PageIndex - 1) * specParams.Pagesize, specParams.Pagesize);

        }
        public BookSpecifications(int id) : base(b=> b.Id == id)
        {

        }
    }
}
