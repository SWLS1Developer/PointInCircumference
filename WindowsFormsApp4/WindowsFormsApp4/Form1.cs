using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp4;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private static int angle = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int offset = 8;
            Pen p = new Pen(Color.White, 2.1f);
            Pen p1 = new Pen(Color.Red, 2.1f);
            Pen p2 = new Pen(Color.SeaGreen, 2.1f);
            Rectangle rect = new Rectangle(offset / 2, offset / 2, this.Width - offset, this.Height - offset);
            PointF olok = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics GFX = Graphics.FromImage(bmp);
            GFX.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            GFX.DrawEllipse(p, rect);

            double radyan = (Math.PI / 180) * angle++;
            double sx, sy, yaricap;
            yaricap = rect.Width / 2;
            PointF OrtaNokta = olok;
            sx = yaricap * Math.Cos(radyan);
            sy = yaricap * Math.Sin(radyan);
            PointF lok = new PointF((float)sx + OrtaNokta.X, (float)sy + OrtaNokta.Y);

            GFX.DrawArrow(p, olok, lok);
            GFX.DrawArrow(p1, olok, new PointF(lok.X, olok.Y));
            GFX.DrawArrow(p2, new PointF(lok.X, olok.Y), lok);

            Form2.SetText($"Derece: {angle}°\r\nRadyan:{radyan} rad\r\nCOS: {sx/yaricap}\r\nSİN: {sy / yaricap}\r\nX,Y: {sx},{sy}\r\nYARIÇAP:{yaricap}\r\n\r\n");
            Form2.SetChart(sx / yaricap, sy / yaricap);

            this.BackgroundImage = bmp;
            if (angle > 360) { angle = angle % 360; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            (new Form2()).Show();
        }
    }
}

public static class GenisletmeMethodlari
{
    public static void DrawArrow(this Graphics g, Pen pen, PointF pt1, PointF pt2)
    {
        g.DrawLine(pen, pt1, pt2);
    }

    public static PointF KartezyenKordinatHesapla(this PointF OrtaNokta, double yaricap, int aci)
    {
        double radyan = (Math.PI / 180) * aci; //A*(𝜋/180)
        double sx, sy;
        sx = yaricap * Math.Cos(radyan);
        sy = yaricap * Math.Sin(radyan);
        return new PointF((float)sx + OrtaNokta.X, (float)sy + OrtaNokta.Y);
    }
}