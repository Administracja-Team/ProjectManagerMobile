using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class ProjectMemberDto
    {
        public ProjectDto Project { get; set; } = new();
        public List<OtherProjectMemberDto> Others { get; set; } = new();

        [JsonPropertyName("system_role")]
        public string SystemRole { get; set; }

        [JsonPropertyName("owner_name")]
        public string OwnerName { get; set; }
    }
}
