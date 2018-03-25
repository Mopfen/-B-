using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Testy
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnListOfUsers()
        {
            var users = new List<User>() { new User
                { email = "mail@gmail.com", password = "asd", username = "username" }, new User
                { email = "mail@gmail.com", password = "asd2", username = "username2" }};
            var userRepository = new Mock<IRepository<User>>();

            var userService = new Mock<IUserService>();

            userService.Setup(x => x.GetAll()).Returns(users);

            var userController = new UserController(userService.Object);

            var result = userController.Get();

            Assert.Equal(users, result);
        }

        public class UserController: Controller
        {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            public List<User> Get()
            {
                var users = _userService.GetAll();
                return users;
            }
        }

        public interface IRepository<T> where T : Entity
        {

        }
        public class Entity
        {
            public long id { get; set; }
        }
        public interface IUserService
        {
            List<User> GetAll();
        }

        public class User: Entity
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }
        }
    }
}
