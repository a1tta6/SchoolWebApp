using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Data.interfaces
{
    interface IClassParallel
    {
        IEnumerable<ClassParallel> AllParallels { get; }
        ClassParallel getObjectClassParallel(int ClassParallelId);

    }
}
