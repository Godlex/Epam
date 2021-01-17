namespace AutomaticTelephoneExchange.Libary.AutomaticTelephoneExchange
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ATE_Models;
    using EventArgs;

    public class AutomaticTelephoneExchange : IDisposable , IAutomaticTelephoneExchange
    {
        private readonly IList<Port> _ports ;
        private readonly IList<CallInfo> _callsInfo = new List<CallInfo>();
        private readonly Dictionary<Port, string> _portTerminalMapping = new Dictionary<Port, string>();
        public AutomaticTelephoneExchange()
        {
            _ports = new List<Port>() {new Port("1"), new Port("2"), new Port("3"), new Port("4")};
            foreach (var port in _ports)
            {
                EndToTryCallExchandeToPortEventHandler += port.EndToTryCallExchandeToPortEventHandler;
                CallExchandeToPortEventHandler += port.CallExchandeToPortEventHandler;
                EndToCallExchandeToPortEventHandler += port.EndToCallExchandeToPortEventHandler;
            }
            Subscribe();
        }
        
        public void Dispose()
        {
            foreach (var port in _ports)
            {
                EndToTryCallExchandeToPortEventHandler -= port.EndToTryCallExchandeToPortEventHandler;
                CallExchandeToPortEventHandler -= port.CallExchandeToPortEventHandler;
                EndToCallExchandeToPortEventHandler -=port.EndToCallExchandeToPortEventHandler;
            }
        }
        
        public void UnSubscribe()
        {
            foreach (var port in _ports) //ATE subscribe to Port
            {
                port.TerminalToPortConnectedEventHandler-= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler-= PortOnTerminalToPortUnConnectedEventHandler;
                port.TryCallPortToExchangeEventHandler -= PortOnTryCallPortToExchangeEventHandler;
                port.EndCallPortToExchangeEventHandler-= PortOnEndCallPortToExchangeEventHandler;
            }
        }
        public Contract AddContractWith(Client client,string number)
        {
            Tariff tariff = new Tariff(15.2f, "Default");
            return new Contract {Client = client, PhoneNumber = number, Tariff = tariff};
        }
        
        public Port GetNotBindPort()
        {
            return _ports.FirstOrDefault(port => port.State == PortState.TerminalNotBind);
            
        }
        public IList<Port> GetPorts()
        {
            return _ports;
        }
        
        public event EventHandler<EndToTryCallExchandeToPortEventArgs> EndToTryCallExchandeToPortEventHandler;
        public event EventHandler<BillTheCallEventArgs> BillTheCAllEventHandler;
        public event EventHandler<CallExchandeToPortEventArgs> CallExchandeToPortEventHandler;
        public event EventHandler<EndToCallExchandeToPortEventArgs> EndToCallExchandeToPortEventHandler;

        private void EndToCallExchandeToPortEvent(EndToCallExchandeToPortEventArgs e)
        {
            if (EndToCallExchandeToPortEventHandler != null)
            {
                EndToCallExchandeToPortEventHandler(this, e);
            }
        }

        private CallInfo getActiveCallByPhoneNumber(string phoneNumber)
        {
            return _callsInfo.FirstOrDefault(info => (info.InPhoneNumber == phoneNumber && info.Duration == null)||(info.OutPhoneNumber == phoneNumber && info.Duration == null));
        }

        private void Subscribe()
        {
            foreach (var port in _ports)
            {
                port.TerminalToPortConnectedEventHandler+= PortOnTerminalToPortConnectedEventHandler;
                port.TerminalToPortUnConnectedEventHandler+= PortOnTerminalToPortUnConnectedEventHandler;
                port.TryCallPortToExchangeEventHandler += PortOnTryCallPortToExchangeEventHandler;
                port.EndCallPortToExchangeEventHandler+= PortOnEndCallPortToExchangeEventHandler;
            }
        }

        private Port GetPortByPhoneNumber(string phoneNumber)
        {
            KeyValuePair<Port, string> neededPort = _portTerminalMapping.FirstOrDefault(pair =>
               pair.Value == phoneNumber);
            return neededPort.Key;
        }
        private void PortOnTryCallPortToExchangeEventHandler(object? sender, TryToCallPortToExchangeEventArgs e)
        {
            Port neededPort = GetPortByPhoneNumber(e.OutPhone);
            if (neededPort.State == PortState.Connect)
            {
                CallInfo call = new CallInfo
                    {Duration = null,InPhoneNumber = e.PhoneNumber, OutPhoneNumber = e.OutPhone, StartCall = DateTime.Now,Guid = Guid.NewGuid()};
                _callsInfo.Add(call); // Добовляем в биллинговую систему
                CallExchandeToPortEvent(new CallExchandeToPortEventArgs{CallInfo = call,PortID = GetPortByPhoneNumber(e.OutPhone).PortId});
                //звонок начинаем
            }
            else
            {
                EndToTryCallExchandeToPortEvent(new EndToTryCallExchandeToPortEventArgs{PhoneNumber = e.PhoneNumber,PortID = GetPortByPhoneNumber(e.PhoneNumber).PortId});
                //закканчиваем звонок
            }
        }

        private void BillTheCAllEvent(BillTheCallEventArgs e)
        {
            if (BillTheCAllEventHandler != null)
            {
                BillTheCAllEventHandler(this, e);
            }
        }

        private void CallExchandeToPortEvent(CallExchandeToPortEventArgs e)
        {
            if (CallExchandeToPortEventHandler != null)
            {
                CallExchandeToPortEventHandler(this, e);
            }
        }

        private void EndToTryCallExchandeToPortEvent(EndToTryCallExchandeToPortEventArgs e)
        {
            if (EndToTryCallExchandeToPortEventHandler != null)
            {
                EndToTryCallExchandeToPortEventHandler(this, e);
            }
        }
      

        private void PortOnTerminalToPortUnConnectedEventHandler(object? sender, TerminalToPortUnConnectedEventArgs e)
        {
            Port port = _ports.FirstOrDefault(x => x.PortId == e.PortID);
            _portTerminalMapping.Remove(port);
        }

        private void PortOnTerminalToPortConnectedEventHandler(object? sender, TerminalToPortConnectedEventArgs e)
        {
            Port port = _ports.FirstOrDefault(x => x.PortId == e.PortID);
            _portTerminalMapping.Add(port, e.PhoneNumber);
        }
        
        private void PortOnEndCallPortToExchangeEventHandler(object? sender, EndCallPortToExchangeEventArgs e)
        {
            CallInfo activeCall = getActiveCallByPhoneNumber(e.PhoneNumber);
            activeCall.Duration = DateTime.Now - activeCall.StartCall;
            BillTheCAllEvent(new BillTheCallEventArgs{CallInfo = activeCall});
            EndToCallExchandeToPortEvent(new EndToCallExchandeToPortEventArgs{PortID = GetPortByPhoneNumber(activeCall.OutPhoneNumber).PortId});
            EndToCallExchandeToPortEvent(new EndToCallExchandeToPortEventArgs{PortID = GetPortByPhoneNumber(activeCall.InPhoneNumber).PortId});
        }
    }
}
