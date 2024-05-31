using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ghinelli.johan._5h.Ecommerce.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int AutoId { get; set; }
        public Auto Auto { get; set; }
        public int Quantity { get; set; }   
   public CartItem()
    {
        Auto = new Auto();
    }
    }
    
}
