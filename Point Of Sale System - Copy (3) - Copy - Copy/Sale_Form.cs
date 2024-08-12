using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;


namespace Point_Of_Sale_System
{
    public partial class Sale_Form : Form
    {
        private readonly string connectionString = "Server=localhost;Database=posproject;Uid=root;Pwd=root;";
        private decimal cartTotal = 0; // Field to track the cart total

        public Sale_Form()
        {
            InitializeComponent();
            this.Load += new EventHandler(Sale_Form_Load);
            Search_Product_id.TextChanged += new EventHandler(Search_Product_id_TextChanged);
            Search_Product_id.KeyDown += new KeyEventHandler(Search_Product_id_KeyDown);
            stock_txt.TextChanged += new EventHandler(stock_txt_TextChanged);
            textBoxDiscount.TextChanged += new EventHandler(CalculateTotals);
            textBox5tax.TextChanged += new EventHandler(CalculateTotals);
            btn_add.Click += new EventHandler(btn_add_Click);
            btn_remove.Click += new EventHandler(btn_remove_Click);
            next_btn.Click += new EventHandler(next_btn_Click);
            comboBoxBankName.SelectedIndexChanged += new EventHandler(comboBoxBankName_SelectedIndexChanged);
        }

        private void Sale_Form_Load(object sender, EventArgs e)
        {
            LoadProductData();
            ConfigureProductDataGridView();
            ConfigureCartDataGridView();
            LoadComboBoxData();
            buy_panel.Visible = false;
        }

        private void ConfigureProductDataGridView()
        {
            Product_Data_Grid_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Product_Data_Grid_View.MultiSelect = false;
            Product_Data_Grid_View.ReadOnly = true;
            Product_Data_Grid_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Product_Data_Grid_View.AutoSize = false;
        }

        private void ConfigureCartDataGridView()
        {
            Cart_Data_Grid_View.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Cart_Data_Grid_View.MultiSelect = true;
            Cart_Data_Grid_View.ReadOnly = false;
            Cart_Data_Grid_View.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Cart_Data_Grid_View.AutoSize = false;
            Cart_Data_Grid_View.RowHeadersVisible = false; // Hide row headers if not needed
            Cart_Data_Grid_View.AllowUserToAddRows = false; // Prevent adding rows directly
        }

        private void LoadProductData()
        {
            string query = "SELECT product_id, product_name, categoryid, unit_in_stock, unit_price, user_id, brand_id FROM tblproduct";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable productDataTable = new DataTable();
                    adapter.Fill(productDataTable);

                    if (productDataTable.Rows.Count > 0)
                    {
                        Product_Data_Grid_View.DataSource = productDataTable;
                    }
                    else
                    {
                        MessageBox.Show("No data found in the database.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            // Load customer names into comboBoxcustomer
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT customer_name FROM tblcustomer";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxcustomer.Items.Add(reader.GetString("customer_name"));
                        }
                    }
                }
            }

            // Load user names into comboxBoxuser
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT full_name FROM tbluser";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxUser.Items.Add(reader.GetString("full_name"));
                        }
                    }
                }
            }

            // Load bank account names into comboBoxBankName
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT bank_account_name FROM tblbankaccount";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxBankName.Items.Add(reader.GetString("bank_account_name"));
                        }
                    }
                }
            }
        }

        private void comboBoxBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected bank account name
            string selectedBankName = comboBoxBankName.SelectedItem.ToString();

            // Find and display the corresponding bank account number
            DisplayBankAccountNumber(selectedBankName);
        }

        private void DisplayBankAccountNumber(string bankAccountName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT bank_account_number FROM tblbankaccount WHERE bank_account_name = @bankAccountName";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@bankAccountName", bankAccountName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            textBoxBankAccountNumber.Text = reader.GetString("bank_account_number");
                        }
                        else
                        {
                            textBoxBankAccountNumber.Text = string.Empty; // Clear if no match
                        }
                    }
                }
            }
        }

        private void Search_Product_id_TextChanged(object sender, EventArgs e)
        {
            DataTable productDataTable = Product_Data_Grid_View.DataSource as DataTable;

            if (productDataTable != null)
            {
                string filterExpression = string.Empty;

                if (int.TryParse(Search_Product_id.Text, out int productId))
                {
                    filterExpression = $"product_id = {productId}";
                }
                else
                {
                    filterExpression = string.Empty; // Show all rows if input is not a valid integer
                }

                productDataTable.DefaultView.RowFilter = filterExpression;

                // Clear the stock and price total text boxes
                stock_txt.Clear();
                price_total_txt.Clear();
                textBoxTotal.Clear(); // Clear the total text box when searching
            }
        }

        private void Search_Product_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MoveSelectedProductToCart();
            }
        }

        private void stock_txt_TextChanged(object sender, EventArgs e)
        {
            // Calculate the total price based on the unit price and stock quantity
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Product_Data_Grid_View.SelectedRows[0];
                string unitPriceStr = (string)selectedRow.Cells["unit_price"].Value;

                if (decimal.TryParse(unitPriceStr, out decimal unitPrice))
                {
                    int quantity = 0;

                    if (int.TryParse(stock_txt.Text, out int stockQuantity))
                    {
                        quantity = stockQuantity;
                        decimal totalPrice = unitPrice * quantity;
                        price_total_txt.Text = totalPrice.ToString("F2");
                    }
                    else
                    {
                        price_total_txt.Text = "0.00";
                    }
                }
            }
        }

        private void MoveSelectedProductToCart()
        {
            if (Product_Data_Grid_View.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = Product_Data_Grid_View.SelectedRows[0];
                DataTable cartTable = Cart_Data_Grid_View.DataSource as DataTable;

                if (cartTable == null)
                {
                    cartTable = new DataTable();
                    cartTable.Columns.Add("product_id", typeof(int));
                    cartTable.Columns.Add("product_name", typeof(string));
                    cartTable.Columns.Add("product_stock", typeof(int));
                    cartTable.Columns.Add("unit_price", typeof(decimal));
                    cartTable.Columns.Add("price_total", typeof(decimal));
                    Cart_Data_Grid_View.DataSource = cartTable;
                }

                int productId = (int)selectedRow.Cells["product_id"].Value;
                string productName = (string)selectedRow.Cells["product_name"].Value;
                string unitPriceStr = (string)selectedRow.Cells["unit_price"].Value;

                if (decimal.TryParse(unitPriceStr, out decimal unitPrice))
                {
                    int quantity = 0;
                    if (int.TryParse(stock_txt.Text, out int stockQuantity))
                    {
                        quantity = stockQuantity;
                        if (quantity > 0)
                        {
                            decimal totalPrice = unitPrice * quantity;
                            price_total_txt.Text = totalPrice.ToString("F2");

                            // Check if the product already exists in the cart
                            DataRow existingRow = cartTable.AsEnumerable()
                                .FirstOrDefault(row => row.Field<int>("product_id") == productId);

                            if (existingRow != null)
                            {
                                // Update the quantity and total price of the existing product
                                existingRow.SetField("product_stock", quantity); // Replace quantity with new quantity
                                existingRow.SetField("price_total", quantity * unitPrice); // Recalculate total price
                            }
                            else
                            {
                                // Add new product to the cart
                                DataRow newRow = cartTable.NewRow();
                                newRow["product_id"] = productId;
                                newRow["product_name"] = productName;
                                newRow["product_stock"] = quantity;
                                newRow["unit_price"] = unitPrice;
                                newRow["price_total"] = totalPrice;

                                cartTable.Rows.Add(newRow);
                            }

                            Cart_Data_Grid_View.DataSource = cartTable;
                            CalculateCartTotal();
                        }
                        else
                        {
                            MessageBox.Show("Quantity must be greater than zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid quantity input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid unit price format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to add to the cart.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            MoveSelectedProductToCart();
            CalculateTotals(null, null); // Ensure totals are recalculated
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            RemoveSelectedProductFromCart();
            CalculateTotals(null, null); // Ensure totals are recalculated
        }

        private void RemoveSelectedProductFromCart()
        {
            foreach (DataGridViewRow row in Cart_Data_Grid_View.SelectedRows)
            {
                Cart_Data_Grid_View.Rows.Remove(row);
            }

            CalculateCartTotal();
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            buy_panel.Visible = true;
            sale_panel.Visible = false;
        }

        private void CalculateCartTotal()
        {
            cartTotal = 0; // Reset the cartTotal before recalculating

            foreach (DataGridViewRow row in Cart_Data_Grid_View.Rows)
            {
                // Ensure the row is not the new row placeholder
                if (!row.IsNewRow && row.Cells["price_total"].Value != null)
                {
                    string cellValue = row.Cells["price_total"].Value.ToString();
                    if (decimal.TryParse(cellValue, out decimal price))
                    {
                        cartTotal += price;
                    }
                }
            }

            // Update the total text boxes
            textBox9.Text = cartTotal.ToString("F2"); // Display the total in textBox9
            textBox1.Text = cartTotal.ToString("F2"); // Display the total in textBox1

           
        }

        private void CalculateTotals(object sender, EventArgs e)
        {
            // Retrieve current values from text boxes
            decimal subtotal = 0;
            decimal discount = 0;
            decimal tax = 0;

            // Get the subtotal from textBox1
            if (!decimal.TryParse(textBox1.Text, out subtotal))
            {
                subtotal = 0; // Default to 0 if not valid
            }

            // Get the discount from textBoxDiscount
            if (decimal.TryParse(textBoxDiscount.Text, out discount) && discount >= 0)
            {
                // Valid discount
            }
            else
            {
                discount = 0; // Default to 0 if not valid
            }

            // Get the tax from textBox5tax
            if (decimal.TryParse(textBox5tax.Text, out tax) && tax >= 0)
            {
                // Valid tax
            }
            else
            {
                tax = 0; // Default to 0 if not valid
            }

            // Calculate total after discount and tax
            decimal finalTotal = subtotal - discount + tax;
           

            // Update textBoxTotal
            textBoxTotal.Text = finalTotal.ToString();


            
        }





        private void textBoxamt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Attempt to parse the values from the text boxes
                if (decimal.TryParse(textBoxTotal.Text, out decimal num1) && decimal.TryParse(textBoxamt.Text, out decimal num2))
                {
                    // Calculate the result
                    decimal result = num1 - num2;

                    // Update textBoxref with the result
                    textBoxref.Text = result.ToString("F2"); // Formatting to two decimal places
                }
                else
                {
                    // Handle the case where the input is not a valid number
                    textBoxref.Text = "Invalid input";
                }
            }
            catch (Exception ex)
            {
                // Handle any other unexpected exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }














        private void btn_insert_Click(object sender, EventArgs e)
        {
            // Ensure there is data in the cart
            if (Cart_Data_Grid_View.Rows.Count == 0)
            {
                MessageBox.Show("The cart is empty. Add items to the cart before inserting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the user name from the selected item in comboBoxUser
            string selectedUserName = comboBoxUser.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUserName))
            {
                MessageBox.Show("Please select a user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the customer name from the selected item in comboBoxcustomer
            string selectedCustomerName = comboBoxcustomer.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedCustomerName))
            {
                MessageBox.Show("Please select a customer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get additional payment details
            string paymentType = comboBoxpayment.Text;
            string bankAccountName = comboBoxBankName.Text;
            string bankAccountNumber = textBoxBankAccountNumber.Text;
            decimal totalAmount = decimal.Parse(textBox1.Text);
            decimal discount = decimal.Parse(textBoxDiscount.Text);
            decimal orderTax = decimal.Parse(textBox5tax.Text);
            decimal priceTotal = decimal.Parse(textBoxTotal.Text);
            decimal amount = decimal.Parse(textBoxamt.Text);
            decimal refund = decimal.Parse(textBoxref.Text);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Get the maximum sale_id from tblsales
                    int newSaleId;
                    string getMaxSaleIdQuery = "SELECT COALESCE(MAX(sale_id), 0) + 1 FROM tblsales";
                    using (MySqlCommand getMaxSaleIdCmd = new MySqlCommand(getMaxSaleIdQuery, conn, transaction))
                    {
                        newSaleId = Convert.ToInt32(getMaxSaleIdCmd.ExecuteScalar());
                    }

                    // Insert into tblsales
                    string insertSaleQuery = "INSERT INTO tblsales (sale_id, product_id, product_name, product_stock, unit_price, price_total, customer_Name, user_name) " +
                                             "VALUES (@saleId, @productId, @productName, @productStock, @unitPrice, @priceTotal, @customerId, @userId)";

                    foreach (DataGridViewRow row in Cart_Data_Grid_View.Rows)
                    {
                        if (row.Cells["product_id"].Value != null)
                        {
                            int productId = Convert.ToInt32(row.Cells["product_id"].Value);
                            string productName = row.Cells["product_name"].Value.ToString();
                            int productStock = Convert.ToInt32(row.Cells["product_stock"].Value);
                            decimal unitPrice = Convert.ToDecimal(row.Cells["unit_price"].Value);
                            decimal priceTotalProduct = unitPrice * productStock;

                            using (MySqlCommand cmd = new MySqlCommand(insertSaleQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@saleId", newSaleId);
                                cmd.Parameters.AddWithValue("@productId", productId);
                                cmd.Parameters.AddWithValue("@productName", productName);
                                cmd.Parameters.AddWithValue("@productStock", productStock);
                                cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
                                cmd.Parameters.AddWithValue("@priceTotal", priceTotalProduct);
                                cmd.Parameters.AddWithValue("@customerId", selectedCustomerName);
                                cmd.Parameters.AddWithValue("@userId", selectedUserName);

                                cmd.ExecuteNonQuery();
                            }

                            string updateProductQuery = "UPDATE tblproduct SET unit_in_stock = unit_in_stock - @productStock WHERE product_id = @productId";
                            using (MySqlCommand updateCmd = new MySqlCommand(updateProductQuery, conn, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@productStock", productStock);
                                updateCmd.Parameters.AddWithValue("@productId", productId);

                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // Insert into tblpayment with the same sale_id as payment_id
                    string insertPaymentQuery = "INSERT INTO tblpayment (payment_id, payment_type, bank_accounts_name, bank_accounts_number, total_amount, discount, order_tax, price_total, amount, refound, customer_name, user_name) " +
                                                "VALUES (@paymentId, @paymentType, @bankAccountName, @bankAccountNumber, @totalAmount, @discount, @orderTax, @priceTotal, @amount, @refund, @customerName, @userName)";

                    using (MySqlCommand paymentCmd = new MySqlCommand(insertPaymentQuery, conn, transaction))
                    {
                        paymentCmd.Parameters.AddWithValue("@paymentId", newSaleId); // Use the same ID as sale_id
                        paymentCmd.Parameters.AddWithValue("@paymentType", paymentType);
                        paymentCmd.Parameters.AddWithValue("@bankAccountName", bankAccountName);
                        paymentCmd.Parameters.AddWithValue("@bankAccountNumber", bankAccountNumber);
                        paymentCmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                        paymentCmd.Parameters.AddWithValue("@discount", discount);
                        paymentCmd.Parameters.AddWithValue("@orderTax", orderTax);
                        paymentCmd.Parameters.AddWithValue("@priceTotal", priceTotal);
                        paymentCmd.Parameters.AddWithValue("@amount", amount);
                        paymentCmd.Parameters.AddWithValue("@refund", refund);
                        paymentCmd.Parameters.AddWithValue("@customerName", selectedCustomerName);
                        paymentCmd.Parameters.AddWithValue("@userName", selectedUserName);

                        paymentCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

























        private void Print_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Assuming you have a method to get the latest sale details
                var latestSale = GetLatestSaleDetails();
                // Assuming you have a method to get the latest payment details
                var latestPayment = GetLatestPaymentDetails();

                // Create a StringBuilder to build the receipt string
                StringBuilder receiptBuilder = new StringBuilder();

                // Add receipt header
                receiptBuilder.AppendLine("RECEIPT");
                receiptBuilder.AppendLine("Lorem ipsum dolor sit amet,");
                receiptBuilder.AppendLine("consectetur adipiscing elit,");
                receiptBuilder.AppendLine("Tel: 003 5676 78 88");
                receiptBuilder.AppendLine($"DATE: {latestSale.Clocki.ToString("dd/MM/yyyy HH:mm")}");
                receiptBuilder.AppendLine("******************************************");

                // Add sale details
                receiptBuilder.AppendLine($"Sale ID: {latestPayment.PaymentID}");
                receiptBuilder.AppendLine("ProductName            Product Stock      Amount           Total");

                // Retrieve sale items for the latest sale ID
                var saleItems = GetSaleItems(latestSale.SaleID);
                decimal totalAmount = 0;
                int itemCount = 0;
                foreach (var item in saleItems)
                {
                    receiptBuilder.AppendLine($"{item.ProductName.PadRight(20)} {item.ProductStock.ToString().PadRight(15)} {item.UnitPrice.ToString("C2").PadRight(15)} {item.Total.ToString("C2").PadRight(15)}");
                    totalAmount += item.Total;
                    itemCount += item.ProductStock;
                }

                receiptBuilder.AppendLine("******************************************");
                decimal orderTax = latestPayment.OrderTax;
                decimal discount = latestPayment.Discount;
                decimal finalTotal = totalAmount - discount + orderTax;
                receiptBuilder.AppendLine($"Item Count: {itemCount}");
                receiptBuilder.AppendLine($"Total Amount: {totalAmount.ToString("C2")}");
                receiptBuilder.AppendLine($"Order Tax: {orderTax.ToString("C2")}");
                receiptBuilder.AppendLine($"Discount: {discount.ToString("C2")}");
                receiptBuilder.AppendLine($"Total: {finalTotal.ToString("C2")}");
                receiptBuilder.AppendLine($"Customer: {latestPayment.CustomerName}");
                receiptBuilder.AppendLine($"Seller: {latestPayment.UserName}");
                receiptBuilder.AppendLine($"Payment Type: {latestPayment.PaymentType}");
                receiptBuilder.AppendLine($"Bank Account Name: {latestPayment.BankAccountName}");
                receiptBuilder.AppendLine($"Bank Account Number: {latestPayment.BankAccountNumber}");

                // Display the receipt
                MessageBox.Show(receiptBuilder.ToString(), "Receipt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private dynamic GetLatestSaleDetails()
        {
            dynamic latestSale = new { SaleID = 0, Clocki = DateTime.Now };
            string query = "SELECT sale_id, Clocki FROM tblsales ORDER BY sale_id DESC LIMIT 1";
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        latestSale = new
                        {
                            SaleID = Convert.ToInt32(reader["sale_id"]),
                            Clocki = Convert.ToDateTime(reader["Clocki"])
                        };
                    }
                }
            }
            return latestSale;
        }

        private dynamic GetLatestPaymentDetails()
        {
            var paymentDetails = new
            {
                PaymentID = 0,
                CustomerName = "",
                PaymentType = "",
                BankAccountName = "",
                BankAccountNumber = "",
                OrderTax = 0m,
                Discount = 0m,
                UserName = "",
                TotalAmount = 0m
            };

            string query = "SELECT payment_id, Customer_Name, Payment_Type, Bank_Accounts_Name, Bank_Accounts_Number, Order_Tax, Discount, User_Name, Total_Amount FROM tblpayment ORDER BY payment_id DESC LIMIT 1";
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        paymentDetails = new
                        {
                            PaymentID = Convert.ToInt32(reader["payment_id"]),
                            CustomerName = reader["Customer_Name"].ToString(),
                            PaymentType = reader["Payment_Type"].ToString(),
                            BankAccountName = reader["Bank_Accounts_Name"].ToString(),
                            BankAccountNumber = reader["Bank_Accounts_Number"].ToString(),
                            OrderTax = Convert.ToDecimal(reader["Order_Tax"]),
                            Discount = Convert.ToDecimal(reader["Discount"]),
                            UserName = reader["User_Name"].ToString(),
                            TotalAmount = Convert.ToDecimal(reader["Total_Amount"])
                        };
                    }
                }
            }
            return paymentDetails;
        }

        private List<dynamic> GetSaleItems(int saleID)
        {
            var saleItems = new List<dynamic>();
            string query = "SELECT Product_Name, Product_Stock, Unit_Price, Price_total FROM tblsales WHERE sale_id = @SaleID";
            using (var connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@SaleID", saleID);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        saleItems.Add(new
                        {
                            ProductName = reader["Product_Name"].ToString(),
                            ProductStock = Convert.ToInt32(reader["Product_Stock"]),
                            UnitPrice = Convert.ToDecimal(reader["Unit_Price"]),
                            Total = Convert.ToDecimal(reader["Price_total"])
                        });
                    }
                }
            }
            return saleItems;
        }
















    }
}
