using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain
{
    public class Order:BaseEnti
    {
        [ForeignKey("ThingId")]
        public Thing Things { set; get; }
        public int ThingId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
