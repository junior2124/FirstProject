using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FirstGitProject.Models
{
    public class Home
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public int Beds { get; set; }

        public int Baths { get; set; }

        public int HomeSize { get; set; }

        public int LotSize { get; set; }

        public decimal Price { get; set; }

        [Display (Name = "Type")]
        
        public Genre Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public string ThumbnailFilePath { get; set; }
    }
}