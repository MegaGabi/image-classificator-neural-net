namespace NN__conf
{
    partial class ResizeDialoge
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
            this.nud_HorizontalSize = new System.Windows.Forms.NumericUpDown();
            this.nud_VerticalSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HorizontalSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_VerticalSize)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_HorizontalSize
            // 
            this.nud_HorizontalSize.Location = new System.Drawing.Point(149, 34);
            this.nud_HorizontalSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_HorizontalSize.Name = "nud_HorizontalSize";
            this.nud_HorizontalSize.Size = new System.Drawing.Size(120, 20);
            this.nud_HorizontalSize.TabIndex = 0;
            this.nud_HorizontalSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nud_VerticalSize
            // 
            this.nud_VerticalSize.Location = new System.Drawing.Point(149, 60);
            this.nud_VerticalSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_VerticalSize.Name = "nud_VerticalSize";
            this.nud_VerticalSize.Size = new System.Drawing.Size(120, 20);
            this.nud_VerticalSize.TabIndex = 1;
            this.nud_VerticalSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "По горизонтали:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "По вертикали:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кол-во юнитов в шаблоне";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(261, 86);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // ResizeDialoge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 120);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_VerticalSize);
            this.Controls.Add(this.nud_HorizontalSize);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 158);
            this.MinimumSize = new System.Drawing.Size(364, 158);
            this.Name = "ResizeDialoge";
            this.Text = "Изменение кол-ва юнитов в шаблоне";
            ((System.ComponentModel.ISupportInitialize)(this.nud_HorizontalSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_VerticalSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nud_HorizontalSize;
        private System.Windows.Forms.NumericUpDown nud_VerticalSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Ok;
    }
}