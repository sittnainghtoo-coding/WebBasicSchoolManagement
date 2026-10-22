using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBasicSchoolManagement.DataAccess;
using WebBasicSchoolManagement.Database.AppDbContextModels;

namespace WebBasicSchoolManagement.BusinessLogic
{
    public  class StudentService
    {
        private readonly DataAccess.StudentDataAccess _studentDataAccess;

        public StudentService(StudentDataAccess studentDataAccess)
        {
            _studentDataAccess = studentDataAccess;
        }

        public async Task<List<TblStudent>> GetAll()
        {
            List<TblStudent> students = await _studentDataAccess.GetAllStudents();
            return students;
        }

        public async Task<int> AddStudentAsync(TblStudent student)
		{
			int result = await _studentDataAccess.AddStudentAsync(student);
			return result;
		}

        public async Task<int> UpdateStudentAsync(TblStudent student)
        {
            int result = await _studentDataAccess.UpdateStudentAsync(student);
            return result;
        }
		public async Task<int> DeleteStudentAsync(TblStudent student)
        {
            int result = await _studentDataAccess.DeleteStudentAsync(student);
            return result;
        }

	}
}
