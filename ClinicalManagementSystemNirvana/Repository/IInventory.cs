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

        //Get All Lab Tests  ----SELECT ----RETRIEVE
        
        Task<List<LabTests>> GetAllLabTests();

        //Add Lab Tests ----INSERT ----CREATE
        
        Task<int> AddLabTests(LabTests labId);

        //update  Lab Tests ----UPDATE ---UPDATE
        
        Task UpdateLabTests(LabTests labId);

        //Find Lab Tests by  Id
      
        Task<ActionResult<LabTests>> GetLabTestsById(int id);

        //Delete a Lab Tests
       
        Task<int> DeleteLabTests(int? id);
      
    }
}
