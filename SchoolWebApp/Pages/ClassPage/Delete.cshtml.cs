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
    public class DeleteModel : PageModel
    {
        private readonly SchoolWebApp.Data.AppDBContent _context;

        public DeleteModel(SchoolWebApp.Data.AppDBContent context)
        {
            _context = context;
        }

        [BindProperty]
        public Class Class { get; set; }
        public Student Student { get; set; }
        public  List<Student> Students { get; set; }
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Class = await _context.Class
                .Include(с => с.Parallel)
                .Include(с => с.Teacher)
                .Include(с => с.Year).FirstOrDefaultAsync(m => m.Id == id);


            Class.DeleteDate = DateTime.Now;
            Class.IsDeleted = true;
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
