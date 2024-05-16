using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces.Servises;
using Library.BLL.Specifications.BookSpecification;
using Library.DAL.Model;

namespace Library.BLL.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUniteOfWork _uniteOfWork;

        public BookServices(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IReadOnlyList<Book>> GetBooksAsync(BookSpecParams specparam)
        {
            var spec = new BookSpecifications(specparam);
            var Books = await _uniteOfWork.Repository<Book>().GetAllWithSpecAsync(spec);
            return Books;
        }
        public async Task<Book?> GetBookAsync(int id)
        {
            var spec = new BookSpecifications(id);

            var book = await _uniteOfWork.Repository<Book>().GetWithSpecAsync(spec);
            return book;
        }
        public async Task<Book?> AddBookAsync(Book book)
        {
            var result = await _uniteOfWork.Repository<Book>().Add(book);
            var succes=  await _uniteOfWork.CompleteAsync();
            if(succes<=0) return null;
            return book;
            
        }
        public async Task<Book?> UpdateBookAsync(Book model)
        {
            var book = GetBookAsync(model.Id);
            if (book != null)
            {
                var result = _uniteOfWork.Repository<Book>().Update(model);
                var succes = await _uniteOfWork.CompleteAsync();
                return model;
            }
            return null;
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var book = GetBookAsync(id);
            if (book != null)
            {
                var result = _uniteOfWork.Repository<Book>().Delete(id);
                return await _uniteOfWork.CompleteAsync();
            }
            return 0;
        }

    }
}
