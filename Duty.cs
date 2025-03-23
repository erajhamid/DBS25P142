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
    public partial class Duty : Form
    {
        public string assigned_to { get; set; }
        public string task_description { get; set; }
        public string  deadline { get; set; }

        public int committee_id { get; set; }
        public Duty()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            assigned_to = comboBox1.SelectedItem.ToString();
            task_description = textBox1.Text.Trim();
            deadline = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    // fetch the committee id
                    string query1 = "SELECT committee_id FROM committee_members WHERE name=@assigned_to";
                    using (MySqlCommand cmd = new(query1, conn))
                    {
                        cmd.Parameters.AddWithValue("@assigned_to", assigned_to);
                        object result = cmd.ExecuteScalar();

                        committee_id = Convert.ToInt32(result);
                    }

                    // insert into 
                    string query2 = "INSERT INTO duties(committee_id,assigned_to,task_description,deadline) VALUES (@committee_id,@assigned_to,@task_description,@deadline)";
                    using (MySqlCommand cmd = new(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@committee_id", committee_id);
                        cmd.Parameters.AddWithValue("@assigned_to", assigned_to);
                        cmd.Parameters.AddWithValue("@task_description", task_description);
                        cmd.Parameters.AddWithValue("@deadline", deadline);


                        cmd.ExecuteNonQuery();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Duty_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    string query = "SELECT name FROM committee_members";
                    using (MySqlCommand cmd = new(query, conn))
                    {
                        using(MySqlDataReader reader=cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                string mem_name = reader.GetString(0);
                                comboBox1.Items.Add(mem_name);
                            }
                        }
                    }
                }
                    
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
