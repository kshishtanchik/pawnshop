using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain.Entities
{
    public class PageContent
    {
        public List<string> CategoryLinks { set; get; }
        public IQueryable<Thing> Catalog { set; get; }
    }
}
