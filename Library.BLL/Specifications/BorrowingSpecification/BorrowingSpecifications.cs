using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;

namespace Library.BLL.Specifications.BorrowingSpecification
{
    internal class BorrowingSpecifications:BaseSpcifications<BorrowingRecord>
    {
        public BorrowingSpecifications():base()
        {
            
        }
        public BorrowingSpecifications(int id):base(br=> br.Id == id)
        {
            
        }
    }
}
