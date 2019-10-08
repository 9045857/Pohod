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
            this.textBoxPersonInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProductInfo = new System.Windows.Forms.TextBox();
            this.listBoxPayGroupLeader = new System.Windows.Forms.ListBox();
            this.listBoxPayGroupDoing = new System.Windows.Forms.ListBox();
            this.buttonDoPayGroup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.labelLeader = new System.Windows.Forms.Label();
            this.groupBoxTripsAndPeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(335, 39);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(261, 22);
            this.textBoxProduct.TabIndex = 0;
            // 
            // textBoxPerson
            // 
            this.textBoxPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPerson.Location = new System.Drawing.Point(11, 211);
            this.textBoxPerson.Name = "textBoxPerson";
            this.textBoxPerson.Size = new System.Drawing.Size(257, 22);
            this.textBoxPerson.TabIndex = 1;
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddPerson.BackgroundImage")));
            this.buttonAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPerson.Location = new System.Drawing.Point(274, 211);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(30, 30);
            this.buttonAddPerson.TabIndex = 8;
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddProduct.BackgroundImage")));
            this.buttonAddProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAddProduct.Location = new System.Drawing.Point(605, 40);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(22, 22);
            this.buttonAddProduct.TabIndex = 9;
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonAddTrip
            // 
            this.buttonAddTrip.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAddTrip.BackgroundImage")));
            this.buttonAddTrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAddTrip.Location = new System.Drawing.Point(274, 42);
            this.buttonAddTrip.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddTrip.Name = "buttonAddTrip";
            this.buttonAddTrip.Size = new System.Drawing.Size(30, 30);
            this.buttonAddTrip.TabIndex = 10;
            this.buttonAddTrip.UseVisualStyleBackColor = true;
            this.buttonAddTrip.Click += new System.EventHandler(this.buttonAddTrip_Click);
            // 
            // textBoxTripName
            // 
            this.textBoxTripName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTripName.Location = new System.Drawing.Point(8, 42);
            this.textBoxTripName.Name = "textBoxTripName";
            this.textBoxTripName.Size = new System.Drawing.Size(257, 22);
            this.textBoxTripName.TabIndex = 11;
            // 
            // listBoxTrips
            // 
            this.listBoxTrips.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxTrips.FormattingEnabled = true;
            this.listBoxTrips.ItemHeight = 16;
            this.listBoxTrips.Location = new System.Drawing.Point(8, 70);
            this.listBoxTrips.Name = "listBoxTrips";
            this.listBoxTrips.ScrollAlwaysVisible = true;
            this.listBoxTrips.Size = new System.Drawing.Size(257, 84);
            this.listBoxTrips.TabIndex = 14;
            this.listBoxTrips.SelectedIndexChanged += new System.EventHandler(this.listBoxTrips_SelectedIndexChanged);
            // 
            // listBoxPeople
            // 
            this.listBoxPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxPeople.FormattingEnabled = true;
            this.listBoxPeople.ItemHeight = 16;
            this.listBoxPeople.Location = new System.Drawing.Point(10, 239);
            this.listBoxPeople.Name = "listBoxPeople";
            this.listBoxPeople.ScrollAlwaysVisible = true;
            this.listBoxPeople.Size = new System.Drawing.Size(257, 100);
            this.listBoxPeople.TabIndex = 15;
            this.listBoxPeople.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPeople_MouseClick);
            this.listBoxPeople.SelectedIndexChanged += new System.EventHandler(this.listBoxPeople_SelectedIndexChanged);
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 16;
            this.listBoxProducts.Location = new System.Drawing.Point(335, 264);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.ScrollAlwaysVisible = true;
            this.listBoxProducts.Size = new System.Drawing.Size(261, 116);
            this.listBoxProducts.TabIndex = 16;
            this.listBoxProducts.SelectedIndexChanged += new System.EventHandler(this.listBoxProducts_SelectedIndexChanged);
            // 
            // buttonDeletTrip
            // 
            this.buttonDeletTrip.FlatAppearance.BorderSize = 0;
            this.buttonDeletTrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeletTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeletTrip.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletTrip.Image")));
            this.buttonDeletTrip.Location = new System.Drawing.Point(274, 279);
            this.buttonDeletTrip.Name = "buttonDeletTrip";
            this.buttonDeletTrip.Size = new System.Drawing.Size(30, 30);
            this.buttonDeletTrip.TabIndex = 18;
            this.buttonDeletTrip.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 21);
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
            this.buttonProductDelet.Location = new System.Drawing.Point(605, 301);
            this.buttonProductDelet.Name = "buttonProductDelet";
            this.buttonProductDelet.Size = new System.Drawing.Size(30, 28);
            this.buttonProductDelet.TabIndex = 20;
            this.buttonProductDelet.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ввести продукт";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 34;
            // 
            // panelDebts
            // 
            this.panelDebts.AutoScroll = true;
            this.panelDebts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDebts.Location = new System.Drawing.Point(335, 88);
            this.panelDebts.Name = "panelDebts";
            this.panelDebts.Size = new System.Drawing.Size(300, 163);
            this.panelDebts.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(8, 188);
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
            this.groupBoxTripsAndPeople.Controls.Add(this.textBoxPersonInfo);
            this.groupBoxTripsAndPeople.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxTripsAndPeople.Location = new System.Drawing.Point(2, 0);
            this.groupBoxTripsAndPeople.Name = "groupBoxTripsAndPeople";
            this.groupBoxTripsAndPeople.Size = new System.Drawing.Size(309, 676);
            this.groupBoxTripsAndPeople.TabIndex = 38;
            this.groupBoxTripsAndPeople.TabStop = false;
            this.groupBoxTripsAndPeople.Text = "Походы и участники";
            // 
            // textBoxPersonInfo
            // 
            this.textBoxPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPersonInfo.Location = new System.Drawing.Point(8, 387);
            this.textBoxPersonInfo.Multiline = true;
            this.textBoxPersonInfo.Name = "textBoxPersonInfo";
            this.textBoxPersonInfo.Size = new System.Drawing.Size(287, 288);
            this.textBoxPersonInfo.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(342, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 17);
            this.label1.TabIndex = 39;
            this.label1.Text = "v  имя              коэф / долг   оплата";
            // 
            // textBoxProductInfo
            // 
            this.textBoxProductInfo.Location = new System.Drawing.Point(335, 386);
            this.textBoxProductInfo.Multiline = true;
            this.textBoxProductInfo.Name = "textBoxProductInfo";
            this.textBoxProductInfo.Size = new System.Drawing.Size(300, 289);
            this.textBoxProductInfo.TabIndex = 40;
            // 
            // listBoxPayGroupLeader
            // 
            this.listBoxPayGroupLeader.FormattingEnabled = true;
            this.listBoxPayGroupLeader.ItemHeight = 16;
            this.listBoxPayGroupLeader.Location = new System.Drawing.Point(677, 36);
            this.listBoxPayGroupLeader.Name = "listBoxPayGroupLeader";
            this.listBoxPayGroupLeader.Size = new System.Drawing.Size(187, 260);
            this.listBoxPayGroupLeader.TabIndex = 49;
            this.listBoxPayGroupLeader.SelectedIndexChanged += new System.EventHandler(this.listBoxPersonalPayGroup_SelectedIndexChanged);
            // 
            // listBoxPayGroupDoing
            // 
            this.listBoxPayGroupDoing.FormattingEnabled = true;
            this.listBoxPayGroupDoing.ItemHeight = 16;
            this.listBoxPayGroupDoing.Location = new System.Drawing.Point(870, 100);
            this.listBoxPayGroupDoing.Name = "listBoxPayGroupDoing";
            this.listBoxPayGroupDoing.Size = new System.Drawing.Size(174, 196);
            this.listBoxPayGroupDoing.TabIndex = 50;
            // 
            // buttonDoPayGroup
            // 
            this.buttonDoPayGroup.Location = new System.Drawing.Point(918, 36);
            this.buttonDoPayGroup.Name = "buttonDoPayGroup";
            this.buttonDoPayGroup.Size = new System.Drawing.Size(126, 28);
            this.buttonDoPayGroup.TabIndex = 52;
            this.buttonDoPayGroup.Text = "Собрать группу";
            this.buttonDoPayGroup.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 53;
            this.label4.Text = "Лидер:";
            // 
            // labelLeader
            // 
            this.labelLeader.AutoSize = true;
            this.labelLeader.Location = new System.Drawing.Point(932, 73);
            this.labelLeader.Name = "labelLeader";
            this.labelLeader.Size = new System.Drawing.Size(64, 17);
            this.labelLeader.TabIndex = 54;
            this.labelLeader.Text = "_______";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 687);
            this.Controls.Add(this.labelLeader);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonDoPayGroup);
            this.Controls.Add(this.listBoxPayGroupDoing);
            this.Controls.Add(this.listBoxPayGroupLeader);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.ListBox listBoxPayGroupLeader;
        private System.Windows.Forms.ListBox listBoxPayGroupDoing;
        private System.Windows.Forms.Button buttonDoPayGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelLeader;
    }
}

