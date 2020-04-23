namespace Lab4
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
            this.tb_byPass = new System.Windows.Forms.TextBox();
            this.tb_ratio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Матриця дерева обходу";
            // 
            // tb_byPass
            // 
            this.tb_byPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_byPass.Location = new System.Drawing.Point(15, 290);
            this.tb_byPass.Multiline = true;
            this.tb_byPass.Name = "tb_byPass";
            this.tb_byPass.ReadOnly = true;
            this.tb_byPass.Size = new System.Drawing.Size(170, 213);
            this.tb_byPass.TabIndex = 8;
            // 
            // tb_ratio
            // 
            this.tb_ratio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_ratio.Location = new System.Drawing.Point(680, 9);
            this.tb_ratio.Multiline = true;
            this.tb_ratio.Name = "tb_ratio";
            this.tb_ratio.ReadOnly = true;
            this.tb_ratio.Size = new System.Drawing.Size(170, 213);
            this.tb_ratio.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Матриця відповідності";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(677, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "(номер в дереві - номер в графі)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 513);
            this.Controls.Add(this.tb_ratio);
            this.Controls.Add(this.tb_byPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Again);
            this.Controls.Add(this.btn_bfsNext);
            this.Controls.Add(this.label4);
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
        private System.Windows.Forms.TextBox tb_byPass;
        private System.Windows.Forms.TextBox tb_ratio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

