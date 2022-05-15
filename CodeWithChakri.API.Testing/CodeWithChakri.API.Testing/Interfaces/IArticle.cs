using CodeWithChakri.API.Testing.Models;

namespace CodeWithChakri.API.Testing.Interfaces
{
    public interface IArticle
    {
        string Add(Article article);
        List<Article> All();
        string Update(Article article);
        string Delete(Article article);
    }
}
