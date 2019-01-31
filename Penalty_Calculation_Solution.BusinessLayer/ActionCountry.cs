using Penalty_Calculation_Solution.DataAccessLayer.MSsqlDB;
using Penalty_Calculation_Solution.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.BusinessLayer
{
    public class ActionCountry
    {
        Repository<Country> repo_country = new Repository<Country>();

        //Database içersinde ki Ülke isimlerinin çekilmesi işlemi.
        public List<Country> GetCountries()
        {
            return repo_country.List();
        }

        //Database içersinde ki istenilen bir kaydı bulma işlemi.
        public Country FindCountry(int? data)
        {
            Country country = repo_country.Find(x => x.ID == data);

            if (country == null)
                throw new Exception("Böyle Bir Ülke Kaydı Bulunamadı.");

            return country;
        }
    }
}
