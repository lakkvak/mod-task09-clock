using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            Width = 800;
            Height = 800;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            Pen pen = new Pen(Color.BurlyWood, 3);           
            Graphics graphics = e.Graphics;
            GraphicsState gs;
            
            graphics.TranslateTransform(Width / 2, Height / 2);
            graphics.ScaleTransform(500 / 200, 500 / 200);
            graphics.DrawEllipse(pen, -120, -120, 240, 240);
            graphics.DrawEllipse(new Pen(new SolidBrush(Color.IndianRed), 1),-115, -115, 230, 230);

            graphics.DrawString(Convert.ToString(12), new Font("Times New Roman", 9F), new SolidBrush(Color.Black), -10, -110);
            graphics.DrawString(Convert.ToString(3), new Font("Times New Roman", 9F), new SolidBrush(Color.Black), 100, -10);
            graphics.DrawString(Convert.ToString(6), new Font("Times New Roman", 9F), new SolidBrush(Color.Black), -5, 95);
            graphics.DrawString(Convert.ToString(9), new Font("Times New Roman", 9F), new SolidBrush(Color.Black), -110, -10);


            gs = graphics.Save();
            
            
           
            for (int i = 0; i < 12; i++)
            {
                
                graphics.RotateTransform(30 * i);                
                graphics.DrawEllipse(new Pen(new SolidBrush(Color.DarkSlateBlue), 6), 115, -2, 4, 4);                
                graphics.Restore(gs);
                gs = graphics.Save();

            }
            
            for (int i = 0; i < 60; i++)
            {
                graphics.RotateTransform(6 * i);
                graphics.DrawLine(new Pen(new SolidBrush(Color.Blue), 2),0, -120, 0, -116);
                graphics.Restore(gs);
                gs = graphics.Save();
            }
            gs = graphics.Save();
            Pen hour = new Pen(Color.Orange, 5);
            hour.EndCap = LineCap.ArrowAnchor;
            Pen minute = new Pen(Color.Green, 3);
            minute.EndCap = LineCap.DiamondAnchor;
            Pen sec = new Pen(Color.DeepPink, 2);
            sec.EndCap = LineCap.Triangle;

            graphics.RotateTransform(6 * (dateTime.Minute+(float)dateTime.Second/60));
            graphics.DrawLine(minute, 0, 0, 0, -85);
            graphics.Restore(gs);
            gs = graphics.Save();
            graphics.RotateTransform(6 * (float)dateTime.Second);
            graphics.DrawLine(sec, 0, 0, 0, -110);
            graphics.Restore(gs);
            gs = graphics.Save();
            graphics.RotateTransform(30 * (dateTime.Hour + (float)dateTime.Minute / 60 + (float)dateTime.Second/3600));
            
            graphics.DrawLine(hour, 0, 0, 0, -55);
            graphics.Restore(gs);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
