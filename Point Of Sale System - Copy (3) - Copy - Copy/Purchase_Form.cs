using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class Purchase_Form : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public Purchase_Form()
        {
            InitializeComponent();
            LoadProductData(); // Load the product data when the form initializes
            LoadSupplierData(); // Load the supplier data when the form initializes
            LoadUserData(); // Load the user data when the form initializes
            InitializeDataGridViewOrder(); // Initialize columns for dataGridVieworder
            dataGridViewProduct.SelectionChanged += DataGridViewProduct_SelectionChanged;
        }

        private void LoadProductData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tblproduct";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewProduct.DataSource = table;

                    // Set the DataGridView column sizes and properties
                    dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    foreach (DataGridViewColumn column in dataGridViewProduct.Columns)
                    {
                        column.Width = 150; // Adjust the width as needed
                    }

                    // Prevent the DataGridView from resizing
                    dataGridViewProduct.AllowUserToResizeColumns = false;
                    dataGridViewProduct.AllowUserToResizeRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadSupplierData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT suppiler_name FROM tblsuppiler";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items
                    comboBoxsuppilercombo.Items.Clear();

                    // Add items to the ComboBox
                    while (reader.Read())
                    {
                        comboBoxsuppilercombo.Items.Add(reader["suppiler_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void LoadUserData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT full_name FROM tbluser";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Clear existing items
                    comboBoxusercombo.Items.Clear();

                    // Add items to the ComboBox
                    while (reader.Read())
                    {
                        comboBoxusercombo.Items.Add(reader["full_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // Get the search text from the textBox
            string searchText = textBox4.Text.Trim();

            // Define the SQL query with a parameterized WHERE clause to prevent SQL injection
            string query = "SELECT * FROM tblproduct WHERE product_id LIKE @searchText OR product_name LIKE @searchText";

            // Filter the DataGridView based on the search text
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@searchText", "%" + searchText + "%");
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewProduct.DataSource = table;

                    // Optional: Adjust column sizes and properties
                    dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    foreach (DataGridViewColumn column in dataGridViewProduct.Columns)
                    {
                        column.Width = 150; // Adjust the width as needed
                    }

                    // Prevent the DataGridView from resizing
                    dataGridViewProduct.AllowUserToResizeColumns = false;
                    dataGridViewProduct.AllowUserToResizeRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void DataGridViewProduct_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewProduct.SelectedRows[0];

                // Get the unit price from the selected row
                string unitPrice = selectedRow.Cells["unit_price"].Value.ToString();

                // Set the unit price to the unit_pricetxt TextBox
                unit_pricetxt.Text = unitPrice;
            }
            else
            {
                // Clear the TextBox if no row is selected
                unit_pricetxt.Clear();
            }
        }

        private void quanitytxt_TextChanged(object sender, EventArgs e)
        {
            // Get the quantity and unit price from the TextBoxes
            string quantityText = quanitytxt.Text.Trim();
            string unitPriceText = unit_pricetxt.Text.Trim();

            // Try to parse the values
            if (decimal.TryParse(quantityText, out decimal quantity) && decimal.TryParse(unitPriceText, out decimal unitPrice))
            {
                // Calculate the subtotal
                decimal subtotal = quantity * unitPrice;

                // Update the subtotal TextBox
                sub_totaltxt.Text = subtotal.ToString("0.00"); // Format as needed
            }
            else
            {
                // Clear the subtotal TextBox if input is invalid
                sub_totaltxt.Clear();
            }
        }

        private void InitializeDataGridViewOrder()
        {
            // Add columns to dataGridVieworder
            dataGridVieworder.Columns.Clear();
            dataGridVieworder.Columns.Add("product_id", "Product ID");
            dataGridVieworder.Columns.Add("product_name", "Product Name");
            dataGridVieworder.Columns.Add("unit_price", "Unit Price");
            dataGridVieworder.Columns.Add("quantity", "Quantity");
            dataGridVieworder.Columns.Add("subtotal", "Subtotal");
           
            dataGridVieworder.Columns.Add("supplier", "Supplier");
            dataGridVieworder.Columns.Add("user", "User");

            // Set column widths or any other properties as needed
            foreach (DataGridViewColumn column in dataGridVieworder.Columns)
            {
                column.Width = 150; // Adjust width as needed
            }

            // Prevent the DataGridView from resizing
            dataGridVieworder.AllowUserToResizeColumns = false;
            dataGridVieworder.AllowUserToResizeRows = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (dataGridViewProduct.SelectedRows.Count > 0)
            {
                // Extract values from the selected product row and form controls
                DataGridViewRow selectedRow = dataGridViewProduct.SelectedRows[0];
                string productId = selectedRow.Cells["product_id"].Value.ToString();
                string productName = selectedRow.Cells["product_name"].Value.ToString();
                string unitPrice = unit_pricetxt.Text.Trim();
                string quantity = quanitytxt.Text.Trim();
                string subtotal = sub_totaltxt.Text.Trim();
                string orderStatus = orderstatustxt.Text.Trim();
                string supplier = comboBoxsuppilercombo.SelectedItem.ToString();
                string user = comboBoxusercombo.SelectedItem.ToString();

                // Add a new row to dataGridVieworder
                dataGridVieworder.Rows.Add(productId, productName, unitPrice, quantity, subtotal, orderStatus, supplier, user);

                // Calculate and update the total amount
                CalculateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please select a product to add.");
            }
        }

        private void buttonremove_Click(object sender, EventArgs e)
        {
            // Check if there are any rows selected in the DataGridView
            if (dataGridVieworder.SelectedRows.Count > 0)
            {
                // Confirm the removal action
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected row?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the selected row from the DataGridView
                    foreach (DataGridViewRow row in dataGridVieworder.SelectedRows)
                    {
                        // Remove the row from the DataGridView
                        dataGridVieworder.Rows.Remove(row);
                    }

                    // Calculate and update the total amount
                    CalculateTotalAmount();
                }
            }
            else
            {
                // Show a message if no row is selected
                MessageBox.Show("Please select a row to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            // Iterate through all rows in the DataGridView
            foreach (DataGridViewRow row in dataGridVieworder.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    // Try to parse the subtotal value
                    if (decimal.TryParse(row.Cells["subtotal"].Value.ToString(), out decimal subtotal))
                    {
                        totalAmount += subtotal;
                    }
                }
            }

            // Update the total amount TextBox
            total_amounttxt.Text = totalAmount.ToString("0.00"); // Format as needed
        }

        private void Suppiler_Create_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Start a transaction
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        // Get the maximum purchase_order_id from the database
                        string checkQuery = "SELECT COALESCE(MAX(purchase_order_id), 0) FROM tblpurchaseorder";
                        MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn, transaction);
                        object result = checkCmd.ExecuteScalar();
                        int nextOrderId = Convert.ToInt32(result) + 1;

                        // Loop through each row in dataGridVieworder and insert into tblpurchaseorder
                        foreach (DataGridViewRow row in dataGridVieworder.Rows)
                        {
                            if (row.IsNewRow) continue; // Skip the new row placeholder

                            // Get values from each column
                            string productId = row.Cells["product_id"].Value?.ToString() ?? string.Empty;
                            string productName = row.Cells["product_name"].Value?.ToString() ?? string.Empty;
                            string unitPrice = row.Cells["unit_price"].Value?.ToString() ?? string.Empty;
                            string quantity = row.Cells["quantity"].Value?.ToString() ?? string.Empty;
                            string subtotal = row.Cells["subtotal"].Value?.ToString() ?? string.Empty;
                            string supplier = row.Cells["supplier"].Value?.ToString() ?? string.Empty;
                            string user = row.Cells["user"].Value?.ToString() ?? string.Empty;

                            // Prepare the INSERT query for tblpurchaseorder
                            string insertQuery = @"
                        INSERT INTO tblpurchaseorder (purchase_order_id, products_id, product_name, unit_price, quanity, sub_total, order_date, suppiler_name, user_name)
                        VALUES (@purchaseOrderId, @productId, @productName, @unitPrice, @quantity, @subtotal, @orderDate, @supplier, @user)";

                            // Execute the INSERT command for tblpurchaseorder
                            MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@purchaseOrderId", nextOrderId);
                            insertCmd.Parameters.AddWithValue("@productId", productId);
                            insertCmd.Parameters.AddWithValue("@productName", productName);
                            insertCmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                            insertCmd.Parameters.AddWithValue("@quantity", quantity);
                            insertCmd.Parameters.AddWithValue("@subtotal", subtotal);
                            insertCmd.Parameters.AddWithValue("@orderDate", DateTime.Now); // Set current timestamp
                            insertCmd.Parameters.AddWithValue("@supplier", supplier);
                            insertCmd.Parameters.AddWithValue("@user", user);

                            insertCmd.ExecuteNonQuery();

                            // Update the unit_in_stock in tblproduct
                            string updateQuery = @"
                        UPDATE tblproduct
                        SET unit_in_stock = unit_in_stock + @quantity
                        WHERE product_id = @productId";

                            MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@quantity", quantity);
                            updateCmd.Parameters.AddWithValue("@productId", productId);

                            updateCmd.ExecuteNonQuery();
                        }

                        // Increment the order ID after the last row is inserted
                        nextOrderId++;

                        // Commit the transaction
                        transaction.Commit();
                        MessageBox.Show("Purchase orders have been successfully created and stock updated.");
                    }
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



    }
}
