using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstGitProject.Models;

namespace FirstGitProject.ViewModels
{
    public class HomeFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Home Home { get; set; }
        public string Title
        {
            get
            {
                if (Home != null && Home.Id != 0)
                    return "Edit Home";

                return "New Home";
            }
        }
    }
}