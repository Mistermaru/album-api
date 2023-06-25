using Album.Api.Controllers;
using Album.Api.Models;
using Album.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Album.Api.Tests
{
    public class AlbumControllerTest
    {
        private readonly AlbumController _controller;
        private readonly IAlbumService<AlbumModel> _service;
        public AlbumControllerTest()
        {
            _service = new AlbumFake();
            _controller = new AlbumController(_service);
        }
        [Fact]
        public void GetAlbums_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetAlbums();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void GetAlbums_ReturnsAllObjects()
        {
            // Act
            var okResult = _controller.GetAlbums() as OkObjectResult;
            // Assert
            var objs = Assert.IsType<List<AlbumModel>>(okResult.Value);
            Assert.Equal(3, objs.Count);
        }


        [Fact]
        public void GetAlbumById_InvalidId_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetAlbumById(12);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetAlbumById_ValidId_ReturnsOkResult()
        {
            // Arrange
            var testId = 2;

            // Act
            var okResult = _controller.GetAlbumById(testId);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetAlbumById_ValidId_ReturnsRightObject()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.GetAlbumById(testId) as OkObjectResult;

            // Assert
            Assert.IsType<AlbumModel>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as AlbumModel).Id);
        }

        [Fact]
        public void CreateAlbum_EmptyObject_ReturnsBadRequest()
        {
            // Arrange
            var testObj = new AlbumModel()
            {
            };

            // Act
            var createResponse = _controller.CreateAlbum(testObj);

            // Assert
            Assert.IsType<BadRequestResult>(createResponse);
        }

        [Fact]
        public void CreateAlbum_ValidObject_ReturnsCreatedResponse()
        {
            // Arrange
            AlbumModel testObj = new AlbumModel()
            {
                Name = "Jar of Dirt",
                Artist = "Jack Sparrow",
                ImageUrl = "https://i.pinimg.com/originals/2e/e3/9a/2ee39a718f03a632523412e80b7d0d7d.jpg"
            };

            // Act
            var createResponse = _controller.CreateAlbum(testObj);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createResponse);
        }

        [Fact]
        public void CreateAlbum_ValidObject_ReturnsCreatedObject()
        {
            // Arrange
            var testObj = new AlbumModel()
            {
                Name = "Jar of Dirt",
                Artist = "Jack Sparrow",
                ImageUrl = "https://i.pinimg.com/originals/2e/e3/9a/2ee39a718f03a632523412e80b7d0d7d.jpg"
            };

            // Act
            var createResponse = _controller.CreateAlbum(testObj) as CreatedAtActionResult;
            var obj = createResponse.Value as AlbumModel;

            // Assert
            Assert.IsType<AlbumModel>(obj);
            Assert.Equal("Jar of Dirt", obj.Name);
        }

        [Fact]
        public void UpdateAlbum_ValidObject_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;
            var testObj = new AlbumModel()
            {
                Name = "Jar of Dirt",
                Artist = "Jack Sparrow",
                ImageUrl = "https://i.pinimg.com/originals/2e/e3/9a/2ee39a718f03a632523412e80b7d0d7d.jpg"
            };

            // Act
            var updateResponse = _controller.UpdateAlbum(testId, testObj);

            // Assert
            Assert.IsType<OkObjectResult>(updateResponse);
        }

        [Fact]
        public void UpdateAlbum_ValidObject_UpdatesObject()
        {
            // Arrange
            var testId = 1;
            var testObj = new AlbumModel()
            {
                Name = "Jar of Dirt",
                Artist = "Jack Sparrow",
                ImageUrl = "https://i.pinimg.com/originals/2e/e3/9a/2ee39a718f03a632523412e80b7d0d7d.jpg"
            };

            // Act
            _controller.UpdateAlbum(testId, testObj);

            // Assert
            Assert.Equal(testObj.Name, _service.GetById(testId).Name);
        }

        [Fact]
        public void UpdateAlbum_InvalidObject_ReturnsBadRequest()
        {
            // Arrange
            var testId = 1;
            var testObj = new AlbumModel()
            {
            };

            // Act
            var updateResponse = _controller.UpdateAlbum(testId, testObj);

            // Assert
            Assert.IsType<BadRequestResult>(updateResponse);
        }

        [Fact]
        public void DeleteAlbum_ExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var testId = 1;

            // Act
            var noContentResponse = _controller.DeleteAlbum(testId);

            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void DeleteAlbum_ExistingId_RemovesOneItem()
        {
            // Arrange
            var testId = 3;

            // Act
            _controller.DeleteAlbum(testId);

            // Assert
            Assert.Equal(2, _service.GetAll().Count());
        }

        [Fact]
        public void DeleteAlbum_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = 4;

            // Act
            var notFoundResult = _controller.DeleteAlbum(testId);

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
    }
}
