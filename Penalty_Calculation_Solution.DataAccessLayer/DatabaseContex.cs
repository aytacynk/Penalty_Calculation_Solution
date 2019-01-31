using Penalty_Calculation_Solution.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.DataAccessLayer
{
    public class DatabaseContex : DbContext //Database Bu tetikleme işlemi ile ayağa kaldırılır.
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DatabaseContex()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
