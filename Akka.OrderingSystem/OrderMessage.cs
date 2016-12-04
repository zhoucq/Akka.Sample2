using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akka.OrderingSystem
{
    public class PlaceOrderMessage
    {
        public string Customer { get; set; }
        public string Item { get; set; }
        public int Number { get; set; }
    }
}
