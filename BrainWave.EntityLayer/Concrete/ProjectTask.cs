using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
	public class ProjectTask
	{
		public int ProjectTaskID { get; set; }
		public int? ProjectID { get; set; }
		public int? SenderID { get; set; }
		public string? ReceiverUsername { get; set; }
		public int? ReceiverID { get; set; }
		public string? TaskDescription { get; set; }
		public string? TaskFinishedNote { get; set; }
		public DateTime? TaskDeadline { get; set; } 
		public bool TaskStatus { get; set; }
		public List<ProjectTask> ProjectTasks { get; set; }
	}
}
