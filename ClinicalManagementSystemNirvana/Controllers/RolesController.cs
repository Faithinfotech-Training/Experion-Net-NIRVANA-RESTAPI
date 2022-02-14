using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicalManagementSystemNirvana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        //data fields
        private readonly IRoleRepository _roleRepository;

        //constructor injection
        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        #region Get All Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetDepartmentALL()
        {
            return await _roleRepository.GetAllRoles();
        }
        #endregion
    }
}
