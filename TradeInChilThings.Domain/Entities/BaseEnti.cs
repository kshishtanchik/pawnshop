using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TradeInChilThings.Domain
{
    public abstract class BaseEnti
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { set; get; }
        [Required, StringLength(255,ErrorMessage ="Необходимо задать имя")]
        [Display(Name = "Наименование")]
        public string Name { set; get; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="Описание")]
        public string Description { set; get; }
    }
}
