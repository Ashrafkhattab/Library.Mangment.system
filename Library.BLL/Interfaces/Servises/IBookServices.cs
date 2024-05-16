using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Specifications.BookSpecification;
using Library.DAL.Model;

namespace Library.BLL.Interfaces.Servises
{
    public interface IBookServices
    {
        Task<IReadOnlyList<Book>> GetBooksAsync(BookSpecParams specparam);

        Task<Book?> GetBookAsync(int id);
        Task<Book?> AddBookAsync(Book book);
        Task<Book?> UpdateBookAsync(Book book);
        Task<int> DeleteBookAsync(int id);
    }
}
