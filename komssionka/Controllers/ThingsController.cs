using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;

namespace komssionka.Controllers
{
    public class ThingsController : ApiController
    {
        private IThingRepository repository;
        public ThingsController(IThingRepository productrepo)
        {
            repository = productrepo;
        }

        // GET api/values
        //public Product Get(int id) => productrepo.GetItem(id);

        //GET api/Things/5
        [HttpGet]
        public Thing Get(int id) => repository.GetThing(id);

        // POST api/values
        //public void Post([FromBody]Product value) => productrepo.SaveItem(value);

        // PUT api/values/5
        //public void Delete(int id) => productrepo.DeleteItem(id);
    }
}
