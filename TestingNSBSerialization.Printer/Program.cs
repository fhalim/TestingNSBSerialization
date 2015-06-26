using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingNSBSerialization.Printer
{
    using Contracts;
    using NServiceBus;

    class Program
    {
        private static void Main(string[] args)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseTransport<RabbitMQTransport>().DisableCallbackReceiver()
                .ConnectionString("host=localhost");
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.ScaleOut().UseSingleBrokerQueue();
            using (var bus = Bus.Create(busConfiguration)) {
                bus.Start();
                Console.ReadLine();
            }
        }
    }

    public class HelloWriter : IHandleMessages<SayHello>
    {
        public void Handle(SayHello message)
        {
            Console.WriteLine("Hello, {0}", message.Message);
        }
    }
}
