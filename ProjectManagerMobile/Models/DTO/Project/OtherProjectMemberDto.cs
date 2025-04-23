using DevExpress.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class OtherProjectMemberDto
    {
        public UserDto User { get; set; }

        [JsonPropertyName("member_id")]
        public long MemberId { get; set; }

        [JsonPropertyName("system_role")]
        public string SystemRole { get; set; } = "MEMBER"; // Could be OWNER, ADMIN, MEMBER

        [JsonPropertyName("descriptive_role")]
        public string DescriptiveRole { get; set; }
    }
}
