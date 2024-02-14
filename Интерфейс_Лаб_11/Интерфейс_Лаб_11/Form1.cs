using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Лаб_11;

namespace Интерфейс_Лаб_11
{
    
    public partial class Form1 : Form
    {
        Arr arr1 = null;
        Arr arr2 = null;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// load default settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            //size identification
            int a1_s = Convert.ToInt32(numericUpDown1.Value);
            int a2_s = Convert.ToInt32(numericUpDown2.Value);

            //creating arrays
            arr1 = new Arr(a1_s);
            arr2 = new Arr(a2_s);

            //filling arrays with elements
            if(radioButton1.Checked == true)
            {
                arr1.RndInput();
            }
            if (radioButton5.Checked == true)
            {
                arr2.RndInput();
            }

            //filling tablets
            arr1.Print("Array 1", label1, dataGridView1);
            arr2.Print("Array 2", label2, dataGridView2);
        }

        /// <summary>
        /// Iput type changing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton4.Checked == true)
            {
                button3.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                numericUpDown1.Enabled = true;
            }

            if (radioButton5.Checked == true || radioButton8.Checked == true)
            {
                button4.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                numericUpDown2.Enabled = true;
            }

            if (radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                if (textBox2.Text == "")
                button3.Enabled = false;
                numericUpDown1.Enabled = true;
            }

            if (radioButton6.Checked == true)
            {
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                if (textBox4.Text == "")
                button4.Enabled = false;
                numericUpDown2.Enabled = true;
            }

            if (radioButton3.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                if (textBox2.Text == "" || textBox1.Text == "")
                button3.Enabled = false;
                numericUpDown1.Enabled = true;
            }

            if (radioButton7.Checked == true)
            {
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                if (textBox3.Text == "" || textBox4.Text == "")
                button4.Enabled = false;
                numericUpDown2.Enabled = true;
            }
        }







        /// <summary>
        /// create array 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            //creating an array
            int a1_s = Convert.ToInt32(numericUpDown1.Value);
            arr1 = new Arr(a1_s);

            //filling an array
            try
            {
                if (radioButton1.Checked)
                {
                    arr1.RndInput();
                }
                else if (radioButton2.Checked)
                {
                    int N2 = Convert.ToInt32(textBox2.Text);
                    arr1.RndInput(N2);
                }
                else if (radioButton3.Checked)
                {
                    int N1 = Convert.ToInt32(textBox1.Text);
                    int N2 = Convert.ToInt32(textBox2.Text);
                    arr1.RndInput(N1, N2);
                }
                else if (radioButton4.Checked)
                {
                    arr1.file_read("H:\\Прикладное Программирование (1 сем)\\Программы\\Интерфейс_Лаб_11\\array1.txt");
                    numericUpDown1.Value = arr1.return_size();
                    numericUpDown1.Enabled = false;
                }
            
           
                //preparing a tablet
                dataGridView1.ColumnCount = a1_s;

                //filling a tablet
                arr1.Print("Array 1", label1, dataGridView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        /// <summary>
        /// create array 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            //creating an array
            int a2_s = Convert.ToInt32(numericUpDown2.Value);
            arr2 = new Arr(a2_s);


            //filling an array
            try
            {

            
                if (radioButton5.Checked)
                {
                    arr2.RndInput();
                }
                else if (radioButton6.Checked)
                {
                    int N2 = Convert.ToInt32(textBox4.Text);
                    arr2.RndInput(N2);
                }
                else if (radioButton7.Checked)
                {
                    int N1 = Convert.ToInt32(textBox3.Text);
                    int N2 = Convert.ToInt32(textBox4.Text);
                    arr2.RndInput(N1, N2);
                }
                else if (radioButton8.Checked)
                {
                    arr2.file_read("H:\\Прикладное Программирование (1 сем)\\Программы\\Интерфейс_Лаб_11\\array2.txt");
                    numericUpDown2.Value = arr2.return_size();
                    numericUpDown2.Enabled = false;
                }

                //preparing a tablet
                dataGridView2.ColumnCount = a2_s;

                //filling a tablet
                arr2.Print("Array 2", label2, dataGridView2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }






        /// <summary>
        /// check the N1 and N2 boxes if changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (textBox2.Text != "" && textBox1.Text != "")
                    button3.Enabled = true;
                else
                    button3.Enabled = false;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (textBox2.Text != "")
                    button3.Enabled = true;
                else
                    button3.Enabled = false;
            } 
            else if (radioButton3.Checked)
            {
                if (textBox2.Text != "" && textBox1.Text != "")
                    button3.Enabled = true;
                else
                    button3.Enabled = false;
            }

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                if (textBox4.Text != "" && textBox3.Text != "")
                    button4.Enabled = true;
                else
                    button4.Enabled = false;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                if (textBox4.Text != "")
                    button4.Enabled = true;
                else
                    button4.Enabled = false;
            }
            else if (radioButton7.Checked)
            {
                if (textBox4.Text != "" && textBox3.Text != "")
                    button4.Enabled = true;
                else
                    button4.Enabled = false;
            }
        }






        /// <summary>
        /// sum arrays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //creating an array
            Arr arr3;
            arr3 = arr1 + arr2;

            //showing it in tablet
            dataGridView3.Visible = true;
            label11.Visible = true;
            arr3.Print("arr1 + arr2 = ", label11, dataGridView3);
        }

        /// <summary>
        /// diff arrays
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //creating an array
            Arr arr3;
            arr3 = arr1 - arr2;

            //showing it in tablet
            dataGridView3.Visible = true;
            label11.Visible = true;
            arr3.Print("arr1 - arr2 = ", label11, dataGridView3);
        }

        /// <summary>
        /// array1++ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            arr1++;
            arr1.Print("Array 1", label1, dataGridView1);
        }

        /// <summary>
        /// array2++
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            arr2++;
            arr2.Print("Array 2", label2, dataGridView2);
        }

        /// <summary>
        /// array1--
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            arr1--;
            arr1.Print("Array 1", label1, dataGridView1);
        }

        /// <summary>
        /// array2--
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            arr2--;
            arr2.Print("Array 2", label2, dataGridView2);
        }

        /// <summary>
        /// array1 + x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            int x = Convert.ToInt32(textBox5.Text);
            arr1 = arr1 + x;
            arr1.Print("Array 1", label1, dataGridView1);
        }

        /// <summary>
        /// array2 + x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            int x = Convert.ToInt32(textBox6.Text);
            arr2 = arr2 + x;
            arr2.Print("Array 2", label2, dataGridView2);
        }

        /// <summary>
        /// array1 - x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            int x = Convert.ToInt32(textBox5.Text);
            arr1 = arr1 - x;
            arr1.Print("Array 1", label1, dataGridView1);
        }

        /// <summary>
        /// array2 - x
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
            dataGridView3.Visible = false;

            int x = Convert.ToInt32(textBox6.Text);
            arr2 = arr2 - x;
            arr2.Print("Array 2", label2, dataGridView2);
        }

        /// <summary>
        /// enable +- x buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox5.Text != "-")
            {
                button7.Enabled = true;
                button8.Enabled = true;
            }
            else
            {
                button7.Enabled = false;
                button8.Enabled = false;
            }

            if (textBox6.Text != "" && textBox6.Text != "-")
            {
                button11.Enabled = true;
                button12.Enabled = true;
            }
            else
            {
                button11.Enabled = false;
                button12.Enabled = false;
            }
        }

        /// <summary>
        /// check textbox (only nums, "-" and backspace)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
                return;
            if (e.KeyChar > '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == '-' && ((TextBox)sender).Text == "")
                return;
            if (e.KeyChar == '0' && ((TextBox)sender).Text != "" && ((TextBox)sender).Text != "-")
                return;
            e.KeyChar = '\0';
        }

        /// <summary>
        /// the variant function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            arr1 = arr1.the_variant_method();
            arr1.Print("Array 1", label1, dataGridView1);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            arr2 = arr2.the_variant_method();
            arr2.Print("Array 2", label2, dataGridView2);
        }
    }
}
