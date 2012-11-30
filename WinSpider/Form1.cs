using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing.Drawing2D;

namespace WinSpider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.FillEllipse(Brushes.Blue, 10, 20, 50, 100);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillEllipse(Brushes.Blue, 10, 20, 50, 100);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float x, y, w, h;
            x = pictureBox1.Left - 2;
            y = pictureBox1.Top - 2;
            w = pictureBox1.Width + 4;
            h = pictureBox1.Height + 4;
            Pen pen = new Pen(Color.Red, 2);
            g.DrawRectangle(pen, x, y, w, h);

            GraphicsPath gp = new GraphicsPath();
            gp.AddRectangle(new Rectangle(10, 10, 100, 100));
        }
    }
}