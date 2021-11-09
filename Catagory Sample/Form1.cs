using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Catagory_Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();

            //int id = Convert.ToInt32("select id from users where where username = '" + UsernametextBox.Text + "' and password = '" + PasstextBox.Text + "'");
            string sql = "Insert into People(name,post) values('" + textBox1.Text + "','" + comboBox1.Text + "') ";
            SqlCommand command = new SqlCommand(sql, connection);

            int flag = command.ExecuteNonQuery();
            if (flag == 1)
            {
                connection.Close();
                MessageBox.Show("Event Created", "Successful");
            }
            else if (flag == 0)
            {
                connection.Close();
                MessageBox.Show("Event Can't Be Created!", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM people where post = '"+comboBox2.Text+"'";
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();

            List<Events> events = new List<Events>();

            while (reader.Read())
            {
                Events events1 = new Events();

                events1.Name = reader["name"].ToString();
                events1.Post = reader["post"].ToString();

                events.Add(events1);
            }

            dataGridView1.DataSource = events;
            connection.Close();
        }
    }
}
