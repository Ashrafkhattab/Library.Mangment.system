using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Model
{
    public class Book : BaseModel
    {
        public string Title { get; set; }
        public string NormalizTitle { get; set; } 
        public string Author { get; set; }
        public DateTime PublicationYear { get; set; }

        public string ISBN { get; set; }

        
        public virtual ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();



    }
}
