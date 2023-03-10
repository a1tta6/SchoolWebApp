using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.AcademicYearPage
{
    public class IndexModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public IndexModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        public IList<AcademicYear> AcademicYear { get;set; }

        public async Task OnGetAsync()
        {
            AcademicYear = await _context.AcademicYear.Where(x => x.IsDeleted != true).ToListAsync();
        }
    }
}
