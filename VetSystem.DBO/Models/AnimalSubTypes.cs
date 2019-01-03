using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class AnimalSubTypes
    {
        public AnimalSubTypes()
        {
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentAnimal { get; set; }

        public virtual AnimalTypes ParentAnimalNavigation { get; set; }
        public virtual ICollection<Pets> Pets { get; set; }
    }
}
