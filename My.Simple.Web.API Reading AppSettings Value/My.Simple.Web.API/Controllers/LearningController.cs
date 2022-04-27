using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using My.Simple.Web.API.Models;

namespace My.Simple.Web.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Learning")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [EnableCors("SampleCORS")]
    public class LearningController : ControllerBase
    {
        private static AppDbContext _context;
        private readonly MailInfo _mailInfo;

        public LearningController(AppDbContext context, IOptions<MailInfo> mailInfo)
        {
            _context = context;
            _mailInfo = mailInfo.Value;
        }

        [HttpGet("send-mail")]
        public IActionResult SendMail()
        {
            if (_mailInfo.IsMailRequired)
            {
                return Ok("mail sent to xyz@test.com from "+_mailInfo.MailFrom);
            }

            return Ok("Mail Failed");
        }

        [HttpGet("learning-list")]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok(_context.Learning.ToList());
        }

        [HttpGet("learning-list")]
        [MapToApiVersion("2.0")]
        public IActionResult Get2()
        {
            return Ok("Hello I am version 2");
        }

        [HttpPost("learning-create")]
        public IActionResult Create(Learning learning)
        {
            _context.Learning.Add(learning);
            _context.SaveChanges();
            return Ok("success");
        }

        [HttpPost("learning-update")]
        public IActionResult Update(Learning learning, int learningId)
        {
            var learningToUpdate = _context.Learning.Where(o => o.LearningId == learningId).FirstOrDefault();

            if (learningToUpdate == null)
                return BadRequest();

            learningToUpdate.Title = learning.Title;
            learningToUpdate.Description = learning.Description;
            learningToUpdate.DateStarted = learning.DateStarted;
            learningToUpdate.DateCompleted = learning.DateCompleted;


            _context.Learning.Update(learningToUpdate);
            _context.SaveChanges();
            return Ok("success");
        }

        [HttpDelete("learning-delete")]
        public IActionResult Delete(int learningId)
        {
            var learningToDelete = _context.Learning.Where(o => o.LearningId == learningId).FirstOrDefault();

            if (learningToDelete == null)
                return BadRequest();

            _context.Learning.Remove(learningToDelete);
            _context.SaveChanges();
            return Ok("success");
        }
    }
}
