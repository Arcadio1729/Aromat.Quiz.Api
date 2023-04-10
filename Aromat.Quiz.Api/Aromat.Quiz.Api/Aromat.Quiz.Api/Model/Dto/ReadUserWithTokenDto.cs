using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class ReadUserWithTokenDto : ReadUserDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
