using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class CustomerPortal
    {
        public static List<Product> selectedItems = new List<Product>();

        public static IEnumerable<Product> SelectedItems = selectedItems;

        public void AddToCart(Product selectedItem)
        {
            selectedItems.Add(selectedItem);
        }
    }
}
