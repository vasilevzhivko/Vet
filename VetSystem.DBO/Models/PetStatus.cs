using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class PetStatus
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int StatusId { get; set; }
        public int DoctorId { get; set; }

        public virtual Doctors Doctor { get; set; }
        public virtual Pets Pet { get; set; }
        public virtual Statuses Status { get; set; }
    }
}
