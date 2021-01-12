namespace AutomaticTelephoneExchange.Library.ATE_Models
{
    public class Terminal
    {
        public string id;
        public int PhoneNumber { get; }
        
        

        public Terminal(int phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}