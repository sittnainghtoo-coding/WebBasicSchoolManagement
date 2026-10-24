using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBasicSchoolManagement.Database.AppDbContextModels;
using WebBasicSchtoolManagement.MVC.Models;

namespace WebBasicSchtoolManagement.MVC.Controllers
{
	public class TeacherController : Controller
	{
		private readonly AppDbContext _db;
		private readonly TeacherViewModel _teacherViewModel;

		public TeacherController(AppDbContext db, TeacherViewModel teacherViewModel)
		{
			_db = db;
			_teacherViewModel = teacherViewModel;
		}
		[ActionName("Index")]
		public async Task<IActionResult> Index()
		{
			var _teacher = await _teacherViewModel.GetAll();
			
			return View("Index",_teacher);
		}

		[ActionName("Add")]
		public async Task<IActionResult> Add()
		{
			TeacherViewModel.TeacherVM model = new TeacherViewModel.TeacherVM();
			model.Subjects = await _teacherViewModel.GetSubjects();
			return View(model);
        }

		[ActionName("Save")]
		public async Task<IActionResult> Save(TeacherViewModel.TeacherVM requestModel)
        {
			

            TblTeacher teacher = new TblTeacher
            {
                TecId = Guid.NewGuid().ToString().Substring(0, 8),
                TecName = requestModel.Name,
                SubId = requestModel.SelectedItem
            };
            _db.TblTeachers.Add(teacher);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


    }
}
