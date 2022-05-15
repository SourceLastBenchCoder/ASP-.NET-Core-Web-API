using CodeWithChakri.API.Testing.Controllers;
using CodeWithChakri.API.Testing.Interfaces;
using CodeWithChakri.API.Testing.Models;
using CodeWithChakri.API.Testing.UnitTest.Repository;
using System.Collections.Generic;
using Xunit;

namespace CodeWithChakri.API.Testing.UnitTest
{
    public class ArticleControllerTest
    {
        private readonly ArticleController _controller;
        private readonly IArticle _service;
        public ArticleControllerTest()
        {
            _service = new FakeArticleRepository();
            _controller = new ArticleController(_service);
        }

        [Fact]
        public void Get_All_Articles_When_Called()
        {
            //Act
            var listResult = _controller.Get() as List<Article>;

            // Assert
            var items = Assert.IsType<List<Article>>(listResult);
            Assert.Equal(4, items.Count);
        }

        [Fact]
        public void Add_Article_Returns_Response()
        {
            // Arrange
            Article testItem = new Article()
            {
                ArticleId = 5,
                Title = "Test Python Article"
            };

            // Act
            var createdResponse = _controller.Create(testItem);

            // Assert
            Assert.Equal(testItem.Title,createdResponse);
        }

        [Fact]
        public void Update_Article_Returns_Response()
        {
            // Arrange
            Article testItem = new Article()
            {
                ArticleId = 1,
                Title = "Test C# Programming Language"
            };

            // Act
            var updatedResponse = _controller.Update(testItem);

            // Assert
            Assert.Equal(testItem.Title, updatedResponse);
        }

        [Fact]
        public void Remove_Article_Returns_Response()
        {
            //Arrange
            int articleId = 4;

            // Act
            var deleteResponse = _controller.Delete(articleId);

            // Assert
            Assert.Equal("Success", deleteResponse);
        }
    }
}