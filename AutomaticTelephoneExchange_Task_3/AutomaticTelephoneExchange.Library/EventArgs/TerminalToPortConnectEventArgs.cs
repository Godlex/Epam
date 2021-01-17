namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;

    public class TerminalToPortConnectedEventArgs : EventArgs
    {
        public string PhoneNumber;
        public string PortID;
    }
}