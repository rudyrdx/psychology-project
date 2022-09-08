using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        Button[] btns;
        public Form2()
        {
            InitializeComponent();
            //int minx, miny, maxx, maxy;
            //minx = miny = int.MaxValue;
            //maxx = maxy = int.MinValue;

            //foreach (Screen screen in Screen.AllScreens)
            //{
            //    var bounds = screen.Bounds;
            //    minx = Math.Min(minx, bounds.X);
            //    miny = Math.Min(miny, bounds.Y);
            //    maxx = Math.Max(maxx, bounds.Right);
            //    maxy = Math.Max(maxy, bounds.Bottom);
            //}

            //Rectangle tempRect = new Rectangle(1, 0, maxx, maxy);
            //this.DesktopBounds = tempRect;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

        }
        
        List<int> pattern_1 = new List<int> { 255 - 235, 255 - 165, 255 - 215, 
            255 - 195, 255 - 245, 255 - 175, 255 - 225, 255 - 205, 0, 255 - 185};

        //pattern 2 reverse of pattern_1
        List<int> pattern_2 = new List<int> { 255 - 185, 0, 255 - 205, 255 - 225,
            255 - 175, 255 - 245, 255 - 195, 255 - 215, 255 - 165, 255 - 235 };

        //pattern_3 another pattern of 
        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            panel1.Size = this.Size;
            panel1.Location = new Point(15, 0);
            panel1.BackColor = Color.White;

            int rows = 2;
            int cols = 5;
            int spacing = 10;
            int width = (panel1.Width / cols) - spacing;
            int height = (panel1.Height / rows) - spacing;
            int count = 0;
            int red = 255;
            btns = new Button[10];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    red = 255;
                    Button btn = new Button();
                    btn.Size = new Size(width, height);
                    btn.Location = new Point(j * width + spacing, i * height + spacing);
                    //each iteration, subtract 15 from red
                    red -= pattern_1.ElementAt(count);
                    btn.BackColor = Color.FromArgb(255, red, 0, 0);
                    btn.Text = pattern_1[count].ToString();
                    panel1.Controls.Add(btn);
                    count++;
                    btns.Append(btn);
                }
            }

            
        }
    }
}
