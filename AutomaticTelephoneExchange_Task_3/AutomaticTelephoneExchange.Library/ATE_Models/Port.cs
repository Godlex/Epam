namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    using System;
    using System.Data;
    using Libary.EventArgs;
    using Library;

    public class Port
    {
        public string PortId;
        public PortState _state;

        public event EventHandler<TerminalToPortConnectedEventArgs> TerminalToPortConnectedEventHandler;
        
        private void OnTerminalToPortConnectedEvent(TerminalToPortConnectedEventArgs e)
        {
            if (TerminalToPortConnectedEventHandler != null)
            {
                TerminalToPortConnectedEventHandler(this, e);
            }
        }
        
        public event EventHandler<TerminalToPortUnConnectedEventArgs> TerminalToPortUnConnectedEventHandler;
        
        private void OnTerminalToPortUnConnectedEvent(TerminalToPortUnConnectedEventArgs e)
        {
            if (TerminalToPortUnConnectedEventHandler != null)
            {
                TerminalToPortUnConnectedEventHandler(this, e);
            }
        }
        
        public event EventHandler<TryCallPortToExchangeEventArgs> TryCallPortToExchangeEventHandler;
        
        private void TryCallPortToExchangeEvent(TryCallPortToExchangeEventArgs e)
        {
            if (TryCallPortToExchangeEventHandler != null)
            {
                TryCallPortToExchangeEventHandler(this, e);
            }
        }
        
        public event EventHandler<EndTryCallPortToExchangeEventArgs> EndTryCallPortToExchangeEventHandler;
        
        private void EndTryCallPortToExchangeEvent(EndTryCallPortToExchangeEventArgs e)
        {
            if (EndTryCallPortToExchangeEventHandler != null)
            {
                EndTryCallPortToExchangeEventHandler(this, e);
            }
        }
        
        public event EventHandler<AcceptCallPortToExchangeEventArgs> AcceptCallPortToExchangeEventHandler;
        
        private void AcceptCallPortToExchangeEvent(AcceptCallPortToExchangeEventArgs e)
        {
            if (AcceptCallPortToExchangeEventHandler != null)
            {
                AcceptCallPortToExchangeEventHandler(this, e);
            }
        }
        
        public event EventHandler<EndCallPortToExchangeEventArgs> EndCallPortToExchangeEventHandler;
        
        private void EndCallPortToExchangeEvent(EndCallPortToExchangeEventArgs e)
        {
            if (EndCallPortToExchangeEventHandler != null)
            {
                EndCallPortToExchangeEventHandler(this, e);
            }
        }

        public Port(string number)
        {
            PortId = number;
            _state = PortState.TerminalNotBind;
        }

        public void Connect(Terminal terminal) //подпиисываемся на терминал 
        {
            _state = PortState.Connect;
            terminal.CallTerminalToPortEventHandler += TerminalOnCallTerminalToPortEventHandler;
            terminal.EndCallTerminalToPortEventHandler+= TerminalOnEndCallTerminalToPortEventHandler;
            OnTerminalToPortConnectedEvent(new TerminalToPortConnectedEventArgs{TerminalId = terminal.id});
        }
        
        public void UnConnect(Terminal terminal) //отписываемся от терминала
        {
            _state = PortState.NotConnect;
            terminal.CallTerminalToPortEventHandler -= TerminalOnCallTerminalToPortEventHandler;
            terminal.EndCallTerminalToPortEventHandler-= TerminalOnEndCallTerminalToPortEventHandler;
            OnTerminalToPortUnConnectedEvent(new TerminalToPortUnConnectedEventArgs{PortID = terminal.id});
        }
        private void TerminalOnCallTerminalToPortEventHandler(object? sender, CallTerminalToPortEventArgs e)
        {
            _state = PortState.Busy;
            TryCallPortToExchangeEvent(new TryCallPortToExchangeEventArgs{CallInfo = e.CallInfo,PhoneNumber = e.PhoneNumber});
            //обращаемся к станции
        }

        public void EndCall()
        {
            _state = PortState.Connect;
            EndTryCallPortToExchangeEvent(new EndTryCallPortToExchangeEventArgs());
        }

        public void AcceptCall()
        {
            _state = PortState.Busy;
            AcceptCallPortToExchangeEvent(new AcceptCallPortToExchangeEventArgs());
        }
        
        private void TerminalOnEndCallTerminalToPortEventHandler(object? sender, EndCallTerminalToPortEventArgs e)
        {
            EndCall();
            EndCallPortToExchangeEvent(new EndCallPortToExchangeEventArgs());
        }
    }
}