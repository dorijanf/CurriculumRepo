namespace CurriculumRepository.CORE.Data.Models.Account
{ 
    public class AuthenticationResponseDTO
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        public int UserTypeId { get; set; }
    }
}
