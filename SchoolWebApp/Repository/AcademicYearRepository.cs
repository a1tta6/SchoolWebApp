using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;
using SchoolWebApp.Data;

namespace SchoolWebApp.Repository
{
    public class AcademicYearRepository: IAcademicYear
    {
        private readonly AppDBContent appDBContent;
        public AcademicYearRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        // Коллекция всех годов (по которым не стоит флаг удаления)
        public IEnumerable<AcademicYear> AllYears => appDBContent.AcademicYear.Where(p => p.IsDeleted != true);
        public AcademicYear getObjectYear(int AcademicYearId) => appDBContent.AcademicYear.FirstOrDefault(p => p.Id == AcademicYearId);
    }
}
