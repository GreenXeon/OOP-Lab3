using System;
using System.Collections.Generic;

namespace Test
{
    class Client
    {
        private string _name;
        private string _surname;
        private int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public void GetInfo()
        {
            Console.WriteLine("Enter the name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the surname: ");
            Surname = Console.ReadLine();
            Console.WriteLine("Enter the age: ");
            Age = Convert.ToInt32(Console.ReadLine());
        }
        public Client()
        {
            Name = "Null";
            Surname = "Null";
            Age = 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> CatalogClients = new List<Client>();
            int count = 1;
            while (count != 0)
            {
                Client client = new Client();
                client.GetInfo();
                CatalogClients.Add(client);
                Console.WriteLine("Enter number: ");
                count = Convert.ToInt32(Console.ReadLine());
            }

            foreach(Client client in CatalogClients)
            {
                if (client.Name == "Zakhar")
                {
                    Console.WriteLine("Name: {0}, Surname: {1}, Age: {2}", client.Name, client.Surname, client.Age);
                }
            }
        }
    }
}
