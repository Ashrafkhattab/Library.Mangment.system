using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Model
{
    public class BorrowingRecord :BaseModel
    {
        public DateTime BorrowingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Patron Patron { get; set; }


    }
}
