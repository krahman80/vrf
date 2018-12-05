using POSB.VRF.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace POSB.VRF.Data.EntityConfigurations
{
    public class VisitorRequestFormConfiguration : EntityTypeConfiguration<VisitorRequestForm>
    {

        public VisitorRequestFormConfiguration ()
	    {

            Property(v => v.VisitorName)
                .IsRequired()
                .HasMaxLength(50);

            Property(v => v.VisitorEmail)
                .IsRequired()
                .HasMaxLength(70);

            Property(v => v.VisitorPhone)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.VisitorCompany)
                .IsOptional()
                .HasMaxLength(50);

            Property(c => c.VisitPurpose)
                .IsOptional()
                .HasMaxLength(255);

            Property(c => c.VisitDestination)
                .IsOptional()
                .HasMaxLength(100);

            Property(c => c.SponsorName)
                .IsOptional()
                .HasMaxLength(50);

            Property(c => c.SponsorEmail)
                .IsOptional()
                .HasMaxLength(70);

            HasRequired(vt => vt.VisitorTypes)
                .WithMany(v => v.VisitorRequestForms)
                .HasForeignKey(vt => vt.VisitorTypeId)
                .WillCascadeOnDelete(false);
	    }

        
    }
}
