namespace TestingNSBSerialization.Printer
{
    using System;
    using Newtonsoft.Json.Linq;
    using NServiceBus;

    public class HelloWriterJObject : IHandleMessages<JObject>
    {
        public void Handle(JObject message)
        {
            Console.WriteLine("Received message: {0}", message);
        }
    }
}