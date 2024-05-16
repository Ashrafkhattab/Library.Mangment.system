using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Interfaces.Servises;
using Library.BLL.Specifications;
using Library.BLL.Specifications.BookSpecification;
using Library.DAL.Model;
using Library.System.DTOs;
using Library.System.Errors;
using Library.System.Helpers;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Library.System.Controllers
{

    public class BooksController : BaseApiController
    {
       
        private readonly IBookServices _bookServices;
        private readonly IMapper _mapper;
       

        public BooksController(IBookServices bookServices, IMapper  mapper )
        {
            _bookServices = bookServices;
            _mapper = mapper;
            
        } 


        [HttpGet]
        public async Task<ActionResult<Pagination<BookUpdateDTO?>>> GetBooks([FromQuery]BookSpecParams specparam)
        {
            
            var Books = await _bookServices.GetBooksAsync(specparam);
            var data =  _mapper.Map<IReadOnlyList<Book>,IReadOnlyList<BookUpdateDTO>>(Books);
            var count = data.Count();
            

            return Ok(new Pagination<BookUpdateDTO>(specparam.PageIndex , specparam.Pagesize, data, count));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookUpdateDTO>> GetBook(int id)
        {
            if(id <= 0) return BadRequest(new ApiResponse(400));

            var book = await _bookServices.GetBookAsync(id);
            if (book is null) return NotFound(new ApiResponse(404));
            var mapBook = _mapper.Map<Book, BookUpdateDTO>(book);
            return Ok(mapBook);

        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> AddBook(BookDTO bookDTO)
        {
            var mapBook = _mapper.Map<BookDTO, Book>(bookDTO);
            var result = await _bookServices.AddBookAsync(mapBook);
            if(result == null ) return BadRequest(new ApiResponse(400));
            return Ok(bookDTO);
        }
        [HttpPut]
        public async Task<ActionResult<BookDTO>> Edite (BookUpdateDTO bookDTO)
        {
                var mapBook = _mapper.Map<BookUpdateDTO, Book>(bookDTO);
                var result = await _bookServices.UpdateBookAsync(mapBook);
                if(result ==null) return BadRequest(new ApiResponse(400));
                var resp = _mapper.Map<BookUpdateDTO, BookDTO>(bookDTO);
            return Ok(resp);
          
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (id <= 0) return BadRequest(new ApiResponse(400));
            var result = _bookServices.DeleteBookAsync(id);
            if (result == null) return NotFound(new ApiResponse(404));

            return Ok();

        }
    }
}
