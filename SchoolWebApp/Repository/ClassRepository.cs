using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;
using SchoolWebApp.Data;

namespace SchoolWebApp.Repository
{
    public class ClassRepository : IClass
    {
        private readonly AppDBContent appDBContent;
        public ClassRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        // Коллекция всех классов (по которым не стоит флаг удаления)
        public IEnumerable<Class> AllClasses => appDBContent.Class.Where(p => p.IsDeleted != true);

        public Class getObjectClass(int ClassId) => appDBContent.Class.FirstOrDefault(p => p.Id == ClassId);
    }
}
