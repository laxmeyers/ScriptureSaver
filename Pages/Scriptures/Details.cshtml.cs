using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureSaver.Data;
using ScriptureSaver.Models;

namespace ScriptureSaver.Pages.Scriptures
{
    public class DetailsModel : PageModel
    {
        private readonly ScriptureSaver.Data.ScriptureSaverContext _context;

        public DetailsModel(ScriptureSaver.Data.ScriptureSaverContext context)
        {
            _context = context;
        }

      public Scripture Scripture { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Scripture == null)
            {
                return NotFound();
            }

            var scripture = await _context.Scripture.FirstOrDefaultAsync(m => m.ID == id);
            if (scripture == null)
            {
                return NotFound();
            }
            else 
            {
                Scripture = scripture;
            }
            return Page();
        }
    }
}
