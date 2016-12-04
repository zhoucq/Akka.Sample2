using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Akka.OrderingSystem
{
    public class Order : UntypedActor
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public string Item { get; set; }

        public int Number { get; set; }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}
