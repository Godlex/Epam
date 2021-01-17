namespace AutomaticTelephoneExchange.Libary.AutomaticTelephoneExchange
{
    using System;
    using System.Collections.Generic;
    using ATE_Models;
    using EventArgs;

    public interface IAutomaticTelephoneExchange
    {
        public void Dispose();
        public void UnSubscribe();
        public Contract AddContractWith(Client client, string number);
        public Port GetNotBindPort();
        public IList<Port> GetPorts();
        
        public event EventHandler<EndToTryCallExchandeToPortEventArgs> EndToTryCallExchandeToPortEventHandler;
        public event EventHandler<BillTheCallEventArgs> BillTheCAllEventHandler;
        public event EventHandler<CallExchandeToPortEventArgs> CallExchandeToPortEventHandler;
        public event EventHandler<EndToCallExchandeToPortEventArgs> EndToCallExchandeToPortEventHandler;
        
    }
}