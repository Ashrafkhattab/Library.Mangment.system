using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;

namespace Library.BLL.Specifications.PatronSpexification
{
    public class PatronSpecifications :BaseSpcifications<Patron>
    {
        public PatronSpecifications(PatronSpecParams specparams) :base(p=> 
                     (string.IsNullOrEmpty(specparams.Search) || p.NormalizeName.Contains(specparams.Search))     )
        {
             orderBy(p => p.Name);


            ApplyPagination((specparams.PageIndex - 1) * specparams.Pagesize, specparams.Pagesize);

        }
        public PatronSpecifications(int id):base(p=> p.Id == id) 
        {
            
        }
    }
}
