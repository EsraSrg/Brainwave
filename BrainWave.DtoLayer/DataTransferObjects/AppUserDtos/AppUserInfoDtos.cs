using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrainWave.DtoLayer.DataTransferObjects
{
    public class AppUserInfoDtos
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        public string Surname { get; set; }

        public string About { get; set; }
        public string Experience { get; set; }

        [Required(ErrorMessage = "Eğitim alanı zorunludur.")]
        public string Education { get; set; }

        [Required(ErrorMessage = "Yetenekler alanı zorunludur.")]
        public string Skills { get; set; }

        [Required(ErrorMessage = "İlgi alanları alanı zorunludur.")]
        public string Interests { get; set; }

        public string Socials { get; set; }
        //public IFormFile ProfileImage { get; set; }
        //public string ProfileImageName { get; set; }

        // Dropdown options
        public List<string> HighSchoolOptions { get; set; } = new List<string> { "İzmir Kız Lisesi", "İzmir Atatürk Lisesi", "Bornova Anadolu Lisesi" };
        public List<string> UniversityOptions { get; set; } = new List<string> { "Ege Üniversitesi", "Boğaziçi Üniversitesi", "Bilkent Üniversitesi" };
        public List<string> SkillOptions { get; set; } = new List<string> { "C#", "Piyano", "Seramik Yapımı" };
        public List<string> InterestOptions { get; set; } = new List<string> { "Müzik", "Resim", "Yazılım" };
    }
}
