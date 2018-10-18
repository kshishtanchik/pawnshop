using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;
using TradeInChilThings.Domain.Concrete;

namespace komssionka.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //Mock<IThingRepository> mock = new Mock<IThingRepository>();
            //mock.Setup(m => m.Things).Returns(new List<Thing> {
            //    new Thing{Name="Pen",Description="Normal pen",DateOfReceipt=DateTime.Parse("12 02 2018").Date,Price=36.45},
            //    new Thing{Name="Pensil",Description="Normal pensil",DateOfReceipt=DateTime.Parse("02 01 2018").Date,Price=95.47}
            //}.AsQueryable());
            ninjectKernel.Bind<IThingRepository>().To<EFThingRepository>();
        }
    }
}