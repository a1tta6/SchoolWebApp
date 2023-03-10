using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.StudentPage
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
        ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Student.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
