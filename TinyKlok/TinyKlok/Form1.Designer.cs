namespace TinyKlok
{
    partial class f1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timelcl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timeZulu = new System.Windows.Forms.TextBox();
            this.timeAZ = new System.Windows.Forms.TextBox();
            this.dateBox = new System.Windows.Forms.TextBox();
            this.datelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Local Time";
            this.label1.Click += new System.EventHandler(this.lbl_click);
            // 
            // timelcl
            // 
            this.timelcl.BackColor = System.Drawing.SystemColors.Info;
            this.timelcl.Location = new System.Drawing.Point(34, 57);
            this.timelcl.Margin = new System.Windows.Forms.Padding(7);
            this.timelcl.Name = "timelcl";
            this.timelcl.ReadOnly = true;
            this.timelcl.Size = new System.Drawing.Size(128, 37);
            this.timelcl.TabIndex = 1;
            this.timelcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zulu ~ Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 112);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "East Time";
            // 
            // timeZulu
            // 
            this.timeZulu.BackColor = System.Drawing.SystemColors.Info;
            this.timeZulu.Location = new System.Drawing.Point(34, 231);
            this.timeZulu.Margin = new System.Windows.Forms.Padding(7);
            this.timeZulu.Name = "timeZulu";
            this.timeZulu.ReadOnly = true;
            this.timeZulu.Size = new System.Drawing.Size(128, 37);
            this.timeZulu.TabIndex = 4;
            this.timeZulu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeAZ
            // 
            this.timeAZ.BackColor = System.Drawing.SystemColors.Info;
            this.timeAZ.Location = new System.Drawing.Point(34, 144);
            this.timeAZ.Margin = new System.Windows.Forms.Padding(7);
            this.timeAZ.Name = "timeAZ";
            this.timeAZ.ReadOnly = true;
            this.timeAZ.Size = new System.Drawing.Size(128, 37);
            this.timeAZ.TabIndex = 5;
            this.timeAZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateBox
            // 
            this.dateBox.BackColor = System.Drawing.SystemColors.Info;
            this.dateBox.Location = new System.Drawing.Point(34, 318);
            this.dateBox.Margin = new System.Windows.Forms.Padding(7);
            this.dateBox.Name = "dateBox";
            this.dateBox.ReadOnly = true;
            this.dateBox.Size = new System.Drawing.Size(128, 37);
            this.dateBox.TabIndex = 7;
            this.dateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // datelbl
            // 
            this.datelbl.AutoSize = true;
            this.datelbl.Location = new System.Drawing.Point(30, 285);
            this.datelbl.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.datelbl.Name = "datelbl";
            this.datelbl.Size = new System.Drawing.Size(136, 30);
            this.datelbl.TabIndex = 6;
            this.datelbl.Text = "Zulu ~ Date";
            // 
            // f1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(203, 388);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.datelbl);
            this.Controls.Add(this.timeAZ);
            this.Controls.Add(this.timeZulu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timelcl);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f1";
            this.Text = "Time Check";
            this.Load += new System.EventHandler(this.f1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timelcl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeZulu;
        private System.Windows.Forms.TextBox timeAZ;
        private System.Windows.Forms.TextBox dateBox;
        private System.Windows.Forms.Label datelbl;
    }
}

