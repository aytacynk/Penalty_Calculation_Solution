using Penalty_Calculation_Solution.DataAccessLayer.MSsqlDB;
using Penalty_Calculation_Solution.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.BusinessLayer
{
    public class Test
    {
        Repository<Book> repo_book = new Repository<Book>();

        //Code-First mantığına göre database oluşum tetiklenmesi için oluşturulan geçici Test classı.
        public Test()
        {
            List<Book> bookList = repo_book.List();
        }

    }
}
