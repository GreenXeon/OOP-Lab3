using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public interface IMySerialization
    {
        string MySerialize(List<Dish> dishes, string fileName);
        List<Dish> MyDeserialize(string fileName);

    }
}
