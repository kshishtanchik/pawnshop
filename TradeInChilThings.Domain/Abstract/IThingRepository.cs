using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeInChilThings.Domain.Abstract
{
    public interface IThingRepository
    {
        IQueryable<Thing> GetAllThings { get; }
        void Save(Thing thing);
        void Delete(int IdThig);
        Thing GetThing(int id);

    }
}
