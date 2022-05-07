using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Simple.Web.API.Models;

namespace My.Simple.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {

        [HttpGet("learning-list")]
        public IActionResult Get()
        {
            List<Learning> learningList = new List<Learning>();            

            if(learningList.Count <= 0)
                throw new FormatException();

            return Ok(learningList);
        }
    }
}
