using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.Entites
{
    [Table("Countries")] //Book Tablosu oluşturuldu.
    public class Country : Base
    {
        public string CountryName { get; set; }

        public string WeekEndDay1 { get; set; }

        public string WeekEndDay2 { get; set; }

        public string BussinessDay1 { get; set; }

        public string BussinessDay2 { get; set; }

        public string BussinessDay3 { get; set; }

        public string BussinessDay4 { get; set; }

        public string BussinessDay5 { get; set; }

        public string NationalDay1 { get; set; }

        public string NationalDay2 { get; set; }

        public string NationalDay3 { get; set; }

    }

}
