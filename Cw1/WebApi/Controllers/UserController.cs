using Data.DBModels;
using Data.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class UserController : Controller
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
}
