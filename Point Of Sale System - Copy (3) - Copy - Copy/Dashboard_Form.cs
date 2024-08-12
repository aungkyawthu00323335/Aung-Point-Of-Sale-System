using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class Dashboard_Form : Form
    {
        // Your MySQL connection string
        private string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public Dashboard_Form()
        {
            InitializeComponent();
            LoadPriceTotal();
            LoadTodaySaleTotal();
            LoadOrderTaxTotal();
        }

        private void LoadPriceTotal()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SUM(CAST(price_total AS DECIMAL(10, 1))) AS total_price FROM tblsales";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        labelsale.Text = $"{result.ToString()}";
                    }
                    else
                    {
                        labelsale.Text = "Total Price: 0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadTodaySaleTotal()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT SUM(CAST(price_total AS DECIMAL(10, 1))) AS total_price
                        FROM tblsales
                        WHERE DATE(Clocki) = CURDATE()";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        todaysalelabel.Text = $"{result.ToString()}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadOrderTaxTotal()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT SUM(CAST(Order_tax AS DECIMAL(10, 1))) AS total_tax
                        FROM tblpayment";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        labeltax.Text = $"{result.ToString()}";
                    }
                    else
                    {
                        labeltax.Text = "Total Tax: 0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSalesData();
        }

        private void LoadSalesData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM tblsales";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void purchase_Click(object sender, EventArgs e)
        {
            LoadPurchaseData();
        }

        private void LoadPurchaseData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tblpurchaseorder"; // Adjust the table name if necessary
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                    dataGridViewsales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadTopProducts();
        }



        private void LoadTopProducts()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                     SELECT product_name, product_stock 
FROM tblsales 
ORDER BY product_stock DESC 
LIMIT 5";


                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                    dataGridViewsales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }


        }




        private void todaysalebtn_Click(object sender, EventArgs e)
        {
            LoadTodaySales();
        }

        private void LoadTodaySales()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT * 
                    FROM tblsales 
                    WHERE DATE(clocki) = CURDATE()";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                    dataGridViewsales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }






        private void button5_Click(object sender, EventArgs e)
        {
            LoadPaymentData();
        }

        private void LoadPaymentData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM tblpayment"; // Adjust the table name if necessary

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                    dataGridViewsales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }










        private void button4_Click(object sender, EventArgs e)
        {
            LoadTopCustomers();
        }

        private void LoadTopCustomers()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                    SELECT Customer_Name, SUM(price_total) AS TotalSales 
                    FROM tblsales 
                    GROUP BY Customer_Name 
                    ORDER BY price_total DESC 
                    LIMIT 5";

                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridViewsales.DataSource = dataTable;
                    dataGridViewsales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }








    }
}
