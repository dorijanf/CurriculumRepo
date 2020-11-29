namespace CurriculumRepository.CORE.Data.Models.Account
{
    public class RegisterUserBM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}