using Data.DBModels;
using Data.ModelsDTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class UserService : IUserService
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
}
