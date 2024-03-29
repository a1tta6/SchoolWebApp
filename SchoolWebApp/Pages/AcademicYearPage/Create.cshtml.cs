﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolWebApp.Data;
using SchoolWebApp.Data.Models;

namespace SchoolWebApp.Pages.AcademicYearPage
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
            return Page();
        }

        [BindProperty]
        public AcademicYear AcademicYear { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.AcademicYear.Add(AcademicYear);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
