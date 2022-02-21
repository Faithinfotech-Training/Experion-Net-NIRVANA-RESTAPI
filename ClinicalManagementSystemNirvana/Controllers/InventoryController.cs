using ClinicalManagementSystemNirvana.Models;
using ClinicalManagementSystemNirvana.Repository;
using Microsoft.AspNetCore.Authorization;
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
    public class InventoryController : ControllerBase
    {
        //Data fields
        private readonly IInventory _inventory;

        //Constructor injection
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }

        //All  Labtests
        #region Get All  Labtests
        [HttpGet]
        [Route("getalllabtests")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LabTests>>> GetAllLabTests()
        {
            return await _inventory.GetAllLabTests();
        }
        #endregion

        //Add Labtests
        #region Add  Labtests
        
        [HttpPost]
        [Route("labtest")]
        [Authorize]
        public async Task<IActionResult> AddLabTests([FromBody] LabTests labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var labId = await _inventory.AddLabTests(labInv);
                    if (labId > 0)
                    {
                        return Ok(labId);
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

        //Update  Labtests
        #region Update Labtests
        
        [HttpPut]
        [Route("labtest")]
        [Authorize]
        public async Task<IActionResult> UpdateLabTests([FromBody] LabTests labInv)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.UpdateLabTests(labInv);
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

        //Find Labtests
        #region Find  LabTests
        
        [HttpGet("labtest/{id}")]
        [Authorize]
        public async Task<ActionResult<LabTests>> GetLabTestsById(int id)
        {
            try
            {
                var labt = await _inventory.GetLabTestsById(id);
                if (labt == null)
                {
                    return NotFound();
                }
                return labt;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Delete  Labtests
        #region Delete Labtests
       
        [HttpDelete("labtest/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteLabTests(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _inventory.DeleteLabTests(id);
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

    }
}
