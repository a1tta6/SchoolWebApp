using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Repository
{
    public class StudentRepository: IStudent
    {
        private readonly AppDBContent appDBContent;
        public StudentRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        // Коллекция всех студентов (по которым не стоит флаг удаления)
        public IEnumerable<Student> AllStudents => appDBContent.Student.Where(p => p.IsDeleted != true);

        public Student getObjectStudent(int StudentId) => appDBContent.Student.FirstOrDefault(p => p.Id == StudentId);
    }
}
