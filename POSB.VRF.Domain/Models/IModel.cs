using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSB.VRF.Domain.Models
{
    public interface IModel
    {
        int Id { get; set; }
        String CreatedBy { get; set; }
        DateTime? CreatedDate { get; set; }
        String ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        Boolean IsActive { get; set; }
    }
}
