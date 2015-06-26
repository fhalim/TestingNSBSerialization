namespace TestingNSBSerialization.Conventions
{
    using System;
    using NServiceBus;

    public static class BusConventions
    {
        public static BusConfiguration GetBusConfiguration()
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.UseTransport<RabbitMQTransport>()
                .DisableCallbackReceiver()
                .CustomMessageIdStrategy(m => Guid.NewGuid().ToString())
                .ConnectionString("host=localhost");

            busConfiguration.UsePersistence<InMemoryPersistence>();
            busConfiguration.Conventions()
                .DefiningMessagesAs(t =>
                    t.Name.Equals("JObject", StringComparison.InvariantCultureIgnoreCase) ||
                    t.Name.Equals("SayHello", StringComparison.InvariantCultureIgnoreCase));
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.ScaleOut().UseSingleBrokerQueue();
            return busConfiguration;
        }
    }
}