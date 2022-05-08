using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Simple.Web.API.Models;

namespace My.Simple.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        List<Learning> learningList;

        public LearningController()
        {
            learningList = new List<Learning>()
            {
                new Learning{LearningId=1,
                    Title="Test",
                    Description="Test Description",
                    DateStarted=DateTime.Now,
                    DateCompleted=DateTime.Now},
                new Learning{LearningId=1,
                    Title="Test2",
                    Description="Test Description2",
                    DateStarted=DateTime.Now,
                    DateCompleted=DateTime.Now}
            };
        }

        [Authorize]
        [HttpGet("learning-list")]
        public IActionResult Get()
        {
            return Ok(learningList);
        }
    }
}
