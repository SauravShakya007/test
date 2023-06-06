using AutoMapper;
using CodeCheckIn.Core.Context;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Dtos.Receiver;
using CodeCheckIn.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCheckIn.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }

        public ReceiverController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //CRUD
        //Create
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateReceiver([FromBody] ReceiverCreateDto dto)
        {
            var newReceiver = _mapper.Map<Receiver>(dto);
            await _context.Receivers.AddAsync(newReceiver);
            await _context.SaveChangesAsync();
            return Ok("Receiver created Successfully");
        }

        ////Read
        //[HttpGet]
        //[Route("get")]
        //public async Task<ActionResult<IEnumerable<CheckInGetDto>>> GetReceivers()
        //{
        //    var receivers = await _context.Receivers.Include(receiver=>receiver.MainPage).ToListAsync();
        //    var convertedReceivers = _mapper.Map<CheckInGetDto>(receivers);
        //    return Ok(convertedReceivers);
        //}
    }
}
