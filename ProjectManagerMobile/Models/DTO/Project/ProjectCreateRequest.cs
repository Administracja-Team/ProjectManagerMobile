using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models.DTO
{
    public class ProjectCreateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
