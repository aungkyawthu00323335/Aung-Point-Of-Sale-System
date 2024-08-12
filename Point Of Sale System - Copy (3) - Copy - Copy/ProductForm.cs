using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class ProductForm : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public ProductForm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            LoadProductData();
            LoadBrandData();
            LoadCategoryData();
            ShowProductPanel();
            Product_Data_Grid_View.SelectionChanged += Product_Data_Grid_View_SelectionChanged;
        }

        private void LoadProductData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "SELECT product_id, product_name, categoryid, unit_in_stock, unit_price, user_id, brand_id FROM tblproduct ORDER BY product_id DESC";

                var cmd = new MySqlCommand(query, connection);
                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                Product_Data_Grid_View.DataSource = dt;
                SetColumnAutoSizeMode();
            }
        }

        private void SetColumnAutoSizeMode()
        {
            foreach (DataGridViewColumn column in Product_Data_Grid_View.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void LoadBrandData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "SELECT brand_id, brand_name FROM tblproductbrand";
                var cmd = new MySqlCommand(query, connection);
                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                brand_combo_box.DisplayMember = "brand_name";
                brand_combo_box.ValueMember = "brand_id";
                brand_combo_box.DataSource = dt;
            }
        }

        private void LoadCategoryData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "SELECT category_id, category_name FROM tblproductcategory";
                var cmd = new MySqlCommand(query, connection);
                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                category_combo_box.DisplayMember = "category_name";
                category_combo_box.ValueMember = "category_id";
                category_combo_box.DataSource = dt;
            }
        }

        private void ShowProductPanel()
        {
            product_panel.Visible = true;
            product_create_panel.Visible = false;
        }

        private void ShowProductCreatePanel()
        {
            product_panel.Visible = false;
            product_create_panel.Visible = true;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            ShowProductCreatePanel();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                ShowProductCreatePanel();
                var selectedRow = Product_Data_Grid_View.SelectedRows[0];
                txt_product_name.Text = selectedRow.Cells["product_name"].Value.ToString();
                category_combo_box.SelectedValue = selectedRow.Cells["categoryid"].Value;
                txt_unit_in_stock.Text = selectedRow.Cells["unit_in_stock"].Value.ToString();
                txt_unit_price.Text = selectedRow.Cells["unit_price"].Value.ToString();
                txt_UserID.Text = selectedRow.Cells["user_id"].Value.ToString();
                brand_combo_box.SelectedValue = selectedRow.Cells["brand_id"].Value;
            }
        }

        private void Buttom_Update_Click(object sender, EventArgs e)
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                var selectedRow = Product_Data_Grid_View.SelectedRows[0];
                var productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);

                using (var connection = new MySqlConnection(connectionString))
                {
                    const string query = "UPDATE tblproduct SET product_name = @product_name, categoryid = @categoryid, unit_in_stock = @unit_in_stock, unit_price = @unit_price, user_id = @user_id, brand_id = @brand_id WHERE product_id = @product_id";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@product_name", txt_product_name.Text);
                    cmd.Parameters.AddWithValue("@categoryid", category_combo_box.SelectedValue);
                    cmd.Parameters.AddWithValue("@unit_in_stock", txt_unit_in_stock.Text);
                    cmd.Parameters.AddWithValue("@unit_price", txt_unit_price.Text);
                    cmd.Parameters.AddWithValue("@user_id", txt_UserID.Text);
                    cmd.Parameters.AddWithValue("@brand_id", brand_combo_box.SelectedValue);
                    cmd.Parameters.AddWithValue("@product_id", productId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadProductData();
                ShowProductPanel();
            }
        }

        private void Product_Data_Grid_View_SelectionChanged(object sender, EventArgs e)
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                var selectedRow = Product_Data_Grid_View.SelectedRows[0];
                txt_product_name.Text = selectedRow.Cells["product_name"].Value.ToString();
                category_combo_box.SelectedValue = selectedRow.Cells["categoryid"].Value;
                txt_unit_in_stock.Text = selectedRow.Cells["unit_in_stock"].Value.ToString();
                txt_unit_price.Text = selectedRow.Cells["unit_price"].Value.ToString();
                txt_UserID.Text = selectedRow.Cells["user_id"].Value.ToString();
                brand_combo_box.SelectedValue = selectedRow.Cells["brand_id"].Value;
            }
        }

        private void Product_create_Click(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "INSERT INTO tblproduct (product_name, categoryid, unit_in_stock, unit_price, user_id, brand_id) VALUES (@product_name, @categoryid, @unit_in_stock, @unit_price, @user_id, @brand_id)";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@product_name", txt_product_name.Text);
                cmd.Parameters.AddWithValue("@categoryid", category_combo_box.SelectedValue);
                cmd.Parameters.AddWithValue("@unit_in_stock", txt_unit_in_stock.Text);
                cmd.Parameters.AddWithValue("@unit_price", txt_unit_price.Text);
                cmd.Parameters.AddWithValue("@user_id", txt_UserID.Text);
                cmd.Parameters.AddWithValue("@brand_id", brand_combo_box.SelectedValue);

                connection.Open();
                cmd.ExecuteNonQuery();
            }

            LoadProductData();
            ShowProductPanel();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            ShowProductPanel();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                // Confirm deletion
                var result = MessageBox.Show("Are you sure you want to delete the selected product?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Get the selected row
                    var selectedRow = Product_Data_Grid_View.SelectedRows[0];
                    var productId = Convert.ToInt32(selectedRow.Cells["product_id"].Value);

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        const string query = "DELETE FROM tblproduct WHERE product_id = @product_id";
                        var cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@product_id", productId);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    // Reload the product data
                    LoadProductData();
                    ShowProductPanel();
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Get the search text from the textBox1
            string searchText = textBox1.Text.Trim();

            using (var connection = new MySqlConnection(connectionString))
            {
                // Define the SQL query with a LIKE clause for partial matching
                string query = "SELECT product_id, product_name, categoryid, unit_in_stock, unit_price, user_id, brand_id " +
                               "FROM tblproduct " +
                               "WHERE product_name LIKE @searchText";

                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                // Set the filtered DataTable as the DataSource for the DataGridView
                Product_Data_Grid_View.DataSource = dt;
                SetColumnAutoSizeMode();
            }
        }

    }
}
