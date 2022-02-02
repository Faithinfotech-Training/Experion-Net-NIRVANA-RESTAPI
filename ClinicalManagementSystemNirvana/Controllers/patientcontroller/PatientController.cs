using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatient _patient;
        public PatientController(IPatient patient)
        {
            _patient = patient;
        }
        #region add patient
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Patients patients)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var id = await _patient.AddPatient(patients);
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
        #region Get All patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patients>>> GetAllPatient()
        {
            return await _patient.GetAllPatient();
        }
        #endregion
        #region updatepatient
        public async Task<IActionResult> UpdatePatient([FromBody] Patients patients)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _patient.UpdatePatient(patients);
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
        #region delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _patient.DeletePatient(id);
                if (result == 0)
                {
                    return NotFound();

                }
                return Ok(); //return Ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        #region get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Patients>> GetPatientById(int? id)
        {
            try
            {
                var patient = await _patient.GetPatientById(id);
                if (patient == null)
                {
                    return NotFound();

                }
                return patient; //return Ok(employee)
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }

}
