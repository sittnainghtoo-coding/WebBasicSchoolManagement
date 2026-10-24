using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchtoolManagement.MVC.Models
{

	public class TeacherViewModel
	{
		private readonly AppDbContext _db;

		public TeacherViewModel(AppDbContext db)
		{
			_db = db;
		}

		public class TeacherVM
		{
			public string Id { get; set; }
			public string Name { get; set; }
			public int SelectedItem { get; set; }

			public IEnumerable<SelectListItem> Subjects { get; set; }

			public string Subject { get; set; }

		}

		public async Task<List<TeacherVM>> GetAll()
		{

			List<TblTeacher> _teacher = await _db.TblTeachers.ToListAsync();

			List<TblSubject> _subject = await _db.TblSubjects.ToListAsync();

			List<TeacherVM> _teacherVM = new List<TeacherVM>();

			foreach (var teacher in _teacher)
			{
				_teacherVM.Add(new TeacherVM
				{
					Id = teacher.TecId,
					Name = teacher.TecName,
					Subject = _subject.Where(x => x.Id == teacher.SubId).Select(x => x.SubName).FirstOrDefault(),
				});
			}

			return _teacherVM;
		}

		public async Task<IEnumerable<SelectListItem>> GetSubjects()
        {
			List<TblSubject> _SubjectList = await _db.TblSubjects.ToListAsync();
			IEnumerable<SelectListItem> subject = _SubjectList.Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.SubName
			}).ToList();

			return subject;
        }
    }

}	

