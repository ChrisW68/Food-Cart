using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Cart.Models
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<IngredientList> IngredientLists { get; set; }
    }
}