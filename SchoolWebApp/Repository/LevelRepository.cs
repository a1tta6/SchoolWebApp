using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.interfaces;
using SchoolWebApp.Data.Models;
using SchoolWebApp.Data;

namespace SchoolWebApp.Repository
{
    public class LevelRepository : ILevel
    {
        private readonly AppDBContent appDBContent;
        public LevelRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        // Коллекция всех уровней (по которым не стоит флаг удаления)
        public IEnumerable<Level> AllLevels => appDBContent.Level;

        public Level getObjectLevel(int LevelId) => appDBContent.Level.FirstOrDefault(p => p.Id == LevelId);
    }
}
