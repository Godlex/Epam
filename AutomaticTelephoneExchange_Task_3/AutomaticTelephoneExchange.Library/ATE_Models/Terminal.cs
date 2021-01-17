namespace AutomaticTelephoneExchange.Libary.ATE_Models
{
    using System;
    using EventArgs;

    public class Terminal
    {
        public string Id { get; set; } 
        public string PhoneNumber { get; set; }

        public Terminal(string phoneNumber,string id)
        {
            Id = id;
            PhoneNumber = phoneNumber;
        }

        public void Dial(string number)
        {
            TryToConnectToPortEvent(new TryToConnectToPortEventArgs{PhoneNumber = PhoneNumber,OutPhone = number});
        }
        public void EndCall()
        {
            //logic call ending
            EndCallTerminalToPortEvent(new EndCallTerminalToPortEventArgs{PhoneNumber = PhoneNumber});//phone uot in 
        }
        public event EventHandler<TryToConnectToPortEventArgs> TryToConnectToPortEventHandler;
        public event EventHandler<EndCallTerminalToPortEventArgs> EndCallTerminalToPortEventHandler;
        
        private void TryToConnectToPortEvent(TryToConnectToPortEventArgs e)
        {
            if (TryToConnectToPortEventHandler != null)
            {
                TryToConnectToPortEventHandler(this, e);
            }
        }
        private void EndCallTerminalToPortEvent(EndCallTerminalToPortEventArgs e)
        {
            if (EndCallTerminalToPortEventHandler != null)
            {
                EndCallTerminalToPortEventHandler(this, e);
            }
        }
    }
}