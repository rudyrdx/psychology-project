using System.Text.RegularExpressions;
namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        Regex name = new Regex(@"^[a-zA-Z1-9_]+$");
        Regex age = new Regex(@"^[0-9]+$");
        Regex gender = new Regex(@"^[a-zA-Z]+$");
        public Form1()
        {
            InitializeComponent();
            //Form2 form2 = new Form2(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex);
            //form2.Activate();
            //form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(string.Format("Data:\nName: {0}\nAge: {1}\nGender: {2}\nPattern: {3}",
                textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex), "Are You Sure?", MessageBoxButtons.OKCancel);

            if (res == DialogResult.OK)
            {
                if (name.IsMatch(textBox1.Text) && age.IsMatch(textBox2.Text) && gender.IsMatch(textBox3.Text))
                {
                    //if input data is valid, start the program
                    Form2 form2 = new Form2(textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.SelectedIndex);
                    form2.Activate();
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
            if (age.IsMatch(textBox2.Text))
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
            if (gender.IsMatch(textBox3.Text))
            {
                textBox3.ForeColor = Color.Green;
            }
            else
            {
                textBox3.ForeColor = Color.Red;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}