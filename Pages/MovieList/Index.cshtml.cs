using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieApp.Model;

namespace MovieApp.Pages.MovieList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        //with DI, no creation, disposing of object required
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> Movie { get; set; }      //this var name is used in razor page
        public async Task OnGet()
        {
            Movie = await _context.Movies.ToListAsync();

        }

        public async Task<IActionResult> OnPostDelete(int id) {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null) {
                return NotFound();
            }
            _context.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}