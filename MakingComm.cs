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
    public partial class MakingComm : Form
    {
        public string committee_name { get; set; }
        public int itec_id { get; set; }

        public int itec_year{get; set;}
        public MakingComm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            committee_name = textBox1.Text.Trim();
            itec_year = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    string query2 = "SELECT itec_id FROM itec_editions WHERE year =@itec_year";
                    using (MySqlCommand cmd = new(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@itec_year", itec_year);
                        object res = cmd.ExecuteScalar();
                        itec_id = Convert.ToInt32(res);
                    }

                    string query1 = "INSERT INTO committees (itec_id,committee_name) VALUES (@itec_id,@committee_name)";
                    using(MySqlCommand cmd=new(query1,conn))
                    {
                        cmd.Parameters.AddWithValue("@committee_name", committee_name);
                        cmd.Parameters.AddWithValue("@itec_id", itec_id);

                        cmd.ExecuteNonQuery();
                    }

                    
                    MessageBox.Show("Committee has made!");
                    CommitteMembers cm = new();
                    this.Hide();
                    cm.ShowDialog();
                    this.Show();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void MakingComm_Load(object sender, EventArgs e)
        {
            try
            {
                using(MySqlConnection conn=DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    string query = "SELECT year FROM itec_editions ";
                    using(MySqlCommand cmd=new(query,conn))
                    {
                        using(MySqlDataReader reader= cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                int year = reader.GetInt32(0);
                                comboBox1.Items.Add(year.ToString());
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }
    }
}
