using AutoMapper;
using Data.DBModels;
using Data.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;
using Xunit;

namespace Testy
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnListOfUsers()
        {
            var users = new List<User>() { new User
                { Email = "mail@gmail.com", Password = "asd", Username = "username" }, new User
                { Email = "mail@gmail.com", Password = "asd2", Username = "username2" }};

            var usersWithoutPassword = new List<UserDto>();
            foreach(var x in users)
            {
                UserDto bolek = new UserDto(x.Username, x.Email);
                usersWithoutPassword.Add(bolek);
            }

            var userRepository = new Mock<IRepository<User>>();

            var userService = new UserService(userRepository.Object);

            userRepository.Setup(x => x.GetAllWithoutPassword()).Returns(usersWithoutPassword.AsQueryable());

            var userController = new UserController(userService);

            var result = userController.GetWithoutPassword();

            Assert.Equal(usersWithoutPassword, result);
        }
    }
}
