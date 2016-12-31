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
        int width = 300, height = 300, sechand = 140, minhand = 110, hrhand=80;
        int cx, cy;
        Bitmap bmp;
        Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
