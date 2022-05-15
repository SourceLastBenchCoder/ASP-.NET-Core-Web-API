using CodeWithChakri.API.Testing.Interfaces;
using CodeWithChakri.API.Testing.Models;

namespace CodeWithChakri.API.Testing.Repository
{
    public class ArticleRepository : IArticle
    {
        public static List<Article> _articles = new List<Article>()
        {
            new Article() { ArticleId = 1,Title="C# Programming"},
            new Article() { ArticleId = 2,Title="ASP.Net Web API"},
            new Article() { ArticleId = 3,Title="ASP.Net Core MVC"},
            new Article() { ArticleId = 4,Title="MS SQL Server"}
        };

        public string Add(Article article)
        {
           _articles.Add(article);
            return article.Title;
        }

        public List<Article> All()
        {
            return _articles;
        }

        public string Delete(Article article)
        {
            _articles.Remove(article);
            return "Success";
        }

        public string Update(Article article)
        {
            var data=_articles.Where(x => x.ArticleId == article.ArticleId)
                .FirstOrDefault();
            data.Title = article.Title;
            return article.Title;
        }
    }
}