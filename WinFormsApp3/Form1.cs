using System.Text.RegularExpressions;
namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Regex name = new Regex(@"^[a-zA-Z1-9_]+$");
        Regex iterations = new Regex(@"^[0-9]+$");
        Regex sinterval = new Regex(@"^[0-9]+$");
        Regex pinterval = new Regex(@"^[0-9]+$");
        public Form1()
        {
            InitializeComponent();
            this.CreateFolder();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(string.Format("Data:\nName: {0}\nIterations: {1}\nStimuli: {2} ms\nPost Stimuli: {3} ms", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text), "Are You Sure?", MessageBoxButtons.OKCancel);

            //check if input data is valid
            if (res == DialogResult.OK)
            {
                if (name.IsMatch(textBox1.Text) && iterations.IsMatch(textBox2.Text) && sinterval.IsMatch(textBox3.Text) && pinterval.IsMatch(textBox4.Text))
                {
                    //if input data is valid, start the program
                    Form2 form2 = new Form2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                    form2.Show();
                }
                else
                {
                    //if input data is not valid, show error message
                    MessageBox.Show("Invalid input data");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (name.IsMatch(textBox1.Text))
            {
                textBox1.ForeColor = Color.Green;
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (iterations.IsMatch(textBox2.Text))
            {
                textBox2.ForeColor = Color.Green;
            }
            else
            {
                textBox2.ForeColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (sinterval.IsMatch(textBox3.Text))
            {
                textBox3.ForeColor = Color.Green;
            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (pinterval.IsMatch(textBox4.Text))
            {
                textBox4.ForeColor = Color.Green;
            }
            else
            {
                textBox4.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //reset all input values 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2("asd", "1", "2", "3");
            //form2.Show();
        }

        private void CreateFolder()
        {
            string parentFolder = "Psychology Test";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var newPath = System.IO.Path.Combine(path, parentFolder);
            if (!System.IO.Directory.Exists(newPath))
                System.IO.Directory.CreateDirectory(newPath);
        }

    }
}