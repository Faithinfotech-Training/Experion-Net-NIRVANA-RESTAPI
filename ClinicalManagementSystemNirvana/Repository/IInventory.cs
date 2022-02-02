using ClinicalManagementSystemNirvana.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IInventory
    {

        //Get All Medicine and Lab Tests  ----SELECT ----RETRIEVE
        Task<List<MedicineInventory>> GetAllMedicines();
        Task<List<LabTests>> GetAllLabTests();

        //Add Medicine and Lab Tests ----INSERT ----CREATE
        Task<int> AddMedicine(MedicineInventory medInv);
        Task<int> AddLabTests(LabTests labId);

        //update Medicine and Lab Tests ----UPDATE ---UPDATE
        Task UpdateMedicine(MedicineInventory medInv);
        Task UpdateLabTests(LabTests labId);

        //Find Medicine and Lab Tests by  Id
        Task<ActionResult<MedicineInventory>> GetMedicineId(int id);
        Task<ActionResult<LabTests>> GetLabTestsById(int id);

        //Delete a Medicine and Lab Tests
        Task<int> DeleteMedicine(int? id);
        Task<int> DeleteLabTests(int? id);
      
    }
}
