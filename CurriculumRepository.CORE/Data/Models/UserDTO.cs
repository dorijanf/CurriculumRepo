using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models
{
    public class UserDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Role { get; set; }
    }
}
