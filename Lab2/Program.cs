using System;
using System.Collections.Generic;

namespace Lab2
{

    class Dish
    {
        protected string _name;
        protected int _price;
        protected int _calories;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Calories
        {
            get { return _calories; }
            set { _calories = value; }
        }

        public Dish(string name, int price, int calories)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
        }

        public Dish()
        {

        }

        public void GetInfo()
        {
            Console.WriteLine($"The dish info: name - " + this.Name + 
                ", price - " + this.Price + ", calories - " + this.Calories);
        }
    }

    class Salad : Dish
    {
        private Boolean _oil;
        public Boolean Oil
        {
            get { return _oil; }
            set { _oil = value; }
        }

        public Salad(string name, int price, int calories, Boolean oil)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.Oil = oil;
        }
    }

    class Greens
    {
        List<string> greens = new List<string>()
        {
            "mem", "kek", "lol"
        };

        public void GetList()
        {
            int count = 0;
            foreach(string s in greens)
            {
                count++;
                Console.WriteLine($"Element #" + count + " is " + s);
            }
            Console.WriteLine($"There are " + count + " elements");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            /*string name;
            int price;
            int calories;

            Console.WriteLine("Enter dish's name, price and calories:");
            name = Console.ReadLine();
            price = Convert.ToInt32(Console.ReadLine());
            calories = Convert.ToInt32(Console.ReadLine());

            Dish Fries = new Dish(name, price, calories);
            Fries.GetInfo();*/

            List<Dish> dishes = new List<Dish>();
            

        }
    }
}
