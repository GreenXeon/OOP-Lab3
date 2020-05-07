using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Souce
    {
        private string _souce;

        public string SouceType
        {
            get { return _souce; }
            set { _souce = value; }
        }

        public Souce()
        {

        }

        public Souce(string souce)
        {
            this.SouceType = souce;
        }

        public void GetSouceInfo()
        {
            Console.WriteLine($"Type of souce - " + this.SouceType);
        }
    }
}
