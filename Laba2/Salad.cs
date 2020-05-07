using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Salad : Dish
    {
        protected Greens greens;
        protected Souce souce;

        public Salad(string name, int price, int calories, string greens, string souce)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.greens = new Greens(greens);
            this.souce = new Souce(souce);
        }

        public Salad()
        {

        }

        public override void GetInfo()
        {
            Console.WriteLine($"The salad info: name - " + this.Name +
                ", price - " + this.Price + ", calories - " + this.Calories + ", greens - " + this.greens + ", souce - " + this.souce);
        }
    }
}
