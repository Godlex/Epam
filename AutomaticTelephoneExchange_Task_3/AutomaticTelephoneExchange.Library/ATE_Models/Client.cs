namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    public class Client
    {
        public string Name;

        public Client(string name)
        {
            Name = name;
        }

        public void ConnectToPort(Terminal terminal,Port port) //PlugInTerminal
        {
            port.Connect(terminal);
        }

        public void Call(Terminal terminal,string number)
        {
            terminal.Call(number);
        }

        public void EndCall(Terminal terminal)
        {
            terminal.EndCall();
        }
    }
}