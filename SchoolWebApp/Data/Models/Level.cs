using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Data.Models
{
    public class Level
    {
        public Level()
        {
            Parallels = new HashSet<ClassParallel>();
        }
        public string LevelName { get; set; }
        public int Id { get; set; }
        public virtual ICollection<ClassParallel> Parallels { get; set; }

    }
}
