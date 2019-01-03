using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class Pets
    {
        public Pets()
        {
            PetStatus = new HashSet<PetStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int AnimalTypeId { get; set; }
        public int AnimalSubTypeId { get; set; }

        public virtual AnimalSubTypes AnimalSubType { get; set; }
        public virtual AnimalTypes AnimalType { get; set; }
        public virtual Owners Owner { get; set; }
        public virtual ICollection<PetStatus> PetStatus { get; set; }
    }
}
