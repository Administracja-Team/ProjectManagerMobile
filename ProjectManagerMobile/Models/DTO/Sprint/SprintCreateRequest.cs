using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO.Sprint
{
    public class SprintCreateRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<SprintTaskDto> Tasks { get; set; }

        [JsonPropertyName("start_at")]
        public DateTime StartAt { get; set; }

        [JsonPropertyName("end_at")]
        public DateTime EndAt { get; set; }
    }
}
