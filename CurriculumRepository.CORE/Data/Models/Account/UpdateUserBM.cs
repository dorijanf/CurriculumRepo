namespace CurriculumRepository.CORE.Data.Models.Account
{
    public class UpdateUserBM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
