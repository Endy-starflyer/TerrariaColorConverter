namespace TMapArt
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
            this.HexIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TileDataOut = new System.Windows.Forms.RichTextBox();
            this.InputColor = new System.Windows.Forms.PictureBox();
            this.OutputColor = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.InputColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputColor)).BeginInit();
            this.SuspendLayout();
            // 
            // HexIn
            // 
            this.HexIn.Location = new System.Drawing.Point(12, 58);
            this.HexIn.MaxLength = 6;
            this.HexIn.Name = "HexIn";
            this.HexIn.Size = new System.Drawing.Size(100, 20);
            this.HexIn.TabIndex = 0;
            this.HexIn.TextChanged += new System.EventHandler(this.HexIn_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input (Hex)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
            // 
            // TileDataOut
            // 
            this.TileDataOut.Location = new System.Drawing.Point(198, 58);
            this.TileDataOut.Name = "TileDataOut";
            this.TileDataOut.Size = new System.Drawing.Size(299, 45);
            this.TileDataOut.TabIndex = 5;
            this.TileDataOut.Text = "";
            // 
            // InputColor
            // 
            this.InputColor.BackColor = System.Drawing.Color.Transparent;
            this.InputColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputColor.Location = new System.Drawing.Point(12, 28);
            this.InputColor.Name = "InputColor";
            this.InputColor.Size = new System.Drawing.Size(100, 25);
            this.InputColor.TabIndex = 6;
            this.InputColor.TabStop = false;
            // 
            // OutputColor
            // 
            this.OutputColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputColor.Location = new System.Drawing.Point(198, 28);
            this.OutputColor.Name = "OutputColor";
            this.OutputColor.Size = new System.Drawing.Size(100, 25);
            this.OutputColor.TabIndex = 7;
            this.OutputColor.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 119);
            this.Controls.Add(this.OutputColor);
            this.Controls.Add(this.InputColor);
            this.Controls.Add(this.TileDataOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HexIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Convert to Terraria Color";
            ((System.ComponentModel.ISupportInitialize)(this.InputColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutputColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HexIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox TileDataOut;
        private System.Windows.Forms.PictureBox InputColor;
        private System.Windows.Forms.PictureBox OutputColor;
    }
}

