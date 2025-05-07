using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerMobile.Models
{
    public class ProjectModel
    {

        public long Id { get; set; }
        public string Name { get; set; }

        public string OwnerName { get; set; }

        public string NameWithOwner => $"{Name} | {OwnerName}";

        public string CurrentSprintName { get; set; }

        public DateTime CurrentSprintDeadLine { get; set; }

        public int DonePercents { get; set; }

        public ProjectModel()
        {
            
        }
    }
}
