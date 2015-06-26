namespace TestingNSBSerialization.Publisher
{
    using System;
    using Contracts;
    using Conventions;
    using NServiceBus;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = Bus.Create(BusConventions.GetBusConfiguration()))
            {
                bus.Start();
                while (true)
                {
                    Console.WriteLine("Press Enter to publish");
                    Console.ReadKey();
                    bus.Send("TestingNSBSerialization.Printer", new SayHello { Message = "Bob!" });
                }
            }
        }
    }
}