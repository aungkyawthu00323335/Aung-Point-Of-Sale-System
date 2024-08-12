namespace Point_Of_Sale_System
{
    partial class bank_account_form
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.create_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_bank_acc_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_bank_acc_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.create_btn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_bank_acc_number);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_bank_acc_name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 653);
            this.panel1.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(597, 578);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(182, 52);
            this.btn_delete.TabIndex = 73;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // create_btn
            // 
            this.create_btn.Location = new System.Drawing.Point(151, 578);
            this.create_btn.Name = "create_btn";
            this.create_btn.Size = new System.Drawing.Size(182, 52);
            this.create_btn.TabIndex = 72;
            this.create_btn.Text = "Create";
            this.create_btn.UseVisualStyleBackColor = true;
            this.create_btn.Click += new System.EventHandler(this.create_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(454, 524);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 28);
            this.label4.TabIndex = 71;
            this.label4.Text = "Bank Account Number";
            // 
            // txt_bank_acc_number
            // 
            this.txt_bank_acc_number.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bank_acc_number.Location = new System.Drawing.Point(643, 518);
            this.txt_bank_acc_number.Name = "txt_bank_acc_number";
            this.txt_bank_acc_number.Size = new System.Drawing.Size(199, 39);
            this.txt_bank_acc_number.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 524);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 28);
            this.label2.TabIndex = 69;
            this.label2.Text = "Bank Account Name";
            // 
            // txt_bank_acc_name
            // 
            this.txt_bank_acc_name.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_bank_acc_name.Location = new System.Drawing.Point(188, 518);
            this.txt_bank_acc_name.Name = "txt_bank_acc_name";
            this.txt_bank_acc_name.Size = new System.Drawing.Size(199, 39);
            this.txt_bank_acc_name.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 54);
            this.label1.TabIndex = 63;
            this.label1.Text = "Create Bank Account";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(969, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // bank_account_form
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1142, 653);
            this.Controls.Add(this.panel1);
            this.Name = "bank_account_form";
            this.Text = "bank_account_form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_bank_acc_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_bank_acc_name;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button create_btn;
    }
}