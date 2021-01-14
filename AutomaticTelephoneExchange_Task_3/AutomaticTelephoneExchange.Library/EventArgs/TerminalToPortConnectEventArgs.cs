namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;

    public class TerminalToPortConnectedEventArgs : EventArgs
    {
        public string TerminalId;
        public string PortID;
    }
}