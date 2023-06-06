using AutoMapper;
using CodeCheckIn.Core.Context;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeCheckIn.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeCheckinController : ControllerBase
    {
        private ApplicationDbContext _context { get; }

        private IMapper _mapper { get; }

        public CodeCheckinController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CRUD
        //Create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEmail([FromForm] CheckInCreateDto dto, IFormFile pdfFile)
        {
            //first=> save pdf to server
            //then=>save url into entity
            var fileMegaByte = 5 * 1024 * 1024;
            var pdfMimeType = "application/json";
            if(pdfFile.Length> fileMegaByte || pdfFile.ContentType != pdfMimeType)
            {
                return BadRequest("file not valid");
             }
            var fileUrl = Guid.NewGuid().ToString() + ".pdf";
            var filePath=Path.Combine(Directory.GetCurrentDirectory(), "documents","pdfs",fileUrl);
            using(var stream =new FileStream(filePath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream);
            }
            MainPage newMainPage = _mapper.Map<MainPage>(dto);
            await _context.MainPages.AddAsync(newMainPage);
            await _context.SaveChangesAsync();
            return Ok("Email created Successfully");
        }

        //Read
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<CheckInGetDto>>> GetCheckIn()
        {
            var checkIns = await _context.MainPages.ToListAsync();
            var convertedMainPages = _mapper.Map<IEnumerable<CheckInGetDto>>(checkIns);
            return Ok(convertedMainPages);
        }

        //Read(Download Pdf)
       // [HttpGet]
        //Update
        //Delete

    }
}
