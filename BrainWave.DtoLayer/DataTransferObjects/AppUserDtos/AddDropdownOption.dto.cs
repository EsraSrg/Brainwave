using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrainWave.DtoLayer.DataTransferObjects
{
    public class AddDropdownOptionDto
    {
        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Seçenek alanı zorunludur.")]
        public string Option { get; set; }

        public List<string> Categories { get; set; } = new List<string> {"Üniversite", "Yetenekler", "İlgi Alanları" };
    }
}
