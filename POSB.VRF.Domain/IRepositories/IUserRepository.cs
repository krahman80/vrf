using POSB.VRF.Domain.Models;
using System.Collections.Generic;

namespace POSB.VRF.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRole(int id);
        IEnumerable<User> GetUsersWithRole();
    }
}
