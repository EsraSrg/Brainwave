namespace BrainWave.DtoLayer.DataTransferObjects.AppUserDtos
{
    public class AppUserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; } // Kullanıcı yetki tipi
        public string UserType { get; set; } // Kullanıcı türü (Mentor veya Menti)
    }
}
