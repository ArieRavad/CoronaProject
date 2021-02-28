using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CoronaProject
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


        private void InitializeComponent()
        {
            this.AllMyButtns = new mybutton[90, 45];
            this.startB = new mybutton();
            this.startB.BackColor = System.Drawing.Color.White;
            this.startB.Size = new System.Drawing.Size(38, 20);
            this.startB.Location = new System.Drawing.Point(5*15,3);
            this.startB.UseVisualStyleBackColor = true;
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip2.InitialDelay = 100;
            ToolTip2.SetToolTip(this.startB, "Simulate period of time");
            this.startB.Text = "Play";
            this.startB.infactionRatio = 0.4;

           
            this.resetB = new mybutton();
            this.resetB.BackColor = System.Drawing.Color.White;
            this.resetB.Size = new System.Drawing.Size(45, 20);
            this.resetB.Location = new System.Drawing.Point(15, 3);
            this.resetB.UseVisualStyleBackColor = true;
            this.resetB.Text = "Reset";

            this.diseaseNUM = new TextBox();
            this.diseaseNUM.Location = new System.Drawing.Point(8 * 15, 3);
            this.diseaseNUM.Size = new System.Drawing.Size(40, 20);
            this.diseaseNUM.Text = "0.5";
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.InitialDelay = 100;
            ToolTip1.SetToolTip(this.diseaseNUM, "Infection coefficient (from 1 to 0)");

            
            this.Lethality = new NumericUpDown();
            this.Lethality.Location = new System.Drawing.Point(12 * 15, 3);
            this.Lethality.Size = new System.Drawing.Size(40, 20);
            this.Lethality.Value = 50;
            this.Lethality.Maximum = 100;
            this.Lethality.Minimum = 0;
            System.Windows.Forms.ToolTip ToolTip3 = new System.Windows.Forms.ToolTip();
            ToolTip3.InitialDelay = 100;
            ToolTip3.SetToolTip(this.Lethality, "Lethality (percentage)");





            Random rnd = new Random();

            for (int i = 0; i < 90; i++)
                  for (int j = 0; j < 45; j++)
                  {
                      AllMyButtns[i, j] = new mybutton();
                      AllMyButtns[i, j].Size = new System.Drawing.Size(15, 15);
                      AllMyButtns[i, j].Location = new System.Drawing.Point(i * 15 + 10, j * 15 + 25);
                      AllMyButtns[i, j].UseVisualStyleBackColor = true;
                      AllMyButtns[i, j].X = i;
                      AllMyButtns[i, j].Y = j;
                      AllMyButtns[i, j].IsInfected = 0;
                      AllMyButtns[i, j].IsAlive = 1;
                      AllMyButtns[i, j].IsVaccine = 0;
                      AllMyButtns[i, j].BackColor = System.Drawing.Color.White;
                  }

              this.SuspendLayout();

              this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
              this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
              this.ClientSize = new System.Drawing.Size(450, 475);

              //this.WindowState = FormWindowState.Maximized;

              for (int i = 0; i < 90; i++)
                  for (int j = 0; j < 45; j++)
                  { 
                      this.Controls.Add(AllMyButtns[i, j]);
                      AllMyButtns[i, j].Click += new System.EventHandler(ClickB);
                  }
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            
            
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Controls.Add(startB);
            this.Controls.Add(resetB);
            this.Controls.Add(diseaseNUM);
            this.Controls.Add(Lethality);
            startB.Click += new System.EventHandler(startBClick);
            resetB.Click += new System.EventHandler(resetBClick);
            this.Name = "Form1";
            this.Text = "Corona Simulator by Arie Ravad";
            this.ResumeLayout(false);
            
            
        }

        #endregion
        public mybutton [,] AllMyButtns;
        public mybutton startB;
        public mybutton resetB;
        public TextBox diseaseNUM;
        public NumericUpDown Lethality;
       
    }
}

