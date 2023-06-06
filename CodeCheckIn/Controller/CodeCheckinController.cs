using AutoMapper;
using CodeCheckIn.Core.Context;
using CodeCheckIn.Core.Dtos.MainPage;
using CodeCheckIn.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;

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
        public async Task<IActionResult> CreateEmail([FromForm] CheckInCreateDto dto)//, IFormFile pdfFile)
        { 
            var email = new MimeMessage();

            

            email.From.Add(MailboxAddress.Parse("puran.gurung@cedargate.com"));
            //Multiple receivers
            var sendToEmails = dto.SendTo.Split(',');

            foreach (var emailAddr in sendToEmails)
            {
                email.To.Add(MailboxAddress.Parse(emailAddr.Trim()));
            }
            //email.To.Add(MailboxAddress.Parse(dto.SendTo));
            email.Subject = dto.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = dto.Description};
            using var smtp = new SmtpClient();
            smtp.Connect("outlook.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls); // eta outlook to lagi bhako server use garne
            smtp.Authenticate("puran.gurung@cedargate.com", "pw"); //add user pw here
            smtp.Send(email);
            smtp.Disconnect(true);

            MainPage newMainPage = _mapper.Map<MainPage>(dto);
            await _context.MainPages.AddAsync(newMainPage);
            await _context.SaveChangesAsync();
            return Ok("Email created and Sent Successfully");
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


        [HttpPost]
        [Route("upload/files")]

       public IActionResult UploadFile(IFormFile file)
        {
            if(file != null && file.Length > 0)
            {
                var fileName= Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
                var filePath = Path.Combine("C:\\Users\\Saurav.shakya\\source\\repos\\CodeCheckIn\\CodeCheckIn\\NewFolder\\", fileName);
                using(var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                return Ok(filePath);

            }
            return BadRequest("File not upload");
        }


        //Read(Download Pdf)
        // [HttpGet]
        //Update
        //Delete
        //first=> save pdf to server
        //then=>save url into entity
        //var fileMegaByte = 5 * 1024 * 1024;
        //var pdfMimeType = "application/json";
        //if(pdfFile.Length> fileMegaByte || pdfFile.ContentType != pdfMimeType)
        //{
        //    return BadRequest("file not valid");
        // }
        //var fileUrl = Guid.NewGuid().ToString() + ".pdf";
        //var filePath=Path.Combine(Directory.GetCurrentDirectory(), "documents","pdfs",fileUrl);
        //using(var stream =new FileStream(filePath, FileMode.Create))
        //{
        //    await pdfFile.CopyToAsync(stream);
        //}
    }
}
