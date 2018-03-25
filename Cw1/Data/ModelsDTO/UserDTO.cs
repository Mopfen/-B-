using System;
using System.Collections.Generic;
using System.Text;

namespace Data.ModelsDTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public UserDto(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }
    }
}
