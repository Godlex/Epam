namespace AutomaticTelephoneExchange.Library.AutomaticTelephoneExchange
{
    using System;
    using System.Collections.Generic;
    using ATE_Models;
    using Libary.EventArgs;

    public class AutomaticTelephoneExchange
    {
        private readonly IList<Port> _ports ;
        public IList<CallInfo> CallsInfo=new List<CallInfo>();
        private readonly Dictionary<Port, string> _portTerminalMapping;
        public AutomaticTelephoneExchange()
        {
            _ports = new List<Port>() {new Port("1"), new Port("2"), new Port("3"), new Port("4")};
        }

        private void UnSubscribe()
        {
            foreach (var port in _ports)
            {
                port.TerminalToPortConnectedEventHandler-= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler-= PortOnTerminalToPortUnConnectedEventHandler;
                port.TryCallPortToExchangeEventHandler -= PortOnTryCallPortToExchangeEventHandler;
                port.EndCallPortToExchangeEventHandler-= PortOnEndCallPortToExchangeEventHandler;
            }
        }

        private void PortOnEndCallPortToExchangeEventHandler(object? sender, EndCallPortToExchangeEventArgs e)
        {
            foreach (var item in _portTerminalMapping)
            {
                if (item.Value == e...)
                {
                    item.Key.EndCall();
                }
            }
        }

        private void Subscribe()
        {
            foreach (var port in _ports)
            {
                port.TerminalToPortConnectedEventHandler+= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler+= PortOnTerminalToPortUnConnectedEventHandler;
                port.TryCallPortToExchangeEventHandler += PortOnTryCallPortToExchangeEventHandler;
            }
        }

        private void PortOnTryCallPortToExchangeEventHandler(object? sender, TryCallPortToExchangeEventArgs e)
        {
            foreach (var item in _portTerminalMapping)
            {
                if (item.Value == e.PhoneNumber && item.Key._state == PortState.Connect)
                {
                    foreach (var itemOut in _portTerminalMapping)
                    {
                        if (itemOut.Value == e.CallInfo.InPhoneNumber)
                        {
                            itemOut.Key.AcceptCall();
                        }
                    }
                    // create call
                }
                else
                {
                    foreach (var itemOut in _portTerminalMapping)
                    {
                        if (itemOut.Value == e.CallInfo.OutPhoneNumber)
                        {
                            itemOut.Key.EndCall();
                        }
                    }
                    //end call
                }
            }
        }

        private void PortOnTerminalToPortUnConnectedEventHandler(object? sender, TerminalToPortUnConnectedEventArgs e)
        {
            foreach (var port in _ports)
            {
                if (port.PortId == e.PortID)
                {
                    _portTerminalMapping.Remove(port);
                }
            }
        }

        private void PortOnTerminalToPortConnectedEventHandler(object? sender, TerminalToPortConnectedEventArgs e)
        {
            foreach (var port in _ports)
            {
                if (port.PortId == e.PortID)
                {
                    _portTerminalMapping.Add(port, e.TerminalId);
                }
            }
        }
        
        

        public Port GetTerminalNotBindPort()
        {
            foreach (var port in _ports)
            {
                if (port._state == PortState.TerminalNotBind)
                {
                    return port;
                }
            }
            throw new Exception("All port is bind");
        }
    }
}
