using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? About { get; set; }
        public string? Education { get; set; }
        public string? Experience { get; set; }
        public string? Skills { get; set; }
		public string? MainInterest { get; set; }
		public string? Interests { get; set; }
		public string? Socials { get; set; }
		public string? Type { get; set; }
		public int ConfirmCode { get; set; }

        //one to many relationship
        public List<UserProject> UserProjects { get; set; }

	}
}
