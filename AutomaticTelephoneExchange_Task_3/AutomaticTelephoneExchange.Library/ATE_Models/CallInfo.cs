namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    using System;

    public class CallInfo
    {
        public readonly Guid Guid = new Guid();
        public TimeSpan? Duration { get; set; }
        public string OutPhoneNumber;
        public string InPhoneNumber;
        public DateTime StartCall;
        
    }
}