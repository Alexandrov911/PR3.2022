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

namespace _14._01._22
{
    class Figure
    {
        public int x, y, h;
        PictureBox myPb;
        public Figure(int n_x, int n_y, int n_h, PictureBox n_myPb)
        {
            x = n_x;
            y = n_y;
            h = n_h;
            myPb = n_myPb;
        }
        public void Draw()
        {
            
            Graphics g = Graphics.FromImage(myPb.Image);
         
            Pen p = new Pen(Color.Red);
            p.Width = 3;

            SolidBrush b = new SolidBrush(Color.CadetBlue);
           
            g.FillRectangle(b, x, y, h, h);
            g.DrawRectangle(p, x, y, h, h);

            Point p1 = new Point(x, y);
            Point p2 = new Point(x + h, y + h);
            g.DrawLine(p, p1, p2);
            Point p3 = new Point(x, y + h);
            Point p4 = new Point(x + h, y);
            g.DrawLine(p, p3, p4);
            SolidBrush bs2 = new SolidBrush(Color.Green);
            g.FillEllipse(bs2, x + h / 4 + h / 8, y + h / 2 + h / 6, h / 2 - h / 8 - h / 8, h / 2 - h / 8 - h / 8);
            g.FillEllipse(bs2, x + h / 4 + h / 8, y + h / 10, h / 2 - h / 8 - h / 8, h / 2 - h / 8 - h / 8);
            myPb.Refresh();
            /*Graphics g = Graphics.FromImage(myPb.Image);
           
            Pen p = new Pen(Color.Red);
            p.Width = 5;
            
            SolidBrush b = new SolidBrush(Color.Green);
          
            g.FillRectangle(b, x, y, h, h);
            g.DrawRectangle(p, x, y, h, h);

            Point p1 = new Point(x + h / 2, y);
            Point p2 = new Point(x + h / 2, y + h);
            g.DrawLine(p, p1, p2);
            Point p3 = new Point(x, y + h / 2);
            Point p4 = new Point(x + h, y + h / 2);
            g.DrawLine(p, p3, p4);


            SolidBrush bs2 = new SolidBrush(Color.Pink);
            g.FillEllipse(bs2, x + h / 8, y + h / 2 + h / 8, h / 2 - h / 8 - h / 8, h / 2 - h / 8 - h / 8);
            g.FillEllipse(bs2, x + h / 2 + h / 8, y + h / 8, h / 2 - h / 8 - h / 8, h / 2 - h / 8 - h / 8);
            

            Point p5 = new Point(x, y + h);
            Point p6 = new Point(x + h, y + h);

            Point[] mas = new Point[4];
            mas[0] = p1;
            mas[1] = p5;
            mas[2] = p6;
            mas[3] = p1;
            g.DrawLines(p, mas);

            myPb.Refresh();//!!!!!!!!!!*/
        }
        public override string ToString()
        {
            return "Фигура h=" + h.ToString();
        }
    }
}
