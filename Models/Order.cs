using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class Order
    {
        public List<CustomerPortal> orderItems = new List<CustomerPortal>();

        public static List<CustomerPortal> ListOfOrderItems(List<CustomerPortal> orderItems)
        {
            orderItems.AddRange(orderItems);
            return orderItems;
        }
    }
}
