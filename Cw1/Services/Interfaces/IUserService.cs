using Data.DBModels;
using Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();
        List<UserDto> GetAllWithoutPassword();
    }
}
