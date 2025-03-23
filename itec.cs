using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MidProjectDb
{
    public partial class itec : Form
    {
        public int itec_id { get; set; }
        public int year { get; set; }
        public string theme { get; set; }

        public string description { get; set; }

        public itec()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            year = int.Parse(maskedTextBox1.Text);
            theme = textBox3.Text.Trim();
            description = textBox4.Text.Trim();

            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    string query = "INSERT INTO itec_editions(itec_id,year,theme,description) VALUES (@itec_id,@year,@theme,@description)";
                    using (MySqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@itec_id", itec_id);
                        cmd.Parameters.AddWithValue("@year", year);
                        cmd.Parameters.AddWithValue("@theme", theme);
                        cmd.Parameters.AddWithValue("@description", description);

                        cmd.ExecuteNonQuery();


                    }
                    MessageBox.Show("Information added successfully!");

                    this.Hide();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }
    }
}
