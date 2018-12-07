using POSB.VRF.Domain.Models;
using System.Collections.Generic;

namespace POSB.VRF.Domain.IRepositories
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        IEnumerable<Permission> GetPermissionsByRole(int RoleId);
    }
}
