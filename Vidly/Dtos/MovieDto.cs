using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        //[StockNumberValidation]
        public byte NumberInStock { get; set; }
    }
}