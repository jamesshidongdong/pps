using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysPPS.Entity.ViewModel
{
    public class Project
    {
        public string projectName { get; set; }
        public string client { get; set; }
        public int department { get; set; }
        public int projectType { get; set; }
        public DateTime deadline { get; set; }
        public string projectIntroduction { get; set; }

        public string types { get; set; }

        public int projectID { get; set; }

        public int ProjectTeam { get; set; }

        public string Reason { get; set; }

    }
}
