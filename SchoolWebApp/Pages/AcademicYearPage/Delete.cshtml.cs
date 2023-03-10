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
    public class DeleteModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public DeleteModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        [BindProperty]
        public AcademicYear AcademicYear { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcademicYear = await _context.AcademicYear.FirstOrDefaultAsync(m => m.Id == id);

            if (AcademicYear == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AcademicYear = await _context.AcademicYear.FirstOrDefaultAsync(m => m.Id == id);



            AcademicYear.DeleteDate = DateTime.Now;
            AcademicYear.IsDeleted = true;
            _context.Attach(AcademicYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicYearExists(AcademicYear.Id))
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
        private bool AcademicYearExists(int id)
        {
            return _context.AcademicYear.Any(e => e.Id == id);
        }
    }
}
