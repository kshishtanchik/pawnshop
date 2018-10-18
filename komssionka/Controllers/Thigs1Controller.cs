using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;
using TradeInChilThings.Domain.Concrete;

namespace komssionka.Controllers
{
    public class Thigs1Controller : ApiController
    {
        private IThingRepository repository;
        public Thigs1Controller(IThingRepository productrepo)
        {
            repository = productrepo;
        }

        //// GET: api/Thigs1
        public IQueryable<Thing> Get()
        {
            return repository.GetAllThings;
        }

        // GET: api/Thigs1/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Thigs1
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Thigs1/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Thigs1/5
        public void Delete(int id)
        {
        }
    }
}
