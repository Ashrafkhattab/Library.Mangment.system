using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.BLL.Interfaces.Servises;
using Library.BLL.Specifications.PatronSpexification;
using Library.DAL.Model;

namespace Library.BLL.Services
{
    public class PatronServices : IPatronServices
    {
        private readonly IUniteOfWork _uniteOfWork;

        public PatronServices(IUniteOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IReadOnlyList<Patron>> GetPatronsAsync(PatronSpecParams specparam)
        {
            var spec = new PatronSpecifications(specparam);
            var patrons = await _uniteOfWork.Repository<Patron>().GetAllWithSpecAsync(spec);
            return patrons;
        }
        public async Task<Patron?> GetPatronAsync(int id)
        {
            var spec = new PatronSpecifications(id);
            var patron = await _uniteOfWork.Repository<Patron>().GetWithSpecAsync(spec);
            return patron;
        }
        public async Task<Patron?> AddPatronAsync(Patron model)
        {
           var result = await _uniteOfWork.Repository<Patron>().Add(model);
            var succes = await _uniteOfWork.CompleteAsync();
            if(succes<=0) return null;

            return model;
        }

        public async Task<Patron?> UpdatePatronAsync(Patron model)
        {
            var Patron = GetPatronAsync(model.Id);
            if (Patron != null)
            {
                var result = _uniteOfWork.Repository<Patron>().Update(model);
                var succes = await _uniteOfWork.CompleteAsync();
                return model;
            }
             return null;

            
        }
        public async Task<int> DeletePatronAsync(int id)
        {
            var Patron = GetPatronAsync(id);
            if (Patron != null)
            {
                var result = _uniteOfWork.Repository<Patron>().Delete(id);
                return await _uniteOfWork.CompleteAsync();
            }
            return 0;
            
        }
    }
}
