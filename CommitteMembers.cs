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
    public partial class CommitteMembers : Form
    {
        public string name { get; set; }
        public string role_name { get; set; }
        public int role_id { get; set; }

        public string committee_name {get; set;}

        public int committee_id {  get; set; }
        public CommitteMembers()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.Trim();
            role_name = textBox2.Text.Trim();
            committee_name = comboBox1.SelectedItem.ToString();

            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    // fetch the committee id
                    string query2 = "SELECT committee_id FROM committees WHERE  committee_name= @committee_name";
                    using (MySqlCommand cmd = new(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@committee_name", committee_name);
                        object result = cmd.ExecuteScalar();
                        committee_id = Convert.ToInt32(result);
                    }

                    // fetch the role id
                    string query1 = "INSERT INTO roles(role_name) VALUES(@role_name)" ;
                    using (MySqlCommand cmd = new(query1, conn))
                    {
                        cmd.Parameters.AddWithValue("@role_name", role_name);
                        cmd.ExecuteNonQuery();

                    }
                    string query4 = "SELECT LAST_INSERT_ID();";
                    using (MySqlCommand cmd = new(query4, conn))
                    {
                        role_id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    string query3 = "INSERT INTO committee_members(committee_id,name,role_id) VALUES (@committee_id,@name,@role_id)";
                    using(MySqlCommand cmd = new(query3, conn))
                    {
                        cmd.Parameters.AddWithValue("@committee_id", committee_id);
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@role_id", role_id);

                        cmd.ExecuteNonQuery();

                    }
                    Duty d = new();
                    this.Hide();
                    d.ShowDialog();
                    this.Show();
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show("Error" + ex.Message);
            }

        }

        private void CommitteMembers_Load(object sender, EventArgs e)
        {
            try
            {
                using(MySqlConnection conn=DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); //

                    string query = "SELECT committee_name FROM committees";
                    using(MySqlCommand cmd = new(query,conn))
                    {
                        using(MySqlDataReader reader=cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                string  name = reader.GetString(0);
                                comboBox1.Items.Add(name);

                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error" + ex.Message);
            }
        }
    }
}
