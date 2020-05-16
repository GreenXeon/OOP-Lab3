using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    [Serializable]
    class MeatSalad : Salad
    {
        public Meat meat;
        public MeatSalad(string name, int price, int calories, string greens, string souce, string meat)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.greens = new Greens(greens);
            this.souce = new Souce(souce);
            this.meat = new Meat(meat);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"The meat salad info: name - " + this.Name +
                ", price - " + this.Price + ", calories - " + this.Calories + ", greens - " + this.greens
                + ", souce - " + this.souce + ", meat - " + this.meat);
        }
    }
}
