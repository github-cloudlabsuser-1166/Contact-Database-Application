using CRUD_application_2.Controllers;
using CRUD_application_2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public void Details_ValidId_ReturnsView()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(User));
        }

        [TestMethod]
        public void Details_InvalidId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Details(3) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>();
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "John", Email = "john@example.com" };

            // Act
            var result = controller.Create(user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Create_InvalidModel_ReturnsView()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>();
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "", Email = "john@example.com" };
            controller.ModelState.AddModelError("Name", "The Name field is required.");

            // Act
            var result = controller.Create(user) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);
        }

        [TestMethod]
        public void Edit_ValidId_ReturnsView()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Edit(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(User));
        }

        [TestMethod]
        public void Edit_InvalidId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Edit(3) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "Updated John", Email = "updatedjohn@example.com" };

            // Act
            var result = controller.Edit(1, user) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_InvalidModel_ReturnsView()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;
            var user = new User { Id = 1, Name = "", Email = "john@example.com" };
            controller.ModelState.AddModelError("Name", "The Name field is required.");

            // Act
            var result = controller.Edit(1, user) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);
        }

        [TestMethod]
        public void Delete_ValidId_RedirectsToIndex()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Delete(1, new FormCollection()) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Delete_InvalidId_ReturnsHttpNotFound()
        {
            // Arrange
            var controller = new UserController();
            var userlist = new List<User>
            {
                new User { Id = 1, Name = "John", Email = "john@example.com" },
                new User { Id = 2, Name = "Jane", Email = "jane@example.com" }
            };
            controller.userlist = userlist;

            // Act
            var result = controller.Delete(3, new FormCollection()) as HttpNotFoundResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
