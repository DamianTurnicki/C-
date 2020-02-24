using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        int x = -1;
        int y = -1;
        bool isMoving = false;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
            g = panelCanvas.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isMoving = true;
            x = e.X;
            y = e.Y;
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isMoving = false;
            x = -1;
            y = -1;
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(isMoving && x!=-1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panelCanvas.Invalidate();
        }
    }
}
