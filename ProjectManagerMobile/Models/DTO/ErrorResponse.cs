using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

}
