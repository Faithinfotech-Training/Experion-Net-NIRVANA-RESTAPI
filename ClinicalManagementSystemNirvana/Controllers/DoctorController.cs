using ClinicalManagementSystemNirvana.Repository;
using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        //data fields
        private readonly IDoctorRepository _doctorRepository;

        //constructor injection
        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }




        #region Get appointment List By doctor ID 
        //api/appointments/doctor
        [HttpGet]
        [Route("appointments/{id}")]
        public async Task<IActionResult> GetAllDoctorAndTokens(int id)
        {
            try
            {
                var tokens = await _doctorRepository.GetAllDoctorAndTokens(id);

                if (tokens == null)
                {
                    return NotFound();
                }
                return Ok(tokens);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //api/appointments/doctor
        #region Appointment by ID
        [HttpGet]
        [Route("appointment/{id}")]
        public async Task<IActionResult> GetAppById(int id)
        {
            try
            {
                var tokens = await _doctorRepository.GetAppbyId(id);

                if (tokens == null)
                {
                    return NotFound();
                }
                return Ok(tokens);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region getdoctorList
        [HttpGet]
        [Route("doctors")]
        public async Task<ActionResult<IEnumerable<DoctorListViewModel>>> GetDoctorList()
        {
            return await _doctorRepository.GetDoctorList();
        }
        #endregion

    }
}
