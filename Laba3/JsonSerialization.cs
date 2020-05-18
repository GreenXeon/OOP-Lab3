using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Laba3
{
    public class JsonSerialization : IMySerialization
    {
        public string MySerialize(List<Dish> dishes, string fileName)
        {
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    string jsonString = JsonSerializer.Serialize<List<Dish>>(dishes);
                    byte[] arr = Encoding.Default.GetBytes(jsonString);
                    fs.Write(arr, 0, arr.Length);
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
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] arr = new byte[fs.Length];
                fs.Read(arr, 0, arr.Length);
                string jsonBytes = Encoding.Default.GetString(arr);
                List<Dish> dishes = JsonSerializer.Deserialize<List<Dish>>(jsonBytes);
                return dishes;
            }
        }
            
    }
}
