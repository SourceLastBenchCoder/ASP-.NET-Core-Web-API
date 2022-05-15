using CodeWithChakri.API.Testing.Interfaces;
using CodeWithChakri.API.Testing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWithChakri.API.Testing.UnitTest.Repository
{
    public class FakeArticleRepository:IArticle
    {
        public static List<Article> _articles = new List<Article>()
        {
            new Article() { ArticleId = 1,Title="Test C# Programming"},
            new Article() { ArticleId = 2,Title="Test ASP.Net Web API"},
            new Article() { ArticleId = 3,Title="Test ASP.Net Core MVC"},
            new Article() { ArticleId = 4,Title="Test MS SQL Server"}
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
            var data = _articles.Where(x => x.ArticleId == article.ArticleId)
                .FirstOrDefault();
            data.Title = article.Title;
            return article.Title;
        }
    }
}
