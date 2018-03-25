using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var usersWithoutPassword = new List<UserDto>();
            foreach(var x in users)
            {
                UserDto bolek = new UserDto(x.username, x.email);
                usersWithoutPassword.Add(bolek);
            }

            var userRepository = new Mock<IRepository<User>>();

            var userService = new UserService(userRepository.Object);

            userRepository.Setup(x => x.GetAllWithoutPassword()).Returns(usersWithoutPassword.AsQueryable());

            var userController = new UserController(userService);

            var result = userController.GetWithoutPassword();

            Assert.Equal(usersWithoutPassword, result);
        }

        public class UserService: IUserService
        {
            private readonly IRepository<User> _userRepository;

            public UserService(IRepository<User> userRepository)
            {
                _userRepository = userRepository;
            }
            public List<User> GetAll()
            {
                IQueryable<User> users = _userRepository.GetAll();

                return users.ToList();
            }
            public List<UserDto> GetAllWithoutPassword()
            {
                IQueryable<UserDto> users = _userRepository.GetAllWithoutPassword();

                return users.ToList();
            }
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
            public List<UserDto> GetWithoutPassword()
            {
                var users = _userService.GetAllWithoutPassword();

                return users;
            }

        }

        public interface IRepository<T> where T : Entity
        {
            IQueryable<User> GetAll();
            IQueryable<UserDto> GetAllWithoutPassword();
            List<User> GetUsers();
        }
        public class Entity
        {
            public long id { get; set; }
        }
        public interface IUserService
        {
            List<User> GetAll();
            List<UserDto> GetAllWithoutPassword();
        }

        public class User: Entity
        {
            public string username { get; set; }
            public string email { get; set; }
            public string password { get; set; }


        }
        public class UserDto
        {
            public string username { get; set; }
            public string email { get; set; }
            public UserDto(string username, string email)
            {
                this.username = username;
                this.email = email;
            }
        }
    }
}
