using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeInChilThings.Domain.Abstract;
using TradeInChilThings.Domain.Entities;

namespace TradeInChilThings.Domain.Concrete
{
    public class EFThingRepository : IThingRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Thing> GetAllThings
        {
            get { return context.Things; }
        }

        public Thing GetThing(int id) => context.Things.FirstOrDefault(x=>x.Id==id);

        public void Delete(int delId)
        {
            context.Things.Remove(context.Things.FirstOrDefault(x => x.Id == delId));
            context.Images.RemoveRange(context.Images.Where(x => x.ThingId == delId));
            context.SaveChanges();
        }

        public void Save(Thing thing)
        {
            if (thing.Id == 0)
            {
                context.Things.Add(thing);
            }
            else
            {
                Thing dbEntry = context.Things.Find(thing.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = thing.Name;
                    dbEntry.Description = thing.Description;
                    dbEntry.Price = thing.Price;
                    dbEntry.Category = thing.Category;
                    dbEntry.DateOfReceipt = thing.DateOfReceipt;
                    dbEntry.Images = thing.Images;
                }
            }
            context.SaveChanges();
        }
    }
}
