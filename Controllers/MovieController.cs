using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Model;

namespace MovieApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/Movie")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data=_context.Movies.ToList()});
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            var movieFromDb = await _context.Movies.FirstOrDefaultAsync(u => u.Id == id);
            if (movieFromDb == null) {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.Movies.Remove(movieFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success=true,message="Delete successful"});
        }

    }
}