using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using NLog;

namespace Akka.OrderingSystem
{



    class Program
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var system = ActorSystem.Create("orderingSystem");

            Log.Info("\n请输入`客户姓名 商品名 数量`");

            while (true)
            {
                var input = Console.ReadLine();
                try
                {
                    var name = input.Split(' ')[0];
                    var item = input.Split(' ')[1];
                    var num = int.Parse(input.Split(' ')[2]);

                    var props = Props.Create(() => new Customer(name));
                    IActorRef customerActor = system.ActorOf(props, "customerActor");
                    customerActor.Tell(new PlaceOrderMessage
                    {
                        Customer = name,
                        Item = item,
                        Number = num
                    });
                }
                catch (Exception ex)
                {
                    Log.Error(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
