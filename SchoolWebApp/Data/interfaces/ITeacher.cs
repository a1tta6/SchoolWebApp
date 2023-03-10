using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;


namespace SchoolWebApp.Data.interfaces
{
    public interface ITeacher
    {
        IEnumerable<Teacher> AllTeachers { get;}
        Teacher getObjectTeacher(int TeacherId);
    }
}
