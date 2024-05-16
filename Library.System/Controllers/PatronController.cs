using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Interfaces.Servises;
using Library.BLL.Specifications.BookSpecification;
using Library.BLL.Specifications.PatronSpexification;
using Library.DAL.Model;
using Library.System.DTOs;
using Library.System.Errors;
using Library.System.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.System.Controllers
{

    public class PatronController : BaseApiController
    {
        private readonly IGenericRepository<Patron> _repository;
        private readonly IPatronServices _patronServices;
        private readonly IMapper _mapper;

        public PatronController(IPatronServices patronServices , IMapper mapper)
        {
            _patronServices = patronServices;
            _mapper = mapper;
        }
        // GET: api/<PatronController>
        [HttpGet]
        public async Task<ActionResult<Pagination<PatronUpdateDTO>>> GetPatrons([FromQuery] PatronSpecParams specparam)
        {
           
            var patrons = await _patronServices.GetPatronsAsync(specparam);
            var data = _mapper.Map<IReadOnlyList<Patron>, IReadOnlyList<PatronUpdateDTO>>(patrons);
            var count = data.Count();
            return Ok(new Pagination<PatronUpdateDTO>(specparam.PageIndex,specparam.Pagesize,data ,count));
        }

        // GET api/<PatronController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatronUpdateDTO>> Get(int id)
        {
            if (id <= 0) return BadRequest(new ApiResponse(400));
            var patron = await _patronServices.GetPatronAsync(id);
            if (patron == null) return NotFound(new ApiResponse(404));
            var mapPatron = _mapper.Map<Patron, PatronUpdateDTO>(patron);
            return Ok(mapPatron) ;
        }

        // POST api/<PatronController>
        [HttpPost]
        public async Task<ActionResult<BookDTO>> AddPatron(PatronDTO patronDTO)
        {

            var mapPatron = _mapper.Map<PatronDTO, Patron>(patronDTO);
           var result = _patronServices.AddPatronAsync(mapPatron);
            if(result== null) return BadRequest(new ApiResponse(400));
            return Ok(patronDTO);
        }

        // PUT api/<PatronController>
        [HttpPut]
        public async Task<ActionResult<BookDTO>> Edite(PatronUpdateDTO patronDTO)
        {

            var mapPatron = _mapper.Map<PatronUpdateDTO, Patron>(patronDTO);
            var result = _patronServices.UpdatePatronAsync(mapPatron);
            if (result == null) return BadRequest(new ApiResponse(400));
            var resp= _mapper.Map<PatronUpdateDTO, PatronDTO>(patronDTO);
            return Ok(patronDTO);
        }

        // Delete api/<PatronController>/5

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (id <= 0) return BadRequest(new ApiResponse(400));
            var result = _patronServices.DeletePatronAsync(id);
            if (result == null) return NotFound(new ApiResponse(404));

            return Ok();

        }
    }
}
