using Data.DBModels;
using Data.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<User> GetAll();
        IQueryable<UserDto> GetAllWithoutPassword();
        List<User> GetUsers();
    }
}
