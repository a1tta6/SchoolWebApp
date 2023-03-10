using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data.interfaces
{
    interface ILevel
    {
        IEnumerable<Level> AllLevels { get; }
        Level getObjectLevel(int LevelId);

    }
}
