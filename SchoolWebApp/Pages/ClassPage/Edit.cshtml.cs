using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.ClassPage
{
    public class EditModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public EditModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Class
                .Include(с => с.Parallel)
                .Include(с => с.Teacher)
                .Include(с => с.Year).FirstOrDefaultAsync(m => m.Id == id);

            if (Class == null)
            {
                return NotFound();
            }
            ViewData["ParallelId"] = new SelectList(_context.ClassParallel, "Id", "Title");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "Fullname");
            ViewData["YearId"] = new SelectList(_context.AcademicYear, "Id", "Year");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(Class.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.Id == id);
        }
    }
}
