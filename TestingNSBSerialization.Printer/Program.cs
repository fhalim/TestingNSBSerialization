namespace TestingNSBSerialization.Printer
{
    using System;
    using Conventions;
    using NServiceBus;

    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var bus = Bus.Create(BusConventions.GetBusConfiguration()))
            {
                bus.Start();
                Console.ReadLine();
            }
        }
    }
}