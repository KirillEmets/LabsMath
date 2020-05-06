namespace Lab5
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
            this.tbMatrix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_bfsNext = new System.Windows.Forms.Button();
            this.btn_Again = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nondir = new System.Windows.Forms.TextBox();
            this.tb_spanning = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Матриця напрямленого графа";
            // 
            // btn_bfsNext
            // 
            this.btn_bfsNext.Location = new System.Drawing.Point(188, 12);
            this.btn_bfsNext.Name = "btn_bfsNext";
            this.btn_bfsNext.Size = new System.Drawing.Size(75, 23);
            this.btn_bfsNext.TabIndex = 4;
            this.btn_bfsNext.Text = "Next";
            this.btn_bfsNext.UseVisualStyleBackColor = true;
            this.btn_bfsNext.Click += new System.EventHandler(this.btn_bfsNext_Click);
            // 
            // btn_Again
            // 
            this.btn_Again.Location = new System.Drawing.Point(269, 12);
            this.btn_Again.Name = "btn_Again";
            this.btn_Again.Size = new System.Drawing.Size(75, 23);
            this.btn_Again.TabIndex = 5;
            this.btn_Again.Text = "Again";
            this.btn_Again.UseVisualStyleBackColor = true;
            this.btn_Again.Click += new System.EventHandler(this.btn_Again_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Матриця ненапрямленого графа";
            // 
            // tb_nondir
            // 
            this.tb_nondir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_nondir.Location = new System.Drawing.Point(15, 290);
            this.tb_nondir.Multiline = true;
            this.tb_nondir.Name = "tb_nondir";
            this.tb_nondir.ReadOnly = true;
            this.tb_nondir.Size = new System.Drawing.Size(170, 213);
            this.tb_nondir.TabIndex = 8;
            // 
            // tb_spanning
            // 
            this.tb_spanning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_spanning.Location = new System.Drawing.Point(1108, 12);
            this.tb_spanning.Multiline = true;
            this.tb_spanning.Name = "tb_spanning";
            this.tb_spanning.ReadOnly = true;
            this.tb_spanning.Size = new System.Drawing.Size(170, 213);
            this.tb_spanning.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1105, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Матриця кістяка графу";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 513);
            this.Controls.Add(this.tb_spanning);
            this.Controls.Add(this.tb_nondir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Again);
            this.Controls.Add(this.btn_bfsNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMatrix);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource nodeBindingSource;
        private System.Windows.Forms.Button btn_bfsNext;
        private System.Windows.Forms.Button btn_Again;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nondir;
        private System.Windows.Forms.TextBox tb_spanning;
        private System.Windows.Forms.Label label3;
    }
}

