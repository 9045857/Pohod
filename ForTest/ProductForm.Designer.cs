namespace ForTest
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
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panelDebts = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveAndClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(94, 21);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(190, 22);
            this.textBoxProductName.TabIndex = 0;
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 21);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(76, 17);
            this.labelProductName.TabIndex = 1;
            this.labelProductName.Text = "Название:";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 320);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(104, 48);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Сохранить";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panelDebts
            // 
            this.panelDebts.AutoScroll = true;
            this.panelDebts.Location = new System.Drawing.Point(12, 76);
            this.panelDebts.Name = "panelDebts";
            this.panelDebts.Size = new System.Drawing.Size(290, 238);
            this.panelDebts.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "v  имя              коэф / долг   оплата";
            // 
            // buttonSaveAndClose
            // 
            this.buttonSaveAndClose.Location = new System.Drawing.Point(184, 320);
            this.buttonSaveAndClose.Name = "buttonSaveAndClose";
            this.buttonSaveAndClose.Size = new System.Drawing.Size(118, 48);
            this.buttonSaveAndClose.TabIndex = 5;
            this.buttonSaveAndClose.Text = "Сохранить и закрыть";
            this.buttonSaveAndClose.UseVisualStyleBackColor = true;
            this.buttonSaveAndClose.Click += new System.EventHandler(this.buttonSaveAndClose_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 385);
            this.Controls.Add(this.buttonSaveAndClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelDebts);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.textBoxProductName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Данные о покупке";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Panel panelDebts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveAndClose;
    }
}