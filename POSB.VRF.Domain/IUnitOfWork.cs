using POSB.VRF.Domain.IRepositories;
using System;

namespace POSB.VRF.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        int Complete();
    }
}
