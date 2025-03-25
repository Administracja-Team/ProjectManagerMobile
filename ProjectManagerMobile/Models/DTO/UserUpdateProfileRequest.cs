using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class UserUpdateProfileRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LanguageCode { get; set; }
    }

}
