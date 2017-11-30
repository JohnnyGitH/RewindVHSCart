using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RewindVHSDemo.Models;

namespace RewindVHSDemo.Controllers
{
    public class ShoppingCartController : Controller
    {
        private MovieEntities me = new MovieEntities();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This function checks the cart to see if there are existing items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i=0; i< cart.Count; i++)          
                if (cart[i].Movie.movieId == id)
                    return i;
            return -1;
            
        }

        /// <summary>
        ///  Delete Product from Cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;

            return View("Cart");
        }

        /// <summary>
        /// Order Function adding movies to the cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult OrderNow(int id)
        {

            if ((int)Session["CartToken"] == 0)
                return View("Cart");

            if(Session["cart"] == null)// If there is no cart yet
            {
                Session["CartToken"] = 0;//Track refresh on cart page
                List<Item> cart = new List<Item>();
                cart.Add(new Item(me.Movies.Find(id),1));
                Session["cart"] = cart;
            }
            else if((int)Session["CartToken"] == 1)// If a cart exists
            {
                Session["CartToken"] = 0;//Track refresh on cart page
                List<Item> cart = (List<Item>)Session["cart"];                       
                int index = isExisting(id);

                if (index == -1)                //Doesn't Already Exist
                    cart.Add(new Item(me.Movies.Find(id), 1));
                else                            // Exists , Increment Quantity 
                    cart[index].Quantity++;

                Session["cart"] = cart;
            }

            return View("Cart");
        }
    }
}