using Penalty_Calculation_Solution.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.DataAccessLayer.MSsqlDB
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Repository Design Pattern oluşturulma işlemi yapılmaktadır.
        private DataAccessLayer.DatabaseContex db;
        private DbSet<T> _objectSet;

        public Repository()
        {
            db = RepositoryBase.CreateContex();
            _objectSet = db.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).ToList();

        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public int Update(T obj)
        {
            //_objectSet.Find(obj);
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

    }
}
