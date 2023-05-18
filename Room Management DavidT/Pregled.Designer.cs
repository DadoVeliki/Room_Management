namespace Room_Management_DavidT
{
    partial class Pregled
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.rez = new System.Windows.Forms.Button();
            this.dod = new System.Windows.Forms.Button();
            this.obrrez = new System.Windows.Forms.Button();
            this.obkor = new System.Windows.Forms.Button();
            this.uredikor = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackColor = System.Drawing.Color.SteelBlue;
            this.monthCalendar1.Location = new System.Drawing.Point(427, 104);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // rez
            // 
            this.rez.Location = new System.Drawing.Point(118, 143);
            this.rez.Name = "rez";
            this.rez.Size = new System.Drawing.Size(61, 41);
            this.rez.TabIndex = 1;
            this.rez.UseVisualStyleBackColor = true;
            this.rez.Click += new System.EventHandler(this.rez_Click);
            // 
            // dod
            // 
            this.dod.Location = new System.Drawing.Point(51, 143);
            this.dod.Name = "dod";
            this.dod.Size = new System.Drawing.Size(61, 41);
            this.dod.TabIndex = 2;
            this.dod.UseVisualStyleBackColor = true;
            this.dod.Click += new System.EventHandler(this.dod_Click);
            // 
            // obrrez
            // 
            this.obrrez.Location = new System.Drawing.Point(205, 143);
            this.obrrez.Name = "obrrez";
            this.obrrez.Size = new System.Drawing.Size(61, 41);
            this.obrrez.TabIndex = 5;
            this.obrrez.UseVisualStyleBackColor = true;
            this.obrrez.Click += new System.EventHandler(this.obrrez_Click);
            // 
            // obkor
            // 
            this.obkor.Location = new System.Drawing.Point(216, 143);
            this.obkor.Name = "obkor";
            this.obkor.Size = new System.Drawing.Size(61, 41);
            this.obkor.TabIndex = 6;
            this.obkor.UseVisualStyleBackColor = true;
            this.obkor.Click += new System.EventHandler(this.obkor_Click);
            // 
            // uredikor
            // 
            this.uredikor.Location = new System.Drawing.Point(138, 143);
            this.uredikor.Name = "uredikor";
            this.uredikor.Size = new System.Drawing.Size(61, 41);
            this.uredikor.TabIndex = 7;
            this.uredikor.UseVisualStyleBackColor = true;
            this.uredikor.Click += new System.EventHandler(this.uredikor_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(648, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 197);
            this.listBox1.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(427, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(424, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Prostorija:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(12, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 39);
            this.button1.TabIndex = 15;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(643, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Prostorija: ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(793, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 39);
            this.button2.TabIndex = 17;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "KORISNICI";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(112, 47);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(111, 21);
            this.comboBox2.TabIndex = 20;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(112, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Odaberi:";
            // 
            // Pregled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(861, 376);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.uredikor);
            this.Controls.Add(this.obkor);
            this.Controls.Add(this.obrrez);
            this.Controls.Add(this.dod);
            this.Controls.Add(this.rez);
            this.Controls.Add(this.monthCalendar1);
            this.Name = "Pregled";
            this.Text = "Pregled";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pregled_FormClosing);
            this.Load += new System.EventHandler(this.Pregled_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button rez;
        private System.Windows.Forms.Button dod;
        private System.Windows.Forms.Button obrrez;
        private System.Windows.Forms.Button obkor;
        private System.Windows.Forms.Button uredikor;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
    }
}