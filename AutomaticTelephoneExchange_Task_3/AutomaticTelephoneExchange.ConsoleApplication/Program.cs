namespace AutomaticTelephoneExchange.ConcoleApplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Libary.ATE_Models;
    using Libary.AutomaticTelephoneExchange;
    using Libary.BillingSystem;

    class Program
    {
        static void Main(string[] args)
        { 
            BillingSystem billingSystem = new BillingSystem();
            
            using AutomaticTelephoneExchange ATE = new AutomaticTelephoneExchange();

            SubscribeBillingToAte(ATE,billingSystem);
            
            List<Client> clients = new List<Client>() {new Client("Mike"), new Client("Mick"), new Client("Alex")};
            
            List<Terminal> terminals = new List<Terminal>()
                {new Terminal("1111", "1"), new Terminal("2222", "2"), new Terminal("3333", "3")};
            
            List<Contract> contracts = new List<Contract>();
            
            for (int i = 0; i < 3; i++)
            {
                contracts.Add(ATE.AddContractWith(clients[i],terminals[i].PhoneNumber));
            }

            billingSystem.Contracts = contracts;
            
            for (int i = 0; i < 3; i++)
            {
                clients[i].ConnectToPort(terminals[i], ATE.GetNotBindPort());
            }
            
            clients[0].Call(terminals[0],"2222");
            
            clients[2].Call(terminals[2],"2222");
            
            Thread.Sleep(1000);
            
            clients[1].EndCall(terminals[1]);

            Thread.Sleep(1000);
            
            clients[0].Call(terminals[0],"3333");
            
            Thread.Sleep(5000);
            
            clients[0].EndCall(terminals[0]);
            
            clients[0].Call(terminals[0],"2222");
            
            Thread.Sleep(2500);
            
            clients[0].EndCall(terminals[0]);
            
            List<ExendetCallInfo> callInfos = billingSystem.GetCallInfoByDate("1111").ToList();

            Console.WriteLine("\n\n\nСортировка по дате :");
            
            foreach (var call in callInfos)
            {
                Console.WriteLine($"Длительность - {call.Duration.ToString()}\n Цена - {call.Cost}\n Номер абонента которому звонили - {call.OutPhoneNumber} ");
                
            }
            
            Console.WriteLine("\n\n\nСортировка по цене :");
            
            List<ExendetCallInfo> callInfos2 = billingSystem.GetCallInfoByCost("1111").ToList();

            foreach (var call in callInfos2)
            {
                Console.WriteLine($"Длительность - {call.Duration.ToString()}\n Цена - {call.Cost}\n Номер абонента которому звонили - {call.OutPhoneNumber} ");
                
            }
            
            Console.WriteLine("\n\n\nСортировка по номеру :");
            
            List<ExendetCallInfo> callInfos3 = billingSystem.GetCallInfoByOutNumber("1111").ToList();

            foreach (var call in callInfos3)
            {
                Console.WriteLine($"Длительность - {call.Duration.ToString()}\n Цена - {call.Cost}\n Номер абонента которому звонили - {call.OutPhoneNumber} ");
                
            }

            List<Port> ports = new List<Port>(ATE.GetPorts());
            
            for (int i = 0; i < 3; i++)
            {
                clients[i].UnConnectToPort(terminals[i],ports[i]);
            }
            
            UnSubscribeBillingToAte(ATE,billingSystem);
        }
        private static void SubscribeBillingToAte(AutomaticTelephoneExchange automaticTelephoneExchange, BillingSystem billingSystem)
        {
            automaticTelephoneExchange.BillTheCAllEventHandler += billingSystem.BillTheCallEventHandler;
        }
        private static void UnSubscribeBillingToAte(AutomaticTelephoneExchange automaticTelephoneExchange,BillingSystem billingSystem)
        {
            automaticTelephoneExchange.BillTheCAllEventHandler -= billingSystem.BillTheCallEventHandler;
        }

    }
    
}