using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchoolManagement.DataAccess
{
    public class StudentDataAccess
    {
        private readonly AppDbContext _db;

        public StudentDataAccess(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<TblStudent>> GetAllStudents()
        {
            var students = await _db.TblStudents.ToListAsync();
            return students;
        }
        public async Task<int> AddStudentAsync(TblStudent student)
		{
			_db.TblStudents.Add(student);
			int result = await _db.SaveChangesAsync();
			return result;
		}

        public async Task<int> UpdateStudentAsync(TblStudent student)
        {
            _db.TblStudents.Update(student);
            int result = await _db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteStudentAsync(TblStudent student)
		{
			_db.TblStudents.Remove(student);
			int result = await _db.SaveChangesAsync();
			return result;
		}
	}
}
