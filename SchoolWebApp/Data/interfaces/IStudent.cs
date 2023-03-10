using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data.interfaces
{
    interface IStudent
    {
        IEnumerable<Student> AllStudents { get; }
        Student getObjectStudent(int StudentId);

    }
}
