using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    public class Movie
    {
        [Key]         //automatically gives value for this column
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Writer { get; set; }
    }

}
