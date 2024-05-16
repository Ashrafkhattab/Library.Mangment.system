using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Specifications;
using Library.DAL.Model;

namespace Library.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : BaseModel
    {
       Task<IReadOnlyList<T>> GetAllAsync();  
       Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec);
       Task<T?> GetAsync(int id);
       Task<T?> GetWithSpecAsync(ISpecification<T> spec);

        Task<int> Add(T entity);
        int Update (T entity);
        Task<int> Delete (int id);
        //Task savechangesAsync();
        Task<int> GetCountAsync(ISpecification<T> spec);
        
    }
}
