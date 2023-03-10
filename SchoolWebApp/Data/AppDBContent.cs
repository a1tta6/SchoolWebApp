using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent (DbContextOptions<AppDBContent> options)
            : base(options)
        {
            // Создание БД из файлов миграции
            Database.EnsureCreated();
        }

        public DbSet<SchoolWebApp.Data.Models.Teacher> Teacher { get; set; }
        public DbSet<SchoolWebApp.Data.Models.Student> Student { get; set; }
        public DbSet<SchoolWebApp.Data.Models.AcademicYear> AcademicYear { get; set; }
        public DbSet<SchoolWebApp.Data.Models.ClassParallel> ClassParallel { get; set; }
        public DbSet<SchoolWebApp.Data.Models.Level> Level { get; set; }
        public DbSet<SchoolWebApp.Data.Models.Class> Class { get; set; }




    }
}
