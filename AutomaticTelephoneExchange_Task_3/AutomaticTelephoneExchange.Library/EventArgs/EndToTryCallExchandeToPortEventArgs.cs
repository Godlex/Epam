namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;

    public class EndToTryCallExchandeToPortEventArgs : EventArgs
    {
        public string PhoneNumber;
        public string PortID;
    }
}