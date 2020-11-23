using CurriculumRepository.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumRepository.CORE.Data.Models
{
    public class AuthenticationResponseDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
