using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DtoLayer.DataTransferObjects.AppUserDtos
{
	public class AppUserInfoDtos
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string Experience { get; set; }
        public string Education { get; set; }
        public string Skills { get; set; }
		public string Interests { get; set; } 
		public string Socials { get; set; }
		public IFormFile ProfileImage { get; set; }
		public string ProfileImageName { get; set; }
	}
}
