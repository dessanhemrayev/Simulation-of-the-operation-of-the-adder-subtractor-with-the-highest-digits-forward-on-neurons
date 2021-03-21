using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Моделирование_работы_сумматора_вычитателя
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 32; i++)
            {
                dataGridView1.Columns[i].Width = 30;
                dataGridView2.Columns[i].Width = 30;
                dataGridView3.Columns[i].Width = 30;
                dataGridView4.Columns[i].Width = 30;
                dataGridView6.Columns[i].Width = 30;
                dataGridView5.Columns[i].Width = 30;
                dataGridView7.Columns[i].Width = 30;

                dataGridView1.Columns[i].ReadOnly = true;
                dataGridView2.Columns[i].ReadOnly = true;
                dataGridView3.Columns[i].ReadOnly = true;
                dataGridView4.Columns[i].ReadOnly = true;
                dataGridView6.Columns[i].ReadOnly = true;
                dataGridView5.Columns[i].ReadOnly = true;
                dataGridView7.Columns[i].ReadOnly = true;
            }
            dataGridView5[31, 0].Value = 0;

            for (int i = 0; i < 8; i++)
            {
               

                dataGridView8.Columns[i].ReadOnly = true;
                dataGridView9.Columns[i].ReadOnly = true;
                dataGridView10.Columns[i].ReadOnly = true;
               
            }
        }
        static int step = 0;
        static int znak;
        private int mojarit_el(int a1, int a2, int a3)
        {
            int result = 0;

            if (a1 + a2 + a3 >= 2)
            
                result = 1;
            
            else
                result = 0;
        return result;
        }

        private int raznost(int x1, int x2, int z)
        {
            int r = 0;

            if (z == 0 && x1 == 0 && x2 == 0) { r = 0; }
            
            if (z == 0 && x1 == 0 && x2 == 1) { r = 1; }
            
            if (z == 0 && x1 == 1 && x2 == 0) { r = 1; }
            
            if (z == 0 && x1 == 1 && x2 == 1) { r = 0; }
            
            if (z == 1 && x1 == 0 && x2 == 0) { r = 1; }
            
            if (z == 1 && x1 == 0 && x2 == 1) { r = 0; }
            
            if (z == 1 && x1 == 1 && x2 == 0) { r = 0; }
            
            if (z == 1 && x1 == 1 && x2 == 1) { r = 1; }

            return r;
        }
        private int summ3(int a1, int a2, int a3)
        {

            return (a1 + a2 + a3) % 2;
        }

        private int comparation1()
        {
            int s1 = 0;
            int s2 = 0;
            int res = 0;
            for (int j = 0; j < 32; j++)
            {
                s1 =Convert.ToInt32(dataGridView1[j, 0].Value);
                s2 = Convert.ToInt32(dataGridView2[j, 0].Value);
                if (s1 > s2)
                {
                    res = 1;
                    break;
                }
                else if (s1 < s2)
                {
                    res = 2;
                    break;
                }
                else
                    continue;
             }   
            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int f1 = 0;
            int f2 = 0;
            int f3 = 0;
            if (textBox3.Text=="1")
            {
                f2 = 1;
            }
          
            if (textBox4.Text == "1")
            {
                f3 = 1;
            }
            znak=f1 ^ f2 ^ f3;
            /// сравнение чисел

            if (comparation1() == 1)
            {
                label9.Text = "A>B";
                label10.Text = "Число B";
                label11.Text = "Число A";
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView1[j, 0].Value;

                    textBox5.Text = f2.ToString();

                }

            }
            else if (comparation1() == 2)
            {
                label9.Text = "A<B";
               
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView2[j, 0].Value;

                    textBox5.Text = f3.ToString();

                }
            }
            else
            {
                label9.Text = "A=B";
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView1[j, 0].Value;



                }

            }


            if (znak == 1)
            {
                label5.Text = String.Format("вычитание так как кодовое значение '-' (зн.А({0})+зн.В({1}))", textBox3.Text, textBox4.Text);
                for (int i = 0; i < 32; i++)
                {
                    if (Convert.ToInt32(dataGridView6[i, 0].Value) == 0)
                    {
                        dataGridView6[i, 0].Value = 1;
                    }
                    else
                    {
                        dataGridView6[i, 0].Value = 0;
                    }
                }
                for (int j = 31; j > 0; j--)
                {

                    dataGridView5[j - 1, 0].Value = mojarit_el(Convert.ToInt32(dataGridView3[j, 0].Value), Convert.ToInt32(dataGridView6[j, 0].Value), Convert.ToInt32(dataGridView5[j, 0].Value));

                }
              
            }
            else
            {
                label5.Text = String.Format("сложение так как кодовое значение '+' (зн.А({0})+зн.В({1}))", textBox3.Text, textBox4.Text);
                
                for (int j = 31; j > 0; j--)
                {

                    dataGridView5[j-1, 0].Value = mojarit_el(Convert.ToInt32(dataGridView3[j, 0].Value), Convert.ToInt32(dataGridView4[j, 0].Value), Convert.ToInt32(dataGridView5[j, 0].Value));
                    



                }
              
            }

        



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
         {
           
                textBox3.Text = "";
            if (textBox1.Text.Length >=1 )
            { if (textBox1.Text != "-")
                {
                    string s = Convert.ToString(Math.Abs(Convert.ToInt32(Convert.ToInt32(textBox1.Text))), 2);
                    s = s.PadLeft(32, '0');

                    for (int j = 0; j < 32; j++)
                    {

                        dataGridView1[j, 0].Value = Convert.ToInt32(s[j].ToString());

                    }
                    int st1 = Convert.ToInt32(textBox1.Text);
                    if (st1 > 0)
                        textBox3.Text = "0";
                    else
                        textBox3.Text = "1";
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = "";
            if (textBox2.Text.Length >= 1)
            { if (textBox2.Text != "-" )
                {
                    string s = Convert.ToString(Convert.ToInt32(Math.Abs(Convert.ToInt32(textBox2.Text))), 2);
                    s = s.PadLeft(32, '0');

                    for (int j = 0; j < 32; j++)
                    {

                        dataGridView2[j, 0].Value = Convert.ToInt32(s[j].ToString());

                    }
                    int st1 = Convert.ToInt32(textBox2.Text);
                    if (st1 > 0)
                        textBox4.Text = "0";
                    else
                        textBox4.Text = "1";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            int f1 = 1;
            int f2 = 0;
            int f3 = 0;
            if (textBox3.Text == "1")
            {
                f2 = 1;
            }

            if (textBox4.Text == "1")
            {
                f3 = 1;
            }
            znak = f1 ^ f2 ^ f3;
            /// сравнение чисел

            if (comparation1() == 1)
            {
                label9.Text = "A>B";
             
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView1[j, 0].Value;

                    textBox5.Text = f2.ToString();

                }

            }
            else if (comparation1() == 2)
            {
                label9.Text = "A<B";
             
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView2[j, 0].Value;

                    if (f3 != 1)
                    {
                        f3 = 1;
                        textBox5.Text = f3.ToString();

                    }
                    else
                    {
                        textBox5.Text = f3.ToString();
                    }
                   

                }
            }
            else
            {
                label9.Text = "A=B";
                for (int j = 0; j < 32; j++)
                {

                    dataGridView3[j, 0].Value = dataGridView2[j, 0].Value;
                    dataGridView6[j, 0].Value = dataGridView1[j, 0].Value;
                    dataGridView4[j, 0].Value = dataGridView1[j, 0].Value;



                }

            }


            if (znak == 1)
            {
                label5.Text = String.Format("вычитание так как кодовое значение '-' (зн.А({0})-зн.В({1}))", textBox3.Text, textBox4.Text);
                for (int i = 0; i < 32; i++)
                {
                    if (Convert.ToInt32(dataGridView6[i, 0].Value) == 0)
                    {
                        dataGridView6[i, 0].Value = 1;
                    }
                    else
                    {
                        dataGridView6[i, 0].Value = 0;
                    }
                }
                for (int j = 31; j > 0; j--)
                {

                    dataGridView5[j - 1, 0].Value = mojarit_el(Convert.ToInt32(dataGridView3[j, 0].Value), Convert.ToInt32(dataGridView6[j, 0].Value), Convert.ToInt32(dataGridView5[j, 0].Value));

                }

            }
            else
            {
                label5.Text = String.Format("сложение так как кодовое значение '+' (зн.А({0})-зн.В({1}))", textBox3.Text, textBox4.Text);

                for (int j = 31; j > 0; j--)
                {

                    dataGridView5[j - 1, 0].Value = mojarit_el(Convert.ToInt32(dataGridView3[j, 0].Value), Convert.ToInt32(dataGridView4[j, 0].Value), Convert.ToInt32(dataGridView5[j, 0].Value));




                }

            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            label15.Text = step.ToString();
            int start = 0;
            int stop= 0;
            int[] temp = new int[8];
            int[] temp1 = new int[8];
            int[] temp2 = new int[8];
            int[] temp3 = new int[8];

            if (step<5)
            {
                switch (step)
                {
                    case 0: { start = 0;stop = 7; break; }
                    case 1: { start = 8; stop = 15; break; }
                    case 2: { start = 16; stop = 23; break; }
                    case 3: { start = 24; stop = 31; break; }
                }
               
                int k = 0;
                if (znak == 0)
                {
                    for (int i = 0; i < 8; i++)
                    {

                        dataGridView10[i, 0].Value = dataGridView4[i, 0].Value;
                        dataGridView8[i, 0].Value = dataGridView3[i, 0].Value;
                        dataGridView9[i, 0].Value = dataGridView5[i, 0].Value;
                        temp1[i]= Convert.ToInt32(dataGridView10[i, 0].Value);
                        temp2[i] = Convert.ToInt32(dataGridView8[i, 0].Value);
                        temp3[i] = Convert.ToInt32(dataGridView9[i, 0].Value);

                        temp[i]= summ3(Convert.ToInt32(dataGridView8[i, 0].Value), Convert.ToInt32(dataGridView9[i, 0].Value), Convert.ToInt32(dataGridView10[i, 0].Value));
                        
                        
                    }
                }
                else
                {
                    for (int i = 0; i < 8; i++)
                    {
                        dataGridView10[i, 0].Value = dataGridView3[i, 0].Value;

                        dataGridView8[i, 0].Value = dataGridView4[i, 0].Value;
                        dataGridView9[i, 0].Value = dataGridView5[i, 0].Value;
                        
                        temp[i] = raznost(Convert.ToInt32(dataGridView8[i, 0].Value), Convert.ToInt32(dataGridView10[i, 0].Value), Convert.ToInt32(dataGridView9[i, 0].Value));
                    }
                }
              

            }
            for (int i = start; i < stop+1; i++)
            {
                dataGridView7[i, 0].Value = temp[i%8];
            }
            for (int kl = 0; kl < 8; kl++)
            {
                for (int i = 0; i < 31 - 8 * step; i++)
                {
                 dataGridView4[i, 0].Value = Convert.ToInt32(dataGridView4[i + 1, 0].Value);
                   
                    dataGridView3[i, 0].Value = Convert.ToInt32( dataGridView3[i + 1, 0].Value);
                 dataGridView5[i, 0].Value = Convert.ToInt32(dataGridView5[i + 1, 0].Value);
                }
            }
            step += 1;
            for (int i = 31; i > 31 - 8 * step; i--)
            {
                dataGridView4[i, 0].Value = "*";
                dataGridView6[i, 0].Value = "*";
                dataGridView5[i, 0].Value = "*";
                dataGridView3[i, 0].Value = "*";
            }
            
            if (step == 4)
            {
                double result = 0;
                for (int i = 0; i < 32; i++)
                {
                    result += Convert.ToInt32(dataGridView7[i, 0].Value) * Math.Pow(2, 31 - i);
                    
                }
                if (textBox5.Text=="1")
                {
                    label18.Text = "-" + result.ToString();
                }
                else
                {
                    label18.Text =  result.ToString();
                }
                    button3.Enabled = false; 
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            button3.Enabled = true;
            label15.Text = "";
            label18.Text = "";
            step = 0;
            for (int i = 0; i < 32; i++)
            {

                dataGridView1[i, 0].Value = "";
                dataGridView2[i, 0].Value = "";
                dataGridView3[i, 0].Value = "";
                dataGridView4[i, 0].Value = "";
                dataGridView5[i, 0].Value = "";
                dataGridView6[i, 0].Value = "";
                dataGridView7[i, 0].Value = "";
                if (i < 8)
                {
                    dataGridView8[i, 0].Value = "";
                    dataGridView9[i, 0].Value = "";
                    dataGridView10[i, 0].Value = "";
                }

                dataGridView5[31, 0].Value = 0;

            }
        }
    }
}
