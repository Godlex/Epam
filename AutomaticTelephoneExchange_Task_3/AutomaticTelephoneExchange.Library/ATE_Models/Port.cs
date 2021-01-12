namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    using System;
    using System.Data;
    using Libary.EventArgs;
    using Library;

    public class Port
    {
        public int PortId;
        public PortState _state;

        public event EventHandler<TerminalToPortConnectedEventArgs> TerminalToPortConnectedEventHandler;
        
        private void OnTerminalToPortConnectedEventArgs(TerminalToPortConnectedEventArgs e)
        {
            if (TerminalToPortConnectedEventHandler != null)
            {
                TerminalToPortConnectedEventHandler(this, e);
            }
        }
        
        public event EventHandler<TerminalToPortUnConnectedEventArgs> TerminalToPortUnConnectedEventHandler;
        
        private void OnTerminalToPortUnConnectedEventArgs(TerminalToPortUnConnectedEventArgs e)
        {
            if (TerminalToPortUnConnectedEventHandler != null)
            {
                TerminalToPortUnConnectedEventHandler(this, e);
            }
        }
        
        public Port(int number)
        {
            PortId = number;
            _state = PortState.TerminalNotBind;
        }

        public void Connect(Terminal terminal) //подпиисываемся на терминал 
        {
            _state = PortState.Connect;
            OnTerminalToPortConnectedEventArgs(new TerminalToPortConnectedEventArgs{terminalID = terminal.id});
        }
        
        public void UnConnect(Terminal terminal) //отписываемся от терминала
        {
            _state = PortState.NotConnect;
            OnTerminalToPortUnConnectedEventArgs(new TerminalToPortUnConnectedEventArgs{terminalID = terminal.id});
        }

        public void Call()
        {
            TryCall()
        }
    }
}