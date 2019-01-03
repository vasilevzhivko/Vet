using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class DoctorSpecialtiesDoctors
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DoctorSpecialtiesId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual DoctorSpecialties DoctorSpecialties { get; set; }
    }
}
