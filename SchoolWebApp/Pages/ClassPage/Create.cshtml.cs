using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.ClassPage
{
    public class CreateModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public CreateModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ParallelId"] = new SelectList(_context.ClassParallel, "Id", "Title");
        ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Fullname");
        ViewData["YearId"] = new SelectList(_context.AcademicYear, "Id", "Year");

            return Page();
        }

        [BindProperty]
        public Class Class { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Class.Add(Class);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
