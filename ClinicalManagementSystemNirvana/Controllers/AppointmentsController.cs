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
    public class AppointmentsController : ControllerBase
    {
        //data fields
        private readonly IAppointmentRepository _appointmentRepository;

        //constructor injection
        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }



        #region getallappointments
        [HttpGet]
        [Route("getallappointments")]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllAppointments();

                if (appointments == null)
                {
                    return NotFound();
                }
                return Ok(appointments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region  get all DoctorAndAppointments 
        //api/appointments/doctor
        [HttpGet]
        [Route("tokencount")]
        public async Task<IActionResult> GetAllDoctorAndAppointments()
        {
            try
            {
                var appointments = await _appointmentRepository.GetAllDoctorAndAppointments();

                if (appointments == null)
                {
                    return NotFound();
                }
                return Ok(appointments);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
