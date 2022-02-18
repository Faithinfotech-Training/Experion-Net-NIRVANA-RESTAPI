using ClinicalManagementSystemNirvana.Models;
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
        [Route("get")]
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
        
        #region add patient
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Appointments appointments)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _appointmentRepository.AddAppointment(appointments);
                    if (id > 0)
                    {
                        return Ok(id);
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

        #region updateappointment
        public async Task<IActionResult> UpdateAppointment([FromBody] Appointments appointments)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _appointmentRepository.UpdateApppointment(appointments);
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

        #region Get All appiontment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointments>>> GetAppointments()
        {
            return await _appointmentRepository.GetAppointments();
        }
        #endregion

        #region get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointments>> GetAppointmentById(int? id)
        {
            try
            {
                var appointment = await _appointmentRepository.GetAppointmentById(id);
                if (appointment == null)
                {
                    return NotFound();

                }
                return appointment; //return Ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


    }
}
