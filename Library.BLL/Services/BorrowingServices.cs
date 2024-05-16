using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces.Servises;
using Library.DAL.Model;

namespace Library.BLL.Services
{
    public class BorrowingServices : IBorrowingServices
    {
        private readonly IUniteOfWork _uniteOfWork;

        public BorrowingServices(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task<BorrowingRecord?> AddBorrowingAsync(BorrowingRecord model)
        {
            var result = await _uniteOfWork.Repository<BorrowingRecord>().Add(model);
            var succes = await _uniteOfWork.CompleteAsync();
            if (succes <= 0) return null;

            return model;
        }

        public async Task<int> UpdateBorrowingAsync(BorrowingRecord model)
        {
                var result = _uniteOfWork.Repository<BorrowingRecord>().Update(model);
                var succes = await _uniteOfWork.CompleteAsync();
                return result;
            
           
        }
    }
}
