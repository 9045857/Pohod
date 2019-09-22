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
            this.textBoxPerson = new System.Windows.Forms.TextBox();
            this.textBoxEnterPerson = new System.Windows.Forms.TextBox();
            this.comboBoxPerson1 = new System.Windows.Forms.ComboBox();
            this.comboBoxPerson2 = new System.Windows.Forms.ComboBox();
            this.textBoxPay1 = new System.Windows.Forms.TextBox();
            this.textBoxPay2 = new System.Windows.Forms.TextBox();
            this.buttonAddPerson = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.buttonAddTrip = new System.Windows.Forms.Button();
            this.textBoxTripName = new System.Windows.Forms.TextBox();
            this.comboBoxTripList = new System.Windows.Forms.ComboBox();
            this.listBoxTrips = new System.Windows.Forms.ListBox();
            this.listBoxPeople = new System.Windows.Forms.ListBox();
            this.listBoxProducts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeletTrip = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonProductDelet = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDebtAdd = new System.Windows.Forms.Button();
            this.buttonDebtRemove = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBoxTripsAndPeople = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBoxTripsAndPeople.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPerson
            // 
            this.textBoxPerson.Location = new System.Drawing.Point(539, 181);
            this.textBoxPerson.Name = "textBoxPerson";
            this.textBoxPerson.Size = new System.Drawing.Size(253, 22);
            this.textBoxPerson.TabIndex = 0;
            // 
            // textBoxEnterPerson
            // 
            this.textBoxEnterPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEnterPerson.Location = new System.Drawing.Point(16, 295);
            this.textBoxEnterPerson.Name = "textBoxEnterPerson";
            this.textBoxEnterPerson.Size = new System.Drawing.Size(159, 22);
            this.textBoxEnterPerson.TabIndex = 1;
            // 
            // comboBoxPerson1
            // 
            this.comboBoxPerson1.FormattingEnabled = true;
            this.comboBoxPerson1.Location = new System.Drawing.Point(1251, 44);
            this.comboBoxPerson1.Name = "comboBoxPerson1";
            this.comboBoxPerson1.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPerson1.TabIndex = 4;
            // 
            // comboBoxPerson2
            // 
            this.comboBoxPerson2.FormattingEnabled = true;
            this.comboBoxPerson2.Location = new System.Drawing.Point(1251, 84);
            this.comboBoxPerson2.Name = "comboBoxPerson2";
            this.comboBoxPerson2.Size = new System.Drawing.Size(121, 24);
            this.comboBoxPerson2.TabIndex = 5;
            // 
            // textBoxPay1
            // 
            this.textBoxPay1.Location = new System.Drawing.Point(1391, 44);
            this.textBoxPay1.Name = "textBoxPay1";
            this.textBoxPay1.Size = new System.Drawing.Size(100, 22);
            this.textBoxPay1.TabIndex = 6;
            // 
            // textBoxPay2
            // 
            this.textBoxPay2.Location = new System.Drawing.Point(1391, 84);
            this.textBoxPay2.Name = "textBoxPay2";
            this.textBoxPay2.Size = new System.Drawing.Size(100, 22);
            this.textBoxPay2.TabIndex = 7;
            // 
            // buttonAddPerson
            // 
            this.buttonAddPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddPerson.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddPerson.Image")));
            this.buttonAddPerson.Location = new System.Drawing.Point(188, 295);
            this.buttonAddPerson.Name = "buttonAddPerson";
            this.buttonAddPerson.Size = new System.Drawing.Size(28, 28);
            this.buttonAddPerson.TabIndex = 8;
            this.buttonAddPerson.UseVisualStyleBackColor = true;
            this.buttonAddPerson.Click += new System.EventHandler(this.buttonAddPerson_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(539, 211);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 42);
            this.buttonAddProduct.TabIndex = 9;
            this.buttonAddProduct.Text = "ввести продукт";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // buttonAddTrip
            // 
            this.buttonAddTrip.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddTrip.Image")));
            this.buttonAddTrip.Location = new System.Drawing.Point(186, 42);
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
            // comboBoxTripList
            // 
            this.comboBoxTripList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTripList.FormattingEnabled = true;
            this.comboBoxTripList.Location = new System.Drawing.Point(19, 238);
            this.comboBoxTripList.Name = "comboBoxTripList";
            this.comboBoxTripList.Size = new System.Drawing.Size(104, 24);
            this.comboBoxTripList.TabIndex = 13;
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
            this.listBoxPeople.Location = new System.Drawing.Point(16, 329);
            this.listBoxPeople.Name = "listBoxPeople";
            this.listBoxPeople.Size = new System.Drawing.Size(200, 340);
            this.listBoxPeople.TabIndex = 15;
            // 
            // listBoxProducts
            // 
            this.listBoxProducts.FormattingEnabled = true;
            this.listBoxProducts.ItemHeight = 16;
            this.listBoxProducts.Location = new System.Drawing.Point(539, 273);
            this.listBoxProducts.Name = "listBoxProducts";
            this.listBoxProducts.Size = new System.Drawing.Size(253, 292);
            this.listBoxProducts.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Номер похода";
            // 
            // buttonDeletTrip
            // 
            this.buttonDeletTrip.FlatAppearance.BorderSize = 0;
            this.buttonDeletTrip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDeletTrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeletTrip.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeletTrip.Image")));
            this.buttonDeletTrip.Location = new System.Drawing.Point(190, 238);
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
            this.buttonProductDelet.Location = new System.Drawing.Point(676, 43);
            this.buttonProductDelet.Name = "buttonProductDelet";
            this.buttonProductDelet.Size = new System.Drawing.Size(24, 24);
            this.buttonProductDelet.TabIndex = 20;
            this.buttonProductDelet.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(560, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(98, 24);
            this.comboBox1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Номер продукта";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1425, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 26;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1425, 218);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 25;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1285, 258);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 24;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(10, 8);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(55, 24);
            this.comboBox3.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(874, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "номер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(862, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Должники";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(945, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "имя";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "---";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(185, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1042, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "коэфициент/сумма";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(209, 9);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 33;
            this.textBox3.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1042, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 17);
            this.label9.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDebtRemove);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Location = new System.Drawing.Point(860, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 441);
            this.panel1.TabIndex = 35;
            // 
            // buttonDebtAdd
            // 
            this.buttonDebtAdd.FlatAppearance.BorderSize = 0;
            this.buttonDebtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDebtAdd.Image = ((System.Drawing.Image)(resources.GetObject("buttonDebtAdd.Image")));
            this.buttonDebtAdd.Location = new System.Drawing.Point(946, 23);
            this.buttonDebtAdd.Name = "buttonDebtAdd";
            this.buttonDebtAdd.Size = new System.Drawing.Size(32, 32);
            this.buttonDebtAdd.TabIndex = 36;
            this.buttonDebtAdd.UseVisualStyleBackColor = true;
            // 
            // buttonDebtRemove
            // 
            this.buttonDebtRemove.FlatAppearance.BorderSize = 0;
            this.buttonDebtRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDebtRemove.Image = ((System.Drawing.Image)(resources.GetObject("buttonDebtRemove.Image")));
            this.buttonDebtRemove.Location = new System.Drawing.Point(320, 8);
            this.buttonDebtRemove.Name = "buttonDebtRemove";
            this.buttonDebtRemove.Size = new System.Drawing.Size(24, 24);
            this.buttonDebtRemove.TabIndex = 34;
            this.buttonDebtRemove.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(19, 275);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 17);
            this.label10.TabIndex = 37;
            this.label10.Text = "Участники похода";
            // 
            // groupBoxTripsAndPeople
            // 
            this.groupBoxTripsAndPeople.Controls.Add(this.listBoxPeople);
            this.groupBoxTripsAndPeople.Controls.Add(this.label10);
            this.groupBoxTripsAndPeople.Controls.Add(this.textBoxEnterPerson);
            this.groupBoxTripsAndPeople.Controls.Add(this.buttonAddPerson);
            this.groupBoxTripsAndPeople.Controls.Add(this.buttonAddTrip);
            this.groupBoxTripsAndPeople.Controls.Add(this.textBoxTripName);
            this.groupBoxTripsAndPeople.Controls.Add(this.comboBoxTripList);
            this.groupBoxTripsAndPeople.Controls.Add(this.listBoxTrips);
            this.groupBoxTripsAndPeople.Controls.Add(this.label1);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1534, 687);
            this.Controls.Add(this.groupBoxTripsAndPeople);
            this.Controls.Add(this.buttonDebtAdd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonProductDelet);
            this.Controls.Add(this.listBoxProducts);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.textBoxPay2);
            this.Controls.Add(this.textBoxPay1);
            this.Controls.Add(this.comboBoxPerson2);
            this.Controls.Add(this.comboBoxPerson1);
            this.Controls.Add(this.textBoxPerson);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxTripsAndPeople.ResumeLayout(false);
            this.groupBoxTripsAndPeople.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPerson;
        private System.Windows.Forms.TextBox textBoxEnterPerson;
        private System.Windows.Forms.ComboBox comboBoxPerson1;
        private System.Windows.Forms.ComboBox comboBoxPerson2;
        private System.Windows.Forms.TextBox textBoxPay1;
        private System.Windows.Forms.TextBox textBoxPay2;
        private System.Windows.Forms.Button buttonAddPerson;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.Button buttonAddTrip;
        private System.Windows.Forms.TextBox textBoxTripName;
        private System.Windows.Forms.ComboBox comboBoxTripList;
        private System.Windows.Forms.ListBox listBoxTrips;
        private System.Windows.Forms.ListBox listBoxPeople;
        private System.Windows.Forms.ListBox listBoxProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeletTrip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonProductDelet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonDebtRemove;
        private System.Windows.Forms.Button buttonDebtAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBoxTripsAndPeople;
    }
}

