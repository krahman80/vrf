using POSB.VRF.Domain.IRepositories;
using POSB.VRF.Domain.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace POSB.VRF.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(VRFContext context) : base(context)
        {
        }

        public User GetUserWithRole(int id)
        {
            return VRFContext.Users.Include(u => u.Roles).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsersWithRole()
        {
            return VRFContext.Users
                .Include(c => c.Roles)
                .OrderBy(c => c.Login)
                .ToList();
        }

        public VRFContext VRFContext
        {
            get { return Context as VRFContext; }
        }

    }
    
}
