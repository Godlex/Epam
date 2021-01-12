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
        private readonly Dictionary<Port, string> portTerminalMapping;
        public AutomaticTelephoneExchange()
        {
            _ports = new List<Port>() {new Port(1), new Port(2), new Port(3), new Port(4)};
        }

        private void Subscribe()
        {
            foreach (var port in _ports)
            {
                port.TerminalToPortConnectedEventHandler+= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler+= PortOnTerminalToPortUnConnectedEventHandler;
            }
        }

        private void PortOnTerminalToPortUnConnectedEventHandler(object? sender, TerminalToPortUnConnectedEventArgs e)
        {
            portTerminalMapping.Remove(_ports[0]);
        }

        private void UnSubscribe()
        {
            foreach (var port in _ports)
            {
                port.TerminalToPortConnectedEventHandler-= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler-= PortOnTerminalToPortUnConnectedEventHandler;
            }
        }

        private void PortOnTerminalToPortConnectedEventHandler(object? sender, TerminalToPortConnectedEventArgs e)
        {
            portTerminalMapping.Add(_ports[0],e.terminalID);
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
