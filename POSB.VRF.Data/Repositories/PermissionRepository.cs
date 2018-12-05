﻿using POSB.VRF.Domain.IRepositories;
using POSB.VRF.Domain.Models;
using System.Data.Entity;
using System.Linq;

namespace POSB.VRF.Data.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(VRFContext context) : base(context)
        {

        }

        public VRFContext VRFContext
        {
            get { return Context as VRFContext; }
        }
    }
}
