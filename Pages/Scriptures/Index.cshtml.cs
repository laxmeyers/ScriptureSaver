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
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookName { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from s in _context.Scripture
                                           orderby s.Book
                                           select s.Book;

            var scriptures = from s in _context.Scripture
                             select s;
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Notes.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookName))
            {
                scriptures = scriptures.Where(s => s.Book == BookName);

            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.ToListAsync();

        }
    }
}
