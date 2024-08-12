using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class Suppiler_Form : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public Suppiler_Form()
        {
            InitializeComponent();
            LoadSuppilerData();
            dataGridViewSuppiler.SelectionChanged += DataGridViewSuppiler_SelectionChanged;
            textBox4.TextChanged += textBox4_TextChanged; // Subscribe to TextChanged event
        }

        private void LoadSuppilerData(string searchText = "")
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tblsuppiler";
                    if (!string.IsNullOrEmpty(searchText))
                    {
                        query += " WHERE suppiler_name LIKE @searchText OR suppiler_id = @searchId";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    if (int.TryParse(searchText, out int searchId))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@searchId", searchId);
                    }
                    else
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@searchId", DBNull.Value);
                    }

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewSuppiler.DataSource = table;

                    // Set the DataGridView column sizes and properties
                    dataGridViewSuppiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    foreach (DataGridViewColumn column in dataGridViewSuppiler.Columns)
                    {
                        column.Width = 150; // Adjust the width as needed
                    }

                    // Prevent the DataGridView from resizing
                    dataGridViewSuppiler.AllowUserToResizeColumns = false;
                    dataGridViewSuppiler.AllowUserToResizeRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Suppiler_Create_Click(object sender, EventArgs e)
        {
            // Retrieve data from text boxes
            string suppilerName = suppilernametxt.Text.Trim();
            string suppilerContact = suppilercontacttxt.Text.Trim();
            string suppilerAddress = suppileraddresstxt.Text.Trim();
            string suppilerEmail = suppileremailtxt.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(suppilerName) ||
                string.IsNullOrEmpty(suppilerContact) ||
                string.IsNullOrEmpty(suppilerAddress) ||
                string.IsNullOrEmpty(suppilerEmail))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Optional: Validate email format
            try
            {
                var addr = new System.Net.Mail.MailAddress(suppilerEmail);
            }
            catch
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Insert data into database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO tblsuppiler (suppiler_name, suppiler_contact, suppiler_address, suppiler_email) " +
                                   "VALUES (@suppilerName, @suppilerContact, @suppilerAddress, @suppilerEmail)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@suppilerName", suppilerName);
                        cmd.Parameters.AddWithValue("@suppilerContact", suppilerContact);
                        cmd.Parameters.AddWithValue("@suppilerAddress", suppilerAddress);
                        cmd.Parameters.AddWithValue("@suppilerEmail", suppilerEmail);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Supplier added successfully.");
                    LoadSuppilerData(); // Reload the data grid to show the new entry
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void DataGridViewSuppiler_SelectionChanged(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridViewSuppiler.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewSuppiler.SelectedRows[0];

                // Retrieve data from the selected row and display in text boxes
                suppilernametxt.Text = selectedRow.Cells["suppiler_name"].Value.ToString();
                suppilercontacttxt.Text = selectedRow.Cells["suppiler_contact"].Value.ToString();
                suppileraddresstxt.Text = selectedRow.Cells["suppiler_address"].Value.ToString();
                suppileremailtxt.Text = selectedRow.Cells["suppiler_email"].Value.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Call LoadSuppilerData with the search text
            LoadSuppilerData(textBox4.Text.Trim());
        }





        private void Buttom_Update_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridViewSuppiler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to update.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dataGridViewSuppiler.SelectedRows[0];

            // Retrieve the supplier ID from the selected row
            int supplierId = Convert.ToInt32(selectedRow.Cells["suppiler_id"].Value);

            // Retrieve data from text boxes
            string suppilerName = suppilernametxt.Text.Trim();
            string suppilerContact = suppilercontacttxt.Text.Trim();
            string suppilerAddress = suppileraddresstxt.Text.Trim();
            string suppilerEmail = suppileremailtxt.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(suppilerName) ||
                string.IsNullOrEmpty(suppilerContact) ||
                string.IsNullOrEmpty(suppilerAddress) ||
                string.IsNullOrEmpty(suppilerEmail))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Optional: Validate email format
            try
            {
                var addr = new System.Net.Mail.MailAddress(suppilerEmail);
            }
            catch
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Update data in database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tblsuppiler SET suppiler_name = @suppilerName, " +
                                   "suppiler_contact = @suppilerContact, suppiler_address = @suppilerAddress, " +
                                   "suppiler_email = @suppilerEmail WHERE suppiler_id = @suppilerId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@suppilerName", suppilerName);
                        cmd.Parameters.AddWithValue("@suppilerContact", suppilerContact);
                        cmd.Parameters.AddWithValue("@suppilerAddress", suppilerAddress);
                        cmd.Parameters.AddWithValue("@suppilerEmail", suppilerEmail);
                        cmd.Parameters.AddWithValue("@suppilerId", supplierId);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Supplier updated successfully.");
                    LoadSuppilerData(); // Reload the data grid to show the updated entry
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected
            if (dataGridViewSuppiler.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a supplier to delete.");
                return;
            }

            // Get the selected row
            DataGridViewRow selectedRow = dataGridViewSuppiler.SelectedRows[0];

            // Retrieve the supplier ID from the selected row
            int supplierId = Convert.ToInt32(selectedRow.Cells["suppiler_id"].Value);

            // Confirm deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this supplier?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // Delete data from database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM tblsuppiler WHERE suppiler_id = @suppilerId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Add parameter to prevent SQL injection
                        cmd.Parameters.AddWithValue("@suppilerId", supplierId);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Supplier deleted successfully.");
                    LoadSuppilerData(); // Reload the data grid to reflect the changes
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}
