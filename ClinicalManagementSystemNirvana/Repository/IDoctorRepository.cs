using ClinicalManagementSystemNirvana.View_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalManagementSystemNirvana.Repository
{
    public interface IDoctorRepository
    {
        Task<List<DoctorViewModel>> GetAllDoctorAndTokens(int id);

        Task<List<DoctorListViewModel>> GetDoctorList();

        Task<List<DoctorViewModel>> GetAppbyId(int id);

    }
}
