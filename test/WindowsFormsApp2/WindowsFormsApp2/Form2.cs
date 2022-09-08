using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
    
            this.WindowState = FormWindowState.Maximized;
            this.Size = 
            this.FormBorderStyle = FormBorderStyle.None;
            panel1.Size = this.Size;
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.Red;
            int rows = 2;
            int cols = 5;
            int width = panel1.Width / cols;
            int height = panel1.Height / rows;
            int count = 0;
            int red = 255;

            
            
        }
    }
}
