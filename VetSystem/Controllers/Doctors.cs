using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using VetSystem.DBO.Models;
using VetSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VetSystem.Controllers
{
    public class Doctors : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string searchString, string phoneFilter, string emailFilter)
        {
            ViewBag.CurrentFilter = searchString;
            ViewBag.PhoneFilter = phoneFilter;
            ViewBag.EmailFilter = emailFilter;


            using (var context = new VetSystemContext())
            {
                var docs = context.Doctors.Where(s => s.Name != null);

                if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(phoneFilter) || !String.IsNullOrEmpty(emailFilter))
                {
                    docs = context.Doctors.Where(s => s.Name == searchString || s.Phone == phoneFilter || s.Email == emailFilter);
                }
                return View(docs.ToPagedList(1, 100));
            }
        }

        public IActionResult Details(int? id)
        {
            List<DoctorSpecialties> doctorSpecialties = new List<DoctorSpecialties>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var context = new VetSystemContext())
            {
                var doc = context.Doctors.Where(s => s.Id == id).FirstOrDefault();
                if (doc == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var departments = context.DoctorSpecialtiesDoctors.Where(x => x.DoctorId == id);

                foreach (var item in departments)
                {
                    var findName = context.DoctorSpecialties.Where(x => x.Id == item.DoctorSpecialtiesId).FirstOrDefault();
                    doctorSpecialties.Add(findName);
                }

                

                DoctorDetailsModel ddm = new DoctorDetailsModel
                {
                    Name = doc.Name,
                    Departments = doctorSpecialties
                };
                return View(ddm);
            }
        }
    }
}
