using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Specifications.BookSpecification;
using Library.BLL.Specifications.PatronSpexification;
using Library.DAL.Model;

namespace Library.BLL.Interfaces.Servises
{
    public interface IPatronServices
    {
        Task<IReadOnlyList<Patron>> GetPatronsAsync(PatronSpecParams specparam);

        Task<Patron?> GetPatronAsync(int id);
        Task<Patron?> AddPatronAsync(Patron model);
        Task<Patron?> UpdatePatronAsync(Patron model);
        Task<int> DeletePatronAsync(int id);
    }
}
