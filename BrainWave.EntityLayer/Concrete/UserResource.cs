using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
	public class UserResource
	{
        public int UserResourceID { get; set; }
		public string ResourceTitle { get; set; }
		public string? ResourceDescription { get; set; }
		public DateTime ResourcePublishDate { get; set; }
        public string? ResourceAuthor { get; set; }
        public string? ResourceCategories { get; set; }
		public string? ResourceUrl { get; set; }
		public string? ResourceImage { get; set; }
		public int AppUserID { get; set; }
	}
}
