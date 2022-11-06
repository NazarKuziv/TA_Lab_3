using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.LinkLabel;

namespace TA_Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       



        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Random randNum = new Random();
            for (int i = 0; i < 6; i++)
                textBox1.Text += randNum.Next(10, 99).ToString()+" ";

            textBox1.Text = textBox1.Text.Substring(0, (textBox1.TextLength - 1));
        }
        public int[] getArray()
        {
            
                string line = textBox1.Text;
                string[] entries = line.Split(',',' ');
            
            if (entries.Length != 0 || entries.Length < 50)
            {
                int[] arr = new int[entries.Length];
                for (int i = 0; i < entries.Length; i++)
                {
                    arr[i] = Convert.ToInt32(entries[i]);
                    if (arr[i] < 0 || arr[i]>255)
                    {
                        MessageBox.Show("Всі числа повинні бути доданіми і < 255!");
                        return null;
                    }


                }
                return arr;
            }
            else
            {
                MessageBox.Show("Довжина масиву повиння бути < 50!");
                return null;
            }
                
               

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int[] arr;
            arr = getArray();
            if(arr != null)
            {
                try
                {

                    bool isNum = false;
                    int count = 0;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == numericUpDown1.Value)
                        {
                            isNum = true;
                            textBox2.Text += "arr[" + i + "] = " + arr[i] + " ";
                        }
                        count++;
                    }

                    if (isNum == false)
                    {
                        textBox2.Text = "Число не знайдено!";
                    }

                    listBox1.Items.Add("Кількість порівнянь лінійного алгоритму: " + count.ToString());



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int[] arr = getArray();

            
            if (arr != null)
            {
                int[] arr2 = new int[arr.Length + 1];
                for(int i = 0; i < arr.Length; i++)
                {
                    arr2[i] = arr[i];
                }
                arr2[arr2.Length-1] = (int)numericUpDown1.Value;

                try
                {
                    bool isNum = false;
                    int i = 0;

                    while (arr2[i] != (int)numericUpDown1.Value) i++;
                    {

                        if (i < arr.Length)
                        {
                            textBox2.Text += "arr[" + i + "] = " + arr2[i] + " ";
                            isNum = true;
                        }
                        

                        
                    }
                    if (isNum == false)
                    {
                        textBox2.Text = "Число не знайдено!";
                    }

                    listBox1.Items.Add("Кількість порівнянь лінійного алгоритму з бар'єром: "+i);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            int[] arr;
            arr = getArray();
            if (arr != null)
            {
                try
                {
                    Array.Sort(arr);
                    textBox1.Text = "";
                    foreach (int i in arr)
                    {
                        textBox1.Text += i.ToString()+ " ";
                    }
                    textBox1.Text = textBox1.Text.Substring(0, (textBox1.TextLength - 1));

                    bool isNum = false;
                    int count = 0;

                    int minNum = 0;
                    int maxNum = arr.Length - 1;

                    while (minNum <= maxNum)
                    {
                        int i = (minNum + maxNum) / 2;
                        if (arr[i]==numericUpDown1.Value)
                        {
                            isNum = true;
                            textBox2.Text += "arr[" + i + "] = " + arr[i] + " ";
                            break;
                        }
                        else if ((int)numericUpDown1.Value < arr[i])
                        {
                            maxNum = i - 1;
                        }
                        else
                        {
                            minNum = i + 1;
                        }
                        count++;
                    }


                    if (isNum == false)
                    {
                        textBox2.Text = "Число не знайдено!";
                    }

                    listBox1.Items.Add("Кількість порівнянь бінарного флгоритму " + count.ToString());



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
