
namespace Temperature
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.enterTemperatureField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.fromScaleList = new System.Windows.Forms.ComboBox();
            this.toScaleList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.swapButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.enterTemperatureLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterTemperatureField
            // 
            this.enterTemperatureField.Location = new System.Drawing.Point(12, 27);
            this.enterTemperatureField.Name = "enterTemperatureField";
            this.enterTemperatureField.Size = new System.Drawing.Size(193, 23);
            this.enterTemperatureField.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Result:";
            // 
            // convertButton
            // 
            this.convertButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.convertButton.Location = new System.Drawing.Point(12, 106);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(360, 23);
            this.convertButton.TabIndex = 2;
            this.convertButton.Text = "Convert";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.resultLabel.Location = new System.Drawing.Point(211, 27);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(161, 23);
            this.resultLabel.TabIndex = 6;
            // 
            // fromScaleList
            // 
            this.fromScaleList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromScaleList.FormattingEnabled = true;
            this.fromScaleList.Location = new System.Drawing.Point(12, 71);
            this.fromScaleList.Name = "fromScaleList";
            this.fromScaleList.Size = new System.Drawing.Size(164, 23);
            this.fromScaleList.TabIndex = 9;
            this.fromScaleList.SelectedIndexChanged += new System.EventHandler(this.fromScale_SelectedIndexChanged);
            // 
            // toScaleList
            // 
            this.toScaleList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.toScaleList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toScaleList.FormattingEnabled = true;
            this.toScaleList.Location = new System.Drawing.Point(211, 71);
            this.toScaleList.Name = "toScaleList";
            this.toScaleList.Size = new System.Drawing.Size(161, 23);
            this.toScaleList.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "From";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "To";
            // 
            // swapButton
            // 
            this.swapButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.swapButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("swapButton.BackgroundImage")));
            this.swapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.swapButton.Location = new System.Drawing.Point(182, 71);
            this.swapButton.Name = "swapButton";
            this.swapButton.Size = new System.Drawing.Size(23, 23);
            this.swapButton.TabIndex = 13;
            this.swapButton.Tag = "";
            this.swapButton.UseVisualStyleBackColor = true;
            this.swapButton.Click += new System.EventHandler(this.swapButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enterTemperatureLabel);
            this.panel1.Controls.Add(this.swapButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.toScaleList);
            this.panel1.Controls.Add(this.fromScaleList);
            this.panel1.Controls.Add(this.resultLabel);
            this.panel1.Controls.Add(this.convertButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.enterTemperatureField);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 141);
            this.panel1.TabIndex = 14;
            // 
            // enterTemperatureLabel
            // 
            this.enterTemperatureLabel.AutoSize = true;
            this.enterTemperatureLabel.Location = new System.Drawing.Point(12, 9);
            this.enterTemperatureLabel.Name = "enterTemperatureLabel";
            this.enterTemperatureLabel.Size = new System.Drawing.Size(0, 15);
            this.enterTemperatureLabel.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AcceptButton = this.convertButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 141);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 160);
            this.Name = "MainForm";
            this.Text = "Temperature converter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox enterTemperatureField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ComboBox fromScaleList;
        private System.Windows.Forms.ComboBox toScaleList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button swapButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label enterTemperatureLabel;
    }
}

