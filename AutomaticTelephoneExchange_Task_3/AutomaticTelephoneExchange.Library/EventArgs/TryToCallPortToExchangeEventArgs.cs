namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;

    public class TryToCallPortToExchangeEventArgs : EventArgs
    {
        public string PhoneNumber;
        public string OutPhone;
    }
}