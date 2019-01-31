using Penalty_Calculation_Solution.BusinessLayer;
using Penalty_Calculation_Solution.Entites;
using Penalty_Calculation_Solution.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Penalty_Calculation_Solution.Web.Controllers
{
    public class HomeController : Controller
    {
        private ActionCountry actionCountry = new ActionCountry();
        private ActionBook actionBook = new ActionBook();

        // GET: Home
        public ActionResult Index()
        {
            Test test = new Test();//Database oluşması için

            SelectList selectListCountries = new SelectList(actionCountry.GetCountries(), "ID", "CountryName"); //DropdownList içerisne dataları doldurmak

            IndexViewModel indexViewModel = new IndexViewModel()
            {
                CountryData = selectListCountries,
            };

            return View(indexViewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel indexViewModel)
        {
            //Yeni Kayıt alma işlemi ve database ekleme işlemleri
            if (ModelState.IsValid)
            {
                Country country = actionCountry.FindCountry(indexViewModel.Book.Country.ID);

                Book book = new Book()
                {
                    CheckOut = indexViewModel.Book.CheckOut,
                    ReturnedDate = indexViewModel.Book.ReturnedDate,
                    Country = country,
                    CreatedOn = DateTime.Now
                };

                int result = actionBook.InsertBook(book);

                if (result > 0)
                {
                    TempData["Book"] = book as Book;
                    return RedirectToAction("Calculate");
                }
            }

            SelectList selectListCountries = new SelectList(actionCountry.GetCountries(), "ID", "CountryName");
            indexViewModel.CountryData = selectListCountries;

            return View(indexViewModel);
        }

        public ActionResult Calculate()
        {
            return View();
        }

        public ActionResult Penalty()
        {

            //Ödenmesi gereken para miktarının gösterilmesi işlemleri

            Book book = TempData["Book"] as Book;

            decimal result = actionBook.CalculatePenalty(book.CheckOut, book.ReturnedDate, book.Country.ID);

            if (result > 10)
            {
                ViewBag.Penalty = result * 10;
            }
            else
            {
                ViewBag.Penalty = 0.0;
            }

            return View();
        }
    }
}