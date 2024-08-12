using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Point_Of_Sale_System
{
    public partial class bank_account_form : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";

        public bank_account_form()
        {
            InitializeComponent();
            // Subscribe to the Load event
            this.Load += new EventHandler(bank_account_form_Load);
        }

        private void bank_account_form_Load(object sender, EventArgs e)
        {
            LoadBankAccountData();
        }

        private void LoadBankAccountData()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                // Updated query to order by bank_account_id in descending order
                const string query = "SELECT * FROM tblbankaccount ORDER BY bank_account_id DESC";
                var cmd = new MySqlCommand(query, connection);
                var adapter = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                // Bind data to DataGridView
                dataGridView1.DataSource = dt;

                // Set DataGridView properties
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void create_btn_Click(object sender, EventArgs e)
        {
            // Retrieve values from text boxes
            string bankAccountName = txt_bank_acc_name.Text;
            string bankAccountNumber = txt_bank_acc_number.Text;

            // Validate input
            if (string.IsNullOrEmpty(bankAccountName) || string.IsNullOrEmpty(bankAccountNumber))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                const string query = "INSERT INTO tblbankaccount (bank_account_name, bank_account_number) VALUES (@bankAccountName, @bankAccountNumber)";
                var cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@bankAccountName", bankAccountName);
                cmd.Parameters.AddWithValue("@bankAccountNumber", bankAccountNumber);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bank account added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload data to reflect changes
                    LoadBankAccountData();

                    // Clear input fields
                    txt_bank_acc_name.Clear();
                    txt_bank_acc_number.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the selected row
                var selectedRow = dataGridView1.SelectedRows[0];
                // Retrieve the bank_account_id from the selected row
                int bankAccountId = Convert.ToInt32(selectedRow.Cells["bank_account_id"].Value);

                // Confirm deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        const string query = "DELETE FROM tblbankaccount WHERE bank_account_id = @bankAccountId";
                        var cmd = new MySqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@bankAccountId", bankAccountId);

                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Bank account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload data to reflect changes
                            LoadBankAccountData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
