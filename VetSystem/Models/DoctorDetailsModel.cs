using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetSystem.DBO.Models;

namespace VetSystem.Models
{
    public class DoctorDetailsModel
    {
        public string Name { get; set; }

        public List<DoctorSpecialties> Departments { get; set; }
    }
}
