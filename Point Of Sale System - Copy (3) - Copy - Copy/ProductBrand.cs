using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class ProductBrand : Form
    {
        public ProductBrand()
        {
            InitializeComponent();
            this.Load += new EventHandler(ProductBrand_Load);
            this.BranddataGridView.SelectionChanged += new EventHandler(BranddataGridView_SelectionChanged);
        }

        private void ProductBrand_Load(object sender, EventArgs e)
        {
            LoadBrandData();
        }

        private void LoadBrandData()
        {
            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
            string query = "SELECT brand_id, brand_name FROM tblproductbrand";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                BranddataGridView.DataSource = dataTable;
                BranddataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void BranddataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (BranddataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BranddataGridView.SelectedRows[0];
                txt_Brand.Text = selectedRow.Cells["brand_name"].Value.ToString();
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string brandName = txt_Brand.Text.Trim();

            if (string.IsNullOrEmpty(brandName))
            {
                MessageBox.Show("Brand name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
            string query = "INSERT INTO tblproductbrand (brand_name) VALUES (@brand_name)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@brand_name", brandName);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Brand added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBrandData(); // Refresh the DataGridView to show the new brand
                txt_Brand.Clear(); // Clear the textbox after insertion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (BranddataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a brand to update.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = BranddataGridView.SelectedRows[0];
            int brandId = Convert.ToInt32(selectedRow.Cells["brand_id"].Value);
            string brandName = txt_Brand.Text.Trim();

            if (string.IsNullOrEmpty(brandName))
            {
                MessageBox.Show("Brand name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
            string query = "UPDATE tblproductbrand SET brand_name = @brand_name WHERE brand_id = @brand_id";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@brand_name", brandName);
                        command.Parameters.AddWithValue("@brand_id", brandId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Brand updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBrandData(); // Refresh the DataGridView to show the updated brand
                txt_Brand.Clear(); // Clear the textbox after update
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (BranddataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a brand to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = BranddataGridView.SelectedRows[0];
            int brandId = Convert.ToInt32(selectedRow.Cells["brand_id"].Value);

            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
            string query = "DELETE FROM tblproductbrand WHERE brand_id = @brand_id";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@brand_id", brandId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Brand deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadBrandData(); // Refresh the DataGridView to remove the deleted brand
                txt_Brand.Clear(); // Clear the textbox after deletion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
