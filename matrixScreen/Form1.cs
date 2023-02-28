using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace matrixScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public const int a = 50, aa = 50;
        public int[,] matricea = new int[a, aa];
        public Graphics g;
        public Brush b = new SolidBrush(Color.Green);
        public Pen p = new Pen(Color.Black);
        public Color color = Color.White;
        public Font f;
        public Random random= new Random();
        public int sizeoffont = 20;
        public void drawAllChars()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < aa; j++)
                {
                    matricea[i, j] = random.Next(1,49);
                    g.DrawString(matricea[i, j].ToString(),f,b,new Point(j* sizeoffont, i * sizeoffont));
                }
            }
        }
        public void clearAllLines()
        {
            //aici puteti sterge doar o linie de sus sau de jos 
            g.Clear(this.BackColor);
        }
        public void animateAllChars()
        {
            int k = a;
            while (k>1) {
               
                for (int i = 0; i < a-k; i++)
                {
                    for (int j = 0; j < aa; j++)
                    {

                        //g.DrawString(matricea[random.Next(0, a), j].ToString(), f, b, new Point(i * sizeoffont, j * sizeoffont));
                        g.DrawString(matricea[j, random.Next(0, a)].ToString(), f, b, new Point(j * sizeoffont, i * sizeoffont));
                    }
                }
                k--;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1920;
            this.Height = 1080;
            this.Left = 0;
            this.Top = 0;
            this.BackColor= Color.Black;

            g = CreateGraphics();
            f = new Font("Wingdings 3", 10);
           
        }
        public void doit()
        {
            drawAllChars();
            clearAllLines();
            animateAllChars();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawAllChars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearAllLines();
            animateAllChars();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            clearAllLines();
            animateAllChars();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible= false;
            button2.Visible= false;
            button3.Visible= false;
            button4.Visible= false;
            doit();
            timer1.Interval = 1;
            timer1.Enabled = true;
        }
    }
}
