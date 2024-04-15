using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewIdentity.EntityLayer.Concrete
{
    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AboutMe { get; set; }
        public string EducationInfo { get; set; }
        public string ExperienceInfo { get; set; }
        public string PreviousProjects { get; set; }
        public string Reviews { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
