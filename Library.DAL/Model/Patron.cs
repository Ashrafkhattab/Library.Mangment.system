using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Model
{
    public class Patron :BaseModel
    {
        public string Name { get; set; }
        public string NormalizeName { get; set; }
        public String PhoneNumber { get; set; }
        public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();
      

    }

    
}
