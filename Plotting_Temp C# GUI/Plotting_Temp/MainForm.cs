/* 
 * File: MainFrom.cs
 * Copyright(C) 2017 ALHASAN ALKHATIB
 *
 * date:   12, 2017
 * Author: ALHASAN ALKHATIB
 * Description: this C# code is written to read a discrete signal from serial port
 *              process and plot it       
 *             
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace Plotting_Temp
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public double Range { get; set; }
        public string Gelenveri { get; set; }
        public double Data { get; set; }
        public double MyTime { get; set; }
        public bool Stop { get; set; }
        public int amp { get; set; }

        GraphPane myPane = new GraphPane();
        PointPairList listPoints = new PointPairList();
        LineItem myCurve;

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            Range = 0.1;
            MyTime = 0;
            Stop = false;
            amp = 60;
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        private void GrafikHazirla(int xamp)
        {
            myPane = zedGraphControl1.GraphPane;
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = xamp;
            myCurve = myPane.AddCurve(null, listPoints, Color.Red, SymbolType.None);
            myCurve.Line.Width = 1;
        }

        void Button1Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = textBox1.Text;
                serialPort1.BaudRate = Convert.ToInt32(textBox2.Text);
                serialPort1.Open();
            }

            GrafikHazirla(amp);
        }
        void Button2Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            // zedGraphControl1.Invalidate();
        }
        void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Gelenveri = serialPort1.ReadExisting();

            if (Gelenveri[0] == ' ')
            {
                if (Gelenveri.Length >= 3)
                {
                    Data = (Gelenveri[1] - 48) * 100 + 10 * (Gelenveri[2] - 48) + (Gelenveri[3] - 48);
                    Data = Data / 10;
                }
            }
            else
            {
                if (Gelenveri.Length >= 3)
                {
                    Data = (Gelenveri[0] - 48) * 100 + 10 * (Gelenveri[1] - 48) + (Gelenveri[2] - 48);
                    Data = Data / 10;
                }
            }
            this.Invoke(new EventHandler(DisplayText));
        }

        private void DisplayText(object sender, EventArgs e)
        {
            if (!Stop)
            {
                Write();
            }
            textBox6.Text = Data + " C";
        }


        private void button6_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
            GrafikHazirla(amp);

            if (Range > 0.01)
            {
                Range = Range - 0.01;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
            GrafikHazirla(amp);

            if (Range < 1)
            {
                Range = Range + 0.01;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Stop = !Stop;
        }
        private void Write()
        {
            MyTime = MyTime + 0.001;
            listPoints.Add(new PointPair(MyTime, Data));
            myPane.XAxis.Scale.Max = MyTime;
            myPane.XAxis.Scale.Min = MyTime - Range;
            myPane.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void amp1_Click(object sender, EventArgs e)
        {
            if (amp < 100)
            {
                amp = amp + 5;
            }
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
            GrafikHazirla(amp);
        }

        private void amp2_Click(object sender, EventArgs e)
        {
            if (amp > 20)
            {
                amp = amp - 5;
            }
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl1.Invalidate();
            GrafikHazirla(amp);
        }

        private void Delay1_Click(object sender, EventArgs e)
        {
            serialPort1.Write("P");
        }

        private void Delay2_Click(object sender, EventArgs e)
        {
            serialPort1.Write("N");
        }
    }
}
