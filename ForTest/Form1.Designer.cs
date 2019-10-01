namespace ForTest
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.textBoxPerson = new System.Windows.Forms.TextBox();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonAddTrip = new System.Windows.Forms.Button();
            this.textBoxTripName = new System.Windows.Forms.TextBox();
            this.listBoxTrips = new System.Windows.Forms.ListBox();
            this.listBoxPeople = new System.Windows.Forms.ListBox();
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.buttonDeletTrip = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProductDelet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelDebts = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxTripsAndPeople = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProductInfo = new System.Windows.Forms.TextBox();
            this.textBoxPersonInfo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonShowProduct = new System.Windows.Forms.Button();
            this.buttonShowPerson = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonTripsClear = new System.Windows.Forms.Button();
            this.groupBoxTripsAndPeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(261, 42);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(336, 22);
            this.textBoxProduct.TabIndex = 0;
            // 
            // textBoxPerson
            // 
            this.textBoxPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPerson.Location = new System.Drawing.Point(16, 230);
            this.textBoxPerson.Name = "textBoxPerson";
            this.textBoxPerson.Size = new System.Drawing.Size(125, 22);
            this.textBoxPerson.TabIndex = 1;
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddPerson.Image")));
            this.buttonAddPerson.Location = new System.Drawing.Point(147, 227);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(28, 28);
            this.buttonAddPerson.TabIndex = 8;
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddProduct.BackgroundImage")));
            this.buttonAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddProduct.Location = new System.Drawing.Point(627, 40);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(30, 30);
            this.buttonAddProduct.TabIndex = 9;
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonAddTrip
            // 
            this.buttonAddTrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddTrip.BackgroundImage")));
            this.buttonAddTrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddTrip.Location = new System.Drawing.Point(186, 42);
            this.buttonAddTrip.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddTrip.Name = "buttonAddTrip";
            this.buttonAddTrip.Size = new System.Drawing.Size(30, 28);
            this.buttonAddTrip.TabIndex = 10;
            this.buttonAddTrip.UseVisualStyleBackColor = true;
            this.buttonAddTrip.Click += new System.EventHandler(this.buttonAddTrip_Click);
            // 
            // textBoxTripName
            // 
            this.textBoxTripName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTripName.Location = new System.Drawing.Point(16, 42);
            this.textBoxTripName.Name = "textBoxTripName";
            this.textBoxTripName.Size = new System.Drawing.Size(159, 22);
            this.textBoxTripName.TabIndex = 11;
            // 
            // listBoxTrips
            // 
            this.listBoxTrips.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxTrips.FormattingEnabled = true;
            this.listBoxTrips.ItemHeight = 16;
            this.listBoxTrips.Location = new System.Drawing.Point(16, 77);
            this.listBoxTrips.Name = "listBoxTrips";
            this.listBoxTrips.Size = new System.Drawing.Size(200, 116);
            this.listBoxTrips.TabIndex = 14;
            // 
            // listBoxPeople
            // 
            this.listBoxPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPeople.FormattingEnabled = true;
            this.listBoxPeople.ItemHeight = 16;
            this.listBoxPeople.Location = new System.Drawing.Point(16, 265);
            this.listBoxPeople.Name = "listBoxPeople";
            this.listBoxPeople.Size = new System.Drawing.Size(200, 404);
            this.listBoxPeople.TabIndex = 15;
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 16;
            this.listBoxProducts.Location = new System.Drawing.Point(677, 40);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(178, 628);
            this.listBoxProducts.TabIndex = 16;
            // 
            // buttonDeletTrip
            // 
            this.buttonDeletTrip.FlatAppearance.BorderSize = 0;
            this.buttonDeletTrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeletTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeletTrip.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletTrip.Image")));
            this.buttonDeletTrip.Location = new System.Drawing.Point(192, 229);
            this.buttonDeletTrip.Name = "buttonDeletTrip";
            this.buttonDeletTrip.Size = new System.Drawing.Size(24, 24);
            this.buttonDeletTrip.TabIndex = 18;
            this.buttonDeletTrip.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Добавить поход в список";
            // 
            // buttonProductDelet
            // 
            this.buttonProductDelet.FlatAppearance.BorderSize = 0;
            this.buttonProductDelet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProductDelet.Image = ((System.Drawing.Image)(resources.GetObject("buttonProductDelet.Image")));
            this.buttonProductDelet.Location = new System.Drawing.Point(872, 40);
            this.buttonProductDelet.Name = "buttonProductDelet";
            this.buttonProductDelet.Size = new System.Drawing.Size(24, 24);
            this.buttonProductDelet.TabIndex = 20;
            this.buttonProductDelet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ввести продукт";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(423, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 34;
            // 
            // panelDebts
            // 
            this.panelDebts.AutoScroll = true;
            this.panelDebts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDebts.Location = new System.Drawing.Point(261, 89);
            this.panelDebts.Name = "panelDebts";
            this.panelDebts.Size = new System.Drawing.Size(336, 580);
            this.panelDebts.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(19, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Участники похода";
            // 
            // groupBoxTripsAndPeople
            // 
            this.groupBoxTripsAndPeople.Controls.Add(this.listBoxPeople);
            this.groupBoxTripsAndPeople.Controls.Add(this.label10);
            this.groupBoxTripsAndPeople.Controls.Add(this.textBoxPerson);
            this.groupBoxTripsAndPeople.Controls.Add(this.buttonAddPerson);
            this.groupBoxTripsAndPeople.Controls.Add(this.buttonAddTrip);
            this.groupBoxTripsAndPeople.Controls.Add(this.textBoxTripName);
            this.groupBoxTripsAndPeople.Controls.Add(this.listBoxTrips);
            this.groupBoxTripsAndPeople.Controls.Add(this.buttonDeletTrip);
            this.groupBoxTripsAndPeople.Controls.Add(this.label2);
            this.groupBoxTripsAndPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxTripsAndPeople.Location = new System.Drawing.Point(2, 0);
            this.groupBoxTripsAndPeople.Name = "groupBoxTripsAndPeople";
            this.groupBoxTripsAndPeople.Size = new System.Drawing.Size(235, 676);
            this.groupBoxTripsAndPeople.TabIndex = 38;
            this.groupBoxTripsAndPeople.TabStop = false;
            this.groupBoxTripsAndPeople.Text = "Походы и участники";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(261, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "скидывается  имя          кофф     платит";
            // 
            // textBoxProductInfo
            // 
            this.textBoxProductInfo.Location = new System.Drawing.Point(930, 69);
            this.textBoxProductInfo.Multiline = true;
            this.textBoxProductInfo.Name = "textBoxProductInfo";
            this.textBoxProductInfo.Size = new System.Drawing.Size(321, 251);
            this.textBoxProductInfo.TabIndex = 40;
            // 
            // textBoxPersonInfo
            // 
            this.textBoxPersonInfo.Location = new System.Drawing.Point(930, 370);
            this.textBoxPersonInfo.Multiline = true;
            this.textBoxPersonInfo.Name = "textBoxPersonInfo";
            this.textBoxPersonInfo.Size = new System.Drawing.Size(321, 299);
            this.textBoxPersonInfo.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(932, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 17);
            this.label4.TabIndex = 42;
            this.label4.Text = "Информация о продукте";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(932, 345);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 17);
            this.label5.TabIndex = 43;
            this.label5.Text = "Информация о человеке";
            // 
            // buttonShowProduct
            // 
            this.buttonShowProduct.Location = new System.Drawing.Point(883, 114);
            this.buttonShowProduct.Name = "buttonShowProduct";
            this.buttonShowProduct.Size = new System.Drawing.Size(27, 168);
            this.buttonShowProduct.TabIndex = 44;
            this.buttonShowProduct.Text = "Показать";
            this.buttonShowProduct.UseVisualStyleBackColor = true;
            this.buttonShowProduct.Click += new System.EventHandler(this.buttonShowProduct_Click);
            // 
            // buttonShowPerson
            // 
            this.buttonShowPerson.Location = new System.Drawing.Point(882, 394);
            this.buttonShowPerson.Name = "buttonShowPerson";
            this.buttonShowPerson.Size = new System.Drawing.Size(27, 180);
            this.buttonShowPerson.TabIndex = 45;
            this.buttonShowPerson.Text = "показать";
            this.buttonShowPerson.UseVisualStyleBackColor = true;
            this.buttonShowPerson.Click += new System.EventHandler(this.buttonShowPerson_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(1300, 18);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 34);
            this.buttonSave.TabIndex = 46;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(1300, 165);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(87, 28);
            this.buttonOpen.TabIndex = 47;
            this.buttonOpen.Text = "Открыть";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonTripsClear
            // 
            this.buttonTripsClear.Location = new System.Drawing.Point(1300, 89);
            this.buttonTripsClear.Name = "buttonTripsClear";
            this.buttonTripsClear.Size = new System.Drawing.Size(75, 23);
            this.buttonTripsClear.TabIndex = 48;
            this.buttonTripsClear.Text = "очистить";
            this.buttonTripsClear.UseVisualStyleBackColor = true;
            this.buttonTripsClear.Click += new System.EventHandler(this.buttonTripsClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 687);
            this.Controls.Add(this.buttonTripsClear);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonShowPerson);
            this.Controls.Add(this.buttonShowProduct);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPersonInfo);
            this.Controls.Add(this.textBoxProductInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxTripsAndPeople);
            this.Controls.Add(this.panelDebts);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonProductDelet);
            this.Controls.Add(this.listBoxProducts);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.textBoxProduct);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBoxTripsAndPeople.ResumeLayout(false);
            this.groupBoxTripsAndPeople.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.TextBox textBoxPerson;
        private System.Windows.Forms.Button buttonAddPerson;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddTrip;
        private System.Windows.Forms.TextBox textBoxTripName;
        private System.Windows.Forms.ListBox listBoxTrips;
        private System.Windows.Forms.ListBox listBoxPeople;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Button buttonDeletTrip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonProductDelet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panelDebts;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxTripsAndPeople;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProductInfo;
        private System.Windows.Forms.TextBox textBoxPersonInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonShowProduct;
        private System.Windows.Forms.Button buttonShowPerson;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonTripsClear;
    }
}

