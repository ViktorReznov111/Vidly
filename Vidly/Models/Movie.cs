using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required(ErrorMessage="Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }
       
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime ReleaseDate { get; set; }

        [StockNumberValidation]
        public byte NumberInStock { get; set; }

        public byte NumberAvaliable { get; set; }

    }
}
