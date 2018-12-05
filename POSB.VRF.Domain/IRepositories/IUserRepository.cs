using POSB.VRF.Domain.Models;

namespace POSB.VRF.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithRole(int id);
    }
}
