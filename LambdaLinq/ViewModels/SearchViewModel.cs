using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LambdaLinq.ViewModels
{
    public class SearchViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal PriceMin{ get; set; }
        public decimal PriceMax { get; set; }
       
    }
}