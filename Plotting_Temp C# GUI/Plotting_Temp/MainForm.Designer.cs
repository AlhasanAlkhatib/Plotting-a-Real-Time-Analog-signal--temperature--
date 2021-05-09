/* Copyright(C) 2017 ALHASAN ALKHATIB
*
* date:   12, 2017
* Author: ALHASAN ALKHATIB
* Description: this C# code is written to read a discrete signal from serial port
* process and plot it
*
*/
namespace Plotting_Temp
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.F1 = new System.Windows.Forms.Button();
            this.F2 = new System.Windows.Forms.Button();
            this.StartStop = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.amp1 = new System.Windows.Forms.Button();
            this.amp2 = new System.Windows.Forms.Button();
            this.Delay1 = new System.Windows.Forms.Button();
            this.Delay2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(262, 22);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "COM7";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "com number";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(18, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "baud rate";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 80);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 26);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "115200";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1DataReceived);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 80);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 14;
            this.label6.Text = "Temp (C)";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(114, 143);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(121, 26);
            this.textBox6.TabIndex = 15;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // F1
            // 
            this.F1.Location = new System.Drawing.Point(457, 22);
            this.F1.Name = "F1";
            this.F1.Size = new System.Drawing.Size(52, 51);
            this.F1.TabIndex = 17;
            this.F1.Text = "F+";
            this.F1.UseVisualStyleBackColor = true;
            this.F1.Click += new System.EventHandler(this.button5_Click);
            // 
            // F2
            // 
            this.F2.Location = new System.Drawing.Point(524, 22);
            this.F2.Name = "F2";
            this.F2.Size = new System.Drawing.Size(52, 51);
            this.F2.TabIndex = 18;
            this.F2.Text = "F-";
            this.F2.UseVisualStyleBackColor = true;
            this.F2.Click += new System.EventHandler(this.button6_Click);
            // 
            // StartStop
            // 
            this.StartStop.Location = new System.Drawing.Point(480, 80);
            this.StartStop.Name = "StartStop";
            this.StartStop.Size = new System.Drawing.Size(79, 67);
            this.StartStop.TabIndex = 23;
            this.StartStop.Text = "START/STOP";
            this.StartStop.UseVisualStyleBackColor = true;
            this.StartStop.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.AutoSize = true;
            this.zedGraphControl1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.zedGraphControl1.Location = new System.Drawing.Point(155, 193);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(843, 494);
            this.zedGraphControl1.TabIndex = 25;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // amp1
            // 
            this.amp1.Location = new System.Drawing.Point(638, 22);
            this.amp1.Name = "amp1";
            this.amp1.Size = new System.Drawing.Size(59, 51);
            this.amp1.TabIndex = 26;
            this.amp1.Text = "amp+";
            this.amp1.UseVisualStyleBackColor = true;
            this.amp1.Click += new System.EventHandler(this.amp1_Click);
            // 
            // amp2
            // 
            this.amp2.Location = new System.Drawing.Point(714, 22);
            this.amp2.Name = "amp2";
            this.amp2.Size = new System.Drawing.Size(62, 51);
            this.amp2.TabIndex = 27;
            this.amp2.Text = "amp-";
            this.amp2.UseVisualStyleBackColor = true;
            this.amp2.Click += new System.EventHandler(this.amp2_Click);
            // 
            // Delay1
            // 
            this.Delay1.Location = new System.Drawing.Point(810, 22);
            this.Delay1.Name = "Delay1";
            this.Delay1.Size = new System.Drawing.Size(67, 51);
            this.Delay1.TabIndex = 28;
            this.Delay1.Text = "Delay+";
            this.Delay1.UseVisualStyleBackColor = true;
            this.Delay1.Click += new System.EventHandler(this.Delay1_Click);
            // 
            // Delay2
            // 
            this.Delay2.Location = new System.Drawing.Point(894, 22);
            this.Delay2.Name = "Delay2";
            this.Delay2.Size = new System.Drawing.Size(67, 51);
            this.Delay2.TabIndex = 29;
            this.Delay2.Text = "Delay-";
            this.Delay2.UseVisualStyleBackColor = true;
            this.Delay2.Click += new System.EventHandler(this.Delay2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1100, 749);
            this.Controls.Add(this.Delay2);
            this.Controls.Add(this.Delay1);
            this.Controls.Add(this.amp2);
            this.Controls.Add(this.amp1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.StartStop);
            this.Controls.Add(this.F2);
            this.Controls.Add(this.F1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "deneme2";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button F1;
        private System.Windows.Forms.Button F2;
        private System.Windows.Forms.Button StartStop;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Button amp1;
        private System.Windows.Forms.Button amp2;
        private System.Windows.Forms.Button Delay1;
        private System.Windows.Forms.Button Delay2;
    }
}

