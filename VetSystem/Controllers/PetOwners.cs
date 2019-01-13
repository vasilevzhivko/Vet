using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList;
using VetSystem.DBO.Models;
using Newtonsoft.Json;
using VetSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VetSystem.Controllers
{
    public class PetOwners : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string searchString, string phoneFilter, string emailFilter)
        {
            ViewBag.CurrentFilter = searchString;
            ViewBag.PhoneFilter = phoneFilter;
            ViewBag.EmailFilter = emailFilter;


            using (var context = new VetSystemContext())
            {
                var petOwner = context.Owners.Where(s => s.Name != null);

                if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(phoneFilter) || !String.IsNullOrEmpty(emailFilter))
                {
                    petOwner = context.Owners.Where(s => s.Name == searchString || s.Phone == phoneFilter || s.Email == emailFilter);
                }
                return View(petOwner.ToPagedList(1, 100));
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new VetSystemContext())
            {
                var petOwner = context.Owners.Where(s => s.Id == id).FirstOrDefault();
                if (petOwner == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View(petOwner);
            }
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(int? id, string name, string email, string phone)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new VetSystemContext())
            {
                var petOwner = context.Owners.Where(s => s.Id == id).FirstOrDefault();
                if (petOwner == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                try
                {
                    petOwner.Name = name;
                    petOwner.Email = email;
                    petOwner.Phone = phone;
                    context.SaveChanges();
                }
                catch
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                return View(petOwner);
            }      
        }

        public IActionResult Create()
        {
            CreateOwnerModel cm = new CreateOwnerModel();
            var context = new VetSystemContext();
            List<SelectListItem> li = new List<SelectListItem>();
            var test = context.AnimalTypes.Where(x => x.Id !=null).ToList();
            foreach (var item in test)
            {
                li.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewData["animalTypes"] = li;
            return View(cm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name, Email, Phone, Password, AnimalType, AnimalSubType, AnimalName")]CreateOwnerModel customer)
        {
            CreateOwnerModel cm = new CreateOwnerModel();
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }
            try
            {
                Owners o = new Owners();
                o.Name = customer.Name;
                o.Password = customer.Password;
                o.Email = customer.Email;
                o.Phone = customer.Phone;

                using (var context = new VetSystemContext())
                {
                    context.Owners.Add(o);
                    context.SaveChanges();

                    Pets pet = new Pets
                    {
                        Name = customer.AnimalName,
                        OwnerId = o.Id,
                        AnimalSubTypeId = int.Parse(customer.AnimalSubType),
                        AnimalTypeId = int.Parse(customer.AnimalType)
                    };

                    context.Pets.Add(pet);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(cm);
        }


        public IActionResult AddPet(int? id)
        {
            if (id == null)
            {

            }
            else
            {
                PopulateOwners(id);
                PopulateAnimalTypes();
                PopulateAnimalSubTypes();
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPet(int? id,[Bind("Name, Email, Phone, Password")]Owners owner)
        {
            PopulateOwners(id);
            PopulateAnimalTypes();
            PopulateAnimalSubTypes();
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            try
            {
                using (var context = new VetSystemContext())
                {
                    context.Owners.Add(owner);
                    context.SaveChanges();
                }
            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        private void PopulateOwners(int? id)
        {
            var context = new VetSystemContext();
            var petOwner = context.Owners.Where(s => s.Id == id);
            ViewBag.OwnerId = new SelectList(petOwner, "Id", "Name");
        }

        private void PopulateAnimalSubTypes()
        {
            var context = new VetSystemContext();
            var animalSubTypes = context.AnimalSubTypes.Where(s => s.ParentAnimal != null);
            ViewBag.AnimalSubTypeId = new SelectList(animalSubTypes, "Id", "Name");
        }

        private void PopulateAnimalTypes()
        {
            var context = new VetSystemContext();
            var animalSubTypes = context.AnimalTypes.Where(s => s.Name != null);
            ViewBag.AnimalTypeId = new SelectList(animalSubTypes, "Id", "Name");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Action(AnimalTypes at)
        {
            
            return View();
        }

        public JsonResult AnimalList(int id)
        {
            var context = new VetSystemContext();
            List<SelectListItem> li = new List<SelectListItem>();
            var test = context.AnimalTypes.Where(x => x.Id == id).ToList();
            foreach (var item in test)
            {
                li.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            return Json(li);
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new VetSystemContext())
            {
                var petOwner = context.Owners.Where(s => s.Id == id).FirstOrDefault();
                if (petOwner == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var pets = context.Pets.Where(p => p.OwnerId == id).ToList();

                PetOwnerModel pom = new PetOwnerModel
                {
                    Name = petOwner.Name,
                    Pets = pets                    
                };
                return View(pom);
            }
        }
    }
}
