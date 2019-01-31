using Penalty_Calculation_Solution.DataAccessLayer.MSsqlDB;
using Penalty_Calculation_Solution.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.BusinessLayer
{
    public class ActionBook
    {
        Repository<Book> repo_book = new Repository<Book>();

        //Kullanıcı tarafından gelen Yeni bir kayın database insert işlemi.
        public int InsertBook(Book book)
        {
            int result = repo_book.Insert(new Book
            {
                CheckOut = book.CheckOut,
                ReturnedDate = book.ReturnedDate,
                Country = book.Country,
                CreatedOn = DateTime.Now
            });

            return result;
        }

        //Database içersinde ki istenilen bir kaydı bulma işlemi.
        public Book FindBook(int? data)
        {
            Book book = repo_book.Find(x => x.ID == data);

            if (book == null)
                throw new Exception("Kayıt Bulunamadı");

            return book;
        }

        //Oluşturulan yeni bir kaydın ödemesi gereken miktarın hesaplanması
        public decimal CalculatePenalty(DateTime CheckOut, DateTime ReturnedDate, int id)
        {

            TimeSpan totalDate = ReturnedDate - CheckOut;
            decimal totalDays = (int)totalDate.TotalDays;
            decimal OffDaysCount = 0;

            if (id == 1)
            {
                DateTime TR1 = new DateTime(2019, 4, 23);
                DateTime TR2 = new DateTime(2019, 5, 19);

                for (DateTime date = CheckOut; date <= ReturnedDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday || date.Date == TR1 || date.Date == TR2)
                        OffDaysCount++;
                }
            }
            if (id == 2)
            {
                DateTime AE1 = new DateTime(2019, 12, 2);
                DateTime AE2 = new DateTime(2019, 8, 6);

                for (DateTime date = CheckOut; date <= ReturnedDate; date = date.AddDays(1))
                {
                    if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday || date.Date == AE1 || date.Date == AE2)
                        OffDaysCount++;
                }
            }
            return totalDays - OffDaysCount;
        }
    }
}
