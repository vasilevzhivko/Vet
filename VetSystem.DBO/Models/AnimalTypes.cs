using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class AnimalTypes
    {
        public AnimalTypes()
        {
            AnimalSubTypes = new HashSet<AnimalSubTypes>();
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AnimalSubTypes> AnimalSubTypes { get; set; }
        public virtual ICollection<Pets> Pets { get; set; }
    }
}
