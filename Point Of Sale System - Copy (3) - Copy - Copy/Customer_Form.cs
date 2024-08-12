using System;
using MySql.Data.MySqlClient; // Use MySql.Data.MySqlClient for MySQL
using System.Windows.Forms;
using System.Data;

namespace Point_Of_Sale_System
{
    public partial class Customer_Form : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public Customer_Form()
        {
            InitializeComponent();
            LoadCustomerData();
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void LoadCustomerData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT customer_id, customer_name, contact, address FROM tblcustomer";
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }

                    // Set the columns to AutoSize mode
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    // Disable user resizing the columns
                    dataGridView1.AllowUserToResizeColumns = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void Customer_create_Click(object sender, EventArgs e)
        {
            string customerName = txt_customer_name.Text;
            string contactNumber = txt_contact_number.Text;
            string address = txt_address.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tblcustomer (customer_name, contact, address) VALUES (@customerName, @contactNumber, @address)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerName", customerName);
                        cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
                        cmd.Parameters.AddWithValue("@address", address);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer created successfully!");
                            LoadCustomerData(); // Refresh the data grid view
                        }
                        else
                        {
                            MessageBox.Show("Error in creating customer.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txt_customer_name.Text = selectedRow.Cells["customer_name"].Value.ToString();
                txt_contact_number.Text = selectedRow.Cells["contact"].Value.ToString();
                txt_address.Text = selectedRow.Cells["address"].Value.ToString();
            }
        }

        private void Customer_Update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["customer_id"].Value);
                string customerName = txt_customer_name.Text;
                string contactNumber = txt_contact_number.Text;
                string address = txt_address.Text;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE tblcustomer SET customer_name = @customerName, contact = @contactNumber, address = @address WHERE customer_id = @customerId";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);
                            cmd.Parameters.AddWithValue("@customerName", customerName);
                            cmd.Parameters.AddWithValue("@contactNumber", contactNumber);
                            cmd.Parameters.AddWithValue("@address", address);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer updated successfully!");
                                LoadCustomerData(); // Refresh the data grid view
                            }
                            else
                            {
                                MessageBox.Show("Error in updating customer.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["customer_id"].Value);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM tblcustomer WHERE customer_id = @customerId";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@customerId", customerId);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Customer deleted successfully!");
                                LoadCustomerData(); // Refresh the data grid view
                            }
                            else
                            {
                                MessageBox.Show("Error in deleting customer.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

      
    }
}
