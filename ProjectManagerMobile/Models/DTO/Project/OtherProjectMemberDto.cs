using DevExpress.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class OtherProjectMemberDto
    {
        public UserDto User { get; set; } = new();
        public long MemberId { get; set; }
        public string SystemRole { get; set; } = "MEMBER"; // Could be OWNER, ADMIN, MEMBER
        public string DescriptiveRole { get; set; } = string.Empty;
    }
}
