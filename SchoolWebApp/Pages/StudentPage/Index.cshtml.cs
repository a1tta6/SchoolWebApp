using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public IndexModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.Where(x=>x.IsDeleted!=true)
                .Include(s => s.Class).ToListAsync();
        }
    }
}
