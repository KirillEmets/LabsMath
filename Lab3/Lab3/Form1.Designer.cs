namespace Lab3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbMatrix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackScale = new System.Windows.Forms.TrackBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.dataGridViewPows = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hpIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hfOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Pathes2 = new System.Windows.Forms.TextBox();
            this.rb_2 = new System.Windows.Forms.RadioButton();
            this.rb_3 = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ReachMatrix = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_Components = new System.Windows.Forms.TextBox();
            this.tb_LinkMatrix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_CondGraph = new System.Windows.Forms.CheckBox();
            this.nodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPows)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMatrix
            // 
            this.tbMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMatrix.Location = new System.Drawing.Point(12, 12);
            this.tbMatrix.Multiline = true;
            this.tbMatrix.Name = "tbMatrix";
            this.tbMatrix.ReadOnly = true;
            this.tbMatrix.Size = new System.Drawing.Size(170, 213);
            this.tbMatrix.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Матриця напрямленого графа";
            // 
            // trackScale
            // 
            this.trackScale.LargeChange = 1;
            this.trackScale.Location = new System.Drawing.Point(188, 34);
            this.trackScale.Minimum = 1;
            this.trackScale.Name = "trackScale";
            this.trackScale.Size = new System.Drawing.Size(138, 45);
            this.trackScale.TabIndex = 5;
            this.trackScale.Value = 1;
            this.trackScale.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.vScrollBar1.Location = new System.Drawing.Point(775, 9);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 475);
            this.vScrollBar1.TabIndex = 6;
            this.vScrollBar1.Value = 50;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(188, 484);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(608, 17);
            this.hScrollBar1.TabIndex = 7;
            this.hScrollBar1.Value = 50;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // dataGridViewPows
            // 
            this.dataGridViewPows.AllowUserToAddRows = false;
            this.dataGridViewPows.AllowUserToDeleteRows = false;
            this.dataGridViewPows.AllowUserToResizeColumns = false;
            this.dataGridViewPows.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPows.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.hpIn,
            this.hfOut});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewPows.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewPows.Location = new System.Drawing.Point(37, 6);
            this.dataGridViewPows.Name = "dataGridViewPows";
            this.dataGridViewPows.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPows.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewPows.RowHeadersVisible = false;
            this.dataGridViewPows.Size = new System.Drawing.Size(211, 218);
            this.dataGridViewPows.TabIndex = 8;
            this.dataGridViewPows.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPows_ColumnHeaderMouseClick);
            // 
            // Number
            // 
            this.Number.HeaderText = "N";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.Width = 40;
            // 
            // hpIn
            // 
            this.hpIn.HeaderText = "напівстепінь входу";
            this.hpIn.Name = "hpIn";
            this.hpIn.ReadOnly = true;
            this.hpIn.Width = 80;
            // 
            // hfOut
            // 
            this.hfOut.HeaderText = "напівстепінь виходу";
            this.hfOut.Name = "hfOut";
            this.hfOut.ReadOnly = true;
            this.hfOut.Width = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Усі шляхи довжиною";
            // 
            // tb_Pathes2
            // 
            this.tb_Pathes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Pathes2.Location = new System.Drawing.Point(12, 295);
            this.tb_Pathes2.Multiline = true;
            this.tb_Pathes2.Name = "tb_Pathes2";
            this.tb_Pathes2.ReadOnly = true;
            this.tb_Pathes2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Pathes2.Size = new System.Drawing.Size(170, 206);
            this.tb_Pathes2.TabIndex = 14;
            // 
            // rb_2
            // 
            this.rb_2.AutoSize = true;
            this.rb_2.Checked = true;
            this.rb_2.Location = new System.Drawing.Point(130, 272);
            this.rb_2.Name = "rb_2";
            this.rb_2.Size = new System.Drawing.Size(31, 17);
            this.rb_2.TabIndex = 15;
            this.rb_2.TabStop = true;
            this.rb_2.Text = "2";
            this.rb_2.UseVisualStyleBackColor = true;
            this.rb_2.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rb_3
            // 
            this.rb_3.AutoSize = true;
            this.rb_3.Location = new System.Drawing.Point(167, 272);
            this.rb_3.Name = "rb_3";
            this.rb_3.Size = new System.Drawing.Size(31, 17);
            this.rb_3.TabIndex = 16;
            this.rb_3.Text = "3";
            this.rb_3.UseVisualStyleBackColor = true;
            this.rb_3.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(799, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 489);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tb_ReachMatrix);
            this.tabPage1.Controls.Add(this.dataGridViewPows);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(272, 463);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tab 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Матриця досяжності";
            // 
            // tb_ReachMatrix
            // 
            this.tb_ReachMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ReachMatrix.Location = new System.Drawing.Point(37, 247);
            this.tb_ReachMatrix.Multiline = true;
            this.tb_ReachMatrix.Name = "tb_ReachMatrix";
            this.tb_ReachMatrix.ReadOnly = true;
            this.tb_ReachMatrix.Size = new System.Drawing.Size(170, 213);
            this.tb_ReachMatrix.TabIndex = 18;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tb_Components);
            this.tabPage2.Controls.Add(this.tb_LinkMatrix);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(272, 463);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tab 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Матриця сильної зв\'язності";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Компоненти сильної зв\'язності";
            // 
            // tb_Components
            // 
            this.tb_Components.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Components.Location = new System.Drawing.Point(22, 261);
            this.tb_Components.Multiline = true;
            this.tb_Components.Name = "tb_Components";
            this.tb_Components.ReadOnly = true;
            this.tb_Components.Size = new System.Drawing.Size(228, 196);
            this.tb_Components.TabIndex = 19;
            // 
            // tb_LinkMatrix
            // 
            this.tb_LinkMatrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_LinkMatrix.Location = new System.Drawing.Point(53, 29);
            this.tb_LinkMatrix.Multiline = true;
            this.tb_LinkMatrix.Name = "tb_LinkMatrix";
            this.tb_LinkMatrix.ReadOnly = true;
            this.tb_LinkMatrix.Size = new System.Drawing.Size(170, 213);
            this.tb_LinkMatrix.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Scale";
            // 
            // cb_CondGraph
            // 
            this.cb_CondGraph.AutoSize = true;
            this.cb_CondGraph.Location = new System.Drawing.Point(200, 85);
            this.cb_CondGraph.Name = "cb_CondGraph";
            this.cb_CondGraph.Size = new System.Drawing.Size(114, 17);
            this.cb_CondGraph.TabIndex = 19;
            this.cb_CondGraph.Text = "Граф конденсації";
            this.cb_CondGraph.UseVisualStyleBackColor = true;
            this.cb_CondGraph.CheckedChanged += new System.EventHandler(this.cb_CondGraph_CheckedChanged);
            // 
            // nodeBindingSource
            // 
            this.nodeBindingSource.DataSource = typeof(Lab3.Node);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 513);
            this.Controls.Add(this.cb_CondGraph);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.rb_3);
            this.Controls.Add(this.rb_2);
            this.Controls.Add(this.tb_Pathes2);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.trackScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMatrix);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPows)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackScale;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.DataGridView dataGridViewPows;
        private System.Windows.Forms.BindingSource nodeBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Pathes2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn hpIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hfOut;
        private System.Windows.Forms.RadioButton rb_2;
        private System.Windows.Forms.RadioButton rb_3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox tb_ReachMatrix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_LinkMatrix;
        private System.Windows.Forms.TextBox tb_Components;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_CondGraph;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

