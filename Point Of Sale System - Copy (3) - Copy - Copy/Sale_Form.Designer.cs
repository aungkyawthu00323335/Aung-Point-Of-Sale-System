namespace Point_Of_Sale_System
{
    partial class Sale_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sale_panel = new System.Windows.Forms.Panel();
            this.btn_remove = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.next_btn = new System.Windows.Forms.Button();
            this.price_total_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.stock_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Search_Product_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Cart_Data_Grid_View = new System.Windows.Forms.DataGridView();
            this.Product_Data_Grid_View = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.buy_panel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxamt = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxref = new System.Windows.Forms.TextBox();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.comboBoxpayment = new System.Windows.Forms.ComboBox();
            this.textBoxBankAccountNumber = new System.Windows.Forms.TextBox();
            this.comboBoxBankName = new System.Windows.Forms.ComboBox();
            this.comboBoxcustomer = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Print_btn = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5tax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDiscount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_insert = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sale_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cart_Data_Grid_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Data_Grid_View)).BeginInit();
            this.buy_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sale_panel
            // 
            this.sale_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.sale_panel.Controls.Add(this.btn_remove);
            this.sale_panel.Controls.Add(this.label14);
            this.sale_panel.Controls.Add(this.textBox9);
            this.sale_panel.Controls.Add(this.next_btn);
            this.sale_panel.Controls.Add(this.price_total_txt);
            this.sale_panel.Controls.Add(this.label7);
            this.sale_panel.Controls.Add(this.btn_add);
            this.sale_panel.Controls.Add(this.stock_txt);
            this.sale_panel.Controls.Add(this.label6);
            this.sale_panel.Controls.Add(this.Search_Product_id);
            this.sale_panel.Controls.Add(this.label3);
            this.sale_panel.Controls.Add(this.Cart_Data_Grid_View);
            this.sale_panel.Controls.Add(this.Product_Data_Grid_View);
            this.sale_panel.Controls.Add(this.label5);
            this.sale_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sale_panel.Location = new System.Drawing.Point(0, 0);
            this.sale_panel.Name = "sale_panel";
            this.sale_panel.Size = new System.Drawing.Size(1078, 637);
            this.sale_panel.TabIndex = 59;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(138, 279);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(127, 52);
            this.btn_remove.TabIndex = 67;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(601, 297);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(141, 28);
            this.label14.TabIndex = 66;
            this.label14.Text = "Total Amount";
            // 
            // textBox9
            // 
            this.textBox9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(702, 290);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(146, 39);
            this.textBox9.TabIndex = 65;
            // 
            // next_btn
            // 
            this.next_btn.Location = new System.Drawing.Point(848, 277);
            this.next_btn.Name = "next_btn";
            this.next_btn.Size = new System.Drawing.Size(129, 52);
            this.next_btn.TabIndex = 64;
            this.next_btn.Text = "Next";
            this.next_btn.UseVisualStyleBackColor = true;
            this.next_btn.Click += new System.EventHandler(this.next_btn_Click);
            // 
            // price_total_txt
            // 
            this.price_total_txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price_total_txt.Location = new System.Drawing.Point(480, 292);
            this.price_total_txt.Name = "price_total_txt";
            this.price_total_txt.Size = new System.Drawing.Size(120, 39);
            this.price_total_txt.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(400, 298);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 28);
            this.label7.TabIndex = 62;
            this.label7.Text = "Price Total";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(10, 279);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(127, 52);
            this.btn_add.TabIndex = 61;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // stock_txt
            // 
            this.stock_txt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock_txt.Location = new System.Drawing.Point(358, 294);
            this.stock_txt.Name = "stock_txt";
            this.stock_txt.Size = new System.Drawing.Size(42, 39);
            this.stock_txt.TabIndex = 60;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(259, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 28);
            this.label6.TabIndex = 59;
            this.label6.Text = "Product Stock";
            // 
            // Search_Product_id
            // 
            this.Search_Product_id.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_Product_id.Location = new System.Drawing.Point(12, 65);
            this.Search_Product_id.Name = "Search_Product_id";
            this.Search_Product_id.Size = new System.Drawing.Size(268, 39);
            this.Search_Product_id.TabIndex = 56;
            this.Search_Product_id.TextChanged += new System.EventHandler(this.Search_Product_id_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(286, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 54);
            this.label3.TabIndex = 55;
            this.label3.Text = "Search By Product ID";
            // 
            // Cart_Data_Grid_View
            // 
            this.Cart_Data_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Cart_Data_Grid_View.Location = new System.Drawing.Point(12, 337);
            this.Cart_Data_Grid_View.Name = "Cart_Data_Grid_View";
            this.Cart_Data_Grid_View.RowHeadersWidth = 62;
            this.Cart_Data_Grid_View.RowTemplate.Height = 28;
            this.Cart_Data_Grid_View.Size = new System.Drawing.Size(965, 288);
            this.Cart_Data_Grid_View.TabIndex = 54;
            // 
            // Product_Data_Grid_View
            // 
            this.Product_Data_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Product_Data_Grid_View.Location = new System.Drawing.Point(12, 110);
            this.Product_Data_Grid_View.Name = "Product_Data_Grid_View";
            this.Product_Data_Grid_View.RowHeadersWidth = 62;
            this.Product_Data_Grid_View.RowTemplate.Height = 28;
            this.Product_Data_Grid_View.Size = new System.Drawing.Size(965, 167);
            this.Product_Data_Grid_View.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(218, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(572, 54);
            this.label5.TabIndex = 52;
            this.label5.Text = "Customer Imformatin Details";
            // 
            // buy_panel
            // 
            this.buy_panel.Controls.Add(this.label17);
            this.buy_panel.Controls.Add(this.textBoxamt);
            this.buy_panel.Controls.Add(this.label16);
            this.buy_panel.Controls.Add(this.textBoxref);
            this.buy_panel.Controls.Add(this.comboBoxUser);
            this.buy_panel.Controls.Add(this.comboBoxpayment);
            this.buy_panel.Controls.Add(this.textBoxBankAccountNumber);
            this.buy_panel.Controls.Add(this.comboBoxBankName);
            this.buy_panel.Controls.Add(this.comboBoxcustomer);
            this.buy_panel.Controls.Add(this.button3);
            this.buy_panel.Controls.Add(this.Print_btn);
            this.buy_panel.Controls.Add(this.label15);
            this.buy_panel.Controls.Add(this.label10);
            this.buy_panel.Controls.Add(this.textBox5tax);
            this.buy_panel.Controls.Add(this.label11);
            this.buy_panel.Controls.Add(this.label12);
            this.buy_panel.Controls.Add(this.label13);
            this.buy_panel.Controls.Add(this.label9);
            this.buy_panel.Controls.Add(this.label8);
            this.buy_panel.Controls.Add(this.textBoxTotal);
            this.buy_panel.Controls.Add(this.label4);
            this.buy_panel.Controls.Add(this.textBoxDiscount);
            this.buy_panel.Controls.Add(this.label2);
            this.buy_panel.Controls.Add(this.btn_insert);
            this.buy_panel.Controls.Add(this.textBox1);
            this.buy_panel.Controls.Add(this.label1);
            this.buy_panel.Location = new System.Drawing.Point(0, 0);
            this.buy_panel.Name = "buy_panel";
            this.buy_panel.Size = new System.Drawing.Size(1078, 634);
            this.buy_panel.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(447, 365);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 28);
            this.label17.TabIndex = 98;
            this.label17.Text = "Amount";
            // 
            // textBoxamt
            // 
            this.textBoxamt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxamt.Location = new System.Drawing.Point(600, 359);
            this.textBoxamt.Name = "textBoxamt";
            this.textBoxamt.Size = new System.Drawing.Size(131, 39);
            this.textBoxamt.TabIndex = 97;
            this.textBoxamt.TextChanged += new System.EventHandler(this.textBoxamt_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(447, 434);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 28);
            this.label16.TabIndex = 96;
            this.label16.Text = "Refound";
            // 
            // textBoxref
            // 
            this.textBoxref.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxref.Location = new System.Drawing.Point(600, 428);
            this.textBoxref.Name = "textBoxref";
            this.textBoxref.Size = new System.Drawing.Size(131, 39);
            this.textBoxref.TabIndex = 95;
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(213, 358);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(128, 40);
            this.comboBoxUser.TabIndex = 92;
            // 
            // comboBoxpayment
            // 
            this.comboBoxpayment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxpayment.FormattingEnabled = true;
            this.comboBoxpayment.Items.AddRange(new object[] {
            "Cash",
            "Bank"});
            this.comboBoxpayment.Location = new System.Drawing.Point(597, 103);
            this.comboBoxpayment.Name = "comboBoxpayment";
            this.comboBoxpayment.Size = new System.Drawing.Size(128, 40);
            this.comboBoxpayment.TabIndex = 91;
            // 
            // textBoxBankAccountNumber
            // 
            this.textBoxBankAccountNumber.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBankAccountNumber.Location = new System.Drawing.Point(597, 228);
            this.textBoxBankAccountNumber.Name = "textBoxBankAccountNumber";
            this.textBoxBankAccountNumber.Size = new System.Drawing.Size(131, 39);
            this.textBoxBankAccountNumber.TabIndex = 90;
            // 
            // comboBoxBankName
            // 
            this.comboBoxBankName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBankName.FormattingEnabled = true;
            this.comboBoxBankName.Location = new System.Drawing.Point(600, 166);
            this.comboBoxBankName.Name = "comboBoxBankName";
            this.comboBoxBankName.Size = new System.Drawing.Size(128, 40);
            this.comboBoxBankName.TabIndex = 89;
            // 
            // comboBoxcustomer
            // 
            this.comboBoxcustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxcustomer.FormattingEnabled = true;
            this.comboBoxcustomer.Location = new System.Drawing.Point(216, 295);
            this.comboBoxcustomer.Name = "comboBoxcustomer";
            this.comboBoxcustomer.Size = new System.Drawing.Size(128, 40);
            this.comboBoxcustomer.TabIndex = 88;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(654, 516);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 52);
            this.button3.TabIndex = 87;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Print_btn
            // 
            this.Print_btn.Location = new System.Drawing.Point(436, 516);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(182, 52);
            this.Print_btn.TabIndex = 86;
            this.Print_btn.Text = "Print";
            this.Print_btn.UseVisualStyleBackColor = true;
            this.Print_btn.Click += new System.EventHandler(this.Print_btn_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(60, 358);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 28);
            this.label15.TabIndex = 85;
            this.label15.Text = "User id";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(447, 298);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 28);
            this.label10.TabIndex = 79;
            this.label10.Text = "Order Tax";
            // 
            // textBox5tax
            // 
            this.textBox5tax.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5tax.Location = new System.Drawing.Point(600, 292);
            this.textBox5tax.Name = "textBox5tax";
            this.textBox5tax.Size = new System.Drawing.Size(131, 39);
            this.textBox5tax.TabIndex = 78;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(448, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(226, 28);
            this.label11.TabIndex = 77;
            this.label11.Text = "Bank Account Number";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(447, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(205, 28);
            this.label12.TabIndex = 75;
            this.label12.Text = "Bank Account Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(448, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 28);
            this.label13.TabIndex = 73;
            this.label13.Text = "Payment Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(59, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 28);
            this.label9.TabIndex = 71;
            this.label9.Text = "Customer Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(60, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 28);
            this.label8.TabIndex = 69;
            this.label8.Text = "Price Total";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTotal.Location = new System.Drawing.Point(213, 228);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(131, 39);
            this.textBoxTotal.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 28);
            this.label4.TabIndex = 67;
            this.label4.Text = "Discount";
            // 
            // textBoxDiscount
            // 
            this.textBoxDiscount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDiscount.Location = new System.Drawing.Point(213, 167);
            this.textBoxDiscount.Name = "textBoxDiscount";
            this.textBoxDiscount.Size = new System.Drawing.Size(131, 39);
            this.textBoxDiscount.TabIndex = 66;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 28);
            this.label2.TabIndex = 65;
            this.label2.Text = "Total Amount";
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(191, 516);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(182, 52);
            this.btn_insert.TabIndex = 64;
            this.btn_insert.Text = "Compelete";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(213, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 39);
            this.textBox1.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(354, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 54);
            this.label1.TabIndex = 62;
            this.label1.Text = "Sale Our Product";
            // 
            // Sale_Form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1078, 637);
            this.Controls.Add(this.buy_panel);
            this.Controls.Add(this.sale_panel);
            this.Name = "Sale_Form";
            this.Text = "Sale_Form";
            this.sale_panel.ResumeLayout(false);
            this.sale_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Cart_Data_Grid_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Data_Grid_View)).EndInit();
            this.buy_panel.ResumeLayout(false);
            this.buy_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sale_panel;
        private System.Windows.Forms.Button next_btn;
        private System.Windows.Forms.TextBox price_total_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox stock_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Search_Product_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Cart_Data_Grid_View;
        private System.Windows.Forms.DataGridView Product_Data_Grid_View;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel buy_panel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox5tax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDiscount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Print_btn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ComboBox comboBoxcustomer;
        private System.Windows.Forms.ComboBox comboBoxBankName;
        private System.Windows.Forms.TextBox textBoxBankAccountNumber;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private System.Windows.Forms.ComboBox comboBoxpayment;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxamt;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxref;
    }
}