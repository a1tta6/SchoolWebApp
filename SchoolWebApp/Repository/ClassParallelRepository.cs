using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;
using SchoolWebApp.Data;


namespace SchoolWebApp.Repository
{
    public class ClassParallelRepository : IClassParallel
    {
        private readonly AppDBContent appDBContent;
        public ClassParallelRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<ClassParallel> AllParallels => appDBContent.ClassParallel;

        // Коллекция всех параллелей (по которым не стоит флаг удаления)
        public ClassParallel getObjectClassParallel(int ClassParallelId) => appDBContent.ClassParallel.FirstOrDefault(p => p.Id == ClassParallelId);

    }
}
