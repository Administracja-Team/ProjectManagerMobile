using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO.Project
{
    public class ProjectDetailsDto
    {
        public ProjectDto Project { get; set; }

        public List<OtherProjectMemberDto> Others { get; set; }
    }
}
