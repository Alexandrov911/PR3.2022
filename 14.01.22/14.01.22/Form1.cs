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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            pictureBox1.BackColor = Color.White;
            Pen p = new Pen(Color.Red);
            p.Width = 3;

            SolidBrush b = new SolidBrush(Color.CadetBlue);
            int x = Convert.ToInt32(numericUpDown1.Value);
            int y = Convert.ToInt32(numericUpDown2.Value);
            int h = Convert.ToInt32(numericUpDown3.Value);
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

            /* pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
             Graphics g = Graphics.FromImage(pictureBox1.Image);
             pictureBox1.BackColor = Color.White;
             Pen p = new Pen(Color.Red);
             p.Width = 5;

             SolidBrush b = new SolidBrush(Color.Green);
             int x = Convert.ToInt32(numericUpDown1.Value);
             int y = Convert.ToInt32(numericUpDown2.Value);
             int h = Convert.ToInt32(numericUpDown3.Value);
             g.FillRectangle(b, x, y, h, h);
             g.DrawRectangle(p, x, y, h, h);

             Point p1 = new Point(x + h / 2, y);
             Point p2 = new Point(x + h / 2, y+h);
             g.DrawLine(p, p1, p2);
             Point p3 = new Point(x, y+h/2);
             Point p4 = new Point(x + h, y + h/2);
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
             g.DrawLines(p, mas);*/


        }
        public void DrawAll()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            SolidBrush b = new SolidBrush(Color.White);
            g.FillRectangle(b, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh();
            for(int i=0; i<listBox1.Items.Count; i++)
            {
                Figure f = listBox1.Items[i] as Figure;
                f.Draw();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Text = "Добавление";
            if (form.ShowDialog() == DialogResult.OK) 
            {
                int x = Convert.ToInt32(form.numericUpDown1.Value);
                int y = Convert.ToInt32(form.numericUpDown2.Value);
                int h = Convert.ToInt32(form.numericUpDown3.Value);
                Figure f = new Figure(x, y, h, pictureBox1);
                //f.Draw();
                //Сделать перерисовку всех объектов

                listBox1.Items.Add(f);
                DrawAll();
                


            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            
            pictureBox1.BackColor = Color.White;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Объект не выбран");

            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                DrawAll();
                
                button4.Enabled = false;
                button3.Enabled = false;



            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Объект не выбран");
            }
            else
            {
                Figure f = listBox1.Items[listBox1.SelectedIndex] as Figure;
                Form2 form = new Form2();
                form.Text = "Редактирование";
                form.numericUpDown1.Value = f.x;
                form.numericUpDown2.Value = f.y;
                form.numericUpDown3.Value = f.h;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    f.x = Convert.ToInt32(form.numericUpDown1.Value);
                    f.y = Convert.ToInt32(form.numericUpDown2.Value);
                    f.h = Convert.ToInt32(form.numericUpDown3.Value);
                    listBox1.Items[listBox1.SelectedIndex] = f;
                    DrawAll();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }

        }
    }
}
