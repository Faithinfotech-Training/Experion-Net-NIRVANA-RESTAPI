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
    }
}
