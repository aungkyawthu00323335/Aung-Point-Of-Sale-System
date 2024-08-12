using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Add this directive for MySQL connection

namespace Point_Of_Sale_System
{
    public partial class User : Form
    {
        private string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
        private int selectedUserId; // To store the selected user ID
        private DataTable userDataTable; // To store the user data

        public User()
        {
            InitializeComponent();
            this.Load += new EventHandler(User_Load);
            dataGridViewuser.SelectionChanged += new EventHandler(dataGridViewuser_SelectionChanged);
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged); // Add event handler for textBox1 text change
            btn_Delete.Click += new EventHandler(btn_Delete_Click); // Add event handler for Delete button
        }

        private void User_Load(object sender, EventArgs e)
        {
            LoadUserData();
            dataGridViewuser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Ensures columns fill the DataGridView width

            // Set the font size of the DataGridView to 12pt
            dataGridViewuser.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12);
            dataGridViewuser.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold); // Optional: Set font size for column headers
        }

        private void LoadUserData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT user_id, full_name, phone_no, email, password, account_type FROM tbluser";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    userDataTable = new DataTable();
                    adapter.Fill(userDataTable);
                    dataGridViewuser.DataSource = userDataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void dataGridViewuser_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewuser.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewuser.SelectedRows[0];
                selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);
                full_name.Text = row.Cells["full_name"].Value.ToString();
                phone_no.Text = row.Cells["phone_no"].Value.ToString();
                emaill.Text = row.Cells["email"].Value.ToString();
                pass.Text = row.Cells["password"].Value.ToString();
                account_typecbo.SelectedIndex = row.Cells["account_type"].Value.ToString() == "Admin" ? 0 : 1;
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string fullName = full_name.Text;
            string phoneNo = phone_no.Text;
            string email = emaill.Text;
            string password = pass.Text;
            string accountType = account_typecbo.SelectedIndex == 0 ? "Admin" : "Staff";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO tbluser (full_name, phone_no, email, password, account_type) VALUES (@FullName, @PhoneNo, @Email, @Password, @AccountType)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@AccountType", accountType);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("User created successfully!");
                    LoadUserData(); // Refresh the DataGridView to show the new data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string fullName = full_name.Text;
            string phoneNo = phone_no.Text;
            string email = emaill.Text;
            string password = pass.Text;
            string accountType = account_typecbo.SelectedIndex == 0 ? "Admin" : "Staff";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE tbluser SET full_name = @FullName, phone_no = @PhoneNo, email = @Email, password = @Password, account_type = @AccountType WHERE user_id = @UserId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@AccountType", accountType);
                        cmd.Parameters.AddWithValue("@UserId", selectedUserId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("User updated successfully!");
                    LoadUserData(); // Refresh the DataGridView to show the updated data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (selectedUserId != 0)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM tbluser WHERE user_id = @UserId";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@UserId", selectedUserId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("User deleted successfully!");
                        LoadUserData(); // Refresh the DataGridView to show the updated data
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView dv = userDataTable.DefaultView;
            dv.RowFilter = string.Format("full_name LIKE '%{0}%' OR phone_no LIKE '%{0}%' OR email LIKE '%{0}%'", textBox1.Text);
            dataGridViewuser.DataSource = dv.ToTable();
        }
    }
}
