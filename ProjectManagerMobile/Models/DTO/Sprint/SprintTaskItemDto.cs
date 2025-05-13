using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace ProjectManagerMobile.Models.DTO.Sprint
{
    public class SprintTaskItemDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Priority { get; set; }

        [JsonPropertyName("implementers")]
        public List<ImplementerDto> Implementers { get; set; } = new();

        public string Status { get; set; }

        [JsonPropertyName("is_mine")]
        public bool IsMine { get; set; }
    }

    public class ImplementerDto
    {
        public long Id { get; set; }
    }
}
