using System;
using System.Collections.Generic;

namespace CurriculumRepository.API.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int IduserType { get; set; }
        public string UserTypeName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
