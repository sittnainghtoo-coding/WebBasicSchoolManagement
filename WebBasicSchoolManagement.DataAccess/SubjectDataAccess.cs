using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchoolManagement.DataAccess
{
	public class SubjectDataAccess
	{
		private readonly AppDbContext _db;

		public SubjectDataAccess(AppDbContext db)
		{
			_db = db;
		}

		public List<TblSubject> GetSubjects()
		{
			var subjects = _db.TblSubjects.ToList();
			return subjects;
		}
	}
}
