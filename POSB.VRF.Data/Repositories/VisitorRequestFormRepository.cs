using POSB.VRF.Domain.IRepositories;
using POSB.VRF.Domain.Models;
using System.Data.Entity;
using System.Linq;


namespace POSB.VRF.Data.Repositories
{
    public class VisitorRequestFormRepository : Repository<VisitorRequestForm>, IVisitorRequestFormRepository
    {
        public VisitorRequestFormRepository(VRFContext context)
            : base(context)
        {
        }

        public VRFContext VRFContext
        {
            get { return Context as VRFContext; }
        }
    }
}
