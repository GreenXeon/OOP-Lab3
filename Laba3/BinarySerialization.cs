using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Laba3
{
    public class BinarySerialization : IMySerialization
    {
        public string MySerialize(List<Dish> dishes, string fileName)
        {
            try
            {
                BinaryFormatter binForm = new BinaryFormatter();
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    binForm.Serialize(fs, dishes);
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Dish> MyDeserialize(string fileName)
        {
            List<Dish> dishes = new List<Dish>();
            BinaryFormatter binForm = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                dishes = (List<Dish>)binForm.Deserialize(fs);
            }
            return dishes;
        }
    }
}
