using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model
{
    public class RefreshRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
