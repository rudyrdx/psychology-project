using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form2 : Form
    {
        private string name;
        private string age;
        private string gender;
        private static int rows = 2;
        private static int cols = 5;
        private static Random? rand;
        Panel panelr, panelb, panely;
        //pattern 1
        private static List<int> pattern_1 = new List<int> { 20, 90, 40, 60, 10, 80, 30, 50, 0, 70 };
        //pattern 2 reverse of pattern 1
        private static List<int> pattern_2 = new List<int> { 70, 0, 50, 30, 80, 10, 60, 40, 90, 20 };
        //pattern 3 shifted last 4 elements to the front
        private static List<int> pattern_3 = new List<int> { 30, 50, 0, 70, 20, 90, 40, 60, 10, 80 };
        //pattern 4 shifted first 4 elements to the back
        private static List<int> pattern_4 = new List<int> { 10, 80, 30, 50, 0, 70, 20, 90, 40, 60 };
        //pattern 5 shifted first 4 elements to the back and last 4 elements to the front
        private static List<int> pattern_5 = new List<int> { 40, 60, 10, 80, 30, 50, 0, 70, 20, 90 };
        //pattern 6 shifted first 4 elements to the back and last 4 elements to the front and then reversed
        private static List<int> pattern_6 = new List<int> { 90, 20, 70, 0, 50, 30, 80, 10, 60, 40 };
        //pattern 7 shifted first 4 elements to the back and last 4 elements to the front and then reversed and then shifted last 4 elements to the front
        private static List<int> pattern_7 = new List<int> { 60, 40, 90, 20, 70, 0, 50, 30, 80, 10 };

        public Form2(string t1, string t2, string t3)
        {
            this.name = t1.Replace(" ", "_");
            this.age = t2;
            this.gender = t3;
            InitializeComponent();
            panelr = new Panel();
            panelb = new Panel();
            panely = new Panel();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            rand = new Random();
        }

        List<List<int>> patterns = new List<List<int>> { pattern_1, pattern_2, pattern_3, pattern_4, pattern_5, pattern_6, pattern_7 };

        private void Form2_Load(object sender, EventArgs e)
        {
            this.SetupPanel(panelr);
            this.SetupPanel(panelb);
            this.SetupPanel(panely);


            {
                /*int spacing = 10;
            int width = (panel.Width / cols) - spacing;
            int height = (panel.Height / rows) - spacing;
            int count = 0;
            int red = 255;
            //get a random pattern
            var current_pattern = patterns[rand.Next(0, patterns.Count)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    red = 255;

                    PictureBox btn = new PictureBox();
                    btn.Size = new Size(width, height);
                    btn.Location = new Point(j * width + spacing, i * height + spacing);
                    btn.BorderStyle = BorderStyle.Fixed3D;
                    //each iteration, subtract 15 from red
                    red -= current_pattern.ElementAt(count);
                    btn.BackColor = Color.FromArgb(255, red, 0, 0);
                    btn.Text = current_pattern[count].ToString();

                    count++;

                    panel.Controls.Add(btn);
                }
            }*/
            }


            this.DoLoop();
        }

        private void DoLoop()
        {
            int counter = 0;
            const int iter = 3;
            var watchtime = 10000;
            var resettime = 5000;
            var timer1 = new System.Windows.Forms.Timer { Interval = watchtime + resettime };
            timer1.Enabled = true;
            timer1.Tick += (a, e) =>
            {
                //show no panel
                panelr.Hide();
                panelb.Hide();
                panely.Hide();
                if (counter >= iter)
                {
                    this.Close();
                }
                else
                {
                    if (counter == 0)
                    {
                        //show panalr
                        panelr.Show();
                        DoWork(panelr, rows, cols, Color.Red);
                        var timer2 = new System.Windows.Forms.Timer();
                        timer2.Interval = watchtime;
                        timer2.Enabled = true;
                        timer2.Tick += (b, f) =>
                        {
                            panelr.Hide();
                            timer2.Enabled = false;
                        };
                    } 
                    else if (counter == 1)
                    {
                        //show panelb
                        panelb.Show();
                        DoWork(panelb, rows, cols, Color.Blue);
                        var timer2 = new System.Windows.Forms.Timer();
                        timer2.Interval = watchtime;
                        timer2.Enabled = true;
                        timer2.Tick += (b, f) =>
                        {
                            panelb.Hide();
                            timer2.Enabled = false;
                        };
                    }
                    else if (counter == 2)
                    {
                        //show panely
                        panely.Show();
                        DoWork(panely, rows, cols, Color.Yellow);
                        var timer2 = new System.Windows.Forms.Timer();
                        timer2.Interval = watchtime;
                        timer2.Enabled = true;
                        timer2.Tick += (b, f) =>
                        {
                            panely.Hide();
                            timer2.Enabled = false;
                        };
                    }
                    
                    counter = counter + 1;
                }
            };
        }
        private void SetupPanel(Panel panel)
        {
            panel.Size = this.Size;
            panel.Location = new Point(15, 0);
            panel.BackColor = Color.White;
            this.Controls.Add(panel);
        }
        private void DoWork(Panel panel, int rows, int cols, Color color)
        {
            int spacing = 10;
            int width = (panel.Width / cols) - spacing;
            int height = (panel.Height / rows) - spacing;
            int count = 0;
            int colorval = 255;
            //get a random pattern
            var current_pattern = patterns[rand.Next(0, patterns.Count)];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    //ALLAN EDIT ONLY THIS PART !!!
                    colorval = 255;
                    PictureBox btn = new PictureBox();
                    //btn.BorderStyle = BorderStyle.FixedSingle;
                    btn.Size = new Size(width - spacing, height - spacing);
                    btn.Location = new Point(j * width + spacing, i * height + spacing);
                    //each iteration, subtract 15 from red
                    colorval -= current_pattern.ElementAt(count);
                    if (color == Color.Red)
                    {
                        btn.BackColor = Color.FromArgb(255, colorval, 0, 0);
                    }
                    else if (color == Color.Blue)
                    {
                        btn.BackColor = Color.FromArgb(255, 0, 0, colorval);
                    }
                    else if (color == Color.Yellow)
                    {
                        btn.BackColor = Color.FromArgb(255, colorval, colorval, 0);
                    }
                    count++;
                    btn.Text = count.ToString();
                    
                    panel.Controls.Add(btn);
                }
            }
        }
    }
}
