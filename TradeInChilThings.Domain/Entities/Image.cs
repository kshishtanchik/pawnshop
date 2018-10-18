using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public byte[] Picture { get; set; }
        public int? ThingId { get; set; }
    }
}
