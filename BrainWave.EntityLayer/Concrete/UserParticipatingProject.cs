using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
	public class UserParticipatingProject
	{
		public int UserParticipatingProjectID { get; set; }
		public int UserID { get; set; }
		public int ProjectID { get; set; }
	}
}
