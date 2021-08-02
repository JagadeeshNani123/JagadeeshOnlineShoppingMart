using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.Models
{
    public class DeliveryAddress
    {
        public static List<AddressPage> addressList = new List<AddressPage>();

        public static IEnumerable<AddressPage> AddressList = addressList;

        public void AddAdressToList(AddressPage address)
        {
            addressList.Add(address);
        }
    }
}
