using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeInChilThings.Domain.Entities;

namespace TradeInChilThings.Domain
{
    public class Thing:BaseEnti
    {
        [Display(Name = "Дата приема")]
        public DateTime DateOfReceipt { set; get; }
        [Display(Name = "Цена")]
        public decimal Price { set; get; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Категория")]
        public virtual Category Category { set; get; }   
        public int? CategoryId { set; get; }

        [ForeignKey("ThingId")]
        [Display(Name = "Изображения")]
        public virtual List<Image> Images { get; set; }
        //public int? ThingId { get; set; }
    }
}
