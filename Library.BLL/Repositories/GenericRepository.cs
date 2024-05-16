using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces;
using Library.BLL.Specifications;
using Library.DAL.Data;
using Library.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
      
        private readonly LibraryContext _dbContext;

        public GenericRepository(LibraryContext dbContext )
        {
           
            _dbContext = dbContext;
        }
        public async Task<int> Add(T entity)
        {
           var result = await _dbContext.AddAsync(entity);
            return 1;
        }

        public async Task<int> Delete(int id)
        {
          var item =  await GetAsync(id);
            item.IsDeleted = true;
            return 1;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().Where(t=> t.IsDeleted == false).AsNoTracking().ToListAsync() ;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public   int Update(T entity)
        {
           var result =   _dbContext.Update(entity);
            return 1;
        }



        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        {
           var result =  await ApplySpecifcations(spec).Where(t => t.IsDeleted == false).AsNoTracking().ToListAsync();
                return result;
        }



        public async Task<T?> GetWithSpecAsync(ISpecification<T> spec)
        {
            var result = await ApplySpecifcations( spec).Where(t => t.IsDeleted == false).FirstOrDefaultAsync();
            return result;
        }

        private IQueryable<T> ApplySpecifcations(ISpecification<T> spec)
        {
            return SpecificationEvalor<T>.GetQuery( _dbContext.Set<T>(), spec);
        }

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        {
            return await ApplySpecifcations(spec).CountAsync();
        }

        //public async Task savechangesAsync()
        //{
        //   await _dbContext.SaveChangesAsync();
        //}
    }
}
