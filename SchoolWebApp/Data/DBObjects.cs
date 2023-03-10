using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data
{
    // Класс для инициализации объектов бд - Справочников
    public class DBObjects
    {
        public static void Initial (AppDBContent content)
        {
            // Добавление уровней в бд
            if (!content.Level.Any())
                content.Level.AddRange(Levels.Select(c => c.Value));
            content.SaveChanges();

            // Добавление параллелей в бд
            if (!content.ClassParallel.Any())
                content.ClassParallel.AddRange(Parallels.Select(c => c.Value));
            content.SaveChanges();
        }
        // Создание уровней
        private static Dictionary<string, Level> level;
        public static Dictionary<string, Level> Levels
        {
            get
            {
                if (level == null)
                {
                    var list = new Level[]
                    {
                        new Level {LevelName = "Начальная школа"},
                        new Level {LevelName = "Средняя школа"},
                        new Level {LevelName = "Старшая школа"}
                    };
                    level = new Dictionary<string, Level>();
                    foreach (Level el in list)
                        level.Add(el.LevelName, el);
                }
                return level;
            }
        }
        // Создание параллелей
        private static Dictionary<string, ClassParallel> parallel;
        public static Dictionary<string, ClassParallel> Parallels
        {
            get
            {
                if (parallel == null)
                {
                    var list = new ClassParallel[]
                    {
                        new ClassParallel {Title = "1А", LevelId=1},
                        new ClassParallel {Title = "1Б", LevelId=1},
                        new ClassParallel {Title = "2А", LevelId=1},
                        new ClassParallel {Title = "2Б", LevelId=1},
                        new ClassParallel {Title = "3А", LevelId=1},
                        new ClassParallel {Title = "3Б", LevelId=1},
                        new ClassParallel {Title = "4А", LevelId=1},
                        new ClassParallel {Title = "4Б", LevelId=1},
                        new ClassParallel {Title = "5А", LevelId=2},
                        new ClassParallel {Title = "5Б", LevelId=2},
                        new ClassParallel {Title = "6А", LevelId=2},
                        new ClassParallel {Title = "6Б", LevelId=2},
                        new ClassParallel {Title = "7А", LevelId=2},
                        new ClassParallel {Title = "7Б", LevelId=2},
                        new ClassParallel {Title = "8А", LevelId=2},
                        new ClassParallel {Title = "8Б", LevelId=2},
                        new ClassParallel {Title = "9А", LevelId=2},
                        new ClassParallel {Title = "9Б", LevelId=2},
                        new ClassParallel {Title = "10А", LevelId=3},
                        new ClassParallel {Title = "10Б", LevelId=3},
                        new ClassParallel {Title = "11А", LevelId=3},
                        new ClassParallel {Title = "11Б", LevelId=3},
                    };
                    parallel = new Dictionary<string, ClassParallel>();
                    foreach (ClassParallel el in list)
                        parallel.Add(el.Title, el);
                }
                return parallel;
            }
        }
    }
}
