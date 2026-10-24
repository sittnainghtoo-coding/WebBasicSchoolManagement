using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchoolManagement.DataAccess
{
	public class TeacherDataAccess
	{
		private readonly AppDbContext _db;

		public TeacherDataAccess(AppDbContext db)
		{
			_db = db;
		}

		public List<TblTeacher> GetTeachers()
		{
			var teachers = _db.TblTeachers.ToList();
			return teachers;
		}


	}
}
