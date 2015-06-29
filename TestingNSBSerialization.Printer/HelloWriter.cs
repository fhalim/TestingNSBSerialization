namespace TestingNSBSerialization.Printer
{
    using System;
    using Contracts;
    using NServiceBus;

    public class HelloWriter : IHandleMessages<SayHello>
    {
        public void Handle(SayHello message)
        {
            Console.WriteLine("Hello, {0}", message.Message);
        }
    }
}