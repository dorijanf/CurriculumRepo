using CurriculumRepository.API.Models.Entities;
using CurriculumRepository.CORE.Data.Helpers;
using System;
using System.Collections.Generic;

namespace CurriculumRepository.CORE.Entities
{
    public partial class User : IDeletable
    {
        public User()
        {
            Ls = new HashSet<Ls>();
        }

        public int Iduser { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] ProfilePicture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int UserTypeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<Ls> Ls { get; set; }
    }
}
