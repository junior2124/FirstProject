using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstGitProject.Models
{
    public class Home
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

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }
    }
}