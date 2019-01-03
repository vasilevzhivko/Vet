using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class DoctorSpecialties
    {
        public DoctorSpecialties()
        {
            DoctorSpecialtiesDoctors = new HashSet<DoctorSpecialtiesDoctors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DoctorSpecialtiesDoctors> DoctorSpecialtiesDoctors { get; set; }
    }
}
