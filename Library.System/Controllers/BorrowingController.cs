using AutoMapper;
using Library.BLL.Interfaces;
using Library.BLL.Interfaces.Servises;
using Library.DAL.Model;
using Library.System.DTOs;
using Library.System.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.System.Controllers
{

    public class BorrowingController : BaseApiController
    {
        private readonly IBorrowingServices _borrowingServices;
        private readonly IMapper _mapper;

        public BorrowingController(IBorrowingServices borrowingServices, IMapper mapper)
        {
            _borrowingServices = borrowingServices;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<BorrowingDTO>> AddBOrrowing(BorrowingDTO borrowingDTO)
        {
            var mapBorrow = _mapper.Map<BorrowingDTO, BorrowingRecord>(borrowingDTO);
            var result = _borrowingServices.AddBorrowingAsync(mapBorrow);
            if (result == null) return BadRequest(new ApiResponse(400));
            return Ok(borrowingDTO);
        }
        [HttpPut]
        public async Task<ActionResult<BorrowingDTO>> Edite(BorrowingDTO borrowingDTO)
        {
            var mapBorrow = _mapper.Map<BorrowingDTO, BorrowingRecord>(borrowingDTO);
            var result = await  _borrowingServices.UpdateBorrowingAsync(mapBorrow);
            if (result <= 0) return BadRequest(new ApiResponse(400));

            return Ok(borrowingDTO);
        }
    }
}
