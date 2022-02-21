using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClinicalManagementSystemNirvana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        //data fields
        private readonly IStaffRepository _staffRepository;
        private readonly IConfiguration _config;

        //constructor injection
        public StaffController(IConfiguration config,IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
            _config = config;
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
        public async Task<IActionResult> DeleteStaff(int? id)
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

      


        #region  Get Staff By Username Password 
        [HttpGet("login/{un}&{pw}")]
        [AllowAnonymous]
        

        public async Task<IActionResult> GetStaffByUsernamePassword(string un, string pw)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credential
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            //generate token
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            expires: DateTime.Now.AddMinutes(20),
            signingCredentials: credentials);
            var response = Ok(new { token = ' ',Staffs= ' ' });
            if (ModelState.IsValid)
            {
                try
                {
                    var tokens = new JwtSecurityTokenHandler().WriteToken(token);
                    var user = await _staffRepository.GetStaffByUsernamePassword(un, pw);
                    response = Ok(new
                    {
                        token = tokens,
                        Name = user.StaffName,
                        RoleId = user.RoleId,
                        StaffId = user.StaffId

                    });
                    return response;
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

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
