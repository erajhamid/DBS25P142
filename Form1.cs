using System.Windows.Forms.DataVisualization.Charting;

namespace MidProjectDb
{
    public partial class Form1 : Form
    {
        public string username { get;set; }
        public string password_hash { get;set; }
        public Form1()
        {
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {





        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Login_Click(object sender, EventArgs e)
        {
            

            facultydashboard facul = new ();
            this.Hide();
            facul.ShowDialog();
            this.Show();
        }

    }
}
