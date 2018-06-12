namespace Etime2UTC
{
  partial class TimeConvert
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
      this.inputEpochTxt = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.outPutDateTxt = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.timelcl = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.timehawaii = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.timezulu = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.timeeast = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.datebox = new System.Windows.Forms.TextBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.go = new System.Windows.Forms.Button();
      this.clear = new System.Windows.Forms.Button();
      this.EpochTime = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // inputEpochTxt
      // 
      this.inputEpochTxt.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.inputEpochTxt.Location = new System.Drawing.Point(81, 61);
      this.inputEpochTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.inputEpochTxt.Name = "inputEpochTxt";
      this.inputEpochTxt.Size = new System.Drawing.Size(200, 26);
      this.inputEpochTxt.TabIndex = 0;
      this.inputEpochTxt.Text = "Enter Epoch Time here";
      this.inputEpochTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(114, 41);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 16);
      this.label1.TabIndex = 1;
      this.label1.Text = "INPUT ~ Epoch Miliseconds";
      // 
      // outPutDateTxt
      // 
      this.outPutDateTxt.BackColor = System.Drawing.SystemColors.Info;
      this.outPutDateTxt.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.outPutDateTxt.Location = new System.Drawing.Point(81, 120);
      this.outPutDateTxt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.outPutDateTxt.Name = "outPutDateTxt";
      this.outPutDateTxt.ReadOnly = true;
      this.outPutDateTxt.Size = new System.Drawing.Size(200, 32);
      this.outPutDateTxt.TabIndex = 2;
      this.outPutDateTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(83, 100);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(198, 16);
      this.label2.TabIndex = 3;
      this.label2.Text = "OUTPUT ~ UTC Time human Readable";
      this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.Location = new System.Drawing.Point(43, 164);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(109, 20);
      this.label3.TabIndex = 5;
      this.label3.Text = "Local 24 Hr Time";
      // 
      // timelcl
      // 
      this.timelcl.BackColor = System.Drawing.SystemColors.Info;
      this.timelcl.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timelcl.Location = new System.Drawing.Point(33, 188);
      this.timelcl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.timelcl.Name = "timelcl";
      this.timelcl.ReadOnly = true;
      this.timelcl.Size = new System.Drawing.Size(128, 29);
      this.timelcl.TabIndex = 4;
      this.timelcl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(54, 258);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(107, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "Hawaii Time 24H";
      // 
      // timehawaii
      // 
      this.timehawaii.BackColor = System.Drawing.SystemColors.Info;
      this.timehawaii.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timehawaii.Location = new System.Drawing.Point(33, 282);
      this.timehawaii.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.timehawaii.Name = "timehawaii";
      this.timehawaii.ReadOnly = true;
      this.timehawaii.Size = new System.Drawing.Size(128, 29);
      this.timehawaii.TabIndex = 6;
      this.timehawaii.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.Location = new System.Drawing.Point(200, 165);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(115, 20);
      this.label5.TabIndex = 9;
      this.label5.Text = "UTC ~ ZULU Time";
      // 
      // timezulu
      // 
      this.timezulu.BackColor = System.Drawing.SystemColors.Info;
      this.timezulu.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timezulu.Location = new System.Drawing.Point(187, 189);
      this.timezulu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.timezulu.Name = "timezulu";
      this.timezulu.ReadOnly = true;
      this.timezulu.Size = new System.Drawing.Size(128, 29);
      this.timezulu.TabIndex = 8;
      this.timezulu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(200, 258);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(133, 20);
      this.label6.TabIndex = 11;
      this.label6.Text = "East Coast Time 24H";
      // 
      // timeeast
      // 
      this.timeeast.BackColor = System.Drawing.SystemColors.Info;
      this.timeeast.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timeeast.Location = new System.Drawing.Point(187, 282);
      this.timeeast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.timeeast.Name = "timeeast";
      this.timeeast.ReadOnly = true;
      this.timeeast.Size = new System.Drawing.Size(128, 29);
      this.timeeast.TabIndex = 10;
      this.timeeast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(105, 343);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(149, 20);
      this.label7.TabIndex = 13;
      this.label7.Text = "UTC ~ GMT ~ Zulu Date";
      // 
      // datebox
      // 
      this.datebox.BackColor = System.Drawing.SystemColors.Info;
      this.datebox.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.datebox.Location = new System.Drawing.Point(111, 367);
      this.datebox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.datebox.Name = "datebox";
      this.datebox.ReadOnly = true;
      this.datebox.Size = new System.Drawing.Size(128, 29);
      this.datebox.TabIndex = 12;
      this.datebox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Interval = 1;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // go
      // 
      this.go.Location = new System.Drawing.Point(33, 12);
      this.go.Name = "go";
      this.go.Size = new System.Drawing.Size(75, 23);
      this.go.TabIndex = 14;
      this.go.Text = "Convert";
      this.go.UseVisualStyleBackColor = true;
      this.go.Click += new System.EventHandler(this.Click_convert);
      // 
      // clear
      // 
      this.clear.Location = new System.Drawing.Point(258, 12);
      this.clear.Name = "clear";
      this.clear.Size = new System.Drawing.Size(75, 23);
      this.clear.TabIndex = 15;
      this.clear.Text = "Clear";
      this.clear.UseVisualStyleBackColor = true;
      this.clear.Click += new System.EventHandler(this.Click_clear);
      // 
      // EpochTime
      // 
      this.EpochTime.BackColor = System.Drawing.SystemColors.Info;
      this.EpochTime.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.EpochTime.Location = new System.Drawing.Point(58, 444);
      this.EpochTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.EpochTime.Name = "EpochTime";
      this.EpochTime.ReadOnly = true;
      this.EpochTime.Size = new System.Drawing.Size(223, 29);
      this.EpochTime.TabIndex = 16;
      this.EpochTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.Location = new System.Drawing.Point(113, 420);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(103, 20);
      this.label8.TabIndex = 17;
      this.label8.Text = "ZULU ~ EPOCH";
      // 
      // TimeConvert
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(369, 495);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.EpochTime);
      this.Controls.Add(this.clear);
      this.Controls.Add(this.go);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.datebox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.timeeast);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.timezulu);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.timehawaii);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.timelcl);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.outPutDateTxt);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.inputEpochTxt);
      this.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "TimeConvert";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load_1);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox inputEpochTxt;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox outPutDateTxt;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox timelcl;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox timehawaii;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox timezulu;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox timeeast;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox datebox;
    public System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button go;
    private System.Windows.Forms.Button clear;
    private System.Windows.Forms.TextBox EpochTime;
    private System.Windows.Forms.Label label8;
  }
}

