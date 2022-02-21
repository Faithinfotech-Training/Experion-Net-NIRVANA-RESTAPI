using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IRoleRepository
    {
        Task<List<Roles>> GetAllRoles();

        //add roles
        Task<int> AddRole(Roles roles);

        //update Role
        Task UpdateRole(Roles roles);

        //get role by Id 
        Task<Roles> GetRoleById(int roleId);

    }
}
