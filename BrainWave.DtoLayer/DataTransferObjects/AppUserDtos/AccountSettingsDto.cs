using System.ComponentModel.DataAnnotations;

namespace BrainWave.DtoLayer.DataTransferObjects.AppUserDtos
{
    public class AppUserAccountSettingsDto
    {
        public string NewUserName { get; set; }

        [Required(ErrorMessage = "The New Email field is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string NewEmail { get; set; }

        [Required(ErrorMessage = "The Old Password field is required.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "The New Password field is required.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "The Confirm Password field is required.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}