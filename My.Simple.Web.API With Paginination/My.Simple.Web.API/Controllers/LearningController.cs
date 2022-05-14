using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My.Simple.Web.API.Models;

namespace My.Simple.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        List<Learning> learningList = new List<Learning>()
        {
            new Learning
            {
                Title="Course1",
                Description="Course1 Description",
                LearningId=1,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },
           new Learning
            {
                Title="Course2",
                Description="Course2 Description",
                LearningId=2,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course3",
                Description="Course3 Description",
                LearningId=3,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course4",
                Description="Course4 Description",
                LearningId=4,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course5",
                Description="Course5 Description",
                LearningId=5,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course6",
                Description="Course6 Description",
                LearningId=6,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course7",
                Description="Course7 Description",
                LearningId=7,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course8",
                Description="Course8 Description",
                LearningId=8,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course9",
                Description="Course9 Description",
                LearningId=9,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },new Learning
            {
                Title="Course10",
                Description="Course10 Description",
                LearningId=10,
                DateStarted=DateTime.Now,
                DateCompleted=DateTime.Now
            },
        };

        [HttpGet("learning-list")]
        public IActionResult Get([FromQuery]ServiceParameter serviceParameter)
        {
            var response =
            learningList.OrderBy(on => on.Title)
            .Skip((serviceParameter.PageNumber - 1) * serviceParameter.PageSize)
            .Take(serviceParameter.PageSize)
            .ToList();
            return Ok(response);
        }
    }
}
