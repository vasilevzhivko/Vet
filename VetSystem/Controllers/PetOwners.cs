using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using VetSystem.DBO.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VetSystem.Controllers
{
    public class PetOwners : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            using (var context = new VetSystemContext())
            {
                var petOwner = context.Owners;

                return View(petOwner.ToPagedList(1,3));
            }
        }
    }
}
