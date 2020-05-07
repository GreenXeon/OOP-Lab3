using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class FirstCourse : Dish
    {
        protected Souce souce;
        public FirstCourse(string name, int price, int calories, string souce)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.souce = new Souce(souce);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"The first course info: name - " + this.Name +
                ", price - " + this.Price + ", calories - " + this.Calories + ", souce - " + this.souce);
        }
    }
}
