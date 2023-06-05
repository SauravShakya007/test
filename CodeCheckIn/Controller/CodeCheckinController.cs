using AutoMapper;
using CodeCheckIn.Core.Context;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCheckIn.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeCheckinController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper;

        public CodeCheckinController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD
        //Create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmail([FromBody] CheckInCreateDto dto)
        {
            MainPage newMainPage = _mapper.Map<MainPage>(dto);
            await _context.MainPages.AddAsync(newMainPage);
            await _context.SaveChangesAsync();
            return Ok("Email created Successfully");
        }

        //Read
        //Update
        //Delete

    }
}
