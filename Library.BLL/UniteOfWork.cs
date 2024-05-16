using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces;
using Library.BLL.Repositories;
using Library.DAL.Data;
using Library.DAL.Model;

namespace Library.BLL
{
    public class UniteOfWork : IUniteOfWork
    {
        private readonly LibraryContext _dbcontext;
        private Hashtable _Repositries;
        public UniteOfWork(LibraryContext dbcontext)
        {
            _dbcontext = dbcontext;
            _Repositries = new Hashtable();
        }
        public IGenericRepository<T> Repository<T>() where T : BaseModel
        {
            var key = typeof(T).Name;
            if (!_Repositries.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_dbcontext);
                _Repositries.Add(key, repository);
            }
            return _Repositries[key] as IGenericRepository<T>; 
        }
        public async Task<int> CompleteAsync()
                    => await _dbcontext.SaveChangesAsync();

        public async ValueTask DisposeAsync()
                => await _dbcontext.DisposeAsync();


    }
}
