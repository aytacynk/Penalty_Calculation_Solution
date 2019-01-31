using Penalty_Calculation_Solution.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penalty_Calculation_Solution.Web.ViewModels
{
    public class IndexViewModel
    {
        public Country Country { get; set; }

        public Book Book { get; set; }

        public SelectList CountryData { get; set; }
    }
}