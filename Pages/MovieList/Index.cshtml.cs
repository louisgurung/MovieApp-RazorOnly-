using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public void OnGet()
        {

        }
    }
}