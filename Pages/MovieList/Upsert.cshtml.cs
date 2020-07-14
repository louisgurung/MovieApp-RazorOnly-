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
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _context;

        public UpsertModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            Movie = new Movie();
            if (id == null) {
                //create
                return Page();
            }

            //update
            Movie = await _context.Movies.FirstOrDefaultAsync(u => u.Id == id);
            if (Movie == null) {
                return NotFound();
            }
            return Page();
            //Movie = await _context.Movies.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Movie.Id == 0)
                {
                    _context.Movies.Add(Movie);
                }
                else {
                    _context.Movies.Update(Movie);      //if we want to update all properties
                }

                await _context.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}