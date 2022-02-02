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

        //ADD MEDICINE and LAB TESTS
        #region ADD MEDICINE and LAB TESTS
        public async Task<int> AddMedicine(MedicineInventory medInv)
        {
            if (_context != null)
            {
                await _context.MedicineInventory.AddAsync(medInv);
                await _context.SaveChangesAsync();
                return medInv.MedInvId;
            }
            return 0;
        }
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

        //DELETE MEDICINE and LAB TESTS
        #region DELETE MEDICINE and LAB TESTS
        public async Task<int> DeleteMedicine(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var medc = await _context.MedicineInventory.FirstOrDefaultAsync(med => med.MedInvId == id);

                //check condition
                if (medc != null)
                {
                    _context.MedicineInventory.Remove(medc);

                    //commit the trancsaction
                    result = await _context.SaveChangesAsync();
                }

                return result;
            }
            return result;
        }
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

        //GET ALL MEDICINE and LAB TESTS
        #region GET ALL MEDICINE and LAB TESTS
        public async Task<List<MedicineInventory>> GetAllMedicines()
        {
            if (_context != null)
            {
                return await _context.MedicineInventory.ToListAsync();
            }
            return null;
        }
        public async Task<List<LabTests>> GetAllLabTests()
        {
            if (_context != null)
            {
                return await _context.LabTests.ToListAsync();
            }
            return null;
        }
        #endregion

        //GET MEDICINE and LAB TESTS BY ID
        #region GET MEDICINE and LAB TESTS BY ID
        public async Task<ActionResult<MedicineInventory>> GetMedicineId(int id)
        {
            if (_context != null)
            {
                var medc = await _context.MedicineInventory.FindAsync(id);// concentrating on primary key
                return medc;
            }
            return null;
        }
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

        //UPDATE MEDICINE and LAB TESTS
        #region UPDATE MEDICINE and LAB TESTS
        public async Task UpdateMedicine(MedicineInventory medInv)
        {
            if (_context != null)
            {
                _context.Entry(medInv).State = EntityState.Modified;
                _context.MedicineInventory.Update(medInv);
                await _context.SaveChangesAsync(); //Commit the transaction
            }
        }
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
