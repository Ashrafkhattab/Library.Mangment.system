using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces;
using Library.DAL.Model;

namespace Library.BLL
{
    public interface IUniteOfWork :IAsyncDisposable
    {
      IGenericRepository<T> Repository<T> () where T : BaseModel;

        Task<int> CompleteAsync();
    }
}
