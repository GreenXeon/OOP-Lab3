using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBoxTypes.SelectedIndex = 0;
        }
        List<Dish> Dishes = new List<Dish>();

        public bool CheckData()
        {
            if (textBoxName.Text == "" || textBoxPrice.Text == "" || textBoxCalories.Text == "")
            {
                return false;
            }
            else
            if ((textBox1.Visible == true && textBox1.Text == "") || (textBox2.Visible == true && textBox2.Text == "")
                || (textBox3.Visible == true && textBox3.Text == ""))
                return false;
            else return true;
        }

        public void ClearBoxes()
        {
            textBoxName.Text = "";
            textBoxPrice.Text = "";
            textBoxCalories.Text = "";
            if (textBox1.Visible) textBox1.Text = "";
            if (textBox2.Visible) textBox2.Text = "";
            if (textBox3.Visible) textBox3.Text = "";
        }

        private static Dish GetFoodInstance(string name, int price, int calories, string dishType, Meat meat, Greens greens, Souce souce)
        {
            if (dishType.Equals("Блюдо"))
                return new Dish(name, price, calories);
            else
            if (dishType.Equals("Салат"))
                return new Salad(name, price, calories, greens.GreensType, souce.SouceType);
            else
            if (dishType.Equals("Мясной салат"))
                return new MeatSalad(name, price, calories, greens.GreensType, souce.SouceType, meat.MeatType);
            else
            if (dishType.Equals("Основное блюдо"))
                return new FirstCourse(name, price, calories, souce.SouceType);
            else
                throw new Exception(dishType + " не существует в списке назначений!");
        } 
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (!CheckData())
                MessageBox.Show("Введите все данные!");
            else
            {
                Meat meat = new Meat();
                Greens greens = new Greens();
                Souce souce = new Souce();

                if (comboBoxTypes.SelectedIndex == 1)
                {
                    greens = new Greens(Convert.ToString(textBox3.Text));
                    souce = new Souce(Convert.ToString(textBox2.Text));
                }
                else
                if (comboBoxTypes.SelectedIndex == 2)
                {
                    meat = new Meat(Convert.ToString(textBox1.Text));
                    greens = new Greens(Convert.ToString(textBox3.Text));
                    souce = new Souce(Convert.ToString(textBox2.Text));
                }
                else
                if (comboBoxTypes.SelectedIndex == 3)
                {
                    souce = new Souce(Convert.ToString(textBox3.Text));
                }

                Dish dish = GetFoodInstance(textBoxName.Text.ToString(), Convert.ToInt32(textBoxPrice.Text), Convert.ToInt32(textBoxCalories.Text),
                    comboBoxTypes.Text.ToString(), meat, greens, souce);
                Dishes.Add(dish);
                listBox2.Items.Add(textBoxName.Text.ToString());
                ClearBoxes();
            }
        }

        private void comboBoxTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTypes.SelectedIndex == 0)
            {
                label8.Visible = false;
                label7.Visible = false;
                label6.Visible = false;
                textBox3.Visible = false;
                textBox2.Visible = false;
                textBox1.Visible = false;
            }
            else 
            if (comboBoxTypes.SelectedIndex == 1)
            {
                label8.Visible = true;
                label7.Visible = true;
                label6.Visible = false;
                textBox3.Visible = true;
                label8.Text = "Зелень";
                textBox2.Visible = true;
                label7.Text = "Соус";
                textBox1.Visible = false;
            }
            else
            if (comboBoxTypes.SelectedIndex == 2)
            {
                label8.Visible = true;
                label7.Visible = true;
                label6.Visible = true;
                textBox3.Visible = true;
                label8.Text = "Зелень";
                textBox2.Visible = true;
                label7.Text = "Соус";
                textBox1.Visible = true;
                label6.Text = "Мясо";
            }
            else
            if (comboBoxTypes.SelectedIndex == 3)
            {
                label8.Visible = true;
                label7.Visible = false;
                label6.Visible = false;
                textBox3.Visible = true;
                label8.Text = "Соус";
                textBox2.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if ((listBox2.SelectedIndex != -1) && CheckData())
            {
                Dishes[listBox2.SelectedIndex].Name = textBoxName.Text.ToString();
                Dishes[listBox2.SelectedIndex].Price = Convert.ToInt32(textBoxPrice.Text);
                Dishes[listBox2.SelectedIndex].Calories = Convert.ToInt32(textBoxCalories.Text);
                if (Dishes[listBox2.SelectedIndex].GetType().ToString() == "Salad")
                {
                    Salad curr = Dishes[listBox2.SelectedIndex] as Salad;
                    curr.greens.GreensType = textBox3.Text.ToString();
                    curr.souce.SouceType = textBox2.Text.ToString();
                }
                else
                if (Dishes[listBox2.SelectedIndex].GetType().ToString() == "MeatSalad")
                {
                    MeatSalad curr = Dishes[listBox2.SelectedIndex] as MeatSalad;
                    curr.greens.GreensType = textBox3.Text.ToString();
                    curr.souce.SouceType = textBox2.Text.ToString();
                    curr.meat.MeatType = textBox1.Text.ToString();
                }
                else
                if (Dishes[listBox2.SelectedIndex].GetType().ToString() == "FirstCourse")
                {
                    FirstCourse curr = Dishes[listBox2.SelectedIndex] as FirstCourse;
                    curr.souce.SouceType = textBox2.Text.ToString();
                }
                MessageBox.Show($"Блюдо {Dishes[listBox2.SelectedIndex].Name} успешно обновлено!");
                listBoxInfo.Items.Clear();
                
            }
            else
                MessageBox.Show("Выберите блюдо или введите данные!");
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                listBoxInfo.Items.Clear();
                listBoxInfo.Items.Add($"Название - {Dishes[listBox2.SelectedIndex].Name}");
                textBoxName.Text = Dishes[listBox2.SelectedIndex].Name;
                listBoxInfo.Items.Add($"Цена - {Dishes[listBox2.SelectedIndex].Price.ToString()}");
                textBoxPrice.Text = Dishes[listBox2.SelectedIndex].Price.ToString();
                listBoxInfo.Items.Add($"Калории - {Dishes[listBox2.SelectedIndex].Calories.ToString()}");
                textBoxCalories.Text = Dishes[listBox2.SelectedIndex].Calories.ToString();
                if (Dishes[listBox2.SelectedIndex] is MeatSalad)
                {
                    MeatSalad curr = Dishes[listBox2.SelectedIndex] as MeatSalad;

                    listBoxInfo.Items.Add($"Зелень - {curr.greens.GreensType}");
                    listBoxInfo.Items.Add($"Соус - {curr.souce.SouceType}");
                    listBoxInfo.Items.Add($"Мясо - {curr.meat.MeatType}");

                    label8.Visible = true;
                    label7.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    label8.Text = "Зелень";
                    textBox2.Visible = true;
                    label7.Text = "Соус";
                    textBox1.Visible = true;
                    label6.Text = "Мясо";

                    comboBoxTypes.SelectedIndex = 2;
                    textBox3.Text = curr.greens.GreensType.ToString();
                    textBox2.Text = curr.souce.SouceType.ToString();
                    textBox1.Text = curr.meat.MeatType.ToString();
                }
                else
                if (Dishes[listBox2.SelectedIndex] is Salad)
                {
                    Salad curr = Dishes[listBox2.SelectedIndex] as Salad;
                    listBoxInfo.Items.Add($"Зелень - {curr.greens.GreensType}");
                    listBoxInfo.Items.Add($"Соус - {curr.souce.SouceType}");

                    label8.Visible = true;
                    label7.Visible = true;
                    label6.Visible = false;
                    textBox3.Visible = true;
                    label8.Text = "Зелень";
                    textBox2.Visible = true;
                    label7.Text = "Соус";
                    textBox1.Visible = false;

                    comboBoxTypes.SelectedIndex = 1;
                    textBox3.Text = curr.greens.GreensType.ToString();
                    textBox2.Text = curr.souce.SouceType.ToString();
                }
                else
                if (Dishes[listBox2.SelectedIndex] is FirstCourse)
                {
                    FirstCourse curr = Dishes[listBox2.SelectedIndex] as FirstCourse;
                    listBoxInfo.Items.Add($"Соус - {curr.souce.SouceType}");

                    label8.Visible = true;
                    label7.Visible = false;
                    label6.Visible = false;
                    textBox3.Visible = true;
                    label8.Text = "Соус";
                    textBox2.Visible = false;
                    textBox1.Visible = false;

                    comboBoxTypes.SelectedIndex = 3;
                    textBox3.Text = curr.souce.SouceType.ToString();
                }
                else
                {
                    label8.Visible = false;
                    label7.Visible = false;
                    label6.Visible = false;
                    textBox3.Visible = false;
                    textBox2.Visible = false;
                    textBox1.Visible = false;
                    comboBoxTypes.SelectedIndex = 0;
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                Dishes.RemoveAt(listBox2.SelectedIndex);
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                listBoxInfo.Items.Clear();
                MessageBox.Show("Блюдо успешно удалено!");
                ClearBoxes();
            }
            else
                MessageBox.Show("Выберите блюдо для удаления!");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearBoxes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
