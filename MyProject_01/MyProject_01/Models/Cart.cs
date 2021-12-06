using MyProject_01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject_01.Models
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}