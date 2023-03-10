using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Data.Models
{
    public class Class
    {
        public Class()
        {
            Students = new HashSet<Student>();
        }
        public int Id { get; set; }
        public int ParallelId { get; set; }
        public int YearId { get; set; }
        public int TeacherId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ClassParallel Parallel { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual AcademicYear Year { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
