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
    public class PrescribeController : ControllerBase
    {
        private readonly IMedLabPresc _medlabRepository;

        //constructor injection
        public PrescribeController(IMedLabPresc medlabRepository)
        {
            _medlabRepository = medlabRepository;
        }

        #region Medicine Prescription
        [HttpPost]
        [Route("medicine")]
        public async Task<IActionResult> PrescribeMed([FromBody] Medicines med)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.PrescribeMed(med);
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

        #region Lab Test Prescription
        [HttpPost]
        [Route("labtest")]
        public async Task<IActionResult> AddCategory([FromBody] Tests test)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = await _medlabRepository.PrescribeLabTests(test);
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

    }
}
