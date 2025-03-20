using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace MidProjectDb
{
    public partial class sign : Form
    {


        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
       

       
        public int user_id { get; set; }

        public sign()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            email = textBox2.Text;
            password_hash = textBox3.Text;
           

            
            

            try
            {
                using (MySqlConnection conn = DatabaseHelper.Instance.getConnection())
                {
                    conn.Open(); // 

                  


                    // SQL query
                    string query = "INSERT INTO users ( user_id,username, email, password_hash) VALUES (@user_id, @Username, @Email, @Password)";

                    using (MySqlCommand cmd = new(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user_id);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password_hash);
                        


                        cmd.ExecuteNonQuery();
                    }
                   

                    MessageBox.Show("User registered successfully!");
                    this.Hide();
                    facultydashboard facul = new();
                    facul.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void sign_Load(object sender, EventArgs e)
        {

        }
    }
}
       

