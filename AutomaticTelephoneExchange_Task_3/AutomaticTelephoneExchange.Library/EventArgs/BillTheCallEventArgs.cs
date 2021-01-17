namespace AutomaticTelephoneExchange.Libary.EventArgs
{
    using System;
    using ATE_Models;

    public class BillTheCallEventArgs : EventArgs
    {
       public CallInfo CallInfo;
    }
}