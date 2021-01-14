namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;
    using System.Dynamic;

    public class AcceptCallPortToExchangeEventArgs : EventArgs
    {
        public CallInfo CallInfo;
    }
}