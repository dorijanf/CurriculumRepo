using System;

namespace CurriculumRepository.CORE.Data.Models.Account
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int UserTypeId { get; set; }
    }
}
