using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSB.VRF.Domain.Models
{
    public class VisitorType : BaseEntity, IModel
    {
        [Required(ErrorMessage = "Please enter Description.")]
        public string Description { get; set; }
        public ICollection<VisitorRequestForm> VisitorRequestForms { get; set; }
    }
}
