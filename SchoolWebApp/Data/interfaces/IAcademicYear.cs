using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data.interfaces
{
    interface IAcademicYear
    {
        IEnumerable<AcademicYear> AllYears { get; }
        AcademicYear getObjectYear(int YearId);
    }
}
