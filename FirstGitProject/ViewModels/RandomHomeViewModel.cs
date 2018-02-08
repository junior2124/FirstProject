using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FirstGitProject.Models;

namespace FirstGitProject.ViewModels
{
    public class RandomHomeViewModel
    {
        public Home Home { get; set; }
        public List<Customer> Customers { get; set; }
    }
}