using ClinicalManagementSystemNirvana.Repository;
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




        #region  list doctor view model
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

    }
}
