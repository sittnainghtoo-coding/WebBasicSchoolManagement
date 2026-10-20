using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchtoolManagement.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;

        public StudentController(AppDbContext db)
        {
            _db = db;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            List<TblStudent> students = await _db.TblStudents.ToListAsync();
           
            return View(students);
        }

        [ActionName("Details")]

        public IActionResult Details(string id)
		{
			var student = _db.TblStudents.FirstOrDefault(s => s.StdId == id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}
	}
}
