using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSB.VRF.Domain.Models
{

    public class Permission : BaseEntity, IModel
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string ControllerMethod { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
