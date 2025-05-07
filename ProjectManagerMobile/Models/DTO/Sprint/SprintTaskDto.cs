using ProjectManagerMobile.Utilities.Converters.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO.Sprint
{
    public class SprintTaskDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; }

        [JsonPropertyName("implementer_member_ids")]
        public List<long> ImplementerMemberIds { get; set; }

        [JsonPropertyName("start_at")]
        [JsonConverter(typeof(DateTimeWithoutOffsetConverter))]
        public DateTime StartAt { get; set; }

        [JsonPropertyName("end_at")]
        [JsonConverter(typeof(DateTimeWithoutOffsetConverter))]
        public DateTime EndAt { get; set; }

        [JsonIgnore]
        public string EndAtShort => EndAt.ToString("dd.MM");
    }
}
