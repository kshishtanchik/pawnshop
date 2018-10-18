using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain
{
    public class Customer:BaseEnti
    {
        [Display(Name = "Номер телефона")]
        public string TelephoneNumer { get; set; }
        [Display(Name = "Адресс")]
        public string Addreess { get; set; }
    }
}
