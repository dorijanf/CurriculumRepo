using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Ls = new HashSet<Ls>();
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Ls> Ls { get; set; }
    }
}
