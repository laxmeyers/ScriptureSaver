using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureSaver.Data;
using ScriptureSaver.Models;

namespace ScriptureSaver.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureSaver.Data.ScriptureSaverContext _context;

        public IndexModel(ScriptureSaver.Data.ScriptureSaverContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Keyword { get; set; }

        public async Task OnGetAsync()
        {
            var keywords = from s in _context.Scripture
                           select s;

            var scriptures = from s in _context.Scripture
                             select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(SearchString));
                Console.WriteLine(scriptures);
                Console.WriteLine("trial");
            }

            if(!string.IsNullOrEmpty(Keyword))
            {
                keywords = keywords.Where(s => s.Notes.Contains("Hi"));
                Console.WriteLine(keywords);
                Console.WriteLine("hello");
            }

            Scripture = await scriptures.ToListAsync();

        }
    }
}
