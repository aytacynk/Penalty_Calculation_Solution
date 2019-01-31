using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.DataAccessLayer.MSsqlDB
{
    public class RepositoryBase
    {
        //Singleton Design Pattern oluşturulma işlemi yapılmaktadır.
        private static DatabaseContex _db;
        private static object _lockSync = new object();

        protected RepositoryBase()
        {

        }
        public static DatabaseContex CreateContex()
        {
            if (_db == null)
            {
                lock (_lockSync)
                {
                    if (_db == null)
                    {
                        _db = new DatabaseContex();
                    }
                }
            }
            return _db;
        }
    }
}
