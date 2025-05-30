using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Common.DTO.Requests
{
    public class LoginRequest
    {
        public string Username { set; get; }
        public string Password { set; get; }
        public bool Remember { set;get; }
    }
}
