namespace AutomaticTelephoneExchange.Libary.ATE_Models
{
    using System;
    using EventArgs;

    public class Port
    {
        public string PortId { get; set; }
        public PortState State { get; set; }

        public Port(string number)
        {
            PortId = number;
            State = PortState.TerminalNotBind;
        }
        public void Connect(Terminal terminal) //подпиисываемся на терминал 
        {
            State = PortState.Connect; // отдельный метод subscribe
            terminal.TryToConnectToPortEventHandler += TerminalOnTryToConnectToPortEventHandler;
            terminal.EndCallTerminalToPortEventHandler+= TerminalOnEndCallTerminalToPortEventHandler;
            OnTerminalToPortConnectedEvent(new TerminalToPortConnectedEventArgs{PhoneNumber = terminal.PhoneNumber,PortID = PortId});
        }
        
        public void UnConnect(Terminal terminal) //отписываемся от терминала
        {
            State = PortState.NotConnect;
            terminal.TryToConnectToPortEventHandler -= TerminalOnTryToConnectToPortEventHandler;
            terminal.EndCallTerminalToPortEventHandler-= TerminalOnEndCallTerminalToPortEventHandler;
            OnTerminalToPortUnConnectedEvent(new TerminalToPortUnConnectedEventArgs{PortID = terminal.Id});
        }
        public event EventHandler<TerminalToPortConnectedEventArgs> TerminalToPortConnectedEventHandler;
        public event EventHandler<TryToCallPortToExchangeEventArgs> TryCallPortToExchangeEventHandler;
        public event EventHandler<TerminalToPortUnConnectedEventArgs> TerminalToPortUnConnectedEventHandler;
        public event EventHandler<EndCallPortToExchangeEventArgs> EndCallPortToExchangeEventHandler;
        public void CallExchandeToPortEventHandler(object? sender, CallExchandeToPortEventArgs e)
        {
            if (PortId == e.PortID)
            {
                Console.WriteLine("Звонок удался");
                State = PortState.Busy;
            }
            //logic Call To terminal
            //logic
        }

        public void EndToTryCallExchandeToPortEventHandler(object? sender, EndToTryCallExchandeToPortEventArgs e)
        {
            if (PortId == e.PortID)
            {
                State = PortState.Connect;
                //logic EndCall To terminal
                Console.WriteLine("Звонок не удался ");
            }
        }
        
        public void EndToCallExchandeToPortEventHandler(object? sender, EndToCallExchandeToPortEventArgs e)
        {
            if (PortId == e.PortID)
            {
                State = PortState.Connect;
                Console.WriteLine("Конец звонка");
                //logic EndCall To terminal
            }
        }
        private void OnTerminalToPortUnConnectedEvent(TerminalToPortUnConnectedEventArgs e)
        {
            if (TerminalToPortUnConnectedEventHandler != null)
            {
                TerminalToPortUnConnectedEventHandler(this, e);
            }
        }

        private void TryToCallPortToExchangeEvent(TryToCallPortToExchangeEventArgs e)
        {
            if (TryCallPortToExchangeEventHandler != null)
            {
                TryCallPortToExchangeEventHandler(this, e);
            }
        }
        private void EndCallPortToExchangeEvent(EndCallPortToExchangeEventArgs e)
        {
            if (EndCallPortToExchangeEventHandler != null)
            {
                EndCallPortToExchangeEventHandler(this, e);
            }
        }
        
        private void TerminalOnTryToConnectToPortEventHandler(object? sender, TryToConnectToPortEventArgs e)
        {
            if (State != PortState.Busy)
            {
                State = PortState.Busy;
                TryToCallPortToExchangeEvent(new TryToCallPortToExchangeEventArgs
                    {PhoneNumber = e.PhoneNumber, OutPhone = e.OutPhone});
                //обращаемся к станции
                //exeption
            }
        }

        private void TerminalOnEndCallTerminalToPortEventHandler(object? sender, EndCallTerminalToPortEventArgs e)
        {
            if (State == PortState.Connect)
            {
                Console.WriteLine("Он не подключён!");
            }
            else
            {
                EndCallPortToExchangeEvent(new EndCallPortToExchangeEventArgs {PhoneNumber = e.PhoneNumber});
            }
        }
        private void OnTerminalToPortConnectedEvent(TerminalToPortConnectedEventArgs e)
        {
            if (TerminalToPortConnectedEventHandler != null)
            {
                TerminalToPortConnectedEventHandler(this, e);
            }
        }
        
        //startCallEventHandler{create CallInfo an dadd to collection 
    }
}