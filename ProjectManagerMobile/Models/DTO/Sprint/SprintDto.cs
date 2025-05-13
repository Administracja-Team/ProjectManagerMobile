using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO.Sprint
{
    public class SprintDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonPropertyName("tasks")]
        public int TaskCount { get; set; }

        [JsonPropertyName("is_ended")]
        public bool IsEnded { get; set; }

        [JsonPropertyName("is_started")]
        public bool IsStarted { get; set; }

        [JsonPropertyName("start_time")]
        public DateTime StartAt { get; set; }

        [JsonPropertyName("end_time")]
        public DateTime EndAt { get; set; }

        [JsonPropertyName("done_percents")]
        public double DonePercents { get; set; }

        [JsonIgnore]
        public string EndAtShort => EndAt.ToString("dd.MM");
    }
}
