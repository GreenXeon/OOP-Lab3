using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Meat
    {
        private string _meat;

        public string MeatType
        {
            get { return _meat; }
            set { _meat = value; }
        }
        
        public Meat()
        {

        }

        public Meat(string meat)
        {
            this.MeatType = meat;
        }

        public void GetMeatInfo()
        {
            Console.WriteLine($"Type of meat - " + this.MeatType);
        }
    }
}
