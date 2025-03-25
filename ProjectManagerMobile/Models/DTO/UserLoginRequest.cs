using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class UserLoginRequest
    {
        public string Identifier { get; set; }
        public string Password { get; set; }
    }

}
