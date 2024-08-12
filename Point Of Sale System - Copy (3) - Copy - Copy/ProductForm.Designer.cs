namespace Point_Of_Sale_System
{
    partial class ProductForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductForm));
            this.product_panel = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Product_Data_Grid_View = new System.Windows.Forms.DataGridView();
            this.product_create_panel = new System.Windows.Forms.Panel();
            this.category_combo_box = new System.Windows.Forms.ComboBox();
            this.brand_combo_box = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_UserID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_unit_price = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_unit_in_stock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.Buttom_Update = new System.Windows.Forms.Button();
            this.Product_create = new System.Windows.Forms.Button();
            this.txt_product_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.product_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Data_Grid_View)).BeginInit();
            this.product_create_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // product_panel
            // 
            this.product_panel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.product_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("product_panel.BackgroundImage")));
            this.product_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.product_panel.Controls.Add(this.btn_Delete);
            this.product_panel.Controls.Add(this.btn_Update);
            this.product_panel.Controls.Add(this.btn_Create);
            this.product_panel.Controls.Add(this.textBox1);
            this.product_panel.Controls.Add(this.label2);
            this.product_panel.Controls.Add(this.Product_Data_Grid_View);
            this.product_panel.Location = new System.Drawing.Point(1, 1);
            this.product_panel.Name = "product_panel";
            this.product_panel.Size = new System.Drawing.Size(1107, 644);
            this.product_panel.TabIndex = 0;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(786, 563);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(182, 52);
            this.btn_Delete.TabIndex = 23;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.Location = new System.Drawing.Point(401, 563);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(182, 52);
            this.btn_Update.TabIndex = 22;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.Location = new System.Drawing.Point(18, 563);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(182, 52);
            this.btn_Create.TabIndex = 21;
            this.btn_Create.Text = "Create";
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(557, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 39);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Aqua;
            this.label2.Location = new System.Drawing.Point(60, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 54);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search By Product Name";
            // 
            // Product_Data_Grid_View
            // 
            this.Product_Data_Grid_View.BackgroundColor = System.Drawing.Color.White;
            this.Product_Data_Grid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Product_Data_Grid_View.Location = new System.Drawing.Point(12, 153);
            this.Product_Data_Grid_View.Name = "Product_Data_Grid_View";
            this.Product_Data_Grid_View.RowHeadersWidth = 62;
            this.Product_Data_Grid_View.RowTemplate.Height = 28;
            this.Product_Data_Grid_View.Size = new System.Drawing.Size(968, 365);
            this.Product_Data_Grid_View.TabIndex = 0;
            // 
            // product_create_panel
            // 
            this.product_create_panel.BackColor = System.Drawing.Color.Transparent;
            this.product_create_panel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("product_create_panel.BackgroundImage")));
            this.product_create_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.product_create_panel.Controls.Add(this.category_combo_box);
            this.product_create_panel.Controls.Add(this.brand_combo_box);
            this.product_create_panel.Controls.Add(this.label7);
            this.product_create_panel.Controls.Add(this.txt_UserID);
            this.product_create_panel.Controls.Add(this.label8);
            this.product_create_panel.Controls.Add(this.txt_unit_price);
            this.product_create_panel.Controls.Add(this.label9);
            this.product_create_panel.Controls.Add(this.txt_unit_in_stock);
            this.product_create_panel.Controls.Add(this.label6);
            this.product_create_panel.Controls.Add(this.label5);
            this.product_create_panel.Controls.Add(this.label4);
            this.product_create_panel.Controls.Add(this.btn_exit);
            this.product_create_panel.Controls.Add(this.Buttom_Update);
            this.product_create_panel.Controls.Add(this.Product_create);
            this.product_create_panel.Controls.Add(this.txt_product_name);
            this.product_create_panel.Controls.Add(this.label3);
            this.product_create_panel.Location = new System.Drawing.Point(-10, 4);
            this.product_create_panel.Name = "product_create_panel";
            this.product_create_panel.Size = new System.Drawing.Size(1144, 657);
            this.product_create_panel.TabIndex = 24;
            // 
            // category_combo_box
            // 
            this.category_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category_combo_box.FormattingEnabled = true;
            this.category_combo_box.Location = new System.Drawing.Point(516, 183);
            this.category_combo_box.Name = "category_combo_box";
            this.category_combo_box.Size = new System.Drawing.Size(268, 37);
            this.category_combo_box.TabIndex = 36;
            // 
            // brand_combo_box
            // 
            this.brand_combo_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brand_combo_box.FormattingEnabled = true;
            this.brand_combo_box.Location = new System.Drawing.Point(516, 441);
            this.brand_combo_box.Name = "brand_combo_box";
            this.brand_combo_box.Size = new System.Drawing.Size(268, 37);
            this.brand_combo_box.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(243, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 38);
            this.label7.TabIndex = 34;
            this.label7.Text = "Brand ID";
            // 
            // txt_UserID
            // 
            this.txt_UserID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UserID.Location = new System.Drawing.Point(516, 376);
            this.txt_UserID.Name = "txt_UserID";
            this.txt_UserID.Size = new System.Drawing.Size(268, 39);
            this.txt_UserID.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(243, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 38);
            this.label8.TabIndex = 32;
            this.label8.Text = "User ID";
            // 
            // txt_unit_price
            // 
            this.txt_unit_price.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_unit_price.Location = new System.Drawing.Point(516, 308);
            this.txt_unit_price.Name = "txt_unit_price";
            this.txt_unit_price.Size = new System.Drawing.Size(268, 39);
            this.txt_unit_price.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(243, 309);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 38);
            this.label9.TabIndex = 30;
            this.label9.Text = "Unit Price";
            // 
            // txt_unit_in_stock
            // 
            this.txt_unit_in_stock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_unit_in_stock.Location = new System.Drawing.Point(516, 246);
            this.txt_unit_in_stock.Name = "txt_unit_in_stock";
            this.txt_unit_in_stock.Size = new System.Drawing.Size(268, 39);
            this.txt_unit_in_stock.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Yellow;
            this.label6.Location = new System.Drawing.Point(243, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 38);
            this.label6.TabIndex = 28;
            this.label6.Text = "Unit In Stock";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(243, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 38);
            this.label5.TabIndex = 26;
            this.label5.Text = "Category ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Aqua;
            this.label4.Location = new System.Drawing.Point(297, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(539, 54);
            this.label4.TabIndex = 25;
            this.label4.Text = "Product Imformatin Details";
            // 
            // btn_exit
            // 
            this.btn_exit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btn_exit.Location = new System.Drawing.Point(779, 560);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(182, 52);
            this.btn_exit.TabIndex = 24;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Buttom_Update
            // 
            this.Buttom_Update.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Buttom_Update.Location = new System.Drawing.Point(453, 560);
            this.Buttom_Update.Name = "Buttom_Update";
            this.Buttom_Update.Size = new System.Drawing.Size(182, 52);
            this.Buttom_Update.TabIndex = 22;
            this.Buttom_Update.Text = "Update";
            this.Buttom_Update.UseVisualStyleBackColor = true;
            this.Buttom_Update.Click += new System.EventHandler(this.Buttom_Update_Click);
            // 
            // Product_create
            // 
            this.Product_create.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Product_create.Location = new System.Drawing.Point(143, 560);
            this.Product_create.Name = "Product_create";
            this.Product_create.Size = new System.Drawing.Size(182, 52);
            this.Product_create.TabIndex = 21;
            this.Product_create.Text = "Create";
            this.Product_create.UseVisualStyleBackColor = true;
            this.Product_create.Click += new System.EventHandler(this.Product_create_Click);
            // 
            // txt_product_name
            // 
            this.txt_product_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_product_name.Location = new System.Drawing.Point(516, 112);
            this.txt_product_name.Name = "txt_product_name";
            this.txt_product_name.Size = new System.Drawing.Size(268, 39);
            this.txt_product_name.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(243, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Product Name";
            // 
            // ProductForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1131, 653);
            this.Controls.Add(this.product_create_panel);
            this.Controls.Add(this.product_panel);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.product_panel.ResumeLayout(false);
            this.product_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Data_Grid_View)).EndInit();
            this.product_create_panel.ResumeLayout(false);
            this.product_create_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel product_panel;
        private System.Windows.Forms.DataGridView Product_Data_Grid_View;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Panel product_create_panel;
        private System.Windows.Forms.Button Buttom_Update;
        private System.Windows.Forms.Button Product_create;
        private System.Windows.Forms.TextBox txt_product_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_UserID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_unit_price;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_unit_in_stock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox category_combo_box;
        private System.Windows.Forms.ComboBox brand_combo_box;
    }
}