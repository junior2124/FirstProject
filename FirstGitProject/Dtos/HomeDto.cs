using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FirstGitProject.Models;

namespace FirstGitProject.Dtos
{
    public class HomeDto
    {
        public int Id { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public int Beds { get; set; }

        public int Baths { get; set; }

        public int HomeSize { get; set; }

        public int LotSize { get; set; }

        public decimal Price { get; set; }


        [Required]
        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

    }
}