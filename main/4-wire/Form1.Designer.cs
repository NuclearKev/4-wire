namespace _4_wire
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
            this.wire4Button = new System.Windows.Forms.Button();
            this.IDTextBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NoPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LightPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediumPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeavyPressure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Automated4Wire = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SmallCurrentRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MediumCurrentRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LargeCurrentRes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.powerSupplyButtons = new System.Windows.Forms.Button();
            this.pasteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // wire4Button
            // 
            this.wire4Button.Location = new System.Drawing.Point(12, 12);
            this.wire4Button.Name = "wire4Button";
            this.wire4Button.Size = new System.Drawing.Size(75, 23);
            this.wire4Button.TabIndex = 0;
            this.wire4Button.Text = "4-Wire";
            this.wire4Button.UseVisualStyleBackColor = true;
            this.wire4Button.Click += new System.EventHandler(this.wire4Button_Click);
            // 
            // IDTextBox1
            // 
            this.IDTextBox1.Location = new System.Drawing.Point(272, 14);
            this.IDTextBox1.Multiline = true;
            this.IDTextBox1.Name = "IDTextBox1";
            this.IDTextBox1.Size = new System.Drawing.Size(85, 20);
            this.IDTextBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoPressure,
            this.LightPressure,
            this.MediumPressure,
            this.HeavyPressure,
            this.Automated4Wire,
            this.SmallCurrentRes,
            this.MediumCurrentRes,
            this.LargeCurrentRes});
            this.dataGridView1.Location = new System.Drawing.Point(103, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 513);
            this.dataGridView1.TabIndex = 2;
            // 
            // NoPressure
            // 
            this.NoPressure.HeaderText = "No Pressure";
            this.NoPressure.Name = "NoPressure";
            // 
            // LightPressure
            // 
            this.LightPressure.HeaderText = "Light Pressure";
            this.LightPressure.Name = "LightPressure";
            // 
            // MediumPressure
            // 
            this.MediumPressure.HeaderText = "Medium Pressure";
            this.MediumPressure.Name = "MediumPressure";
            // 
            // HeavyPressure
            // 
            this.HeavyPressure.HeaderText = "Heavy Pressure";
            this.HeavyPressure.Name = "HeavyPressure";
            // 
            // Automated4Wire
            // 
            this.Automated4Wire.HeaderText = "Automated 4-Wire";
            this.Automated4Wire.Name = "Automated4Wire";
            // 
            // SmallCurrentRes
            // 
            this.SmallCurrentRes.HeaderText = "Small Current Resistance";
            this.SmallCurrentRes.Name = "SmallCurrentRes";
            // 
            // MediumCurrentRes
            // 
            this.MediumCurrentRes.HeaderText = "Medium Current Resistance";
            this.MediumCurrentRes.Name = "MediumCurrentRes";
            // 
            // LargeCurrentRes
            // 
            this.LargeCurrentRes.HeaderText = "Large Current Resistance";
            this.LargeCurrentRes.Name = "LargeCurrentRes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(216, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Group ID";
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(871, 17);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // powerSupplyButtons
            // 
            this.powerSupplyButtons.Location = new System.Drawing.Point(103, 12);
            this.powerSupplyButtons.Name = "powerSupplyButtons";
            this.powerSupplyButtons.Size = new System.Drawing.Size(89, 23);
            this.powerSupplyButtons.TabIndex = 5;
            this.powerSupplyButtons.Text = "Power Supply";
            this.powerSupplyButtons.UseVisualStyleBackColor = true;
            this.powerSupplyButtons.Click += new System.EventHandler(this.powerSupplyButtons_Click);
            // 
            // pasteButton
            // 
            this.pasteButton.Location = new System.Drawing.Point(12, 76);
            this.pasteButton.Name = "pasteButton";
            this.pasteButton.Size = new System.Drawing.Size(75, 23);
            this.pasteButton.TabIndex = 6;
            this.pasteButton.Text = "Paste";
            this.pasteButton.UseVisualStyleBackColor = true;
            this.pasteButton.Click += new System.EventHandler(this.pasteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 583);
            this.Controls.Add(this.pasteButton);
            this.Controls.Add(this.powerSupplyButtons);
            this.Controls.Add(this.uploadButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.IDTextBox1);
            this.Controls.Add(this.wire4Button);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button wire4Button;
        private System.Windows.Forms.TextBox IDTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button powerSupplyButtons;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn LightPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediumPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeavyPressure;
        private System.Windows.Forms.DataGridViewTextBoxColumn Automated4Wire;
        private System.Windows.Forms.DataGridViewTextBoxColumn SmallCurrentRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn MediumCurrentRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn LargeCurrentRes;
        private System.Windows.Forms.Button pasteButton;
    }
}

