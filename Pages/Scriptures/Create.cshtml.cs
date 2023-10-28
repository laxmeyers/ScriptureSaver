using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureSaver.Data;
using ScriptureSaver.Models;

namespace ScriptureSaver.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureSaver.Data.ScriptureSaverContext _context;

        public CreateModel(ScriptureSaver.Data.ScriptureSaverContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scripture Scripture { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Scripture == null || Scripture == null)
            {
                return Page();
            }
            Scripture.CreatedDate = DateTime.Now.Date;

            _context.Scripture.Add(Scripture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
