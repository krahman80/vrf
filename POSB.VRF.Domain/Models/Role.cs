using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSB.VRF.Domain.Models
{
    public class Role : BaseEntity, IModel
    {

        public Role()
        {
            Permissions = new HashSet<Permission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<User> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

    }
}
