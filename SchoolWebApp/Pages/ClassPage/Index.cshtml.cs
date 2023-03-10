using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.ClassPage
{
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public IndexModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        public IList<Class> Class { get;set; }

        public async Task OnGetAsync()
        {
            Class = await _context.Class.Where(x => x.IsDeleted != true)
                .Include(с => с.Parallel)
                .Include(с => с.Teacher)
                .Include(с => с.Year).ToListAsync();
        }
    }
}
