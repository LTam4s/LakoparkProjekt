namespace LakoparkProjekt
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnbalnyil = new System.Windows.Forms.PictureBox();
            this.btnjobbnyil = new System.Windows.Forms.PictureBox();
            this.namePic = new System.Windows.Forms.PictureBox();
            this.save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.btnbalnyil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnjobbnyil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(200, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 378);
            this.panel1.TabIndex = 0;
            // 
            // btnbalnyil
            // 
            this.btnbalnyil.Location = new System.Drawing.Point(400, 396);
            this.btnbalnyil.Name = "btnbalnyil";
            this.btnbalnyil.Size = new System.Drawing.Size(100, 50);
            this.btnbalnyil.TabIndex = 1;
            this.btnbalnyil.TabStop = false;
            this.btnbalnyil.Click += new System.EventHandler(this.btnbalnyil_Click);
            // 
            // btnjobbnyil
            // 
            this.btnjobbnyil.Location = new System.Drawing.Point(533, 396);
            this.btnjobbnyil.Name = "btnjobbnyil";
            this.btnjobbnyil.Size = new System.Drawing.Size(100, 50);
            this.btnjobbnyil.TabIndex = 2;
            this.btnjobbnyil.TabStop = false;
            this.btnjobbnyil.Click += new System.EventHandler(this.btnjobbnyil_Click);
            // 
            // namePic
            // 
            this.namePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.namePic.Location = new System.Drawing.Point(42, 28);
            this.namePic.Name = "namePic";
            this.namePic.Size = new System.Drawing.Size(100, 133);
            this.namePic.TabIndex = 3;
            this.namePic.TabStop = false;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(13, 415);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 4;
            this.save.Text = "Mentés";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.save);
            this.Controls.Add(this.namePic);
            this.Controls.Add(this.btnjobbnyil);
            this.Controls.Add(this.btnbalnyil);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnbalnyil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnjobbnyil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.namePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnbalnyil;
        private System.Windows.Forms.PictureBox btnjobbnyil;
        private System.Windows.Forms.PictureBox namePic;
        private System.Windows.Forms.Button save;
    }
}

