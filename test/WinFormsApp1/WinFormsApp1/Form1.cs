namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form2 form2 = new Form2();
            form2.Show();
            form2.Activate();
        }

        //random seed
        
    }
}