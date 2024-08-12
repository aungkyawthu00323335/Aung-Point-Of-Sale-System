using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class Invoice_Form : Form
    {
        private string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
        private BindingSource paymentBindingSource = new BindingSource();
        private BindingSource salesBindingSource = new BindingSource();

        public Invoice_Form()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadPaymentData();
            LoadSalesData();
        }

        private void LoadPaymentData()
        {
            string query = "SELECT * FROM tblpayment";
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable paymentTable = new DataTable();
                adapter.Fill(paymentTable);
                paymentBindingSource.DataSource = paymentTable;
                dataGridViewPayment.DataSource = paymentBindingSource;

                foreach (DataGridViewColumn column in dataGridViewPayment.Columns)
                {
                    column.Width = 100; // Set the desired column width
                }

                dataGridViewPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }

        private void LoadSalesData()
        {
            string query = "SELECT * FROM tblsales";
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable salesTable = new DataTable();
                adapter.Fill(salesTable);
                salesBindingSource.DataSource = salesTable;
                dataGridViewProduct.DataSource = salesBindingSource;

                foreach (DataGridViewColumn column in dataGridViewProduct.Columns)
                {
                    column.Width = 100; // Set the desired column width
                }

                dataGridViewProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
        }
        
        private void txtSearchinvoice_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearchinvoice.Text.Trim();

            if (string.IsNullOrEmpty(filterText))
            {
                paymentBindingSource.RemoveFilter();
                salesBindingSource.RemoveFilter();
            }
            else
            {
                paymentBindingSource.Filter = $"Convert(payment_id, 'System.String') LIKE '%{filterText}%'";
                salesBindingSource.Filter = $"Convert(sale_id, 'System.String') LIKE '%{filterText}%'";
            }
        }
    }
}
