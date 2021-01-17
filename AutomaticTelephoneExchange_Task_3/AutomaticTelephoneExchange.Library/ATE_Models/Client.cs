namespace AutomaticTelephoneExchange.Libary.ATE_Models
{
    public class Client
    {
        private string _name;
        
        public Client(string name)
        {
            _name = name;
        }

        public void ConnectToPort(Terminal terminal,Port port) //PlugInTerminal
        {
            port.Connect(terminal);
        }
        public void UnConnectToPort(Terminal terminal,Port port) //PlugInTerminal
        {
            port.UnConnect(terminal);
        }
        public void Call(Terminal terminal,string number)
        {
            terminal.Dial(number);
        }

        public void EndCall(Terminal terminal)
        {
            terminal.EndCall();
        }
    }
}