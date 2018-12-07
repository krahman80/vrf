using POSB.VRF.Domain.IRepositories;
using POSB.VRF.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace POSB.VRF.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(VRFContext context) : base(context)
        {

        }

        public IEnumerable<Permission> GetPermissionsByRole(int RoleId)
        {
            return VRFContext.Permissions
                .Where(x => x.Roles.Any(r => r.Id == RoleId))
                .ToList();
        }

        public VRFContext VRFContext
        {
            get { return Context as VRFContext; }
        }
    }
}
