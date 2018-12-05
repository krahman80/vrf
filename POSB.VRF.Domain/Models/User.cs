using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSB.VRF.Domain.Models
{
    public class User : BaseEntity, IModel
    {
        
        public string Login { get; set; }
        
        public string FullName { get; set; }

        public string Title { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public virtual Role Roles { get; set; }

        public int RoleId { get; set; }
    }
}
