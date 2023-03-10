using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Repository
{
    public class TeacherRepository: ITeacher
    {
        private readonly AppDBContent appDBContent;
        public TeacherRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        // Коллекция всех учителей (по которым не стоит флаг удаления)
        public IEnumerable<Teacher> AllTeachers => appDBContent.Teacher.Where(p => p.IsDeleted != true);
        public Teacher getObjectTeacher(int TeacherId) => appDBContent.Teacher.FirstOrDefault(p => p.Id == TeacherId);

    }
}
