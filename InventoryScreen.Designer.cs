namespace IMS
{
    partial class InventoryScreen
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDeletePart = new System.Windows.Forms.Button();
            this.buttonModifyPart = new System.Windows.Forms.Button();
            this.buttonAddPart = new System.Windows.Forms.Button();
            this.textBoxSearchParts = new System.Windows.Forms.TextBox();
            this.buttonSearchParts = new System.Windows.Forms.Button();
            this.PartsTable = new System.Windows.Forms.DataGridView();
            this.labelParts = new System.Windows.Forms.Label();
            this.MainTitle = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonModifyProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.textBoxSearchProducts = new System.Windows.Forms.TextBox();
            this.buttonSearchProducts = new System.Windows.Forms.Button();
            this.ProductsTable = new System.Windows.Forms.DataGridView();
            this.labelProducts = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartsTable)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDeletePart);
            this.groupBox1.Controls.Add(this.buttonModifyPart);
            this.groupBox1.Controls.Add(this.buttonAddPart);
            this.groupBox1.Controls.Add(this.textBoxSearchParts);
            this.groupBox1.Controls.Add(this.buttonSearchParts);
            this.groupBox1.Controls.Add(this.PartsTable);
            this.groupBox1.Controls.Add(this.labelParts);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 320);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonDeletePart
            // 
            this.buttonDeletePart.Location = new System.Drawing.Point(519, 273);
            this.buttonDeletePart.Name = "buttonDeletePart";
            this.buttonDeletePart.Size = new System.Drawing.Size(75, 36);
            this.buttonDeletePart.TabIndex = 6;
            this.buttonDeletePart.Text = "Delete";
            this.buttonDeletePart.UseVisualStyleBackColor = true;
            this.buttonDeletePart.Click += new System.EventHandler(this.buttonDeletePart_Click);
            // 
            // buttonModifyPart
            // 
            this.buttonModifyPart.Location = new System.Drawing.Point(438, 273);
            this.buttonModifyPart.Name = "buttonModifyPart";
            this.buttonModifyPart.Size = new System.Drawing.Size(75, 36);
            this.buttonModifyPart.TabIndex = 5;
            this.buttonModifyPart.Text = "Modify";
            this.buttonModifyPart.UseVisualStyleBackColor = true;
            this.buttonModifyPart.Click += new System.EventHandler(this.buttonModifyPart_Click);
            // 
            // buttonAddPart
            // 
            this.buttonAddPart.Location = new System.Drawing.Point(357, 273);
            this.buttonAddPart.Name = "buttonAddPart";
            this.buttonAddPart.Size = new System.Drawing.Size(75, 36);
            this.buttonAddPart.TabIndex = 4;
            this.buttonAddPart.Text = "Add";
            this.buttonAddPart.UseVisualStyleBackColor = true;
            this.buttonAddPart.Click += new System.EventHandler(this.buttonAddPart_Click);
            // 
            // textBoxSearchParts
            // 
            this.textBoxSearchParts.Location = new System.Drawing.Point(394, 16);
            this.textBoxSearchParts.Name = "textBoxSearchParts";
            this.textBoxSearchParts.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearchParts.TabIndex = 3;
            // 
            // buttonSearchParts
            // 
            this.buttonSearchParts.Location = new System.Drawing.Point(299, 14);
            this.buttonSearchParts.Name = "buttonSearchParts";
            this.buttonSearchParts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchParts.TabIndex = 2;
            this.buttonSearchParts.Text = "Search";
            this.buttonSearchParts.UseVisualStyleBackColor = true;
            this.buttonSearchParts.Click += new System.EventHandler(this.buttonSearchParts_Click);
            // 
            // PartsTable
            // 
            this.PartsTable.AllowUserToAddRows = false;
            this.PartsTable.AllowUserToDeleteRows = false;
            this.PartsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PartsTable.Location = new System.Drawing.Point(6, 43);
            this.PartsTable.Name = "PartsTable";
            this.PartsTable.ReadOnly = true;
            this.PartsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartsTable.Size = new System.Drawing.Size(588, 224);
            this.PartsTable.TabIndex = 1;
            // 
            // labelParts
            // 
            this.labelParts.AutoSize = true;
            this.labelParts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParts.Location = new System.Drawing.Point(6, 16);
            this.labelParts.Name = "labelParts";
            this.labelParts.Size = new System.Drawing.Size(51, 24);
            this.labelParts.TabIndex = 0;
            this.labelParts.Text = "Parts";
            // 
            // MainTitle
            // 
            this.MainTitle.AutoSize = true;
            this.MainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainTitle.Location = new System.Drawing.Point(7, 21);
            this.MainTitle.Name = "MainTitle";
            this.MainTitle.Size = new System.Drawing.Size(308, 25);
            this.MainTitle.TabIndex = 1;
            this.MainTitle.Text = "Inventory Management System";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1241, 402);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 36);
            this.button5.TabIndex = 2;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDeleteProduct);
            this.groupBox2.Controls.Add(this.buttonModifyProduct);
            this.groupBox2.Controls.Add(this.buttonAddProduct);
            this.groupBox2.Controls.Add(this.textBoxSearchProducts);
            this.groupBox2.Controls.Add(this.buttonSearchProducts);
            this.groupBox2.Controls.Add(this.ProductsTable);
            this.groupBox2.Controls.Add(this.labelProducts);
            this.groupBox2.Location = new System.Drawing.Point(716, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 320);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(519, 273);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(75, 36);
            this.buttonDeleteProduct.TabIndex = 6;
            this.buttonDeleteProduct.Text = "Delete";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonModifyProduct
            // 
            this.buttonModifyProduct.Location = new System.Drawing.Point(438, 273);
            this.buttonModifyProduct.Name = "buttonModifyProduct";
            this.buttonModifyProduct.Size = new System.Drawing.Size(75, 36);
            this.buttonModifyProduct.TabIndex = 5;
            this.buttonModifyProduct.Text = "Modify";
            this.buttonModifyProduct.UseVisualStyleBackColor = true;
            this.buttonModifyProduct.Click += new System.EventHandler(this.buttonModifyProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(357, 273);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 36);
            this.buttonAddProduct.TabIndex = 4;
            this.buttonAddProduct.Text = "Add";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // textBoxSearchProducts
            // 
            this.textBoxSearchProducts.Location = new System.Drawing.Point(394, 16);
            this.textBoxSearchProducts.Name = "textBoxSearchProducts";
            this.textBoxSearchProducts.Size = new System.Drawing.Size(200, 20);
            this.textBoxSearchProducts.TabIndex = 3;
            // 
            // buttonSearchProducts
            // 
            this.buttonSearchProducts.Location = new System.Drawing.Point(299, 14);
            this.buttonSearchProducts.Name = "buttonSearchProducts";
            this.buttonSearchProducts.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchProducts.TabIndex = 2;
            this.buttonSearchProducts.Text = "Search";
            this.buttonSearchProducts.UseVisualStyleBackColor = true;
            this.buttonSearchProducts.Click += new System.EventHandler(this.buttonSearchProducts_Click);
            // 
            // ProductsTable
            // 
            this.ProductsTable.AllowUserToAddRows = false;
            this.ProductsTable.AllowUserToDeleteRows = false;
            this.ProductsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsTable.Location = new System.Drawing.Point(6, 43);
            this.ProductsTable.Name = "ProductsTable";
            this.ProductsTable.ReadOnly = true;
            this.ProductsTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProductsTable.Size = new System.Drawing.Size(588, 224);
            this.ProductsTable.TabIndex = 1;
            // 
            // labelProducts
            // 
            this.labelProducts.AutoSize = true;
            this.labelProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProducts.Location = new System.Drawing.Point(6, 16);
            this.labelProducts.Name = "labelProducts";
            this.labelProducts.Size = new System.Drawing.Size(84, 24);
            this.labelProducts.TabIndex = 0;
            this.labelProducts.Text = "Products";
            // 
            // InventoryScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.MainTitle);
            this.Controls.Add(this.groupBox1);
            this.Name = "InventoryScreen";
            this.Text = "Inventory Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartsTable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label MainTitle;
        private System.Windows.Forms.Button buttonModifyPart;
        private System.Windows.Forms.Button buttonAddPart;
        private System.Windows.Forms.TextBox textBoxSearchParts;
        private System.Windows.Forms.Button buttonSearchParts;
        private System.Windows.Forms.DataGridView PartsTable;
        private System.Windows.Forms.Label labelParts;
        private System.Windows.Forms.Button buttonDeletePart;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Button buttonModifyProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.TextBox textBoxSearchProducts;
        private System.Windows.Forms.Button buttonSearchProducts;
        private System.Windows.Forms.DataGridView ProductsTable;
        private System.Windows.Forms.Label labelProducts;
    }
}

