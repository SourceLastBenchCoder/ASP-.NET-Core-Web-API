using CodeWithChakri.API.Testing.Interfaces;
using CodeWithChakri.API.Testing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWithChakri.API.Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private IArticle articleContext;

        public ArticleController(IArticle articleContext)
        {
            this.articleContext = articleContext;
        }

        [HttpGet("list")]
        public List<Article> Get()
        {
            return articleContext.All();
        }

        [HttpPost("create")]
        public string Create(Article article)
        {
            return articleContext.Add(article);
        }

        [HttpPost("update")]
        public string Update(Article article)
        {
            return articleContext.Update(article);
        }

        [HttpPost("delete")]
        public string Delete(int articleId)
        {
            var article = articleContext.All().Where(x => x.ArticleId == articleId).FirstOrDefault();
            return articleContext.Delete(article);
        }
    }
}
