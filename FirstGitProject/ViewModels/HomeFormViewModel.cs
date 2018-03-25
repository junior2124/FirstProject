using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FirstGitProject.Models;

namespace FirstGitProject.ViewModels
{
    public class HomeFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public int Beds { get; set; }

        public int Baths { get; set; }

        public int HomeSize { get; set; }

        public int LotSize { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Type")]
        [Required]
        public byte? GenreId { get; set; }

        public string ThumbnailFilePath { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Home" : "New Home";
            }
        }

        public HomeFormViewModel()
        {
            Id = 0;
        }
        public HomeFormViewModel(Home home)
        {
            Id = home.Id;
            Address = home.Address;
            City = home.City;
            State = home.State;
            Zip = home.Zip;
            GenreId = home.GenreId;
            ThumbnailFilePath = home.ThumbnailFilePath;
        }
    }
}