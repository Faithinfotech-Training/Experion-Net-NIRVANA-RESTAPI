using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class RolesRepository : IRoleRepository
    {
        private readonly CMSDBContext _context;

        public RolesRepository(CMSDBContext context)
        {
            _context = context;
        }
        public async Task<List<Roles>> GetAllRoles()
        {
            if (_context != null)
            {
                return await _context.Roles.ToListAsync();
            }
            return null;
        }
    }
}
