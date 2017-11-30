using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RewindVHSDemo.Models;

namespace RewindVHSDemo.Controllers
{
    public class ProductController : Controller
    {

        private MovieEntities me = new MovieEntities();

        /// <summary>
        /// Main product page listing all movies in DB
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            ViewBag.listProducts = me.Movies.ToList();

            return View();
        }

        /// <summary>
        /// NavBar return to shoppingcart link
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnToCart()
        {
            return View("~/Views/ShoppingCart/Cart.cshtml");
        }
    }
}