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

        public async Task<int> AddRole(Roles roles)
        {
            if (_context != null)
            {
                await _context.Roles.AddAsync(roles);
                await _context.SaveChangesAsync();
                return roles.RoleId;
            }
            return 0;
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            if (_context != null)
            {
                return await _context.Roles.ToListAsync();
            }
            return null;
        }

        public async Task<Roles> GetRoleById(int roleId)
        {
            if (_context != null)
            {
                var staff = await _context.Roles.FindAsync(roleId);// concentrating on primary key
                return staff;
            }
            return null;
        }

        //UpdateRole
        public async Task UpdateRole(Roles roles)
        {
            if (_context != null)
            {
                _context.Entry(roles).State = EntityState.Modified;
                _context.Roles.Update(roles);

                await _context.SaveChangesAsync();
            }
        }
    }
}
