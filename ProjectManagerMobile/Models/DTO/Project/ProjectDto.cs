using ProjectManagerMobile.Utilities.Converters.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        [JsonPropertyName("done_percents")]
        public double DonePercents { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }
    }
}
