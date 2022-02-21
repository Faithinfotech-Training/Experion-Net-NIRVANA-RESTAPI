using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<Roles>>> GetDepartmentALL()
        {
            return await _roleRepository.GetAllRoles();
        }
        #endregion

        #region Add Department
        [HttpPost]
        [Route("adddepartment")]
        [Authorize]
        public async Task<IActionResult> AddUser([FromBody] Roles role)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    var Id = await _roleRepository.AddRole(role);
                    if (Id > 0)
                    {
                        return Ok(Id);

                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }
        #endregion

        #region UpdateRole
        [HttpPut]
        [Route("updatedepartment")]
        [Authorize]
        public async Task<IActionResult> UpdateRole([FromBody] Roles role)
        {
            //check the validation of body
            if (ModelState.IsValid)

            {
                try
                {
                    await _roleRepository.UpdateRole(role);

                    return Ok();

                }
                catch (Exception)
                {
                    return BadRequest();
                }


            }
            return BadRequest();
        }
        #endregion

        #region Find Role By Id
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Roles>> GetRoleId(int id)
        {
            try
            {
                var roles = await _roleRepository.GetRoleById(id);
                if (roles == null)
                {
                    return NotFound();
                }
                return roles;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
