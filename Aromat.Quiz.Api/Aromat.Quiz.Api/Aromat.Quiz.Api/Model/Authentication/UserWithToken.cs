using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Authentication
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.Id = user.Id;
            this.Email = user.Email;
            this.FirstName = user.FirstName;
            this.LastName = user.LastName;
            this.RoleId = user.RoleId;
            this.Role = user.Role;
        }
    }
}
