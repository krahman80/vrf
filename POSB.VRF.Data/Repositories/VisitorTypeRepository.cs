using POSB.VRF.Domain.IRepositories;
using POSB.VRF.Domain.Models;
using System.Data.Entity;
using System.Linq;


namespace POSB.VRF.Data.Repositories
{
    public class VisitorTypeRepository : Repository<VisitorType>, IVisitorTypeRepository
    {
        public VisitorTypeRepository(VRFContext context)
            : base(context)
        {
        }

        public VRFContext VRFContext
        {
            get { return Context as VRFContext; }
        }
    }
}
