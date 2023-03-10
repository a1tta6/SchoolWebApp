using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApp.Data.Models
{
    public class ClassParallel
    {
        public ClassParallel()
        {
            Classes = new HashSet<Class>();
        }

        public string Title { get; set; }
        public int Id { get; set; }
        public int LevelId { get; set; }

        public virtual Level Level { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
