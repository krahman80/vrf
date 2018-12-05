using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace POSB.VRF.Domain.Models
{
    public class VisitorRequestForm : BaseEntity, IModel
    {
        [DisplayName("Visitor Name")]
        
        public string VisitorName { get; set; }

        [DisplayName("Visitor Email")]
        public string VisitorEmail { get; set; }

        [DisplayName("Visitor Phone")]
        public string VisitorPhone { get; set; }

        [DisplayName("Visitor Type Id")]
        public int VisitorTypeId { get; set; }

        [DisplayName("Visitor Type")]
        public virtual VisitorType VisitorTypes { get; set; }

        [DisplayName("Visitor Company")]
        public string VisitorCompany { get; set; }

        [DisplayName("Visit Purpose")]
        public string VisitPurpose { get; set; }

        [DisplayName("Visit Destination")]
        public string VisitDestination { get; set; }

        [DisplayName("Visit Start Date")]
        public DateTime VisitStartDate { get; set; }

        [DisplayName("Visit End Date")]
        public DateTime VisitEndDate { get; set; }

        [DisplayName("Visit Duration")]
        public string VisitDuration { get; set; }

        [DisplayName("Visitor ID")]
        public string VisitorIDUpload { get; set; }

        [DisplayName("Sponsor Name")]
        public string SponsorName { get; set; }

        [DisplayName("Sponsor Email")]
        public string SponsorEmail { get; set; }
    }
}
