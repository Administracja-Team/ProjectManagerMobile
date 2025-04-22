using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName => $"{Name} {Surname}";

        public string Description { get; set; }
        public string LanguageCode { get; set; }    
        public DateTime RegisteredAt { get; set; }
    }

}
