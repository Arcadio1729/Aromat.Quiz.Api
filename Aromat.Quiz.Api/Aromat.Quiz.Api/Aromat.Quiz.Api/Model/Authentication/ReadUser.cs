using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Authentication
{
    public class ReadUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int Role { get; set; }


    }
}
