using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    [Serializable]
    class Greens
    {
        private string _greens;

        public string GreensType
        {
            get { return _greens; }
            set { _greens = value; }
        }
        
        public Greens()
        {

        }

        public Greens(string greens)
        {
            this.GreensType = greens;
        }

        public void GetGreensInfo()
        {
            Console.WriteLine($"Type of greens - " + this.GreensType);
        }
    }
}
