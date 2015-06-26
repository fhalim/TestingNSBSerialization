namespace TestingNSBSerialization.Publisher
{
    using System;
    using Contracts;
    using NServiceBus;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseTransport<RabbitMQTransport>().DisableCallbackReceiver()
                .ConnectionString("host=localhost");
            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.UseSerialization<JsonSerializer>();

            using (var bus = Bus.Create(busConfiguration))
            {
                bus.Start();
                Console.WriteLine("Press Enter to publish");
                Console.ReadKey();
                bus.Send("TestingNSBSerialization.Printer", new SayHello { Message = "Bob!" });
                Console.ReadKey();
            }
        }
    }
}