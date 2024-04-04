using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbs
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=LAPTOP-5975IE7S;User ID=system;Password=***********";
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedState = comboBox1.SelectedItem.ToString();

            // Retrieve the selected sector from comboBox2
            string selectedSector = comboBox2.SelectedItem.ToString();

            // SQL query to fetch NGO information for the selected state and sector
            string query = "SELECT ngo_name, sector, address, type FROM NGO WHERE state = @State AND sector = @Sector";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@State", selectedState);
                command.Parameters.AddWithValue("@Sector", selectedSector);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Display NGO information (You can modify this part to suit your UI)
                        MessageBox.Show($"NGO Name: {reader["ngo_name"]}\nSector: {reader["sector"]}\nAddress: {reader["address"]}\nType: {reader["type"]}", "NGO Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
