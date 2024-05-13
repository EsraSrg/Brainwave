using BrainWave.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DtoLayer.DataTransferObjects.UserProjectDtos
{
    public class CreateProjectDto
    {
        public int UserProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public string? ProjectCategories { get; set; }
        public string? ProjectTools { get; set; }
        public string? ProjectSources { get; set; }
        public string? ProjectTasks { get; set; }
        public bool? ProjectStatus { get; set; }
        public bool? ProjectPrivacy { get; set; }
        public int AppUserID { get; set; }
    }
}
