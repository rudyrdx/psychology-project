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
        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Size = this.Size;
            panel1.Location = new Point(0, 0);

            int rows = 2;
            int cols = 5;
            int width = panel1.Width / cols;
            int height = panel1.Height / rows;
            int count = 0;
            int red = 255;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    PictureBox btn = new PictureBox();
                    btn.Size = new Size(width, height);
                    btn.Location = new Point(j * width, i * height);
                    btn.BorderStyle = BorderStyle.FixedSingle;
                    //each iteration, subtract 15 from red
                    btn.BackColor = Color.FromArgb(255, red, 0, 0);
                    red -= 15;
                    panel1.Controls.Add(btn);
                    count++;
                }
            }
            panel1.Hide();

        }
    }
}
