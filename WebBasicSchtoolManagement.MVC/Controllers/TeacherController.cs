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

			return View("Index", _teacher);
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

		[ActionName("Edit")]

		public async Task<IActionResult> Edit(string id)
		{
			var teacher = await _db.TblTeachers.FirstOrDefaultAsync(t => t.TecId == id);
			if (teacher == null)
			{
				RedirectToAction("Index");
			}
			var model = new TeacherViewModel.TeacherVM
			{
				Id = id,
				Name = teacher.TecName,
				Subjects = await _teacherViewModel.GetSubjects(),
			};
			return View("Edit", model);
		}

		[ActionName("Update")]

		public async Task<IActionResult> Update(string id, TeacherViewModel.TeacherVM requestModel)
		{
			var teacher = await _db.TblTeachers.FirstOrDefaultAsync(t => t.TecId == id);
			if (teacher == null)
			{
				RedirectToAction("Index");
			}
			teacher.TecId = id;
			teacher.TecName = requestModel.Name;
			teacher.SubId = requestModel.SelectedItem;
			await _db.SaveChangesAsync();
			return RedirectToAction("Index");

		}
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var teacher = await _db.TblTeachers
                .FirstOrDefaultAsync(t => t.TecId == id);

            if (teacher == null)
            {
                return NotFound();
            }

            _db.TblTeachers.Remove(teacher);

            int result = await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
