using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace analog_clock
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int width = 300, height = 300, sechand = 140, minhand = 110, hrhand = 80;
        int cx, cy;
        Bitmap bmp;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(width + 1, height + 1);
            cx = width / 2;
            cy = height / 2;
            this.BackColor = Color.White;
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_tick);
        }
        private void t_tick(object sender, EventArgs e)
        {
            g = Graphics.FromImage(bmp);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;

            int[] handcoord = new int[2];
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, width, height);
            g.DrawString("12", new Font("arial", 12), Brushes.Black, new Point(140, 2));
            g.DrawString("3", new Font("arial", 12), Brushes.Black, new Point(286, 140)); 
            g.DrawString("6", new Font("arial", 12), Brushes.Black, new Point(142, 282));
            g.DrawString("9", new Font("arial", 12), Brushes.Black, new Point(0,140));
            handcoord = mscoord(ss, sechand);
            g.DrawLine(new Pen(Color.Red, 1f), new Point(cx,cy), new Point(handcoord[1]));
            handcoord = mscoord(mm, minhand);
            g.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(handcoord[1]));
            handcoord =hrcoord(hh%12,mm, hrhand);
            g.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(handcoord[1]));
            pictureBox1.Image = bmp;
            this.Text
                = "analog clock-" +hh+":"+mm+":"+ss;
            g.Dispose();
        }
        private int[] mscoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;
            if (val >= 0 && val < +180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));


            }
            else
            {
                coord[0] = cx - (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));

            }
            return coord;
        }
        private int[] hrcoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
            int val = (int)((hval * 30) + (mval * 0.5));
            if (val >= 0 && val < +180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));


            }
            else
            {
                coord[0] = cx - (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));

            }
            return coord;
        }
    }
}
