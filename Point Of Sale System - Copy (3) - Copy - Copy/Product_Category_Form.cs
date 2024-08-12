using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class Product_Category_Form : Form
    {
        public Product_Category_Form()
        {
            InitializeComponent();
            // Load data when the form loads
            LoadData();
            // Handle DataGridView selection change event
            dataGridViewProductCategory.SelectionChanged += DataGridViewProductCategory_SelectionChanged;
        }

        private void LoadData()
        {
            // Define the connection string
            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

            // Define the query to select categories
            string query = "SELECT category_id, category_name FROM tblproductcategory ORDER BY category_id DESC";


            // Create a new DataTable
            DataTable dataTable = new DataTable();

            // Create a new MySqlConnection
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    cn.Open();

                    // Create a MySqlDataAdapter to fetch the data
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, cn))
                    {
                        // Fill the DataTable with data
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridViewProductCategory.DataSource = dataTable;

                    // Set DataGridView to fill columns
                    dataGridViewProductCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Optionally set each column to fill proportionally
                    foreach (DataGridViewColumn column in dataGridViewProductCategory.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void DataGridViewProductCategory_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewProductCategory.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewProductCategory.SelectedRows[0];

                // Get the category_name from the selected row and set it to txt_Category
                txt_Category.Text = selectedRow.Cells["category_name"].Value.ToString();
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            // Define the connection string
            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

            // Get the category name from the textbox
            string categoryName = txt_Category.Text.Trim();

            // Validate the input
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            // Define the query to insert a new category
            string query = "INSERT INTO tblproductcategory (category_name) VALUES (@CategoryName)";

            // Create a new MySqlConnection
            using (MySqlConnection cn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    cn.Open();

                    // Create a MySqlCommand
                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        // Add the parameter to the command
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Optionally, you can show a message to the user
                        MessageBox.Show("Category added successfully!");

                        // Reload data into DataGridView
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductCategory.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewProductCategory.SelectedRows[0];

                // Get the category_id from the selected row
                int categoryId = Convert.ToInt32(selectedRow.Cells["category_id"].Value);

                // Get the new category name from the textbox
                string newCategoryName = txt_Category.Text.Trim();

                // Validate the input
                if (string.IsNullOrEmpty(newCategoryName))
                {
                    MessageBox.Show("Please enter a category name.");
                    return;
                }

                // Define the connection string
                string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

                // Define the query to update the category name
                string query = "UPDATE tblproductcategory SET category_name = @CategoryName WHERE category_id = @CategoryId";

                // Create a new MySqlConnection
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        cn.Open();

                        // Create a MySqlCommand
                        using (MySqlCommand cmd = new MySqlCommand(query, cn))
                        {
                            // Add the parameters to the command
                            cmd.Parameters.AddWithValue("@CategoryName", newCategoryName);
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                            // Execute the command
                            cmd.ExecuteNonQuery();

                            // Optionally, you can show a message to the user
                            MessageBox.Show("Category updated successfully!");

                            // Reload data into DataGridView
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to update.");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductCategory.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridViewProductCategory.SelectedRows[0];

                // Get the category_id from the selected row
                int categoryId = Convert.ToInt32(selectedRow.Cells["category_id"].Value);

                // Define the connection string
                string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

                // Define the query to delete the category
                string query = "DELETE FROM tblproductcategory WHERE category_id = @CategoryId";

                // Create a new MySqlConnection
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        cn.Open();

                        // Create a MySqlCommand
                        using (MySqlCommand cmd = new MySqlCommand(query, cn))
                        {
                            // Add the parameter to the command
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                            // Execute the command
                            cmd.ExecuteNonQuery();

                            // Optionally, you can show a message to the user
                            MessageBox.Show("Category deleted successfully!");

                            // Reload data into DataGridView
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.");
            }
        }
    }
}
