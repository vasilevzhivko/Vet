using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class Doctors
    {
        public Doctors()
        {
            DoctorSpecialtiesDoctors = new HashSet<DoctorSpecialtiesDoctors>();
            PetStatus = new HashSet<PetStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<DoctorSpecialtiesDoctors> DoctorSpecialtiesDoctors { get; set; }
        public virtual ICollection<PetStatus> PetStatus { get; set; }
    }
}
