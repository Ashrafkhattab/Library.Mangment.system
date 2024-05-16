using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DAL.Model;

namespace Library.BLL.Interfaces.Servises
{
    public interface IBorrowingServices
    {
        Task<BorrowingRecord?> AddBorrowingAsync(BorrowingRecord model);
        Task<int> UpdateBorrowingAsync(BorrowingRecord model);
    }
}
