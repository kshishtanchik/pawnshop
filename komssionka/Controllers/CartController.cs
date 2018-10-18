using komssionka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradeInChilThings.Domain;
using TradeInChilThings.Domain.Abstract;
using TradeInChilThings.Domain.Entities;

namespace komssionka.Controllers
{
    public class CartController : Controller
    {
        private IThingRepository repository;
        public CartController(IThingRepository repo)
        {
            repository = repo;
        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Thing product = repository.GetAllThings
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Thing product = repository.GetAllThings
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}
