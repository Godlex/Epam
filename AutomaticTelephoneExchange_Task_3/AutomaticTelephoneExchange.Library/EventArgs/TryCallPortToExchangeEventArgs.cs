namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;
    using Library.ATE_Models;

    public class TryCallPortToExchangeEventArgs : EventArgs
    {
        public string PhoneNumber;
        public CallInfo CallInfo;
    }
}