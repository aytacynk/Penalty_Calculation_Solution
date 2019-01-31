using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penalty_Calculation_Solution.Entites
{
    [Table("Books")] //Book Tablosu oluşturuldu.
    public class Book : Base
    {
        [DisplayName("Check Out Date"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public DateTime CheckOut { get; set; }

        [DisplayName("Return Date"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public DateTime ReturnedDate { get; set; }

        [DisplayName("Country"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public virtual Country Country { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
