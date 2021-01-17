namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;

    public class TryToConnectToPortEventArgs : EventArgs
    {
        public string PhoneNumber;
        public string OutPhone;
    }
}