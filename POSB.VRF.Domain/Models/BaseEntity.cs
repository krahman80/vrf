using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSB.VRF.Domain.Models
{
    public abstract class BaseEntity
    {
        [Editable(false)]
        public virtual int Id { get; set; }

        [DisplayFormat(NullDisplayText = ""), Editable(false), StringLength(50)]
        public virtual string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}"), Editable(false)]
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set
            {
                if (value != null)
                {
                    _createdDate = new DateTime(value.Value.Ticks, DateTimeKind.Utc);
                }
                else
                {
                    _createdDate = value;
                }
            }
        }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}"), Editable(false)]
        private DateTime? _modifiedDate;

        [Editable(false)]
        public DateTime? ModifiedDate
        {
            get { return _modifiedDate; }
            set
            {
                if (value != null)
                {
                    _modifiedDate = new DateTime(value.Value.Ticks, DateTimeKind.Utc);
                }
                else
                {
                    _modifiedDate = value;
                }
            }
        }

        [DisplayFormat(NullDisplayText = ""), Editable(false), StringLength(50)]
        public virtual String ModifiedBy { get; set; }
        
        public virtual Boolean IsActive { get; set; }
    }
}
