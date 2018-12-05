using POSB.VRF.Data.Repositories;
using POSB.VRF.Domain;
using POSB.VRF.Domain.IRepositories;


namespace POSB.VRF.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VRFContext _context;

        public UnitOfWork(VRFContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            VisitorTypes = new VisitorTypeRepository(_context);
            VisitorRequestForms = new VisitorRequestFormRepository(_context);
            Permissions = new PermissionRepository(_context);
            Roles = new RoleRepository(_context); 
        }

        public IUserRepository Users { get; set; }
        public IVisitorTypeRepository VisitorTypes { get; set; }
        public IVisitorRequestFormRepository VisitorRequestForms { get; set; }
        public IPermissionRepository Permissions { get; set; }
        public IRoleRepository Roles { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
