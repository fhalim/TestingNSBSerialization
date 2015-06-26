namespace TestingNSBSerialization.Contracts
{
    using NServiceBus;

    public class SayHello:ICommand
    {
        public string Message { get; set; }
    }
}
