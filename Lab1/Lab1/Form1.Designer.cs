namespace Lab1
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
            this.tbMatrix = new System.Windows.Forms.TextBox();
            this.cbArrows = new System.Windows.Forms.CheckBox();
            this.tbMatrixUnDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackScale = new System.Windows.Forms.TrackBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).BeginInit();
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
            // cbArrows
            // 
            this.cbArrows.AutoSize = true;
            this.cbArrows.Location = new System.Drawing.Point(188, 12);
            this.cbArrows.Name = "cbArrows";
            this.cbArrows.Size = new System.Drawing.Size(138, 17);
            this.cbArrows.TabIndex = 1;
            this.cbArrows.Text = "Малюнок зі стрілками";
            this.cbArrows.UseVisualStyleBackColor = true;
            this.cbArrows.CheckedChanged += new System.EventHandler(this.cbArrows_CheckedChanged);
            // 
            // tbMatrixUnDir
            // 
            this.tbMatrixUnDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbMatrixUnDir.Location = new System.Drawing.Point(12, 288);
            this.tbMatrixUnDir.Multiline = true;
            this.tbMatrixUnDir.Name = "tbMatrixUnDir";
            this.tbMatrixUnDir.ReadOnly = true;
            this.tbMatrixUnDir.Size = new System.Drawing.Size(170, 213);
            this.tbMatrixUnDir.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Матриця ненапрямленого графа";
            // 
            // trackScale
            // 
            this.trackScale.LargeChange = 1;
            this.trackScale.Location = new System.Drawing.Point(188, 51);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 513);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.trackScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMatrixUnDir);
            this.Controls.Add(this.cbArrows);
            this.Controls.Add(this.tbMatrix);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMatrix;
        private System.Windows.Forms.CheckBox cbArrows;
        private System.Windows.Forms.TextBox tbMatrixUnDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackScale;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
    }
}

