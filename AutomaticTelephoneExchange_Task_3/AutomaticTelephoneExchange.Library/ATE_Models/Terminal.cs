namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    using System;
    using Libary.EventArgs;

    public class Terminal
    {
        public string id; 
        public string PhoneNumber { get; }

        public Port HPort;
        
        public Terminal(string phoneNumber,Port port)
        {
            PhoneNumber = phoneNumber;
            HPort = port;
        }

        public void Call(string number)
        {
            CallInfo callInfo = new CallInfo{Duration = TimeSpan.Zero,InPhoneNumber = PhoneNumber,OutPhoneNumber = number,StartCall = DateTime.Now};
            HPort.EndTryCallPortToExchangeEventHandler+= HPortOnEndTryCallPortToExchangeEventHandler;
            HPort.AcceptCallPortToExchangeEventHandler+= HPortOnAcceptCallPortToExchangeEventHandler;
            CallTerminalToPortEvent(new CallTerminalToPortEventArgs{PhoneNumber = number,CallInfo = callInfo});
        }

        private void HPortOnAcceptCallPortToExchangeEventHandler(object? sender, AcceptCallPortToExchangeEventArgs e)
        {
            Console.WriteLine("Звонок удался");
            //логика разговора
        }

        private void HPortOnEndTryCallPortToExchangeEventHandler(object? sender, EndTryCallPortToExchangeEventArgs e)
        {
            Console.WriteLine("Звонок не удался");
            HPort.EndTryCallPortToExchangeEventHandler-= HPortOnEndTryCallPortToExchangeEventHandler;
            HPort.AcceptCallPortToExchangeEventHandler-= HPortOnAcceptCallPortToExchangeEventHandler;
        }

        public event EventHandler<CallTerminalToPortEventArgs> CallTerminalToPortEventHandler;
        
        private void CallTerminalToPortEvent(CallTerminalToPortEventArgs e)
        {
            if (CallTerminalToPortEventHandler != null)
            {
                CallTerminalToPortEventHandler(this, e);
            }
        }
        
        public event EventHandler<EndCallTerminalToPortEventArgs> EndCallTerminalToPortEventHandler;
        
        private void EndCallTerminalToPortEvent(EndCallTerminalToPortEventArgs e)
        {
            if (EndCallTerminalToPortEventHandler != null)
            {
                EndCallTerminalToPortEventHandler(this, e);
            }
        }

        public void EndCall()
        {
            EndCallTerminalToPortEvent(new EndCallTerminalToPortEventArgs());
        }
    }
}