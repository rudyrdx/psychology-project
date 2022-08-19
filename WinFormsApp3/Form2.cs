using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;

namespace WinFormsApp3
{
    public partial class Form2 : Form
    {
        public WaveIn? waveSource = null;
        public WaveFileWriter? waveFile = null;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private string audioPath;
        private string name;
        private int iterations;
        private int sinterval;
        private int pinterval;
        private int counter;
        private int kC = 0;
        public Form2(string t1, string t2, string t3, string t4)
        {
            //replace space with underscore
            this.name = t1.Replace(" ", "_");
            this.iterations = int.Parse(t2);
            this.sinterval = int.Parse(t3);
            this.pinterval = int.Parse(t4);

            InitializeComponent();

            this.CreateTestOutput();

            this.ScreenSize();

            this.PbAlign(pictureBox1);
            this.PbAlign(pictureBox2);
            this.PbAlign(pictureBox3);

            this.SetupAudio();

            this.Loop();
        }

        private void Loop()
        {
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Show();
            var timer1 = new System.Windows.Forms.Timer { Interval = sinterval + pinterval };
            timer1.Enabled = true;
            timer1.Tick += (a, e) =>
            {
                pictureBox3.Hide();
                pictureBox2.Hide();

                if (counter >= iterations)
                {
                    timer1.Enabled = false;
                    counter = 0;
                    waveSource.StopRecording();
                    waveSource.Dispose();
                    string strCmdText;
                    strCmdText = "/C python main.py " + name;
                    System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                    this.Close();
                }
                else
                {
                    if (counter == 0)
                        waveSource.StartRecording();
                    
                    pictureBox1.Show();

                    var timer2 = new System.Windows.Forms.Timer();
                    timer2.Interval = sinterval;
                    timer2.Enabled = true;
                    timer2.Tick += (b, f) =>
                    {
                        pictureBox1.Hide();
                        pictureBox3.Location = new Point(0, 0);
                        pictureBox3.Show();
                        timer2.Enabled = false;
                    };
                    int cc = counter + 1;
                    waveFile = new WaveFileWriter(audioPath + @"\" + cc.ToString() + ".wav", waveSource.WaveFormat);
                    counter = counter + 1;
                }
            };
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //close form when excape is pressed for 2 seconds
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(Form2_KeyPress);
        }
        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                kC++;
                if (kC == 2)
                {
                    this.Close();
                }
            }
        }

        private void CreateTestOutput()
        {
            string parentFolder = "Psychology Test";
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var newPath = System.IO.Path.Combine(desktop, parentFolder);

            string finalPath = System.IO.Path.Combine(newPath, this.name);

            if (!System.IO.Directory.Exists(finalPath))
            {
                System.IO.Directory.CreateDirectory(finalPath);
            }

            string audioPath = finalPath + @"\Audio";
            this.audioPath = audioPath;
            if (!System.IO.Directory.Exists(audioPath))
            {
                System.IO.Directory.CreateDirectory(audioPath);
            }

        }

        private void SetupAudio()
        {
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += (a, e) =>
            {
                if (waveFile != null)
                {
                    waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                    waveFile.Flush();
                }
            };
            waveSource.RecordingStopped += (a, e) =>
            {
                if (waveSource != null)
                {
                    waveSource.Dispose();
                    waveSource = null;
                }

                if (waveFile != null)
                {
                    waveFile.Dispose();
                    waveFile = null;
                }
            };
        }

        private void ScreenSize()
        {
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.WindowState = FormWindowState.Maximized;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void PbAlign(PictureBox pb)
        {
            pb.Hide();
            pb.Width = Screen.PrimaryScreen.Bounds.Width;
            pb.Height = Screen.PrimaryScreen.Bounds.Height;
            pictureBox1.Location = new Point(0, 0);
        }
    }
}

