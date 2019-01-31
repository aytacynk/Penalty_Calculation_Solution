using Penalty_Calculation_Solution.Entites;
using Penalty_Calculation_Solution.Entites.OffAndBusinessDayCode;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.DataAccessLayer
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContex>
    {
        //Code-First mantığına göre Fake-Daata ile Database tabloları veri girişi .
        protected override void Seed(DatabaseContex context)
        {
            for (int i = 0; i < 1; i++)
            {

                Country country = new Country()
                {
                    CountryName = "TURKEY",
                    WeekEndDay1 = OffDaysCode.Saturday.ToString(),
                    WeekEndDay2 = OffDaysCode.Sunday.ToString(),
                    BussinessDay1 = BusinessDaysCode.Monday.ToString(),
                    BussinessDay2 = BusinessDaysCode.Tuesday.ToString(),
                    BussinessDay3 = BusinessDaysCode.Wednesday.ToString(),
                    BussinessDay4 = BusinessDaysCode.Thursday.ToString(),
                    BussinessDay5 = BusinessDaysCode.Friday.ToString(),
                    NationalDay1 = "2019-04-23",
                    NationalDay2 = "2019-05-19",
                    NationalDay3 = null
                };


                Country country2 = new Country()
                {
                    CountryName = "DUBAI",
                    WeekEndDay1 = OffDaysCode.Friday.ToString(),
                    WeekEndDay2 = OffDaysCode.Saturday.ToString(),
                    BussinessDay1 = BusinessDaysCode.Monday.ToString(),
                    BussinessDay2 = BusinessDaysCode.Tuesday.ToString(),
                    BussinessDay3 = BusinessDaysCode.Wednesday.ToString(),
                    BussinessDay4 = BusinessDaysCode.Thursday.ToString(),
                    BussinessDay5 = BusinessDaysCode.Sunday.ToString(),
                    NationalDay1 = "2019-12-02",
                    NationalDay2 = "2019-08-06",
                    NationalDay3 = null
                };

                context.Countries.Add(country);
                context.Countries.Add(country2);

                Book book1 = new Book()
                {
                    CheckOut = DateTime.Now.AddDays(6),
                    ReturnedDate = DateTime.Now.AddMonths(10),
                    Country = country,
                    CreatedOn = DateTime.Now
                };
                Book book2 = new Book()
                {
                    CheckOut = DateTime.Now.AddDays(6),
                    ReturnedDate = DateTime.Now.AddMonths(10),
                    Country = country2,
                    CreatedOn = DateTime.Now
                };
                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges();
            }
        }
    }
}
