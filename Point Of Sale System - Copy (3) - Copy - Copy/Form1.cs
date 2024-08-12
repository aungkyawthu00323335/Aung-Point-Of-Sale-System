using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Point_Of_Sale_System
{
    public partial class Welcome_Form : Form
    {
        public Welcome_Form()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Hide all buttons
            btn_product_category.Visible = false;
            btn_ProductBrand.Visible = false;
            Btn_User.Visible = false;
            btn_Product.Visible = false;
            button6.Visible = false;
            Sale_Buttom.Visible = false;
            Btn_Bank_account.Visible = false;
            button8.Visible = false;
            btn_suppiler.Visible = false;
            button9.Visible = false;
            button1.Visible = false;
            panel3.Visible = false;
          
        }

        private void EmbedFormInPanel(Form form, Panel panel)
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Controls.Add(form);
            panel.Tag = form;
            form.Show();
        }

        private void btn_product_category_Click(object sender, EventArgs e)
        {
            Product_Category_Form category = new Product_Category_Form();
            EmbedFormInPanel(category, main_panel);
            main_panel.Visible = true;
        }

        private void btn_ProductBrand_Click(object sender, EventArgs e)
        {
            ProductBrand brand = new ProductBrand();
            EmbedFormInPanel(brand, main_panel);
            main_panel.Visible = true;
        }

        private void Btn_User_Click(object sender, EventArgs e)
        {
            User usr = new User();
            EmbedFormInPanel(usr, main_panel);
            main_panel.Visible = true;
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            EmbedFormInPanel(pro, main_panel);
            main_panel.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer_Form pro1 = new Customer_Form();
            EmbedFormInPanel(pro1, main_panel);
            main_panel.Visible = true;
        }

        private void Sale_Buttom_Click(object sender, EventArgs e)
        {
            Sale_Form sale = new Sale_Form();
            EmbedFormInPanel(sale, main_panel);
            main_panel.Visible = true;
        }

        private void Btn_Bank_account_Click(object sender, EventArgs e)
        {
            bank_account_form bankace = new bank_account_form();
            EmbedFormInPanel(bankace, main_panel);
            main_panel.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Invoice_Form inv = new Invoice_Form();
            EmbedFormInPanel(inv, main_panel);
            main_panel.Visible = true;
        }

        private void btn_suppiler_Click(object sender, EventArgs e)
        {
            Suppiler_Form sup = new Suppiler_Form();
            EmbedFormInPanel(sup, main_panel);
            main_panel.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Purchase_Form pur = new Purchase_Form();
            EmbedFormInPanel(pur, main_panel);
            main_panel.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard_Form dash = new Dashboard_Form();
            EmbedFormInPanel(dash, main_panel);
            main_panel.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string email = textBox4.Text;
            string password = textBox1.Text;

            string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM tbluser WHERE email = @Email AND password = @Password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string accountType = reader["account_type"].ToString();

                    MessageBox.Show("Login successful!");

                    if (accountType == "Admin")
                    {
                        // Show all buttons for admin
                        ShowAllButtons();
                    }
                    else if (accountType == "Staff")
                    {
                        // Show only specific buttons for staff
                        panel3.Visible = true;
                        Sale_Buttom.Visible = true;
                        button8.Visible = true;
                      
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong. Please check your email and password.");
                }
                reader.Close();
            }
        }

        private void ShowAllButtons()
        {
            btn_product_category.Visible = true;
            btn_ProductBrand.Visible = true;
            Btn_User.Visible = true;
            btn_Product.Visible = true;
            button6.Visible = true;
            Sale_Buttom.Visible = true;
            Btn_Bank_account.Visible = true;
            button8.Visible = true;
            btn_suppiler.Visible = true;
            button9.Visible = true;
            button1.Visible = true;
            panel3.Visible = true;
            
        }

     
    }
}
