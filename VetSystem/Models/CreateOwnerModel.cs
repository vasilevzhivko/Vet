using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetSystem.DBO.Models;

namespace VetSystem.Models
{
    public class CreateOwnerModel
    {
        public CreateOwnerModel()
        {
           // var context = new VetSystemContext();
           // AnimalSubTypes = context.AnimalSubTypes.Where(x => x.Name != null);
          //  AnimalTypes = context.AnimalTypes.Where(x => x.Name != null);
        }
            
           
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<SelectListItem> GetAllAnimalSubTypes()
        {
            var context = new VetSystemContext();
            var AnimalSubTypes = context.AnimalSubTypes.Where(x => x.Name != null);
            foreach (var item in AnimalSubTypes)
            {
                yield return new SelectListItem { Text = item.Name, Value = item.Id.ToString() };

            }
        }

        public IEnumerable<SelectListItem> GetAllAnimalTypes()
        {
            var context = new VetSystemContext();
            var AnimalTypes = context.AnimalTypes.Where(x => x.Name != null);
            foreach (var item in AnimalTypes)
            {
                yield return new SelectListItem { Text = item.Name, Value = item.Id.ToString() };

            }
        }

        public string AnimalType { get; set; }

        public string AnimalSubType { get; set; }

        public string AnimalName { get; set; }

    }
}
