
namespace Faculty_Evaluation_System
{
    partial class TeachingTableForm
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
            this.dgvTeaching = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblResult5 = new System.Windows.Forms.Label();
            this.lblResult4 = new System.Windows.Forms.Label();
            this.lblResult3 = new System.Windows.Forms.Label();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.lblResult1 = new System.Windows.Forms.Label();
            this.btnResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeaching)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTeaching
            // 
            this.dgvTeaching.AllowUserToAddRows = false;
            this.dgvTeaching.AllowUserToDeleteRows = false;
            this.dgvTeaching.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTeaching.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTeaching.Location = new System.Drawing.Point(29, 80);
            this.dgvTeaching.Name = "dgvTeaching";
            this.dgvTeaching.ReadOnly = true;
            this.dgvTeaching.RowHeadersWidth = 51;
            this.dgvTeaching.RowTemplate.Height = 24;
            this.dgvTeaching.Size = new System.Drawing.Size(1144, 150);
            this.dgvTeaching.TabIndex = 2;
            this.dgvTeaching.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTeaching_CellClick);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1032, 336);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(144, 41);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblResult5
            // 
            this.lblResult5.AutoSize = true;
            this.lblResult5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult5.Location = new System.Drawing.Point(1131, 268);
            this.lblResult5.Name = "lblResult5";
            this.lblResult5.Size = new System.Drawing.Size(26, 28);
            this.lblResult5.TabIndex = 21;
            this.lblResult5.Text = "0";
            // 
            // lblResult4
            // 
            this.lblResult4.AutoSize = true;
            this.lblResult4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult4.Location = new System.Drawing.Point(1085, 267);
            this.lblResult4.Name = "lblResult4";
            this.lblResult4.Size = new System.Drawing.Size(26, 28);
            this.lblResult4.TabIndex = 20;
            this.lblResult4.Text = "0";
            // 
            // lblResult3
            // 
            this.lblResult3.AutoSize = true;
            this.lblResult3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult3.Location = new System.Drawing.Point(1037, 267);
            this.lblResult3.Name = "lblResult3";
            this.lblResult3.Size = new System.Drawing.Size(26, 28);
            this.lblResult3.TabIndex = 19;
            this.lblResult3.Text = "0";
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult2.Location = new System.Drawing.Point(986, 267);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(26, 28);
            this.lblResult2.TabIndex = 18;
            this.lblResult2.Text = "0";
            // 
            // lblResult1
            // 
            this.lblResult1.AutoSize = true;
            this.lblResult1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult1.Location = new System.Drawing.Point(930, 267);
            this.lblResult1.Name = "lblResult1";
            this.lblResult1.Size = new System.Drawing.Size(26, 28);
            this.lblResult1.TabIndex = 17;
            this.lblResult1.Text = "0";
            // 
            // btnResult
            // 
            this.btnResult.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResult.Location = new System.Drawing.Point(858, 336);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(144, 41);
            this.btnResult.TabIndex = 16;
            this.btnResult.Text = "Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(474, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "C. Teaching for Independent Learning";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(769, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 27);
            this.label2.TabIndex = 23;
            this.label2.Text = "SCORE:";
            // 
            // TeachingTableForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::Faculty_Evaluation_System.Properties.Resources._17973908_min;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1195, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult5);
            this.Controls.Add(this.lblResult4);
            this.Controls.Add(this.lblResult3);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.lblResult1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.dgvTeaching);
            this.Name = "TeachingTableForm";
            this.Load += new System.EventHandler(this.TeachingTableForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTeaching)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTeaching;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblResult5;
        private System.Windows.Forms.Label lblResult4;
        private System.Windows.Forms.Label lblResult3;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label lblResult1;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}