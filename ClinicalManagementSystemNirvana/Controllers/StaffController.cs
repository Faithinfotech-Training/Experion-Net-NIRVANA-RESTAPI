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
    public class StaffController : ControllerBase
    {
        //data fields
        private readonly IStaffRepository _staffRepository;

        //constructor injection
        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        #region Get All Staff
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staffs>>> GetStaffs()
        {
            return await _staffRepository.GetAllstaff();
        }
        #endregion

        #region Add staff
        [HttpPost]
        [Route("addstaff")]
        public async Task<IActionResult> AddStaff([FromBody] Staffs staffs)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var staffId = await _staffRepository.AddStaff(staffs);
                    if (staffId > 0)
                    {
                        return Ok(staffId);
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

        #region Update STaff
        [HttpPut]
        public async Task<IActionResult> UpdateStaff([FromBody] Staffs staffs)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _staffRepository.UpdateStaff(staffs);
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

        #region Find Staff
        [HttpGet("{id}")]
        public async Task<ActionResult<Staffs>> GetStaffId(int id)
        {
            try
            {
                var staff = await _staffRepository.GetStaffId(id);
                if (staff == null)
                {
                    return NotFound();
                }
                return staff;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete Staff
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _staffRepository.DeleteStaff(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Search Staff using username and password
        [HttpGet("{search}/{name}&{password}")]
        public async Task<ActionResult<IEnumerable<Staffs>>> GetStaffByNameandPassword(string name, string password)
        {
            try
            {
                var result = await _staffRepository.GetStaffByNameandPassword(name, password);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region GetAll Post ViewModel
        [HttpGet]
        [Route("GetStaffsAll")]
        public async Task<IActionResult> GetAllStaff()
        {
            try
            {
                var posts = await _staffRepository.GetAllStaff();
                if (posts == null)
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
