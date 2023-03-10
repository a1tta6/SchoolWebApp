using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.TeacherPage
{
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public IndexModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        public IList<Teacher> Teacher { get;set; }

        public async Task OnGetAsync()
        {
            Teacher = await _context.Teacher.Where(x => x.IsDeleted != true).ToListAsync();
        }
    }
}
