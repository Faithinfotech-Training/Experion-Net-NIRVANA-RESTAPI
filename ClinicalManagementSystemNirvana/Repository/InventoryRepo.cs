using ClinicalManagementSystemNirvana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public class InventoryRepo : IInventory
    {

        private readonly CMSDBContext _context;

        public InventoryRepo(CMSDBContext context)
        {
            _context = context;
        }

        //ADD  LAB TESTS
        #region ADD LAB TESTS
       
        public async Task<int> AddLabTests(LabTests labId)
        {
            if (_context != null)
            {
                await _context.LabTests.AddAsync(labId);
                await _context.SaveChangesAsync();
                return labId.LabTestId;
            }
            return 0;
        }
        #endregion

        //DELETE  LAB TESTS
        #region DELETE LAB TESTS
        
        public async Task<int> DeleteLabTests(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var labt = await _context.LabTests.FirstOrDefaultAsync(lab => lab.LabTestId == id);

                //check condition
                if (labt != null)
                {
                    _context.LabTests.Remove(labt);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }

        #endregion

        //GET ALL  LAB TESTS
        #region GET ALL LAB TESTS
       
        public async Task<List<LabTests>> GetAllLabTests()
        {
            if (_context != null)
            {
                return await _context.LabTests.ToListAsync();
            }
            return null;
        }
        #endregion

        //GET  LAB TESTS BY ID
        #region GET LAB TESTS BY ID
      
        public async Task<ActionResult<LabTests>> GetLabTestsById(int id)
        {
            if (_context != null)
            {
                var labt = await _context.LabTests.FindAsync(id);// concentrating on primary key
                return labt;
            }
            return null;
        }
        #endregion

        //UPDATE  LAB TESTS
        #region UPDATE  LAB TESTS
       
        public async Task UpdateLabTests(LabTests labId)
        {
            if (_context != null)
            {
                _context.Entry(labId).State = EntityState.Modified;
                _context.LabTests.Update(labId);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }
        #endregion

    }
}
