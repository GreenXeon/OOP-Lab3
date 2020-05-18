using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba3
{
    class TextSerialization:IMySerialization
    {
        public string MySerialize(List<Dish> dishes, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (Dish dish in dishes)
                    {
                        string res = "";
                        if (dish is MeatSalad)
                        {
                            MeatSalad newDish = dish as MeatSalad;
                            res = $"0;{newDish.Name};{newDish.Price.ToString()};{newDish.Calories.ToString()};" +
                                $"{newDish.greens.GreensType};{newDish.meat.MeatType};{newDish.souce.SouceType}\n";
                            sw.Write(res);
                        }
                        else
                        if (dish is Salad)
                        {
                            Salad newDish = dish as Salad;
                            res = $"1;{newDish.Name};{newDish.Price.ToString()};{newDish.Calories.ToString()};" +
                                $"{newDish.greens.GreensType};{newDish.souce.SouceType}\n";
                            sw.Write(res);
                        }
                        else
                        if (dish is FirstCourse)
                        {
                            FirstCourse newDish = dish as FirstCourse;
                            res = $"2;{newDish.Name};{newDish.Price.ToString()};{newDish.Calories.ToString()};" +
                                $"{newDish.souce.SouceType}\n";
                            sw.Write(res);
                        }
                        else
                        if (dish is Dish)
                        {
                            res = $"3;{dish.Name};{dish.Price.ToString()};{dish.Calories.ToString()}\n";
                            sw.Write(res);
                        }
                    }
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Dish> MyDeserialize(string fileName)
        {
            List<Dish> dishes = new List<Dish>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string dishStr = "";
                while (!sr.EndOfStream)
                {
                    dishStr = sr.ReadLine();
                    string[] arr = dishStr.Split(';');
                    if (arr[0].Equals("0")){
                        MeatSalad newMS = new MeatSalad();
                        newMS.greens = new Greens();
                        newMS.meat = new Meat();
                        newMS.souce = new Souce();
                        newMS.Name = arr[1];
                        newMS.Price = Convert.ToInt32(arr[2]);
                        newMS.Calories = Convert.ToInt32(arr[3]);
                        newMS.greens.GreensType = arr[4];
                        newMS.meat.MeatType = arr[5];
                        newMS.souce.SouceType = arr[6];
                        dishes.Add(newMS);
                    }
                    else
                    if (arr[0].Equals("1"))
                    {
                        Salad newS = new Salad();
                        newS.Name = arr[1];
                        newS.greens = new Greens();
                        newS.souce = new Souce();
                        newS.Price = Convert.ToInt32(arr[2]);
                        newS.Calories = Convert.ToInt32(arr[3]);
                        newS.greens.GreensType = arr[4];
                        newS.souce.SouceType = arr[5];
                        dishes.Add(newS);
                    }
                    else
                    if (arr[0].Equals("2"))
                    {
                        FirstCourse newFC = new FirstCourse();
                        newFC.souce = new Souce();
                        newFC.Name = arr[1];
                        newFC.Price = Convert.ToInt32(arr[2]);
                        newFC.Calories = Convert.ToInt32(arr[3]);
                        newFC.souce.SouceType = arr[4];
                        dishes.Add(newFC);
                    }
                    else
                    if (arr[0].Equals("3"))
                    {
                        Dish newDish = new Dish();
                        newDish.Name = arr[1];
                        newDish.Price = Convert.ToInt32(arr[2]);
                        newDish.Calories = Convert.ToInt32(arr[3]);
                        dishes.Add(newDish);                       
                    }
                    arr = null;
                }
            }
            return dishes;
        }
    }
}
