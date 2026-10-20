using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBasicSchoolManagement.Controllers
{
    public class StudentController : Controller
    {

        private AppDbContext _db = new AppDbContext();

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Index()
        {
            var data = _db.YourTableName.ToList();
            return View(data);
        }
    }
}