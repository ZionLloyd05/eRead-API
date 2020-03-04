using Books.API.Controllers;
using Books.API.Dtos;
using Books.ApplicationCore.Entities;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.Infrastructure;
using Books.Infrastructure.Data;
using Books.UnitTest.Data;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Books.UnitTest.ControllerTest
{
    public class TagControllerTest
    {
        private BooksRepository<Tag> repository;
        public static DbContextOptions<BooksContext> dbContextOptions { get; }
        public static string connectionString = "Server=DESKTOP-UU6UAJD;Database=BookStandTestDB;Trusted_Connection=True";
        static TagControllerTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<BooksContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public TagControllerTest()
        {
            var context = new BooksContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);

            repository = new BooksRepository<Tag>(context);
        }

       // #region Get By Id

       //[Fact]
       //public async void Task_GetTagById_Return_OkResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 2;

       //     // Act
       //     var data = await controller.GetTag(tagId);

       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);
       // }

       // [Fact]
       // public async void Task_GetTagById_NotFoundResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 5;

       //     // Act
       //     var data = await controller.GetTag(tagId);

       //     // Assert
       //     Assert.IsType<NotFoundResult>(data);
       // }

       // [Fact]
       // public async void Task_GetTagById_BadRequestResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     int? tagId = null;

       //     // Act
       //     var data = await controller.GetTag(tagId);

       //     // Assert
       //     Assert.IsType<BadRequestResult>(data);
       // }

       // [Fact]
       // public async void Task_GetTagById_MatchResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     int tagId = 1;

       //     // Act
       //     var data = await controller.GetTag(tagId);
                     
       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);

       //     var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
       //     var tag = OkResult.Value.Should().BeAssignableTo<Tag>().Subject;

       //     Assert.Equal("Faith", tag.Name);
       //     Assert.Equal("Christian book on faith", tag.Description);
       // }
       // #endregion

       // #region Get All Tags

       // [Fact]
       // public async void Task_GetTags_OkResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);

       //     // Act
       //     var data = await controller.GetTags();

       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);
       // }

       // [Fact]
       // public async void Task_GetTags_NotFound()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);

       //     // Act
       //     var data = await controller.GetTags();

       //     if (data == null) {
       //         // Assert
       //         Assert.IsType<NotFoundResult>(data);
       //     }
          
       // }

       // [Fact]
       // public async void Task_GetTags_MatchResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);

       //     // Act
       //     var data = await controller.GetTags();

       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);

       //     var OkResult = data.Should().BeOfType<OkObjectResult>().Subject;
       //     var tag = OkResult.Value.Should().BeAssignableTo<List<Tag>>().Subject;

       //     Assert.Equal("Faith", tag[0].Name);
       //     Assert.Equal("Christian book on faith", tag[0].Description);
       // }
       // #endregion

       // #region Add New Tag
       // [Fact]
       // public async void Task_Post_ValidData_Return_OkResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tag = new TagDto() { Name = "TestTag", Description = "Tags are made to stick to books for easy recognition" };

       //     // Act
       //     var data = await controller.Post(tag);

       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);
       // }

       // [Fact]
       // public async void Task_Post_Return_BadRequest()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tag = new TagDto() {
       //         Name = "TestTag title More than 20 character to test",
       //         Description = "Tags are made to stick to books for easy recognition"
       //     };

       //     // Act
       //     var data = await controller.Post(tag);

       //     // Assert
       //     Assert.IsType<BadRequestResult>(data);
       // }

       // [Fact]
       // public async void Task_Post_ValidData_MatchResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tag = new TagDto() { Name = "TestTag", Description = "Tags are made to stick to books for easy recognition" };

       //     // Act
       //     var data = await controller.Post(tag);

       //     // Assert
       //     Assert.IsType<OkObjectResult>(data);

       //     //var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
       // }
       // #endregion

       // #region Update Existing Tag
       // [Fact]
       // public async void Task_Update_ValidData_Return_OkResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 2;

       //     // Act
       //     ///var existingTag = await controller.GetTag(tagId);
       //     //var okResult = existingTag.Should().BeOfType<OkObjectResult>().Subject;
       //     //var result = okResult.Value.Should().BeAssignableTo<Tag>().Subject;

       //     var tagForUpdate = new TagDto();
       //     tagForUpdate.Name = "Updated tag";
       //     tagForUpdate.Description = "updated description";

       //     var updatedTag = await controller.Update(tagId, tagForUpdate);

       //     // Assert
       //     Assert.IsType<OkResult>(updatedTag);
       // }

       // [Fact]
       // public async void Task_Update_InvalidData_Return_BadRequest()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 2;

       //     // Act
       //     var tagForUpdate = new TagDto() { Name = "TestTag title More than 20 character to test", Description = "Tags are made to stick to books for easy recognition" };

       //     var updatedTag = await controller.Update(tagId, tagForUpdate);

       //     // Assert
       //     Assert.IsType<BadRequestResult>(updatedTag);
       // }

       // [Fact]
       // public async void Task_Update_InvalidData_Return_NotFound()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 100;

       //     // Act
       //     var data = await controller.GetTag(tagId);

       //     // Assert
       //     Assert.IsType<NotFoundResult>(data);
       // }
       // #endregion

       // #region Delete Tag
       // [Fact]
       // public async void Task_Delete_OkResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 2;

       //     // Act
       //     var data = await controller.Delete(tagId);

       //     // Assert
       //     Assert.IsType<OkResult>(data);
       // }

       // [Fact]
       // public async void Task_Delete_NotFoundResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     var tagId = 100;

       //     // Act
       //     var data = await controller.Delete(tagId);

       //     // Assert
       //     Assert.IsType<NotFoundResult>(data);
       // }

       // [Fact]
       // public async void Task_Delete_BadRequestResult()
       // {
       //     // Arrange
       //     var controller = new TagsController(repository);
       //     int? tagId = null;

       //     // Act
       //     var data = await controller.Delete(tagId);

       //     // Assert
       //     Assert.IsType<BadRequestResult>(data);
       // }
       // #endregion

    }
}
