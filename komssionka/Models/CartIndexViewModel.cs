using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TradeInChilThings.Domain.Entities;

namespace komssionka.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}