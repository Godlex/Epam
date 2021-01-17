namespace AutomaticTelephoneExchange.Libary.ATE_Models
{
    using System;

    public class CallInfo
    {
        public Guid Guid { get; set; }
        public TimeSpan? Duration { get; set; }
        public string OutPhoneNumber { get; set; }
        public string InPhoneNumber { get; set; }
        public DateTime StartCall { get; set; }
    }
}