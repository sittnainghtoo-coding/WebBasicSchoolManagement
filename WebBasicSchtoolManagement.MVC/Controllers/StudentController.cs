using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBasicSchoolManagement.BusinessLogic;
using WebBasicSchoolManagement.Database.AppDbContextModels;
using WebBasicSchtoolManagement.MVC.Models;

namespace WebBasicSchtoolManagement.MVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAll();

            return View(students);
        }

	
		[ActionName("Add")]
		public async Task<IActionResult> Add()
		{
            return View("Add");
		}

        [ActionName("Save")]
        public async Task<IActionResult> Save(StudentRequestModel requestModel)
        {
            await _studentService.AddStudentAsync(new TblStudent
			{
				StdId = Guid.NewGuid().ToString().Substring(0,10),
				StdName = requestModel.StdName,
				FatherName = requestModel.FatherName,
				StdAge = requestModel.StdAge,
				Dob = requestModel.Dob,
				Gender = requestModel.Gender,
				ResgisterDate = DateOnly.FromDateTime(DateTime.Now)
			});
			return RedirectToAction("Index");

		}
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(string id)
        {
            var students = await _studentService.GetAll();
            var student = students.FirstOrDefault(s => s.StdId == id);
            if (student == null)
            {
                return Redirect("Index");
            }
            else
            {
                var model = new StudentRequestModel
                {
                    StdId = student.StdId,
                    StdName = student.StdName,
                    FatherName = student.FatherName,
                    StdAge = student.StdAge,
                    Dob = student.Dob,
                    Gender = student.Gender,
                };
                return View("Edit",model);

            }


        }
        [ActionName("Update")]
        public async Task<IActionResult> Update(string id,StudentRequestModel requestModel)
        {
            var students = await _studentService.GetAll();
            var student = students.FirstOrDefault(s => s.StdId == id);
            if (student == null)
            {
                return Redirect("Index");
            }
            else
            {

                student.StdId = id;
                student.StdName = requestModel.StdName;
                student.FatherName = requestModel.FatherName;
                student.StdAge = requestModel.StdAge;
                student.Dob = requestModel.Dob;
                student.Gender = requestModel.Gender;
                await _studentService.UpdateStudentAsync(student);
                return RedirectToAction("Index");
            }
        }

        [ActionName("Delete")]

        public async Task<IActionResult> Delete(string id)
		{
			var students = await _studentService.GetAll();
			var student = students.FirstOrDefault(s => s.StdId == id);
			if (student == null)
			{
				return Redirect("Index");
			}
			else
			{
				student.StdId = id;
                await _studentService.DeleteStudentAsync(student);
				return RedirectToAction("Index");
			}
		}


	}
}
