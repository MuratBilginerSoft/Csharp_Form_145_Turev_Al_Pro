using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Türev_Al_Pro_App_v._1._0._0
{
    public partial class Form1 : Form
    {
        #region Metodlar

        public void Temizlik()
        {
            textBox1.Text = "1";
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        public void Değerata()
        {
            #region Textbox1

            if (textBox1.Text == "1" || textBox1.Text == "")
            {
                sabitdeğer[a] = 1;

            }

            else
            {
                sabitdeğer[a] = int.Parse(textBox1.Text);
            }

            #endregion

            #region Combobox1


            if (comboBox1.Text == "Var")
            {
                x1[a] = "x1";
            }

            else
            {
                x1[a] = "";
            }

            #endregion

            #region Combobox2

            if (comboBox2.Text == "Var")
            {
                x2[a] = "x2";
            }

            else
            {
                x2[a] = "";
            }

            #endregion

            #region Textbox2

            if (textBox2.Text != "")
            {
                x1üzeri[a] = int.Parse(textBox2.Text);
            }

            else if (comboBox1.Text == "Var" && textBox2.Text == "")
            {
                x1üzeri[a] = 1;
            }

            else
            {
                x1üzeri[a] = 0;
            }

            #endregion

            #region Textbox3

            if (textBox3.Text != "")
            {
                x2üzeri[a] = int.Parse(textBox3.Text);
            }

            else if (comboBox2.Text == "Var" && textBox3.Text == "")
            {
                x2üzeri[a] = 1;
            }

            else
            {
                x2üzeri[a] = 0;
            }

            #endregion


        }

        public void İfadeyaz()
        {
            label2.Text += sabitdeğer[a].ToString();

            if (x1[a] != "" && x1üzeri[a] != 0)
            {
                label2.Text += "*(" + x1[a] + "^" + x1üzeri[a] + ")";
            }

            if (x2[a] != "" && x2üzeri[a] != 0)
            {
                label2.Text += "*(" + x2[a] + "^" + x2üzeri[a] + ")";
            }

        }

        #endregion

        #region Tanımlamalar

        int[] sabitdeğer = new int[50];
        string[] x1 = new string[50];
        string[] x2 = new string[50];
        int[] x1üzeri = new int[50];
        int[] x2üzeri = new int[50];
        string[] işlem = new string[50];

        int[] x1türevsabit = new int[50];
        int[] x1türevx1 = new int[50];
        int[] x1türevx2 = new int[50];

        int[] x2türevsabit = new int[50];
        int[] x2türevx1 = new int[50];
        int[] x2türevx2 = new int[50];

        int a = 0;
        int b = 0;

        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Ekstralar

            if (a == 0)
            {
                groupBox2.Enabled = true;
            }

            #endregion

            #region İlkdeğer


            if (a == 0)
            {
                Değerata();
                İfadeyaz();
                Temizlik();
                a++;
            }

            #endregion

            #region DiğerDeğerler

            else
            {
                if (radioButton1.Checked != true && radioButton2.Checked != true)
                {
                    MessageBox.Show("Bir işlem değeri seçmeden devam edemessiniz!!!");

                }

                #region İşlem

                if (radioButton1.Checked == true)
                {
                    işlem[a] = "+";
                }

                else if (radioButton2.Checked == true)
                {
                    işlem[a] = "-";
                }

                #endregion

                label2.Text += " " + işlem[a];

                Değerata();

                İfadeyaz();

                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    Temizlik();
                    a++;
                }


            }

            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {

            #region X1 E Göre Türev

            for (int i = 0; i < a; i++)
            {
                if (i == 0)
                {
                    if (x1[b] != "" && x1üzeri[b] != 0 && x1üzeri[b] != 1 && x2[b] != "")
                    {
                        x1türevsabit[b] = sabitdeğer[b] * (x1üzeri[b]);
                        label8.Text += x1türevsabit[b] + "*(" + x1[b] + "^" + (x1üzeri[b] - 1) + ")*(" + x2[b] + "^" + x2üzeri[b] + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] != "" && x1üzeri[b] != 0 && x1üzeri[b] != 1 && x2[b] == "")
                    {
                        x1türevsabit[b] = sabitdeğer[b] * (x1üzeri[b]);
                        label8.Text += x1türevsabit[b] + "*(" + x1[b] + "^" + (x1üzeri[b] - 1) + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] != "" && x1üzeri[b] == 1 && x2[b] != "")
                    {
                        x1türevsabit[b] = sabitdeğer[b];
                        label8.Text += x1türevsabit[b] + "*(" + x2[b] + "^" + x2üzeri[b] + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];

                    }

                    else if (x1[b] != "" && x1üzeri[b] == 1 && x2[b] == "")
                    {
                        x1türevsabit[b] = sabitdeğer[b];
                        label8.Text += x1türevsabit[b];
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] == "")
                    {
                        x1türevsabit[b] = 0;
                        label8.Text += x1türevsabit[b];
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                }

                else if (i != 0)
                {
                    if (x1[b] != "" && x1üzeri[b] != 0 && x1üzeri[b] != 1 && x2[b] != "")
                    {
                        x1türevsabit[b] = sabitdeğer[b] * (x1üzeri[b]);
                        label8.Text += işlem[b] + " " + x1türevsabit[b] + "*(" + x1[b] + "^" + (x1üzeri[b] - 1) + ")*(" + x2[b] + "^" + x2üzeri[b] + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] != "" && x1üzeri[b] != 0 && x1üzeri[b] != 1 && x2[b] == "")
                    {
                        x1türevsabit[b] = sabitdeğer[b] * (x1üzeri[b]);
                        label8.Text += işlem[b] + " " + x1türevsabit[b] + "*(" + x1[b] + "^" + (x1üzeri[b] - 1) + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] != "" && x1üzeri[b] == 1 && x2[b] != "")
                    {
                        x1türevsabit[b] = sabitdeğer[b];
                        label8.Text += işlem[b] + " " + x1türevsabit[b] + "*(" + x2[b] + "^" + x2üzeri[b] + ")";
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];

                    }

                    else if (x1[b] != "" && x1üzeri[b] == 1 && x2[b] == "")
                    {
                        x1türevsabit[b] = sabitdeğer[b];
                        label8.Text += işlem[b] + " " + x1türevsabit[b];
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }

                    else if (x1[b] == "")
                    {
                        x1türevsabit[b] = 0;
                        label8.Text += işlem[b] + " " + x1türevsabit[b];
                        x1türevx1[b] = (x1üzeri[b] - 1);
                        x1türevx2[b] = x2üzeri[b];
                    }
                }

                if (i == 0)
                {
                    if (x2[b] != "" && x2üzeri[b] != 0 && x2üzeri[b] != 1 && x1[b] != "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += x2türevsabit[b] + "*(" + x2[b] + "^" + (x2üzeri[b] - 1) + ")*(" + x1[b] + "^" + x1üzeri[b] + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] != "" && x2üzeri[b] != 0 && x2üzeri[b] != 1 && x1[b] == "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += x2türevsabit[b] + "*(" + x2[b] + "^" + (x2üzeri[b] - 1) + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] != "" && x2üzeri[b] == 1 && x1[b] != "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += x2türevsabit[b] + "*(" + x1[b] + "^" + x1üzeri[b] + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];

                    }

                    else if (x2[b] != "" && x2üzeri[b] == 1 && x1[b] == "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += x2türevsabit[b];
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] == "")
                    {
                        x2türevsabit[b] = 0;
                        label9.Text += x2türevsabit[b];
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }
                }

                else if (i != 0)
                {
                    if (x2[b] != "" && x2üzeri[b] != 0 && x2üzeri[b] != 1 && x1[b] != "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += işlem[b] + " " + x2türevsabit[b] + "*(" + x2[b] + "^" + (x2üzeri[b] - 1) + ")*(" + x1[b] + "^" + x1üzeri[b] + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] != "" && x2üzeri[b] != 0 && x2üzeri[b] != 1 && x1[b] == "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += işlem[b] + " " + x2türevsabit[b] + "*(" + x2[b] + "^" + (x2üzeri[b] - 1) + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] != "" && x2üzeri[b] == 1 && x1[b] != "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += işlem[b] + " " + x2türevsabit[b] + "*(" + x1[b] + "^" + x1üzeri[b] + ")";
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];

                    }

                    else if (x2[b] != "" && x2üzeri[b] == 1 && x1[b] == "")
                    {
                        x2türevsabit[b] = sabitdeğer[b] * (x2üzeri[b]);
                        label9.Text += işlem[b] + " " + x2türevsabit[b];
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }

                    else if (x2[b] == "")
                    {
                        x2türevsabit[b] = 0;
                        label9.Text += işlem[b] + " " + x2türevsabit[b];
                        x2türevx1[b] = (x2üzeri[b] - 1);
                        x2türevx2[b] = x1üzeri[b];
                    }
                }

                b++;

            }


            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (comboBox1.Text=="Var")
            {
                textBox2.Enabled = true; 
            }

            else
            {
                textBox2.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             if (a==0)
            {
                groupBox2.Enabled = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (comboBox2.Text == "Var")
            {
                textBox3.Enabled = true;
            }

            else
            {
                textBox3.Enabled = false;
            }
        
        }

    }
}
