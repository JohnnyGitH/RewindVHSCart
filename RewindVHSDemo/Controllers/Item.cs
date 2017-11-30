using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RewindVHSDemo.Models;

namespace RewindVHSDemo.Controllers
{
    public class Item
    {
        private Movie movie = new Movie();

        public Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }

        private int quantity;

        public Item()
        {

        }

        public Item(Movie movie, int quantity)
        {
            this.Movie = movie;
            this.Quantity = quantity;
        }



        public int Quantity
        {
            get{ return quantity; }
            set{ quantity = value; }
        }
    }
}