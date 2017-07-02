namespace NN__conf
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
            this.components = new System.ComponentModel.Container();
            this.p_DrawHere = new System.Windows.Forms.Panel();
            this.CxtMnDraw = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsctx_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsctx_Resize = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_LearnNeuro = new System.Windows.Forms.Button();
            this.nud_EpochsCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Patterns = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Recognize = new System.Windows.Forms.Button();
            this.btn_AddTemplate = new System.Windows.Forms.Button();
            this.btn_DeleteTemplate = new System.Windows.Forms.Button();
            this.btn_SaveTemplate = new System.Windows.Forms.Button();
            this.tb_Answer = new System.Windows.Forms.TextBox();
            this.tb_TemplateName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Load = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.Ping = new System.Windows.Forms.Timer(this.components);
            this.nud_ErrorEpoch = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.CxtMnDraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_EpochsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErrorEpoch)).BeginInit();
            this.SuspendLayout();
            // 
            // p_DrawHere
            // 
            this.p_DrawHere.BackColor = System.Drawing.Color.Transparent;
            this.p_DrawHere.ContextMenuStrip = this.CxtMnDraw;
            this.p_DrawHere.Location = new System.Drawing.Point(12, 102);
            this.p_DrawHere.Name = "p_DrawHere";
            this.p_DrawHere.Size = new System.Drawing.Size(245, 251);
            this.p_DrawHere.TabIndex = 0;
            this.p_DrawHere.Paint += new System.Windows.Forms.PaintEventHandler(this.p_DrawHere_Paint);
            this.p_DrawHere.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownTemplate);
            this.p_DrawHere.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoveTemplate);
            this.p_DrawHere.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpTemplate);
            // 
            // CxtMnDraw
            // 
            this.CxtMnDraw.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsctx_Clear,
            this.tsctx_Resize});
            this.CxtMnDraw.Name = "CxtMnDraw";
            this.CxtMnDraw.Size = new System.Drawing.Size(226, 48);
            // 
            // tsctx_Clear
            // 
            this.tsctx_Clear.Name = "tsctx_Clear";
            this.tsctx_Clear.Size = new System.Drawing.Size(225, 22);
            this.tsctx_Clear.Text = "Очистить";
            this.tsctx_Clear.Click += new System.EventHandler(this.tsctx_Click);
            // 
            // tsctx_Resize
            // 
            this.tsctx_Resize.Name = "tsctx_Resize";
            this.tsctx_Resize.Size = new System.Drawing.Size(225, 22);
            this.tsctx_Resize.Text = "Изменить Размер Шаблона";
            this.tsctx_Resize.Click += new System.EventHandler(this.tsctx_Click);
            // 
            // btn_LearnNeuro
            // 
            this.btn_LearnNeuro.Location = new System.Drawing.Point(12, 12);
            this.btn_LearnNeuro.Name = "btn_LearnNeuro";
            this.btn_LearnNeuro.Size = new System.Drawing.Size(213, 23);
            this.btn_LearnNeuro.TabIndex = 1;
            this.btn_LearnNeuro.Text = "Учить нейросеть по шаблонам";
            this.btn_LearnNeuro.UseVisualStyleBackColor = true;
            this.btn_LearnNeuro.Click += new System.EventHandler(this.btn_Click);
            // 
            // nud_EpochsCount
            // 
            this.nud_EpochsCount.Location = new System.Drawing.Point(304, 15);
            this.nud_EpochsCount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nud_EpochsCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_EpochsCount.Name = "nud_EpochsCount";
            this.nud_EpochsCount.Size = new System.Drawing.Size(120, 20);
            this.nud_EpochsCount.TabIndex = 2;
            this.nud_EpochsCount.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во эпох:";
            // 
            // lb_Patterns
            // 
            this.lb_Patterns.FormattingEnabled = true;
            this.lb_Patterns.Location = new System.Drawing.Point(263, 102);
            this.lb_Patterns.Name = "lb_Patterns";
            this.lb_Patterns.Size = new System.Drawing.Size(161, 251);
            this.lb_Patterns.TabIndex = 4;
            this.lb_Patterns.SelectedIndexChanged += new System.EventHandler(this.lb_Patterns_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Шаблоны";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Рисовать здесь:";
            // 
            // btn_Recognize
            // 
            this.btn_Recognize.Location = new System.Drawing.Point(96, 359);
            this.btn_Recognize.Name = "btn_Recognize";
            this.btn_Recognize.Size = new System.Drawing.Size(161, 23);
            this.btn_Recognize.TabIndex = 7;
            this.btn_Recognize.Text = "Распознать изображение";
            this.btn_Recognize.UseVisualStyleBackColor = true;
            this.btn_Recognize.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_AddTemplate
            // 
            this.btn_AddTemplate.Location = new System.Drawing.Point(127, 412);
            this.btn_AddTemplate.Name = "btn_AddTemplate";
            this.btn_AddTemplate.Size = new System.Drawing.Size(130, 23);
            this.btn_AddTemplate.TabIndex = 8;
            this.btn_AddTemplate.Text = "Добавить шаблон";
            this.btn_AddTemplate.UseVisualStyleBackColor = true;
            this.btn_AddTemplate.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_DeleteTemplate
            // 
            this.btn_DeleteTemplate.Location = new System.Drawing.Point(263, 412);
            this.btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            this.btn_DeleteTemplate.Size = new System.Drawing.Size(161, 23);
            this.btn_DeleteTemplate.TabIndex = 9;
            this.btn_DeleteTemplate.Text = "Удалить шаблон";
            this.btn_DeleteTemplate.UseVisualStyleBackColor = true;
            this.btn_DeleteTemplate.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_SaveTemplate
            // 
            this.btn_SaveTemplate.Location = new System.Drawing.Point(263, 359);
            this.btn_SaveTemplate.Name = "btn_SaveTemplate";
            this.btn_SaveTemplate.Size = new System.Drawing.Size(161, 23);
            this.btn_SaveTemplate.TabIndex = 10;
            this.btn_SaveTemplate.Text = "Сохранить шаблоны";
            this.btn_SaveTemplate.UseVisualStyleBackColor = true;
            this.btn_SaveTemplate.Click += new System.EventHandler(this.btn_Click);
            // 
            // tb_Answer
            // 
            this.tb_Answer.Location = new System.Drawing.Point(12, 361);
            this.tb_Answer.Name = "tb_Answer";
            this.tb_Answer.ReadOnly = true;
            this.tb_Answer.Size = new System.Drawing.Size(78, 20);
            this.tb_Answer.TabIndex = 11;
            this.tb_Answer.Text = "Ответы";
            // 
            // tb_TemplateName
            // 
            this.tb_TemplateName.Location = new System.Drawing.Point(12, 414);
            this.tb_TemplateName.Name = "tb_TemplateName";
            this.tb_TemplateName.Size = new System.Drawing.Size(109, 20);
            this.tb_TemplateName.TabIndex = 12;
            this.tb_TemplateName.Text = "Название шаблона";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Ошибка каждую ";
            // 
            // btn_Load
            // 
            this.btn_Load.Location = new System.Drawing.Point(263, 385);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.Size = new System.Drawing.Size(161, 23);
            this.btn_Load.TabIndex = 15;
            this.btn_Load.Text = "Загрузить шаблоны";
            this.btn_Load.UseVisualStyleBackColor = true;
            this.btn_Load.Click += new System.EventHandler(this.btn_Click);
            // 
            // sfd
            // 
            this.sfd.FileName = "DataSet";
            this.sfd.Filter = "Binary files (*.bin)|*.bin";
            // 
            // ofd
            // 
            this.ofd.Filter = "Binary files (*.bin)|*.bin";
            // 
            // Ping
            // 
            this.Ping.Tick += new System.EventHandler(this.Ping_Tick);
            // 
            // nud_ErrorEpoch
            // 
            this.nud_ErrorEpoch.Location = new System.Drawing.Point(304, 48);
            this.nud_ErrorEpoch.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_ErrorEpoch.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ErrorEpoch.Name = "nud_ErrorEpoch";
            this.nud_ErrorEpoch.Size = new System.Drawing.Size(78, 20);
            this.nud_ErrorEpoch.TabIndex = 16;
            this.nud_ErrorEpoch.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(388, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "эпоху";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 447);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nud_ErrorEpoch);
            this.Controls.Add(this.btn_Load);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_TemplateName);
            this.Controls.Add(this.tb_Answer);
            this.Controls.Add(this.btn_SaveTemplate);
            this.Controls.Add(this.btn_DeleteTemplate);
            this.Controls.Add(this.btn_AddTemplate);
            this.Controls.Add(this.btn_Recognize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_Patterns);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nud_EpochsCount);
            this.Controls.Add(this.btn_LearnNeuro);
            this.Controls.Add(this.p_DrawHere);
            this.MaximumSize = new System.Drawing.Size(452, 485);
            this.MinimumSize = new System.Drawing.Size(452, 485);
            this.Name = "Form1";
            this.Text = "ИНC распознавание изображений";
            this.CxtMnDraw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nud_EpochsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErrorEpoch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel p_DrawHere;
        private System.Windows.Forms.Button btn_LearnNeuro;
        private System.Windows.Forms.NumericUpDown nud_EpochsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lb_Patterns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Recognize;
        private System.Windows.Forms.Button btn_AddTemplate;
        private System.Windows.Forms.Button btn_DeleteTemplate;
        private System.Windows.Forms.Button btn_SaveTemplate;
        private System.Windows.Forms.TextBox tb_Answer;
        private System.Windows.Forms.TextBox tb_TemplateName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Load;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ContextMenuStrip CxtMnDraw;
        private System.Windows.Forms.ToolStripMenuItem tsctx_Clear;
        private System.Windows.Forms.ToolStripMenuItem tsctx_Resize;
        private System.Windows.Forms.Timer Ping;
        private System.Windows.Forms.NumericUpDown nud_ErrorEpoch;
        private System.Windows.Forms.Label label5;
    }
}

