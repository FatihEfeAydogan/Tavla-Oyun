﻿namespace BackgammonWinformView
{
    partial class BaslangicForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaslangicForm));
            this.Cikis = new System.Windows.Forms.Button();
            this.Oyna = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cikis
            // 
            this.Cikis.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Cikis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Cikis.Location = new System.Drawing.Point(515, 269);
            this.Cikis.Name = "Cikis";
            this.Cikis.Size = new System.Drawing.Size(153, 54);
            this.Cikis.TabIndex = 11;
            this.Cikis.Text = "Cikis";
            this.Cikis.UseVisualStyleBackColor = false;
            this.Cikis.Click += new System.EventHandler(this.Cikis_Click);
            // 
            // Oyna
            // 
            this.Oyna.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Oyna.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Oyna.Location = new System.Drawing.Point(515, 189);
            this.Oyna.Name = "Oyna";
            this.Oyna.Size = new System.Drawing.Size(153, 54);
            this.Oyna.TabIndex = 10;
            this.Oyna.Text = "Oyna";
            this.Oyna.UseVisualStyleBackColor = false;
            this.Oyna.Click += new System.EventHandler(this.Oyna_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tamer Yılmaz 032190036";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Berke Kadir Çelik 032290005";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Emir Uçar 032290062";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Fatih Efe Aydoğan 032290083";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(280, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "TAVLA OYUNU";
            // 
            // BaslangicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Cikis);
            this.Controls.Add(this.Oyna);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BaslangicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tavla Oyunu";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cikis;
        private System.Windows.Forms.Button Oyna;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
    }
}