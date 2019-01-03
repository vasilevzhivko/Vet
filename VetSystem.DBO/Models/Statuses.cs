using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            PetStatus = new HashSet<PetStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PetStatus> PetStatus { get; set; }
    }
}
