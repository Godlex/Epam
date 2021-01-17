namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;
    using ATE_Models;

    public class CallExchandeToPortEventArgs : EventArgs
    {
        public CallInfo CallInfo;
        public string PortID;
    }
}