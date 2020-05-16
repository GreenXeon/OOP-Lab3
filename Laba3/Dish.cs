using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    [Serializable]
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

        public virtual void GetInfo()
        {
            Console.WriteLine($"The dish info: name - " + this.Name +
                ", price - " + this.Price + ", calories - " + this.Calories);
        }
    }
}
