using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetSystem.DBO.Models;

namespace VetSystem.Models
{
    public class PetOwnerModel
    {
        public string Name { get; set; }

        public virtual ICollection<Pets> Pets { get; set; }
    }
}
