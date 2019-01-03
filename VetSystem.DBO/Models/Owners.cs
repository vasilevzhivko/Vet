using System;
using System.Collections.Generic;

namespace VetSystem.DBO.Models
{
    public partial class Owners
    {
        public Owners()
        {
            Pets = new HashSet<Pets>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Pets> Pets { get; set; }
    }
}
