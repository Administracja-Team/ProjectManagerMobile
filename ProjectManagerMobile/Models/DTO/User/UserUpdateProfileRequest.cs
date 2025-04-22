using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class UserUpdateProfileRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Description { get; set; }
        //public string Username { get; set; }

        //[JsonPropertyName("language_code")]
        //public string LanguageCode { get; set; }
    }

}
