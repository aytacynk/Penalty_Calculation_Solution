using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.DataAccessLayer.Abstract
{
    interface IRepository<T> where T : class
    {
        //Repository Design Pattern için Interface oluşturm işlemi yapılmaktadır.
        List<T> List();

        List<T> List(Expression<Func<T, bool>> where);

        T Find(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();
    }
}
