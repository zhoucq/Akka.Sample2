using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using NLog;

namespace Akka.OrderingSystem
{
    public class Customer : UntypedActor
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        public Customer(string name)
        {
            if (name == "a" || name == "b")
                Name = name;
            else
                throw new ApplicationException("user not exists");

        }

        public string Name { get; }

        protected override void OnReceive(object message)
        {
            if (message is PlaceOrderMessage)
            {
                var msg = message as PlaceOrderMessage;
                msg.Customer = this.Name;
                var act = Context.ActorOf(Props.Create(() => new Order()));
                act.Tell(message);
            }
        }
    }
}
