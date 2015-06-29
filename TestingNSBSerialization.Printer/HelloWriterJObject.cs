namespace TestingNSBSerialization.Printer
{
    using System;
    using Contracts;
    using NServiceBus;

    public class HelloWriterJObject : IHandleMessages<Object>
    {
        public void Handle(Object message)
        {
            var hello = message as SayHello;
            if (hello != null)
            {
                Console.WriteLine("Saying hello to {0}", hello.Message);
            }
            else
            {
                Console.WriteLine("Received unknown message: {0}", message);
            }
        }

    }
}