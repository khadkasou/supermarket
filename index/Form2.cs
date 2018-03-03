using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace index
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static string connStr = "server=localhost; database=super_market; userId=root";

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM userlogin WHERE username = '" + userTextBox.Text + "' AND upassword = '" + passwordTextBox.Text + "'";
                    cmd.CommandType = CommandType.Text;

                    conn.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            this.Hide();
                            Main so = new Main();
                            so.Show();
                        }
                        else { MessageBox.Show("Incorrect username or password"); }
                    }
                }
            }

        }
    }
}
