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
    public partial class manageEvents : Form
    {
        public int itec_id { get; set; } // Store ITEC ID here
        public int event_id { get; set; }
        public string event_name { get; set; }
        public string description { get; set; }
        public string event_date { get; set; }
        public int event_category_id { get; set; }
        public int itec_year { get; set; }
        public string category_name { get; set; }

        public manageEvents()
        {
            InitializeComponent();
        }
        private void manageEvents_Load_1(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void manageEvents_Load(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open();
                    string query = "SELECT year FROM itec_editions";

                    using (MySqlCommand cmd = new(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int yearValue = reader.GetInt32(0);
                                comboBox1.Items.Add(yearValue.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading years: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Ensure the user selects an ITEC year
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select an ITEC Year before proceeding.");
                return;
            }

            event_name = textBox1.Text.Trim();
            description = textBox3.Text.Trim();
            category_name = textBox4.Text.Trim();
            event_date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            itec_year = Convert.ToInt32(comboBox1.SelectedItem.ToString());

            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open();

                    // Fetch the ITEC ID using the selected year
                    string query3 = "SELECT itec_id FROM itec_editions WHERE year = @itec_year";
                    using (MySqlCommand cmd = new(query3, conn))
                    {
                        cmd.Parameters.AddWithValue("@itec_year", itec_year);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            itec_id = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Error: Selected ITEC Year does not exist in the database.");
                            return;
                        }
                    }

                   

                    // Insert event category and get the category ID
                    string query2 = "INSERT INTO event_categories(category_name) VALUES (@category_name); SELECT LAST_INSERT_ID();";

                    using (MySqlCommand cmd = new(query2, conn))
                    {
                        cmd.Parameters.AddWithValue("@category_name", category_name);
                        event_category_id = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert into itec_events
                    string query1 = "INSERT INTO itec_events(itec_id, event_name, description, event_date, event_category_id) VALUES(@itec_id, @event_name, @description, @event_date, @event_category_id)";

                    using (MySqlCommand cmd = new(query1, conn))
                    {
                        cmd.Parameters.AddWithValue("@itec_id", itec_id);
                        cmd.Parameters.AddWithValue("@event_name", event_name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@event_date", event_date);
                        cmd.Parameters.AddWithValue("@event_category_id", event_category_id);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Event added successfully!");
                    facultydashboard facul = new();
                    this.Hide();
                    facul.ShowDialog();
                    this.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting event: " + ex.Message);
            }
        }
    }
}