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
            if (listBox2.SelectedIndex != -1)
            {
                MessageBox.Show("Updated!");
            }
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            listBoxInfo.Items.Clear();
            listBoxInfo.Items.Add(Dishes[listBox2.SelectedIndex].Name);
            listBoxInfo.Items.Add(Dishes[listBox2.SelectedIndex].Price.ToString());
            listBoxInfo.Items.Add(Dishes[listBox2.SelectedIndex].Name.ToString());
            if (Dishes[listBox2.SelectedIndex] is Salad)
            {
                Salad curr = Dishes[listBox2.SelectedIndex] as Salad;
                   
            }
        }
    }
}
