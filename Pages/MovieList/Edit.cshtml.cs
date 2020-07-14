using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieApp.Model;

namespace MovieApp.Pages.MovieList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public async Task OnGet(int id)
        {
            Movie = await _context.Movies.FindAsync(id);
        }

        public async Task<IActionResult> OnPost() {
            if (ModelState.IsValid) {
                var MovieFromDb = await _context.Movies.FindAsync(Movie.Id);
                MovieFromDb.Name = Movie.Name;
                MovieFromDb.Writer = Movie.Writer;
                MovieFromDb.IMDB = Movie.IMDB;

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}