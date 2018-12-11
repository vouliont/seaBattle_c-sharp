using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace igra_MorskoyBoy
{
    public partial class Form1 : Form
    {
        public Label label1, label2, label3, label4, labelX1, labelX2, labelX3, labelX4;
        public int x, y;
        public string korNomer = "";
        public PictureBox pole;
        public int[,] pole1 = new int[10, 10], pole2 = new int[10, 10];
        public bool flag2_1 = false, flag2_2 = false, flag2_3 = false, flag3_1 = false, flag3_2 = false, flag4_1 = false;
        public bool vidKor2_1 = false, vidKor2_2 = false, vidKor2_3 = false, vidKor3_1 = false, vidKor3_2 = false, vidKor4_1 = false; 
        public int koordX, koordY, k, Number, poleNomer, korX, korY;
        public bool prov, est;
        public int poleActive = 1;
        public Bitmap tochka, krestik, nothing;
        public PictureBox[,] pictOne, pictTwo;
        public PictureBox pictone, picttwo, PictPole1, PictPole2;
        public int pict1X, pict1Y;
        public Point MousePoint;
        public bool flagKor;
        public int killOne = 0, killTwo = 0;

        public Form1()
        {
            InitializeComponent();
            
            // tochka, krestik, nul
            tochka = new Bitmap("image/tochka.png"); krestik = new Bitmap("image/krestik.png"); nothing = new Bitmap("image/nothing.png");
            // buttons
            button1.Size = new Size(200, 70); button1.Location = new Point(125, 80);
            button1.Font = new Font("Comic Sans Ms", 18); button1.BackColor = Color.Red;

            button2.Size = new Size(200, 70); button2.Location = new Point(125, 240);
            button2.Font = new Font("Comic Sans Ms", 18); button2.BackColor = Color.Red;

            button3.Size = new Size(200, 70); button3.Location = new Point(125, 160);
            button3.Font = new Font("Comic Sans Ms", 18); button3.BackColor = Color.Red;
            // pole
            pole = new PictureBox();
            pole.Image = new Bitmap("image/myPole.png");
            pole.Size = new Size(255, 255);
            pole.Location = new Point(165, 55);
            Controls.Add(pole);
            // PictPole1, PictPole2
            PictPole1 = new PictureBox(); PictPole1.Image = new Bitmap("image/myPole.png"); PictPole1.Size = new Size(255, 255); PictPole1.Location = new Point(17, 55); Controls.Add(PictPole1);
            PictPole2 = new PictureBox(); PictPole2.Image = new Bitmap("image/myPole.png"); PictPole2.Size = new Size(255, 255); PictPole2.Location = new Point(348, 55); Controls.Add(PictPole2);
            // labels
            label1 = new Label(); label1.Text = "4"; label1.Location = new Point(19, 60); label1.Font = new Font("Comic Sans MS", 14); Controls.Add(label1);
            label2 = new Label(); label2.Text = "3"; label2.Location = new Point(19, 100); label2.Font = new Font("Comic Sans MS", 14); Controls.Add(label2);
            label3 = new Label(); label3.Text = "2"; label3.Location = new Point(19, 140); label3.Font = new Font("Comic Sans MS", 14); Controls.Add(label3);
            label4 = new Label(); label4.Text = "1"; label4.Location = new Point(19, 180); label4.Font = new Font("Comic Sans MS", 14); Controls.Add(label4);
            labelX1 = new Label(); labelX1.Text = "x"; labelX1.Location = new Point(7, 63); labelX1.Font = new Font("Comic Sans MS", 11); Controls.Add(labelX1);
            labelX2 = new Label(); labelX2.Text = "x"; labelX2.Location = new Point(7, 103); labelX2.Font = new Font("Comic Sans MS", 11); Controls.Add(labelX2);
            labelX3 = new Label(); labelX3.Text = "x"; labelX3.Location = new Point(7, 143); labelX3.Font = new Font("Comic Sans MS", 11); Controls.Add(labelX3);
            labelX4 = new Label(); labelX4.Text = "x"; labelX4.Location = new Point(7, 183); labelX4.Font = new Font("Comic Sans MS", 11); Controls.Add(labelX4);
            // window
            ClientSize = new Size(450, 375); FormBorderStyle = FormBorderStyle.FixedSingle; Text = "Морской бой";
            BackColor = Color.Gray;
            // pictures location
            pictureBox1_1.Location = new Point(50, 60); pictureBox1_2.Location = new Point(50, 60); pictureBox1_3.Location = new Point(50, 60); pictureBox1_4.Location = new Point(50, 60); pictureBox2_1.Location = new Point(50, 100); pictureBox2_2.Location = new Point(50, 100); pictureBox2_3.Location = new Point(50, 100); pictureBox3_1.Location = new Point(50, 140); pictureBox3_2.Location = new Point(50, 140); pictureBox4_1.Location = new Point(50, 180);
            // pictures size
            pictureBox1_1.Size = new Size(24, 24); pictureBox1_2.Size = new Size(24, 24); pictureBox1_3.Size = new Size(24, 24); pictureBox1_4.Size = new Size(24, 24); pictureBox2_1.Size = new Size(47, 24); pictureBox2_2.Size = new Size(47, 24); pictureBox2_3.Size = new Size(47, 24); pictureBox3_1.Size = new Size(70, 24); pictureBox3_2.Size = new Size(70, 24); pictureBox4_1.Size = new Size(93, 24);
            // pictures image
            pictureBox1_1.Image = new Bitmap("image/pole1.png"); pictureBox1_2.Image = new Bitmap("image/pole1.png"); pictureBox1_3.Image = new Bitmap("image/pole1.png"); pictureBox1_4.Image = new Bitmap("image/pole1.png"); pictureBox2_1.Image = new Bitmap("image/pole2.png"); pictureBox2_2.Image = new Bitmap("image/pole2.png"); pictureBox2_3.Image = new Bitmap("image/pole2.png"); pictureBox3_1.Image = new Bitmap("image/pole3.png"); pictureBox3_2.Image = new Bitmap("image/pole3.png"); pictureBox4_1.Image = new Bitmap("image/pole4.png");
            // visible
            pictureBox1_1.Visible = false; pictureBox1_2.Visible = false; pictureBox1_3.Visible = false; pictureBox1_4.Visible = false; pictureBox2_1.Visible = false; pictureBox2_2.Visible = false; pictureBox2_3.Visible = false; pictureBox3_1.Visible = false; pictureBox3_2.Visible = false; pictureBox4_1.Visible = false;
            label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false;
            labelX1.Visible = false; labelX2.Visible = false; labelX3.Visible = false; labelX4.Visible = false;
            pole.Visible = false; PictPole1.Visible = false; PictPole2.Visible = false;
            button4.Visible = false; button5.Visible = false; povorot.Visible = false;
            // Действия
            pictureBox1_1.MouseDown += new MouseEventHandler(kor1_1_Down); pictureBox1_2.MouseDown += new MouseEventHandler(kor1_2_Down); pictureBox1_3.MouseDown += new MouseEventHandler(kor1_3_Down); pictureBox1_4.MouseDown += new MouseEventHandler(kor1_4_Down); pictureBox2_1.MouseDown += new MouseEventHandler(kor2_1_Down); pictureBox2_2.MouseDown += new MouseEventHandler(kor2_2_Down); pictureBox2_3.MouseDown += new MouseEventHandler(kor2_3_Down); pictureBox3_1.MouseDown += new MouseEventHandler(kor3_1_Down); pictureBox3_2.MouseDown += new MouseEventHandler(kor3_2_Down); pictureBox4_1.MouseDown += new MouseEventHandler(kor4_1_Down);
            pictureBox1_1.MouseMove += new MouseEventHandler(korMoved); pictureBox1_2.MouseMove += new MouseEventHandler(korMoved); pictureBox1_3.MouseMove += new MouseEventHandler(korMoved); pictureBox1_4.MouseMove += new MouseEventHandler(korMoved); pictureBox2_1.MouseMove += new MouseEventHandler(korMoved); pictureBox2_2.MouseMove += new MouseEventHandler(korMoved); pictureBox2_3.MouseMove += new MouseEventHandler(korMoved); pictureBox3_1.MouseMove += new MouseEventHandler(korMoved); pictureBox3_2.MouseMove += new MouseEventHandler(korMoved); pictureBox4_1.MouseMove += new MouseEventHandler(korMoved);
            pictureBox1_1.MouseUp += new MouseEventHandler(korUp); pictureBox1_2.MouseUp += new MouseEventHandler(korUp); pictureBox1_3.MouseUp += new MouseEventHandler(korUp); pictureBox1_4.MouseUp += new MouseEventHandler(korUp); pictureBox2_1.MouseUp += new MouseEventHandler(korUp); pictureBox2_2.MouseUp += new MouseEventHandler(korUp); pictureBox2_3.MouseUp += new MouseEventHandler(korUp); pictureBox3_1.MouseUp += new MouseEventHandler(korUp); pictureBox3_2.MouseUp += new MouseEventHandler(korUp); pictureBox4_1.MouseUp += new MouseEventHandler(korUp);
            button1.Click += new System.EventHandler(button1_click); button2.Click += new System.EventHandler(button2_click); button3.Click += new System.EventHandler(button3_click); button4.Click += new System.EventHandler(button4_click); button5.Click += new System.EventHandler(button5_click);
            // pictOne, pictTwo
            pictOne = new PictureBox[10, 10]; pictTwo = new PictureBox[10, 10];
            int a1 = 38, a2 = 369, b = 75;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    pictone = new PictureBox(); pictone.Size = new Size(24, 24); pictone.Image = (Image) nothing; pictone.Location = new Point(a1, b);
                    pictOne[i, j] = pictone; Controls.Add(pictOne[i, j]); pictOne[i, j].Visible = false; pictOne[i, j].MouseClick += new MouseEventHandler(pictOne_click);
                    picttwo = new PictureBox(); picttwo.Size = new Size(24, 24); picttwo.Image = (Image)nothing; picttwo.Location = new Point(a2, b);
                    pictTwo[i, j] = picttwo; Controls.Add(pictTwo[i, j]); pictTwo[i, j].Visible = false; pictTwo[i, j].MouseClick += new MouseEventHandler(pictTwo_click);
                    a1 += 23; a2 += 23;
                }
                a1 = 38; a2 = 369; b += 23;
            }
            // pole1, pole2
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    pole1[i, j] = 0;
                    pole2[i, j] = 0;
                }
            }
        }

            // Начать игру
        public void button1_click(object sender, EventArgs e)
        {
            poleNomer = 1;
            pictureBox1_1.Visible = true; pictureBox1_2.Visible = true;
            pictureBox1_3.Visible = true; pictureBox1_4.Visible = true;
            pictureBox2_1.Visible = true; pictureBox2_2.Visible = true;
            pictureBox2_3.Visible = true; pictureBox3_1.Visible = true;
            pictureBox3_2.Visible = true; pictureBox4_1.Visible = true;
            label1.Visible = true; label2.Visible = true; label3.Visible = true; label4.Visible = true;
            labelX1.Visible = true; labelX2.Visible = true; labelX3.Visible = true; labelX4.Visible = true;
            pole.Visible = true;
            button1.Visible = false; button2.Visible = false; button3.Visible = false;
            button4.Visible = true; povorot.Visible = true;
        }
            // Выход
        public void button2_click(object sender, EventArgs e)
        {
            Dispose();
        }
            // Правила игры
        public void button3_click(object sender, EventArgs e)
        {
            
        }
            // Далее
        public void button4_click(object sender, EventArgs e)
        {
            if (pictureBox1_1.Location != new Point(50, 60) && pictureBox1_2.Location != new Point(50, 60) && pictureBox1_3.Location != new Point(50, 60) && pictureBox1_4.Location != new Point(50, 60) && pictureBox2_1.Location != new Point(50, 100) && pictureBox2_2.Location != new Point(50, 100) && pictureBox2_3.Location != new Point(50, 100) && pictureBox3_1.Location != new Point(50, 140) && pictureBox3_2.Location != new Point(50, 140) && pictureBox4_1.Location != new Point(50, 180))
            {
                poleNomer = 2;
                button3.Visible = false; button4.Visible = false;
                button5.Visible = true;
                pictureBox1_1.Location = new Point(50, 60); pictureBox1_2.Location = new Point(50, 60);
                pictureBox1_3.Location = new Point(50, 60); pictureBox1_4.Location = new Point(50, 60);
                pictureBox2_1.Location = new Point(50, 100); pictureBox2_2.Location = new Point(50, 100);
                pictureBox2_3.Location = new Point(50, 100); pictureBox3_1.Location = new Point(50, 140);
                pictureBox3_2.Location = new Point(50, 140); pictureBox4_1.Location = new Point(50, 180);
                label1.Text = "4"; label2.Text = "3"; label3.Text = "2"; label4.Text = "1";
            }
            else
            {
                MessageBox.Show("Розставте все корабли!", "Ошибка", MessageBoxButtons.OK);
            }
        }
            // Играть
        public void button5_click(object sender, EventArgs e)
        {
            if (pictureBox1_1.Location != new Point(50, 60) && pictureBox1_2.Location != new Point(50, 60) && pictureBox1_3.Location != new Point(50, 60) && pictureBox1_4.Location != new Point(50, 60) && pictureBox2_1.Location != new Point(50, 100) && pictureBox2_2.Location != new Point(50, 100) && pictureBox2_3.Location != new Point(50, 100) && pictureBox3_1.Location != new Point(50, 140) && pictureBox3_2.Location != new Point(50, 140) && pictureBox4_1.Location != new Point(50, 180))
            {
                pictureBox1_1.Visible = false; pictureBox1_2.Visible = false; pictureBox1_3.Visible = false; pictureBox1_4.Visible = false; pictureBox2_1.Visible = false; pictureBox2_2.Visible = false; pictureBox2_3.Visible = false; pictureBox3_1.Visible = false; pictureBox3_2.Visible = false; pictureBox4_1.Visible = false;
                pole.Visible = false; PictPole1.Visible = true; PictPole2.Visible = true;
                label1.Visible = false; label2.Visible = false; label3.Visible = false; label4.Visible = false;
                labelX1.Visible = false; labelX2.Visible = false; labelX3.Visible = false; labelX4.Visible = false;
                povorot.Visible = false; button5.Visible = false;
                ClientSize = new Size(620, 375);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        pictOne[i, j].Visible = true; pictOne[i, j].BringToFront();
                        pictTwo[i, j].Visible = true; pictTwo[i, j].BringToFront();
                    }
                }
            }
            else
            {
                MessageBox.Show("Розставте все корабли!", "Ошибка", MessageBoxButtons.OK);
            }
        }
            // Поворот корабля
        public void povorot_click(object sender, EventArgs e)
        {
            switch (Number)
            {
                case 2:
                    if (flag2_1 == true && pictureBox2_1.Top != 100 && pictureBox2_1.Left != 50)
                    {
                        
                    }
                    else if (flag2_2 == true && pictureBox2_2.Top != 100 && pictureBox2_2.Left != 50)
                    {

                    }
                    else if (flag2_3 == true && pictureBox2_3.Top != 100 && pictureBox2_3.Left != 50)
                    {

                    }
                    break;
                case 3:
                    if (flag3_1 == true)
                    {

                    }
                    else if (flag3_2 == true)
                    {

                    }
                    break;
                case 4:
                    if (flag4_1 == true)
                    {

                    }
                    break;
            }
        }

        // picturesDown
        public void kor1_1_Down(object sender, MouseEventArgs e)
        {
            korNomer = "kor1_1"; Number = 1; k = 24;
            koordX = pictureBox1_1.Left; koordY = pictureBox1_1.Top;
            x = e.X; y = e.Y;
            pictureBox1_1.BringToFront();
            if (pictureBox1_1.Top == 60 && pictureBox1_1.Left == 50)
            {
                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
            }
            Koordinaty();
        }
        public void kor1_2_Down(object sender, MouseEventArgs e)
        {
            korNomer = "kor1_2"; Number = 1; k = 24;
            koordX = pictureBox1_2.Left; koordY = pictureBox1_2.Top;
            x = e.X; y = e.Y;
            pictureBox1_2.BringToFront();
            if (pictureBox1_2.Top == 60 && pictureBox1_2.Left == 50)
            {
                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
            }
            Koordinaty();
        }
        public void kor1_3_Down(object sender, MouseEventArgs e)
        {
            korNomer = "kor1_3"; Number = 1; k = 24;
            koordX = pictureBox1_3.Left; koordY = pictureBox1_3.Top;
            x = e.X; y = e.Y;
            pictureBox1_3.BringToFront();
            if (pictureBox1_3.Top == 60 && pictureBox1_3.Left == 50)
            {
                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
            }
            Koordinaty();
        }
        public void kor1_4_Down(object sender, MouseEventArgs e)
        {
            korNomer = "kor1_4"; Number = 1; k = 24;
            koordX = pictureBox1_4.Left; koordY = pictureBox1_4.Top;
            x = e.X; y = e.Y;
            pictureBox1_4.BringToFront();
            if (pictureBox1_4.Top == 60 && pictureBox1_4.Left == 50)
            {
                label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) - 1);
            }
            Koordinaty();
        }
        public void kor2_1_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = true; flag2_2 = false; flag2_3 = false; flag3_1 = false; flag3_2 = false; flag4_1 = false;
            korNomer = "kor2_1"; Number = 2; k = 47;
            koordX = pictureBox2_1.Left; koordY = pictureBox2_1.Top;
            x = e.X; y = e.Y;
            pictureBox2_1.BringToFront();
            if (pictureBox2_1.Top == 100 && pictureBox2_1.Left == 50)
            {
                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
            }
            Koordinaty();
        }
        public void kor2_2_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = false; flag2_2 = true; flag2_3 = false; flag3_1 = false; flag3_2 = false; flag4_1 = false;
            korNomer = "kor2_2"; Number = 2; k = 47;
            koordX = pictureBox2_2.Left; koordY = pictureBox2_2.Top;
            x = e.X; y = e.Y;
            pictureBox2_2.BringToFront();
            if (pictureBox2_2.Top == 100 && pictureBox2_2.Left == 50)
            {
                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
            }
            Koordinaty();
        }
        public void kor2_3_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = false; flag2_2 = false; flag2_3 = true; flag3_1 = false; flag3_2 = false; flag4_1 = false;
            korNomer = "kor2_3"; Number = 2; k = 47;
            koordX = pictureBox2_3.Left; koordY = pictureBox2_3.Top;
            x = e.X; y = e.Y;
            pictureBox2_3.BringToFront();
            if (pictureBox2_3.Top == 100 && pictureBox2_3.Left == 50)
            {
                label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) - 1);
            }
            Koordinaty();
        }
        public void kor3_1_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = false; flag2_2 = false; flag2_3 = false; flag3_1 = true; flag3_2 = false; flag4_1 = false;
            korNomer = "kor3_1"; Number = 3; k = 70;
            koordX = pictureBox3_1.Left; koordY = pictureBox3_1.Top;
            x = e.X; y = e.Y;
            pictureBox3_1.BringToFront();
            if (pictureBox3_1.Top == 140 && pictureBox3_1.Left == 50)
            {
                label3.Text = Convert.ToString(Convert.ToInt32(label3.Text) - 1);
            }
            Koordinaty();
        }
        public void kor3_2_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = false; flag2_2 = false; flag2_3 = false; flag3_1 = false; flag3_2 = true; flag4_1 = false;
            korNomer = "kor3_2"; Number = 3; k = 70;
            koordX = pictureBox3_2.Left; koordY = pictureBox3_2.Top;
            x = e.X; y = e.Y;
            pictureBox3_2.BringToFront();
            if (pictureBox3_2.Top == 140 && pictureBox3_2.Left == 50)
            {
                label3.Text = Convert.ToString(Convert.ToInt32(label3.Text) - 1);
            }
            Koordinaty();
        }
        public void kor4_1_Down(object sender, MouseEventArgs e)
        {
            flag2_1 = false; flag2_2 = false; flag2_3 = false; flag3_1 = false; flag3_2 = false; flag4_1 = true;
            korNomer = "kor4_1"; Number = 4; k = 93;
            koordX = pictureBox4_1.Left; koordY = pictureBox4_1.Top;
            x = e.X; y = e.Y;
            pictureBox4_1.BringToFront();
            if (pictureBox4_1.Top == 180 && pictureBox4_1.Left == 50)
            {
                label4.Text = Convert.ToString(Convert.ToInt32(label4.Text) - 1);
            }
            Koordinaty();
        }

        public void pictOne_click(object sender, MouseEventArgs e)
        {
            if (poleActive == 2)
            {
                MousePoint = PointToClient(Cursor.Position); pict1X = MousePoint.X; pict1Y = MousePoint.Y;
                flagKor = true;
                if (pict1X >= 38 && pict1X <= 60)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 0].Image == (Image)nothing)
                    { pictOne_dopov(0, 0); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 0].Image == (Image)nothing)
                    { pictOne_dopov(1, 0); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 0].Image == (Image)nothing)
                    { pictOne_dopov(2, 0); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 0].Image == (Image)nothing)
                    { pictOne_dopov(3, 0); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 0].Image == (Image)nothing)
                    { pictOne_dopov(4, 0); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 0].Image == (Image)nothing)
                    { pictOne_dopov(5, 0); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 0].Image == (Image)nothing)
                    { pictOne_dopov(6, 0); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 0].Image == (Image)nothing)
                    { pictOne_dopov(7, 0); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 0].Image == (Image)nothing)
                    { pictOne_dopov(8, 0); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 0].Image == (Image)nothing)
                    { pictOne_dopov(9, 0); }
                }
                else if (pict1X >= 61 && pict1X <= 83)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 1].Image == (Image)nothing)
                    { pictOne_dopov(0, 1); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 1].Image == (Image)nothing)
                    { pictOne_dopov(1, 1); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 1].Image == (Image)nothing)
                    { pictOne_dopov(2, 1); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 1].Image == (Image)nothing)
                    { pictOne_dopov(3, 1); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 1].Image == (Image)nothing)
                    { pictOne_dopov(4, 1); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 1].Image == (Image)nothing)
                    { pictOne_dopov(5, 1); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 1].Image == (Image)nothing)
                    { pictOne_dopov(6, 1); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 1].Image == (Image)nothing)
                    { pictOne_dopov(7, 1); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 1].Image == (Image)nothing)
                    { pictOne_dopov(8, 1); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 1].Image == (Image)nothing)
                    { pictOne_dopov(9, 1); }
                }
                else if (pict1X >= 84 && pict1X <= 106)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 2].Image == (Image)nothing)
                    { pictOne_dopov(0, 2); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 2].Image == (Image)nothing)
                    { pictOne_dopov(1, 2); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 2].Image == (Image)nothing)
                    { pictOne_dopov(2, 2); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 2].Image == (Image)nothing)
                    { pictOne_dopov(3, 2); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 2].Image == (Image)nothing)
                    { pictOne_dopov(4, 2); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 2].Image == (Image)nothing)
                    { pictOne_dopov(5, 2); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 2].Image == (Image)nothing)
                    { pictOne_dopov(6, 2); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 2].Image == (Image)nothing)
                    { pictOne_dopov(7, 2); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 2].Image == (Image)nothing)
                    { pictOne_dopov(8, 2); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 2].Image == (Image)nothing)
                    { pictOne_dopov(9, 2); }
                }
                else if (pict1X >= 107 && pict1X <= 129)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 3].Image == (Image)nothing)
                    { pictOne_dopov(0, 3); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 3].Image == (Image)nothing)
                    { pictOne_dopov(1, 3); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 3].Image == (Image)nothing)
                    { pictOne_dopov(2, 3); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 3].Image == (Image)nothing)
                    { pictOne_dopov(3, 3); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 3].Image == (Image)nothing)
                    { pictOne_dopov(4, 3); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 3].Image == (Image)nothing)
                    { pictOne_dopov(5, 3); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 3].Image == (Image)nothing)
                    { pictOne_dopov(6, 3); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 3].Image == (Image)nothing)
                    { pictOne_dopov(7, 3); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 3].Image == (Image)nothing)
                    { pictOne_dopov(8, 3); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 3].Image == (Image)nothing)
                    { pictOne_dopov(9, 3); }
                }
                else if (pict1X >= 130 && pict1X <= 152)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 4].Image == (Image)nothing)
                    { pictOne_dopov(0, 4); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 4].Image == (Image)nothing)
                    { pictOne_dopov(1, 4); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 4].Image == (Image)nothing)
                    { pictOne_dopov(2, 4); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 4].Image == (Image)nothing)
                    { pictOne_dopov(3, 4); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 4].Image == (Image)nothing)
                    { pictOne_dopov(4, 4); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 4].Image == (Image)nothing)
                    { pictOne_dopov(5, 4); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 4].Image == (Image)nothing)
                    { pictOne_dopov(6, 4); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 4].Image == (Image)nothing)
                    { pictOne_dopov(7, 4); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 4].Image == (Image)nothing)
                    { pictOne_dopov(8, 4); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 4].Image == (Image)nothing)
                    { pictOne_dopov(9, 4); }
                }
                else if (pict1X >= 153 && pict1X <= 175)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 5].Image == (Image)nothing)
                    { pictOne_dopov(0, 5); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 5].Image == (Image)nothing)
                    { pictOne_dopov(1, 5); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 5].Image == (Image)nothing)
                    { pictOne_dopov(2, 5); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 5].Image == (Image)nothing)
                    { pictOne_dopov(3, 5); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 5].Image == (Image)nothing)
                    { pictOne_dopov(4, 5); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 5].Image == (Image)nothing)
                    { pictOne_dopov(5, 5); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 5].Image == (Image)nothing)
                    { pictOne_dopov(6, 5); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 5].Image == (Image)nothing)
                    { pictOne_dopov(7, 5); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 5].Image == (Image)nothing)
                    { pictOne_dopov(8, 5); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 5].Image == (Image)nothing)
                    { pictOne_dopov(9, 5); }
                }
                else if (pict1X >= 176 && pict1X <= 198)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 6].Image == (Image)nothing)
                    { pictOne_dopov(0, 6); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 6].Image == (Image)nothing)
                    { pictOne_dopov(1, 6); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 6].Image == (Image)nothing)
                    { pictOne_dopov(2, 6); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 6].Image == (Image)nothing)
                    { pictOne_dopov(3, 6); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 6].Image == (Image)nothing)
                    { pictOne_dopov(4, 6); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 6].Image == (Image)nothing)
                    { pictOne_dopov(5, 6); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 6].Image == (Image)nothing)
                    { pictOne_dopov(6, 6); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 6].Image == (Image)nothing)
                    { pictOne_dopov(7, 6); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 6].Image == (Image)nothing)
                    { pictOne_dopov(8, 6); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 6].Image == (Image)nothing)
                    { pictOne_dopov(9, 6); }
                }
                else if (pict1X >= 199 && pict1X <= 221)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 7].Image == (Image)nothing)
                    { pictOne_dopov(0, 7); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 7].Image == (Image)nothing)
                    { pictOne_dopov(1, 7); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 7].Image == (Image)nothing)
                    { pictOne_dopov(2, 7); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 7].Image == (Image)nothing)
                    { pictOne_dopov(3, 7); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 7].Image == (Image)nothing)
                    { pictOne_dopov(4, 7); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 7].Image == (Image)nothing)
                    { pictOne_dopov(5, 7); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 7].Image == (Image)nothing)
                    { pictOne_dopov(6, 7); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 7].Image == (Image)nothing)
                    { pictOne_dopov(7, 7); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 7].Image == (Image)nothing)
                    { pictOne_dopov(8, 7); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 7].Image == (Image)nothing)
                    { pictOne_dopov(9, 7); }
                }
                else if (pict1X >= 222 && pict1X <= 244)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 8].Image == (Image)nothing)
                    { pictOne_dopov(0, 8); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 8].Image == (Image)nothing)
                    { pictOne_dopov(1, 8); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 8].Image == (Image)nothing)
                    { pictOne_dopov(2, 8); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 8].Image == (Image)nothing)
                    { pictOne_dopov(3, 8); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 8].Image == (Image)nothing)
                    { pictOne_dopov(4, 8); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 8].Image == (Image)nothing)
                    { pictOne_dopov(5, 8); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 8].Image == (Image)nothing)
                    { pictOne_dopov(6, 8); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 8].Image == (Image)nothing)
                    { pictOne_dopov(7, 8); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 8].Image == (Image)nothing)
                    { pictOne_dopov(8, 8); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 8].Image == (Image)nothing)
                    { pictOne_dopov(9, 8); }
                }
                else if (pict1X >= 245 && pict1X <= 267)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictOne[0, 9].Image == (Image)nothing)
                    { pictOne_dopov(0, 9); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictOne[1, 9].Image == (Image)nothing)
                    { pictOne_dopov(1, 9); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictOne[2, 9].Image == (Image)nothing)
                    { pictOne_dopov(2, 9); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictOne[3, 9].Image == (Image)nothing)
                    { pictOne_dopov(3, 9); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictOne[4, 9].Image == (Image)nothing)
                    { pictOne_dopov(4, 9); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictOne[5, 9].Image == (Image)nothing)
                    { pictOne_dopov(5, 9); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictOne[6, 9].Image == (Image)nothing)
                    { pictOne_dopov(6, 9); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictOne[7, 9].Image == (Image)nothing)
                    { pictOne_dopov(7, 9); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictOne[8, 9].Image == (Image)nothing)
                    { pictOne_dopov(8, 9); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictOne[9, 9].Image == (Image)nothing)
                    { pictOne_dopov(9, 9); }
                }
            }
        }

        public void pictTwo_click(object sender, MouseEventArgs e)
        {
            if (poleActive == 1)
            {
                MousePoint = PointToClient(Cursor.Position); pict1X = MousePoint.X; pict1Y = MousePoint.Y;
                flagKor = true;
                if (pict1X >= 369 && pict1X <= 391)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 0].Image == (Image)nothing)
                    { pictTwo_dopov(0, 0); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 0].Image == (Image)nothing)
                    { pictTwo_dopov(1, 0); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 0].Image == (Image)nothing)
                    { pictTwo_dopov(2, 0); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 0].Image == (Image)nothing)
                    { pictTwo_dopov(3, 0); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 0].Image == (Image)nothing)
                    { pictTwo_dopov(4, 0); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 0].Image == (Image)nothing)
                    { pictTwo_dopov(5, 0); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 0].Image == (Image)nothing)
                    { pictTwo_dopov(6, 0); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 0].Image == (Image)nothing)
                    { pictTwo_dopov(7, 0); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 0].Image == (Image)nothing)
                    { pictTwo_dopov(8, 0); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 0].Image == (Image)nothing)
                    { pictTwo_dopov(9, 0); }
                }
                else if (pict1X >= 392 && pict1X <= 414)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 1].Image == (Image)nothing)
                    { pictTwo_dopov(0, 1); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 1].Image == (Image)nothing)
                    { pictTwo_dopov(1, 1); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 1].Image == (Image)nothing)
                    { pictTwo_dopov(2, 1); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 1].Image == (Image)nothing)
                    { pictTwo_dopov(3, 1); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 1].Image == (Image)nothing)
                    { pictTwo_dopov(4, 1); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 1].Image == (Image)nothing)
                    { pictTwo_dopov(5, 1); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 1].Image == (Image)nothing)
                    { pictTwo_dopov(6, 1); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 1].Image == (Image)nothing)
                    { pictTwo_dopov(7, 1); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 1].Image == (Image)nothing)
                    { pictTwo_dopov(8, 1); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 1].Image == (Image)nothing)
                    { pictTwo_dopov(9, 1); }
                }
                else if (pict1X >= 415 && pict1X <= 437)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 2].Image == (Image)nothing)
                    { pictTwo_dopov(0, 2); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 2].Image == (Image)nothing)
                    { pictTwo_dopov(1, 2); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 2].Image == (Image)nothing)
                    { pictTwo_dopov(2, 2); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 2].Image == (Image)nothing)
                    { pictTwo_dopov(3, 2); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 2].Image == (Image)nothing)
                    { pictTwo_dopov(4, 2); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 2].Image == (Image)nothing)
                    { pictTwo_dopov(5, 2); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 2].Image == (Image)nothing)
                    { pictTwo_dopov(6, 2); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 2].Image == (Image)nothing)
                    { pictTwo_dopov(7, 2); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 2].Image == (Image)nothing)
                    { pictTwo_dopov(8, 2); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 2].Image == (Image)nothing)
                    { pictTwo_dopov(9, 2); }
                }
                else if (pict1X >= 438 && pict1X <= 460)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 3].Image == (Image)nothing)
                    { pictTwo_dopov(0, 3); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 3].Image == (Image)nothing)
                    { pictTwo_dopov(1, 3); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 3].Image == (Image)nothing)
                    { pictTwo_dopov(2, 3); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 3].Image == (Image)nothing)
                    { pictTwo_dopov(3, 3); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 3].Image == (Image)nothing)
                    { pictTwo_dopov(4, 3); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 3].Image == (Image)nothing)
                    { pictTwo_dopov(5, 3); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 3].Image == (Image)nothing)
                    { pictTwo_dopov(6, 3); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 3].Image == (Image)nothing)
                    { pictTwo_dopov(7, 3); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 3].Image == (Image)nothing)
                    { pictTwo_dopov(8, 3); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 3].Image == (Image)nothing)
                    { pictTwo_dopov(9, 3); }
                }
                else if (pict1X >= 461 && pict1X <= 483)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 4].Image == (Image)nothing)
                    { pictTwo_dopov(0, 4); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 4].Image == (Image)nothing)
                    { pictTwo_dopov(1, 4); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 4].Image == (Image)nothing)
                    { pictTwo_dopov(2, 4); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 4].Image == (Image)nothing)
                    { pictTwo_dopov(3, 4); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 4].Image == (Image)nothing)
                    { pictTwo_dopov(4, 4); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 4].Image == (Image)nothing)
                    { pictTwo_dopov(5, 4); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 4].Image == (Image)nothing)
                    { pictTwo_dopov(6, 4); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 4].Image == (Image)nothing)
                    { pictTwo_dopov(7, 4); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 4].Image == (Image)nothing)
                    { pictTwo_dopov(8, 4); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 4].Image == (Image)nothing)
                    { pictTwo_dopov(9, 4); }
                }
                else if (pict1X >= 484 && pict1X <= 506)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 5].Image == (Image)nothing)
                    { pictTwo_dopov(0, 5); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 5].Image == (Image)nothing)
                    { pictTwo_dopov(1, 5); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 5].Image == (Image)nothing)
                    { pictTwo_dopov(2, 5); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 5].Image == (Image)nothing)
                    { pictTwo_dopov(3, 5); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 5].Image == (Image)nothing)
                    { pictTwo_dopov(4, 5); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 5].Image == (Image)nothing)
                    { pictTwo_dopov(5, 5); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 5].Image == (Image)nothing)
                    { pictTwo_dopov(6, 5); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 5].Image == (Image)nothing)
                    { pictTwo_dopov(7, 5); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 5].Image == (Image)nothing)
                    { pictTwo_dopov(8, 5); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 5].Image == (Image)nothing)
                    { pictTwo_dopov(9, 5); }
                }
                else if (pict1X >= 507 && pict1X <= 529)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 6].Image == (Image)nothing)
                    { pictTwo_dopov(0, 6); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 6].Image == (Image)nothing)
                    { pictTwo_dopov(1, 6); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 6].Image == (Image)nothing)
                    { pictTwo_dopov(2, 6); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 6].Image == (Image)nothing)
                    { pictTwo_dopov(3, 6); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 6].Image == (Image)nothing)
                    { pictTwo_dopov(4, 6); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 6].Image == (Image)nothing)
                    { pictTwo_dopov(5, 6); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 6].Image == (Image)nothing)
                    { pictTwo_dopov(6, 6); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 6].Image == (Image)nothing)
                    { pictTwo_dopov(7, 6); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 6].Image == (Image)nothing)
                    { pictTwo_dopov(8, 6); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 6].Image == (Image)nothing)
                    { pictTwo_dopov(9, 6); }
                }
                else if (pict1X >= 530 && pict1X <= 552)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 7].Image == (Image)nothing)
                    { pictTwo_dopov(0, 7); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 7].Image == (Image)nothing)
                    { pictTwo_dopov(1, 7); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 7].Image == (Image)nothing)
                    { pictTwo_dopov(2, 7); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 7].Image == (Image)nothing)
                    { pictTwo_dopov(3, 7); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 7].Image == (Image)nothing)
                    { pictTwo_dopov(4, 7); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 7].Image == (Image)nothing)
                    { pictTwo_dopov(5, 7); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 7].Image == (Image)nothing)
                    { pictTwo_dopov(6, 7); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 7].Image == (Image)nothing)
                    { pictTwo_dopov(7, 7); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 7].Image == (Image)nothing)
                    { pictTwo_dopov(8, 7); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 7].Image == (Image)nothing)
                    { pictTwo_dopov(9, 7); }
                }
                else if (pict1X >= 553 && pict1X <= 575)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 8].Image == (Image)nothing)
                    { pictTwo_dopov(0, 8); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 8].Image == (Image)nothing)
                    { pictTwo_dopov(1, 8); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 8].Image == (Image)nothing)
                    { pictTwo_dopov(2, 8); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 8].Image == (Image)nothing)
                    { pictTwo_dopov(3, 8); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 8].Image == (Image)nothing)
                    { pictTwo_dopov(4, 8); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 8].Image == (Image)nothing)
                    { pictTwo_dopov(5, 8); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 8].Image == (Image)nothing)
                    { pictTwo_dopov(6, 8); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 8].Image == (Image)nothing)
                    { pictTwo_dopov(7, 8); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 8].Image == (Image)nothing)
                    { pictTwo_dopov(8, 8); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 8].Image == (Image)nothing)
                    { pictTwo_dopov(9, 8); }
                }
                else if (pict1X >= 576 && pict1X <= 599)
                {
                    if (pict1Y >= 75 && pict1Y <= 97 && pictTwo[0, 9].Image == (Image)nothing)
                    { pictTwo_dopov(0, 9); }
                    else if (pict1Y >= 98 && pict1Y <= 120 && pictTwo[1, 9].Image == (Image)nothing)
                    { pictTwo_dopov(1, 9); }
                    else if (pict1Y >= 121 && pict1Y <= 143 && pictTwo[2, 9].Image == (Image)nothing)
                    { pictTwo_dopov(2, 9); }
                    else if (pict1Y >= 144 && pict1Y <= 166 && pictTwo[3, 9].Image == (Image)nothing)
                    { pictTwo_dopov(3, 9); }
                    else if (pict1Y >= 167 && pict1Y <= 189 && pictTwo[4, 9].Image == (Image)nothing)
                    { pictTwo_dopov(4, 9); }
                    else if (pict1Y >= 190 && pict1Y <= 212 && pictTwo[5, 9].Image == (Image)nothing)
                    { pictTwo_dopov(5, 9); }
                    else if (pict1Y >= 213 && pict1Y <= 235 && pictTwo[6, 9].Image == (Image)nothing)
                    { pictTwo_dopov(6, 9); }
                    else if (pict1Y >= 236 && pict1Y <= 258 && pictTwo[7, 9].Image == (Image)nothing)
                    { pictTwo_dopov(7, 9); }
                    else if (pict1Y >= 259 && pict1Y <= 281 && pictTwo[8, 9].Image == (Image)nothing)
                    { pictTwo_dopov(8, 9); }
                    else if (pict1Y >= 282 && pict1Y <= 305 && pictTwo[9, 9].Image == (Image)nothing)
                    { pictTwo_dopov(9, 9); }
                }
            }
        }

        public void pictOne_dopov(int i, int j)
        {
            if (pole1[i, j] == 0 || pole1[i, j] == 1)
            {
                pictOne[i, j].Image = (Image)tochka;
                poleActive = 1;
            }
            else if (pole1[i, j] == 2)
            {
                pictOne[i, j].Image = (Image)krestik;
                poleActive = 2;
                pole1[i, j] = 3;
                PictOneProverka(i, j, "vse");
                if (flagKor == true)
                {
                    killOneKores(i, j, "vse");
                    killOne += 1;
                    if (killOne == 10)
                    {
                        MessageBox.Show("Игрок 2 победил!", "Ура! Победа!", MessageBoxButtons.OK);
                        poleActive = 0;
                    }
                }
            }
        }

        public void pictTwo_dopov(int i, int j)
        {
            if (pole2[i, j] == 0 || pole2[i, j] == 1)
            { pictTwo[i, j].Image = (Image)tochka; poleActive = 2; }
            else if (pole2[i, j] == 2)
            {
                pictTwo[i, j].Image = (Image)krestik; poleActive = 1; pole2[i, j] = 3; PictTwoProverka(i, j, "vse");
                if (flagKor == true)
                {
                    killTwoKores(i, j, "vse");
                    killTwo += 1;
                    if (killTwo == 10)
                    {
                        MessageBox.Show("Игрок 1 победил!", "Ура! Победа!", MessageBoxButtons.OK);
                        poleActive = 0;
                    }
                }
            }
        }

        public void PictOneProverka(int a, int b, string naprav)
        {
            switch (naprav)
            {
                case "vse":
                    if (a - 1 >= 0)
                    {
                        if (pole1[a - 1, b] == 3)
                        {
                            PictOneProverka(a - 1, b, "up");
                        }
                        else if (pole1[a - 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (a + 1 <= 9)
                    {
                        if (pole1[a + 1, b] == 3)
                        {
                            PictOneProverka(a + 1, b, "down");
                        }
                        else if (pole1[a + 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (b - 1 >= 0)
                    {
                        if (pole1[a, b - 1] == 3)
                        {
                            PictOneProverka(a, b - 1, "left");
                        }
                        else if (pole1[a, b - 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (b + 1 <= 9)
                    {
                        if (pole1[a, b + 1] == 3)
                        {
                            PictOneProverka(a, b + 1, "right");
                        }
                        else if (pole1[a, b + 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "left":
                    if (b - 1 >= 0)
                    {
                        if (pole1[a, b - 1] == 3)
                        {
                            PictOneProverka(a, b - 1, "left");
                        }
                        else if (pole1[a, b - 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "right":
                    if (b + 1 <= 9)
                    {
                        if (pole1[a, b + 1] == 3)
                        {
                            PictOneProverka(a, b + 1, "right");
                        }
                        else if (pole1[a, b + 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "up":
                    if (a - 1 >= 0)
                    {
                        if (pole1[a - 1, b] == 3)
                        {
                            PictOneProverka(a - 1, b, "up");
                        }
                        else if (pole1[a - 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "down":
                    if (a + 1 <= 9)
                    {
                        if (pole1[a + 1, b] == 3)
                        {
                            PictOneProverka(a + 1, b, "down");
                        }
                        else if (pole1[a + 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
            }
        }

        public void PictTwoProverka(int a, int b, string naprav)
        {
            switch (naprav)
            {
                case "vse":
                    if (a - 1 >= 0)
                    {
                        if (pole2[a - 1, b] == 3)
                        {
                            PictTwoProverka(a - 1, b, "up");
                        }
                        else if (pole2[a - 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (a + 1 <= 9)
                    {
                        if (pole2[a + 1, b] == 3)
                        {
                            PictTwoProverka(a + 1, b, "down");
                        }
                        else if (pole2[a + 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (b - 1 >= 0)
                    {
                        if (pole2[a, b - 1] == 3)
                        {
                            PictTwoProverka(a, b - 1, "left");
                        }
                        else if (pole2[a, b - 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    if (b + 1 <= 9)
                    {
                        if (pole2[a, b + 1] == 3)
                        {
                            PictTwoProverka(a, b + 1, "right");
                        }
                        else if (pole2[a, b + 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "left":
                    if (b - 1 >= 0)
                    {
                        if (pole2[a, b - 1] == 3)
                        {
                            PictTwoProverka(a, b - 1, "left");
                        }
                        else if (pole2[a, b - 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "right":
                    if (b + 1 <= 9)
                    {
                        if (pole2[a, b + 1] == 3)
                        {
                            PictTwoProverka(a, b + 1, "right");
                        }
                        else if (pole2[a, b + 1] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "up":
                    if (a - 1 >= 0)
                    {
                        if (pole2[a - 1, b] == 3)
                        {
                            PictTwoProverka(a - 1, b, "up");
                        }
                        else if (pole2[a - 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
                case "down":
                    if (a + 1 <= 9)
                    {
                        if (pole2[a + 1, b] == 3)
                        {
                            PictTwoProverka(a + 1, b, "down");
                        }
                        else if (pole2[a + 1, b] == 2)
                        {
                            flagKor = false;
                        }
                    }
                    break;
            }
        }

        public void killOneKores(int a, int b, string naprav)
        {
            switch (naprav)
            {
                case "vse":
                    if (a - 1 >= 0)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a - 1, b] == 3)
                        {
                            killOneKores(a - 1, b, "up");
                        }
                    }
                    if (a + 1 <= 9)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a + 1, b] == 3)
                        {
                            killOneKores(a + 1, b, "down");
                        }
                    }
                    if (b - 1 >= 0)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a, b - 1] == 3)
                        {
                            killOneKores(a, b - 1, "left");
                        }
                    }
                    if (b + 1 <= 9)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a, b + 1] == 3)
                        {
                            killOneKores(a, b + 1, "right");
                        }
                    }
                    break;
                case "left":
                    if (b - 1 >= 0)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a, b - 1] == 3)
                        {
                            killOneKores(a, b - 1, "left");
                        }
                    }
                    break;
                case "right":
                    if (b + 1 <= 9)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a, b + 1] == 3)
                        {
                            killOneKores(a, b + 1, "right");
                        }
                    }
                    break;
                case "up":
                    if (a - 1 >= 0)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a - 1, b] == 3)
                        {
                            killOneKores(a - 1, b, "up");
                        }
                    }
                    break;
                case "down":
                    if (a + 1 <= 9)
                    {
                        zakraskaOne(a, b);
                        if (pole1[a + 1, b] == 3)
                        {
                            killOneKores(a + 1, b, "down");
                        }
                    }
                    break;
            }
        }

        public void killTwoKores(int a, int b, string naprav)
        {
            switch (naprav)
            {
                case "vse":
                    if (a - 1 >= 0)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a - 1, b] == 3)
                        {
                            killTwoKores(a - 1, b, "up");
                        }
                    }
                    if (a + 1 <= 9)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a + 1, b] == 3)
                        {
                            killTwoKores(a + 1, b, "down");
                        }
                    }
                    if (b - 1 >= 0)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a, b - 1] == 3)
                        {
                            killTwoKores(a, b - 1, "left");
                        }
                    }
                    if (b + 1 <= 9)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a, b + 1] == 3)
                        {
                            killTwoKores(a, b + 1, "right");
                        }
                    }
                    break;
                case "left":
                    if (b - 1 >= 0)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a, b - 1] == 3)
                        {
                            killTwoKores(a, b - 1, "left");
                        }
                    }
                    break;
                case "right":
                    if (b + 1 <= 9)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a, b + 1] == 3)
                        {
                            killTwoKores(a, b + 1, "right");
                        }
                    }
                    break;
                case "up":
                    if (a - 1 >= 0)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a - 1, b] == 3)
                        {
                            killTwoKores(a - 1, b, "up");
                        }
                    }
                    break;
                case "down":
                    if (a + 1 <= 9)
                    {
                        zakraskaTwo(a, b);
                        if (pole2[a + 1, b] == 3)
                        {
                            killTwoKores(a + 1, b, "down");
                        }
                    }
                    break;
            }
        }

        public void zakraskaOne(int a, int b)
        {
            if (b - 1 >= 0)
            {
                if (a - 1 >= 0) if (pole1[a - 1, b - 1] == 1) { { pictOne[a - 1, b - 1].Image = (Image)tochka; } }
                if (a + 1 <= 9) if (pole1[a + 1, b - 1] == 1) { { pictOne[a + 1, b - 1].Image = (Image)tochka; } }
                if (pole1[a, b - 1] == 1) { pictOne[a, b - 1].Image = (Image)tochka; }
            }
            if (b + 1 <= 9)
            {
                if (a - 1 >= 0) if (pole1[a - 1, b + 1] == 1) { { pictOne[a - 1, b + 1].Image = (Image)tochka; } }
                if (a + 1 <= 9) if (pole1[a + 1, b + 1] == 1) { { pictOne[a + 1, b + 1].Image = (Image)tochka; } }
                if (pole1[a, b + 1] == 1) { pictOne[a, b + 1].Image = (Image)tochka; }
            }
            if (a - 1 >= 0) { if (pole1[a - 1, b] == 1) { pictOne[a - 1, b].Image = (Image)tochka; } }
            if (a + 1 <= 9) { if (pole1[a + 1, b] == 1) { pictOne[a + 1, b].Image = (Image)tochka; } }
        }

        public void zakraskaTwo(int a, int b)
        {
            if (b - 1 >= 0)
            {
                if (a - 1 >= 0) if (pole2[a - 1, b - 1] == 1) { { pictTwo[a - 1, b - 1].Image = (Image)tochka; } }
                if (a + 1 <= 9) if (pole2[a + 1, b - 1] == 1) { { pictTwo[a + 1, b - 1].Image = (Image)tochka; } }
                if (pole2[a, b - 1] == 1) { pictTwo[a, b - 1].Image = (Image)tochka; }
            }
            if (b + 1 <= 9)
            {
                if (a - 1 >= 0) if (pole2[a - 1, b + 1] == 1) { { pictTwo[a - 1, b + 1].Image = (Image)tochka; } }
                if (a + 1 <= 9) if (pole2[a + 1, b + 1] == 1) { { pictTwo[a + 1, b + 1].Image = (Image)tochka; } }
                if (pole2[a, b + 1] == 1) { pictTwo[a, b + 1].Image = (Image)tochka; }
            }
            if (a - 1 >= 0) { if (pole2[a - 1, b] == 1) { pictTwo[a - 1, b].Image = (Image)tochka; } }
            if (a + 1 <= 9) { if (pole2[a + 1, b] == 1) { pictTwo[a + 1, b].Image = (Image)tochka; } }
        }

        public void korMoved(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (korNomer)
                {
                    case "kor1_1":
                        pictureBox1_1.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor1_2":
                        pictureBox1_2.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor1_3":
                        pictureBox1_3.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor1_4":
                        pictureBox1_4.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor2_1":
                        pictureBox2_1.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor2_2":
                        pictureBox2_2.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor2_3":
                        pictureBox2_3.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor3_1":
                        pictureBox3_1.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor3_2":
                        pictureBox3_2.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                    case "kor4_1":
                        pictureBox4_1.Location = PointToClient(new Point(Cursor.Position.X - x, Cursor.Position.Y - y));
                        break;
                }
            }
        }
        
        public void korUp(object sender, MouseEventArgs e)
        {
            switch (korNomer)
            {
                case "kor1_1": koordX = pictureBox1_1.Left; koordY = pictureBox1_1.Top; break;
                case "kor1_2": koordX = pictureBox1_2.Left; koordY = pictureBox1_2.Top; break;
                case "kor1_3": koordX = pictureBox1_3.Left; koordY = pictureBox1_3.Top; break;
                case "kor1_4": koordX = pictureBox1_4.Left; koordY = pictureBox1_4.Top; break;
                case "kor2_1": koordX = pictureBox2_1.Left; koordY = pictureBox2_1.Top; break;
                case "kor2_2": koordX = pictureBox2_2.Left; koordY = pictureBox2_2.Top; break;
                case "kor2_3": koordX = pictureBox2_3.Left; koordY = pictureBox2_3.Top; break;
                case "kor3_1": koordX = pictureBox3_1.Left; koordY = pictureBox3_1.Top; break;
                case "kor3_2": koordX = pictureBox3_2.Left; koordY = pictureBox3_2.Top; break;
                case "kor4_1": koordX = pictureBox4_1.Left; koordY = pictureBox4_1.Top; break;
            }
            prov = false;
            if (koordY >= 64 && koordX >= 175 && koordY + 24 <= 318 && koordX + k <= 429)
            {
                if (koordY >= 64 && koordY <= 87)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 75; Proverka(0, 0); if (prov == true) { Rozmisch(0, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 75; Proverka(0, 1); if (prov == true) { Rozmisch(0, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 75; Proverka(0, 2); if (prov == true) { Rozmisch(0, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 75; Proverka(0, 3); if (prov == true) { Rozmisch(0, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 75; Proverka(0, 4); if (prov == true) { Rozmisch(0, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 75; Proverka(0, 5); if (prov == true) { Rozmisch(0, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 75; Proverka(0, 6); if (prov == true) { Rozmisch(0, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 75; Proverka(0, 7); if (prov == true) { Rozmisch(0, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 75; Proverka(0, 8); if (prov == true) { Rozmisch(0, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 75; Proverka(0, 9); if (prov == true) { Rozmisch(0, 9); } }
                }
                else if (koordY >= 88 && koordY <= 110)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 98; Proverka(1, 0); if (prov == true) { Rozmisch(1, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 98; Proverka(1, 1); if (prov == true) { Rozmisch(1, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 98; Proverka(1, 2); if (prov == true) { Rozmisch(1, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 98; Proverka(1, 3); if (prov == true) { Rozmisch(1, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 98; Proverka(1, 4); if (prov == true) { Rozmisch(1, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 98; Proverka(1, 5); if (prov == true) { Rozmisch(1, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 98; Proverka(1, 6); if (prov == true) { Rozmisch(1, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 98; Proverka(1, 7); if (prov == true) { Rozmisch(1, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 98; Proverka(1, 8); if (prov == true) { Rozmisch(1, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 98; Proverka(1, 9); if (prov == true) { Rozmisch(1, 9); } }
                }
                else if (koordY >= 111 && koordY <= 133)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 121; Proverka(2, 0); if (prov == true) { Rozmisch(2, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 121; Proverka(2, 1); if (prov == true) { Rozmisch(2, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 121; Proverka(2, 2); if (prov == true) { Rozmisch(2, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 121; Proverka(2, 3); if (prov == true) { Rozmisch(2, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 121; Proverka(2, 4); if (prov == true) { Rozmisch(2, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 121; Proverka(2, 5); if (prov == true) { Rozmisch(2, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 121; Proverka(2, 6); if (prov == true) { Rozmisch(2, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 121; Proverka(2, 7); if (prov == true) { Rozmisch(2, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 121; Proverka(2, 8); if (prov == true) { Rozmisch(2, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 121; Proverka(2, 9); if (prov == true) { Rozmisch(2, 9); } }
                }
                else if (koordY >= 134 && koordY <= 156)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 144; Proverka(3, 0); if (prov == true) { Rozmisch(3, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 144; Proverka(3, 1); if (prov == true) { Rozmisch(3, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 144; Proverka(3, 2); if (prov == true) { Rozmisch(3, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 144; Proverka(3, 3); if (prov == true) { Rozmisch(3, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 144; Proverka(3, 4); if (prov == true) { Rozmisch(3, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 144; Proverka(3, 5); if (prov == true) { Rozmisch(3, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 144; Proverka(3, 6); if (prov == true) { Rozmisch(3, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 144; Proverka(3, 7); if (prov == true) { Rozmisch(3, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 144; Proverka(3, 8); if (prov == true) { Rozmisch(3, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 144; Proverka(3, 9); if (prov == true) { Rozmisch(3, 9); } }
                }
                else if (koordY >= 157 && koordY <= 179)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 167; Proverka(4, 0); if (prov == true) { Rozmisch(4, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 167; Proverka(4, 1); if (prov == true) { Rozmisch(4, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 167; Proverka(4, 2); if (prov == true) { Rozmisch(4, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 167; Proverka(4, 3); if (prov == true) { Rozmisch(4, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 167; Proverka(4, 4); if (prov == true) { Rozmisch(4, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 167; Proverka(4, 5); if (prov == true) { Rozmisch(4, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 167; Proverka(4, 6); if (prov == true) { Rozmisch(4, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 167; Proverka(4, 7); if (prov == true) { Rozmisch(4, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 167; Proverka(4, 8); if (prov == true) { Rozmisch(4, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 167; Proverka(4, 9); if (prov == true) { Rozmisch(4, 9); } }
                }
                else if (koordY >= 180 && koordY <= 202)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 190; Proverka(5, 0); if (prov == true) { Rozmisch(5, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 190; Proverka(5, 1); if (prov == true) { Rozmisch(5, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 190; Proverka(5, 2); if (prov == true) { Rozmisch(5, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 190; Proverka(5, 3); if (prov == true) { Rozmisch(5, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 190; Proverka(5, 4); if (prov == true) { Rozmisch(5, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 190; Proverka(5, 5); if (prov == true) { Rozmisch(5, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 190; Proverka(5, 6); if (prov == true) { Rozmisch(5, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 190; Proverka(5, 7); if (prov == true) { Rozmisch(5, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 190; Proverka(5, 8); if (prov == true) { Rozmisch(5, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 190; Proverka(5, 9); if (prov == true) { Rozmisch(5, 9); } }
                }
                else if (koordY >= 203 && koordY <= 225)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 213; Proverka(6, 0); if (prov == true) { Rozmisch(6, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 213; Proverka(6, 1); if (prov == true) { Rozmisch(6, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 213; Proverka(6, 2); if (prov == true) { Rozmisch(6, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 213; Proverka(6, 3); if (prov == true) { Rozmisch(6, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 213; Proverka(6, 4); if (prov == true) { Rozmisch(6, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 213; Proverka(6, 5); if (prov == true) { Rozmisch(6, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 213; Proverka(6, 6); if (prov == true) { Rozmisch(6, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 213; Proverka(6, 7); if (prov == true) { Rozmisch(6, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 213; Proverka(6, 8); if (prov == true) { Rozmisch(6, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 213; Proverka(6, 9); if (prov == true) { Rozmisch(6, 9); } }
                }
                else if (koordY >= 226 && koordY <= 248)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 236; Proverka(7, 0); if (prov == true) { Rozmisch(7, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 236; Proverka(7, 1); if (prov == true) { Rozmisch(7, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 236; Proverka(7, 2); if (prov == true) { Rozmisch(7, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 236; Proverka(7, 3); if (prov == true) { Rozmisch(7, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 236; Proverka(7, 4); if (prov == true) { Rozmisch(7, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 236; Proverka(7, 5); if (prov == true) { Rozmisch(7, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 236; Proverka(7, 6); if (prov == true) { Rozmisch(7, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 236; Proverka(7, 7); if (prov == true) { Rozmisch(7, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 236; Proverka(7, 8); if (prov == true) { Rozmisch(7, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 236; Proverka(7, 9); if (prov == true) { Rozmisch(7, 9); } }
                }
                else if (koordY >= 249 && koordY <= 271)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 259; Proverka(8, 0); if (prov == true) { Rozmisch(8, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 259; Proverka(8, 1); if (prov == true) { Rozmisch(8, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 259; Proverka(8, 2); if (prov == true) { Rozmisch(8, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 259; Proverka(8, 3); if (prov == true) { Rozmisch(8, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 259; Proverka(8, 4); if (prov == true) { Rozmisch(8, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 259; Proverka(8, 5); if (prov == true) { Rozmisch(8, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 259; Proverka(8, 6); if (prov == true) { Rozmisch(8, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 259; Proverka(8, 7); if (prov == true) { Rozmisch(8, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 259; Proverka(8, 8); if (prov == true) { Rozmisch(8, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 259; Proverka(8, 9); if (prov == true) { Rozmisch(8, 9); } }
                }
                else if (koordY >= 272 && koordY + 24 <= 318)
                {
                    if (koordX >= 175 && koordX <= 198)
                    { koordX = 186; koordY = 282; Proverka(9, 0); if (prov == true) { Rozmisch(9, 0); } }
                    else if (koordX >= 199 && koordX <= 221)
                    { koordX = 209; koordY = 282; Proverka(9, 1); if (prov == true) { Rozmisch(9, 1); } }
                    else if (koordX >= 222 && koordX <= 244)
                    { koordX = 232; koordY = 282; Proverka(9, 2); if (prov == true) { Rozmisch(9, 2); } }
                    else if (koordX >= 245 && koordX <= 267)
                    { koordX = 255; koordY = 282; Proverka(9, 3); if (prov == true) { Rozmisch(9, 3); } }
                    else if (koordX >= 268 && koordX <= 290)
                    { koordX = 278; koordY = 282; Proverka(9, 4); if (prov == true) { Rozmisch(9, 4); } }
                    else if (koordX >= 291 && koordX <= 313)
                    { koordX = 301; koordY = 282; Proverka(9, 5); if (prov == true) { Rozmisch(9, 5); } }
                    else if (koordX >= 314 && koordX <= 336)
                    { koordX = 324; koordY = 282; Proverka(9, 6); if (prov == true) { Rozmisch(9, 6); } }
                    else if (koordX >= 337 && koordX <= 359)
                    { koordX = 347; koordY = 282; Proverka(9, 7); if (prov == true) { Rozmisch(9, 7); } }
                    else if (koordX >= 360 && koordX <= 382)
                    { koordX = 370; koordY = 282; Proverka(9, 8); if (prov == true) { Rozmisch(9, 8); } }
                    else if (koordX >= 383 && koordX + 24 <= 429)
                    { koordX = 393; koordY = 282; Proverka(9, 9); if (prov == true) { Rozmisch(9, 9); } }
                }
                if (prov == false)
                {
                    switch (korNomer)
                    {
                        case "kor1_1":
                        case "kor1_2":
                        case "kor1_3":
                        case "kor1_4": label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1); koordY = 60; break;
                        case "kor2_1":
                        case "kor2_2":
                        case "kor2_3": label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1); koordY = 100; break;
                        case "kor3_1":
                        case "kor3_2": label3.Text = Convert.ToString(Convert.ToInt32(label3.Text) + 1); koordY = 140; break;
                        case "kor4_1": label4.Text = Convert.ToString(Convert.ToInt32(label4.Text) + 1); koordY = 180; break;
                    }
                    koordX = 50;
                }
            }
            else
            {
                switch (korNomer)
                {
                    case "kor1_1":
                    case "kor1_2":
                    case "kor1_3":
                    case "kor1_4": label1.Text = Convert.ToString(Convert.ToInt32(label1.Text) + 1); koordY = 60; break;
                    case "kor2_1":
                    case "kor2_2":
                    case "kor2_3": label2.Text = Convert.ToString(Convert.ToInt32(label2.Text) + 1); koordY = 100; break;
                    case "kor3_1":
                    case "kor3_2": label3.Text = Convert.ToString(Convert.ToInt32(label3.Text) + 1); koordY = 140; break;
                    case "kor4_1": label4.Text = Convert.ToString(Convert.ToInt32(label4.Text) + 1); koordY = 180; break;
                }
                koordX = 50;
            }            
            
            switch (korNomer)
            {
                case "kor1_1": pictureBox1_1.Location = new Point(koordX, koordY); break;
                case "kor1_2": pictureBox1_2.Location = new Point(koordX, koordY); break;
                case "kor1_3": pictureBox1_3.Location = new Point(koordX, koordY); break;
                case "kor1_4": pictureBox1_4.Location = new Point(koordX, koordY); break;
                case "kor2_1": pictureBox2_1.Location = new Point(koordX, koordY); break;
                case "kor2_2": pictureBox2_2.Location = new Point(koordX, koordY); break;
                case "kor2_3": pictureBox2_3.Location = new Point(koordX, koordY); break;
                case "kor3_1": pictureBox3_1.Location = new Point(koordX, koordY); break;
                case "kor3_2": pictureBox3_2.Location = new Point(koordX, koordY); break;
                case "kor4_1": pictureBox4_1.Location = new Point(koordX, koordY); break;
            }            
        }
        
        public void Rozmisch(int ax, int by)
        {
            if (poleNomer == 1)
            {
                switch (Number)
                {
                    case 1:
                        pole1[ax, by] = 2;
                        if (ax < 9 && by < 9) { pole1[ax + 1, by + 1] = 1; }
                        if (ax < 9 && by > 0) { pole1[ax + 1, by - 1] = 1; }
                        if (ax < 9) { pole1[ax + 1, by] = 1; }
                        if (ax > 0 && by < 9) { pole1[ax - 1, by + 1] = 1; }
                        if (ax > 0 && by > 0) { pole1[ax - 1, by - 1] = 1; }
                        if (ax > 0) { pole1[ax - 1, by] = 1; }
                        if (by < 9) { pole1[ax, by + 1] = 1; }
                        if (by > 0) { pole1[ax, by - 1] = 1; }
                        break;
                    case 2:
                        pole1[ax, by] = 2; pole1[ax, by + 1] = 2;
                        if (ax > 0 && by > 0) { pole1[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 8) { pole1[ax - 1, by + 2] = 1; }
                        if (ax > 0) { pole1[ax - 1, by + 1] = 1; pole1[ax - 1, by] = 1; }
                        if (ax < 9 && by > 0) { pole1[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 8) { pole1[ax + 1, by + 2] = 1; }
                        if (ax < 9) { pole1[ax + 1, by + 1] = 1; pole1[ax + 1, by] = 1; }
                        if (by > 0) { pole1[ax, by - 1] = 1; }
                        if (by < 8) { pole1[ax, by + 2] = 1; }
                        break;
                    case 3:
                        pole1[ax, by] = 2; pole1[ax, by + 1] = 2; pole1[ax, by + 2] = 2;
                        if (ax > 0 && by > 0) { pole1[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 7) { pole1[ax - 1, by + 3] = 1; }
                        if (ax > 0) { pole1[ax - 1, by + 2] = 1; pole1[ax - 1, by + 1] = 1; pole1[ax - 1, by] = 1; }
                        if (ax < 9 && by > 0) { pole1[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 7) { pole1[ax + 1, by + 3] = 1; }
                        if (ax < 9) { pole1[ax + 1, by + 2] = 1; pole1[ax + 1, by + 1] = 1; pole1[ax + 1, by] = 1; }
                        if (by > 0) { pole1[ax, by - 1] = 1; }
                        if (by < 7) { pole1[ax, by + 3] = 1; }
                        break;
                    case 4:
                        pole1[ax, by] = 2; pole1[ax, by + 1] = 2; pole1[ax, by + 2] = 2; pole1[ax, by + 3] = 2;
                        if (ax > 0 && by > 0) { pole1[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 6) { pole1[ax - 1, by + 4] = 1; }
                        if (ax < 9 && by > 0) { pole1[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 6) { pole1[ax + 1, by + 4] = 1; }
                        if (ax > 0) { pole1[ax - 1, by + 3] = 1; pole1[ax - 1, by + 2] = 1; pole1[ax - 1, by + 1] = 1; pole1[ax - 1, by] = 1; }
                        if (ax < 9) { pole1[ax + 1, by + 3] = 1; pole1[ax + 1, by + 2] = 1; pole1[ax + 1, by + 1] = 1; pole1[ax + 1, by] = 1; }
                        if (by > 0) { pole1[ax, by - 1] = 1; }
                        if (by < 6) { pole1[ax, by + 4] = 1; }
                        break;
                }
            }
            else
            {
                switch (Number)
                {
                    case 1:
                        pole2[ax, by] = 2;
                        if (ax < 9 && by < 9) { pole2[ax + 1, by + 1] = 1; }
                        if (ax < 9 && by > 0) { pole2[ax + 1, by - 1] = 1; }
                        if (ax < 9) { pole2[ax + 1, by] = 1; }
                        if (ax > 0 && by < 9) { pole2[ax - 1, by + 1] = 1; }
                        if (ax > 0 && by > 0) { pole2[ax - 1, by - 1] = 1; }
                        if (ax > 0) { pole2[ax - 1, by] = 1; }
                        if (by < 9) { pole2[ax, by + 1] = 1; }
                        if (by > 0) { pole2[ax, by - 1] = 1; }
                        break;
                    case 2:
                        pole2[ax, by] = 2; pole2[ax, by + 1] = 2;
                        if (ax > 0 && by > 0) { pole2[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 8) { pole2[ax - 1, by + 2] = 1; }
                        if (ax > 0) { pole2[ax - 1, by + 1] = 1; pole2[ax - 1, by] = 1; }
                        if (ax < 9 && by > 0) { pole2[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 8) { pole2[ax + 1, by + 2] = 1; }
                        if (ax < 9) { pole2[ax + 1, by + 1] = 1; pole2[ax + 1, by] = 1; }
                        if (by > 0) { pole2[ax, by - 1] = 1; }
                        if (by < 8) { pole2[ax, by + 2] = 1; }
                        break;
                    case 3:
                        pole2[ax, by] = 2; pole2[ax, by + 1] = 2; pole2[ax, by + 2] = 2;
                        if (ax > 0 && by > 0) { pole2[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 7) { pole2[ax - 1, by + 3] = 1; }
                        if (ax > 0) { pole2[ax - 1, by + 2] = 1; pole2[ax - 1, by + 1] = 1; pole2[ax - 1, by] = 1; }
                        if (ax < 9 && by > 0) { pole2[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 7) { pole2[ax + 1, by + 3] = 1; }
                        if (ax < 9) { pole2[ax + 1, by + 2] = 1; pole2[ax + 1, by + 1] = 1; pole2[ax + 1, by] = 1; }
                        if (by > 0) { pole2[ax, by - 1] = 1; }
                        if (by < 7) { pole2[ax, by + 3] = 1; }
                        break;
                    case 4:
                        pole2[ax, by] = 2; pole2[ax, by + 1] = 2; pole2[ax, by + 2] = 2; pole2[ax, by + 3] = 2;
                        if (ax > 0 && by > 0) { pole2[ax - 1, by - 1] = 1; }
                        if (ax > 0 && by < 6) { pole2[ax - 1, by + 4] = 1; }
                        if (ax < 9 && by > 0) { pole2[ax + 1, by - 1] = 1; }
                        if (ax < 9 && by < 6) { pole2[ax + 1, by + 4] = 1; }
                        if (ax > 0) { pole2[ax - 1, by + 3] = 1; pole2[ax - 1, by + 2] = 1; pole2[ax - 1, by + 1] = 1; pole2[ax - 1, by] = 1; }
                        if (ax < 9) { pole2[ax + 1, by + 3] = 1; pole2[ax + 1, by + 2] = 1; pole2[ax + 1, by + 1] = 1; pole2[ax + 1, by] = 1; }
                        if (by > 0) { pole2[ax, by - 1] = 1; }
                        if (by < 6) { pole2[ax, by + 4] = 1; }
                        break;
                }
            }
        }

        public void Znyattya(int ax, int by)
        {
            if (poleNomer == 1)
            {
                switch (Number)
                {
                    case 1:
                        pole1[ax, by] = 0;
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole1[ax, by + 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && ax + 2 <= 9) { if (pole1[ax + 2, by + 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 1 <= 9 && est == false) { pole1[ax + 1, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole1[ax + 1, by - 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (by + 1 <= 9) { if (pole1[ax + 2, by + 1] == 2) { est = true; } }
                            if (by - 1 >= 0) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by] = 0; }
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole1[ax, by + 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && ax - 2 >= 0) { if (pole1[ax - 2, by + 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 1 <= 9 && est == false) { pole1[ax - 1, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole1[ax - 1, by - 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (by + 1 <= 9) { if (pole1[ax - 2, by + 1] == 2) { est = true; } }
                            if (by - 1 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by] = 0; }
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole1[ax, by + 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 2] == 2) { est = true; } }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && est == false) { pole1[ax, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole1[ax, by - 1] = 0; }
                        break;
                    case 2:
                        pole1[ax, by] = 0; pole1[ax, by + 1] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole1[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (pole1[ax, by + 3] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 3] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && ax - 2 >= 0) { if (pole1[ax - 2, by + 2] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by + 1] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 2 <= 9 && est == false) { pole1[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                            if (by + 2 <= 9) { if (pole1[ax - 2, by + 2] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole1[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (pole1[ax, by + 3] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 3] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && ax + 2 <= 9) { if (pole1[ax + 2, by + 2] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by + 1] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 2 <= 9 && est == false) { pole1[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                            if (by + 2 <= 9) { if (pole1[ax + 2, by + 2] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole1[ax, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 3] == 2) { est = true; } }
                            if (pole1[ax, by + 3] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && est == false) { pole1[ax, by + 2] = 0; }
                        break;
                    case 3:
                        pole1[ax, by] = 0; pole1[ax, by + 1] = 0; pole1[ax, by + 2] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole1[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (pole1[ax, by + 4] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 4] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && ax - 2 >= 0) { if (pole1[ax - 2, by + 3] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by + 2] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 3 <= 9 && est == false) { pole1[ax - 1, by + 3] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                            if (pole1[ax - 2, by + 2] == 2) { est = true; }
                            if (by + 3 <= 9) { if (pole1[ax - 2, by + 3] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                            if (pole1[ax - 2, by + 2] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole1[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (pole1[ax, by + 4] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 4] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && ax + 2 <= 9) { if (pole1[ax + 2, by + 3] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by + 2] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 3 <= 9 && est == false) { pole1[ax + 1, by + 3] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                            if (pole1[ax + 2, by + 2] == 2) { est = true; }
                            if (by + 3 <= 9) { if (pole1[ax + 2, by + 3] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                            if (pole1[ax + 2, by + 2] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole1[ax, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 4] == 2) { est = true; } }
                            if (pole1[ax, by + 4] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && est == false) { pole1[ax, by + 3] = 0; }
                        break;
                    case 4:
                        pole1[ax, by] = 0; pole1[ax, by + 1] = 0; pole1[ax, by + 2] = 0; pole1[ax, by + 3] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole1[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (pole1[ax, by + 5] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 5] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole1[ax - 2, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && ax - 2 >= 0) { if (pole1[ax - 2, by + 4] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole1[ax - 2, by + 3] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 4 <= 9 && est == false) { pole1[ax - 1, by + 4] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole1[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (pole1[ax, by + 5] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 5] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole1[ax + 2, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && ax + 2 <= 9) { if (pole1[ax + 2, by + 4] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole1[ax + 2, by + 3] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 4 <= 9 && est == false) { pole1[ax + 1, by + 4] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by + 2] == 2) { est = true; }
                            if (pole1[ax - 2, by + 3] == 2) { est = true; }
                            if (by + 4 <= 9) { if (pole1[ax - 2, by + 4] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 3] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                            if (pole1[ax - 2, by + 2] == 2) { est = true; }
                            if (pole1[ax - 2, by + 3] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                            if (pole1[ax - 2, by + 2] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole1[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax - 2, by] == 2) { est = true; }
                            if (pole1[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole1[ax - 1, by] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by + 2] == 2) { est = true; }
                            if (pole1[ax + 2, by + 3] == 2) { est = true; }
                            if (by + 4 <= 9) { if (pole1[ax + 2, by + 4] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 3] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                            if (pole1[ax + 2, by + 2] == 2) { est = true; }
                            if (pole1[ax + 2, by + 3] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                            if (pole1[ax + 2, by + 2] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole1[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole1[ax + 2, by] == 2) { est = true; }
                            if (pole1[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole1[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole1[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole1[ax, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole1[ax - 1, by + 5] == 2) { est = true; } }
                            if (pole1[ax, by + 5] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole1[ax + 1, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && est == false) { pole1[ax, by + 4] = 0; }
                        break;
                }
            }
            else
            {
                switch (Number)
                {
                    case 1:
                        pole2[ax, by] = 0;
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole2[ax, by + 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && ax + 2 <= 9) { if (pole2[ax + 2, by + 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 1 <= 9 && est == false) { pole2[ax + 1, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole2[ax + 1, by - 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (by + 1 <= 9) { if (pole2[ax + 2, by + 1] == 2) { est = true; } }
                            if (by - 1 >= 0) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by] = 0; }
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole2[ax, by + 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && ax - 2 >= 0) { if (pole2[ax - 2, by + 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 1 <= 9 && est == false) { pole2[ax - 1, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole2[ax - 1, by - 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (by + 1 <= 9) { if (pole2[ax - 2, by + 1] == 2) { est = true; } }
                            if (by - 1 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by] = 0; }
                        est = false;
                        if (by + 2 <= 9)
                        {
                            if (pole2[ax, by + 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 2] == 2) { est = true; } }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 2] == 2) { est = true; } }
                        }
                        if (by + 1 <= 9 && est == false) { pole2[ax, by + 1] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole2[ax, by - 1] = 0; }
                        break;
                    case 2:
                        pole2[ax, by] = 0; pole2[ax, by + 1] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole2[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (pole2[ax, by + 3] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 3] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && ax - 2 >= 0) { if (pole2[ax - 2, by + 2] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by + 1] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 2 <= 9 && est == false) { pole2[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                            if (by + 2 <= 9) { if (pole2[ax - 2, by + 2] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole2[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (pole2[ax, by + 3] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 3] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && ax + 2 <= 9) { if (pole2[ax + 2, by + 2] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by + 1] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 2 <= 9 && est == false) { pole2[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                            if (by + 2 <= 9) { if (pole2[ax + 2, by + 2] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole2[ax, by - 1] = 0; }
                        est = false;
                        if (by + 3 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 3] == 2) { est = true; } }
                            if (pole2[ax, by + 3] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 3] == 2) { est = true; } }
                        }
                        if (by + 2 <= 9 && est == false) { pole2[ax, by + 2] = 0; }
                        break;
                    case 3:
                        pole2[ax, by] = 0; pole2[ax, by + 1] = 0; pole2[ax, by + 2] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole2[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (pole2[ax, by + 4] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 4] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && ax - 2 >= 0) { if (pole2[ax - 2, by + 3] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by + 2] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 3 <= 9 && est == false) { pole2[ax - 1, by + 3] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                            if (pole2[ax - 2, by + 2] == 2) { est = true; }
                            if (by + 3 <= 9) { if (pole2[ax - 2, by + 3] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                            if (pole2[ax - 2, by + 2] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole2[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (pole2[ax, by + 4] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 4] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && ax + 2 <= 9) { if (pole2[ax + 2, by + 3] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by + 2] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 3 <= 9 && est == false) { pole2[ax + 1, by + 3] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                            if (pole2[ax + 2, by + 2] == 2) { est = true; }
                            if (by + 3 <= 9) { if (pole2[ax + 2, by + 3] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                            if (pole2[ax + 2, by + 2] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole2[ax, by - 1] = 0; }
                        est = false;
                        if (by + 4 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 4] == 2) { est = true; } }
                            if (pole2[ax, by + 4] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 4] == 2) { est = true; } }
                        }
                        if (by + 3 <= 9 && est == false) { pole2[ax, by + 3] = 0; }
                        break;
                    case 4:
                        pole2[ax, by] = 0; pole2[ax, by + 1] = 0; pole2[ax, by + 2] = 0; pole2[ax, by + 3] = 0;
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax - 2 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by - 1 >= 0 && est == false) { pole2[ax - 1, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (pole2[ax, by + 5] == 2) { est = true; }
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 5] == 2) { est = true; } }
                            if (ax - 2 >= 0) { if (pole2[ax - 2, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && ax - 2 >= 0) { if (pole2[ax - 2, by + 4] == 2) { est = true; } }
                        if (ax - 2 >= 0) { if (pole2[ax - 2, by + 3] == 2) { est = true; } }
                        if (ax - 1 >= 0 && by + 4 <= 9 && est == false) { pole2[ax - 1, by + 4] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && ax + 2 <= 9) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by - 1 >= 0 && est == false) { pole2[ax + 1, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (pole2[ax, by + 5] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 5] == 2) { est = true; } }
                            if (ax + 2 <= 9) { if (pole2[ax + 2, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && ax + 2 <= 9) { if (pole2[ax + 2, by + 4] == 2) { est = true; } }
                        if (ax + 2 <= 9) { if (pole2[ax + 2, by + 3] == 2) { est = true; } }
                        if (ax + 1 <= 9 && by + 4 <= 9 && est == false) { pole2[ax + 1, by + 4] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by + 2] == 2) { est = true; }
                            if (pole2[ax - 2, by + 3] == 2) { est = true; }
                            if (by + 4 <= 9) { if (pole2[ax - 2, by + 4] == 2) { est = true; } }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 3] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                            if (pole2[ax - 2, by + 2] == 2) { est = true; }
                            if (pole2[ax - 2, by + 3] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 2] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                            if (pole2[ax - 2, by + 2] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by + 1] = 0; }
                        est = false;
                        if (ax - 2 >= 0)
                        {
                            if (by - 1 >= 0) { if (pole2[ax - 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax - 2, by] == 2) { est = true; }
                            if (pole2[ax - 2, by + 1] == 2) { est = true; }
                        }
                        if (ax - 1 >= 0 && est == false) { pole2[ax - 1, by] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by + 2] == 2) { est = true; }
                            if (pole2[ax + 2, by + 3] == 2) { est = true; }
                            if (by + 4 <= 9) { if (pole2[ax + 2, by + 4] == 2) { est = true; } }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 3] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                            if (pole2[ax + 2, by + 2] == 2) { est = true; }
                            if (pole2[ax + 2, by + 3] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 2] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                            if (pole2[ax + 2, by + 2] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by + 1] = 0; }
                        est = false;
                        if (ax + 2 <= 9)
                        {
                            if (by - 1 >= 0) { if (pole2[ax + 2, by - 1] == 2) { est = true; } }
                            if (pole2[ax + 2, by] == 2) { est = true; }
                            if (pole2[ax + 2, by + 1] == 2) { est = true; }
                        }
                        if (ax + 1 <= 9 && est == false) { pole2[ax + 1, by] = 0; }
                        est = false;
                        if (by - 2 >= 0)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by - 2] == 2) { est = true; } }
                            if (pole2[ax, by - 2] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by - 2] == 2) { est = true; } }
                        }
                        if (by - 1 >= 0 && est == false) { pole2[ax, by - 1] = 0; }
                        est = false;
                        if (by + 5 <= 9)
                        {
                            if (ax - 1 >= 0) { if (pole2[ax - 1, by + 5] == 2) { est = true; } }
                            if (pole2[ax, by + 5] == 2) { est = true; }
                            if (ax + 1 <= 9) { if (pole2[ax + 1, by + 5] == 2) { est = true; } }
                        }
                        if (by + 4 <= 9 && est == false) { pole2[ax, by + 4] = 0; }
                        break;
                }
            }
        }

        public void Koordinaty()
        {
            if (koordY >= 64 && koordX >= 175 && koordY + 24 <= 318 && koordX + k <= 429)
            {

                switch (koordY)
                {
                    case 75:
                        switch (koordX)
                        {
                            case 186: Znyattya(0, 0); break;
                            case 209: Znyattya(0, 1); break;
                            case 232: Znyattya(0, 2); break;
                            case 255: Znyattya(0, 3); break;
                            case 278: Znyattya(0, 4); break;
                            case 301: Znyattya(0, 5); break;
                            case 324: Znyattya(0, 6); break;
                            case 347: Znyattya(0, 7); break;
                            case 370: Znyattya(0, 8); break;
                            case 393: Znyattya(0, 9); break;
                        }
                        break;
                    case 98:
                        switch (koordX)
                        {
                            case 186: Znyattya(1, 0); break;
                            case 209: Znyattya(1, 1); break;
                            case 232: Znyattya(1, 2); break;
                            case 255: Znyattya(1, 3); break;
                            case 278: Znyattya(1, 4); break;
                            case 301: Znyattya(1, 5); break;
                            case 324: Znyattya(1, 6); break;
                            case 347: Znyattya(1, 7); break;
                            case 370: Znyattya(1, 8); break;
                            case 393: Znyattya(1, 9); break;
                        }
                        break;
                    case 121:
                        switch (koordX)
                        {
                            case 186: Znyattya(2, 0); break;
                            case 209: Znyattya(2, 1); break;
                            case 232: Znyattya(2, 2); break;
                            case 255: Znyattya(2, 3); break;
                            case 278: Znyattya(2, 4); break;
                            case 301: Znyattya(2, 5); break;
                            case 324: Znyattya(2, 6); break;
                            case 347: Znyattya(2, 7); break;
                            case 370: Znyattya(2, 8); break;
                            case 393: Znyattya(2, 9); break;
                        }
                        break;
                    case 144:
                        switch (koordX)
                        {
                            case 186: Znyattya(3, 0); break;
                            case 209: Znyattya(3, 1); break;
                            case 232: Znyattya(3, 2); break;
                            case 255: Znyattya(3, 3); break;
                            case 278: Znyattya(3, 4); break;
                            case 301: Znyattya(3, 5); break;
                            case 324: Znyattya(3, 6); break;
                            case 347: Znyattya(3, 7); break;
                            case 370: Znyattya(3, 8); break;
                            case 393: Znyattya(3, 9); break;
                        }
                        break;
                    case 167:
                        switch (koordX)
                        {
                            case 186: Znyattya(4, 0); break;
                            case 209: Znyattya(4, 1); break;
                            case 232: Znyattya(4, 2); break;
                            case 255: Znyattya(4, 3); break;
                            case 278: Znyattya(4, 4); break;
                            case 301: Znyattya(4, 5); break;
                            case 324: Znyattya(4, 6); break;
                            case 347: Znyattya(4, 7); break;
                            case 370: Znyattya(4, 8); break;
                            case 393: Znyattya(4, 9); break;
                        }
                        break;
                    case 190:
                        switch (koordX)
                        {
                            case 186: Znyattya(5, 0); break;
                            case 209: Znyattya(5, 1); break;
                            case 232: Znyattya(5, 2); break;
                            case 255: Znyattya(5, 3); break;
                            case 278: Znyattya(5, 4); break;
                            case 301: Znyattya(5, 5); break;
                            case 324: Znyattya(5, 6); break;
                            case 347: Znyattya(5, 7); break;
                            case 370: Znyattya(5, 8); break;
                            case 393: Znyattya(5, 9); break;
                        }
                        break;
                    case 213:
                        switch (koordX)
                        {
                            case 186: Znyattya(6, 0); break;
                            case 209: Znyattya(6, 1); break;
                            case 232: Znyattya(6, 2); break;
                            case 255: Znyattya(6, 3); break;
                            case 278: Znyattya(6, 4); break;
                            case 301: Znyattya(6, 5); break;
                            case 324: Znyattya(6, 6); break;
                            case 347: Znyattya(6, 7); break;
                            case 370: Znyattya(6, 8); break;
                            case 393: Znyattya(6, 9); break;
                        }
                        break;
                    case 236:
                        switch (koordX)
                        {
                            case 186: Znyattya(7, 0); break;
                            case 209: Znyattya(7, 1); break;
                            case 232: Znyattya(7, 2); break;
                            case 255: Znyattya(7, 3); break;
                            case 278: Znyattya(7, 4); break;
                            case 301: Znyattya(7, 5); break;
                            case 324: Znyattya(7, 6); break;
                            case 347: Znyattya(7, 7); break;
                            case 370: Znyattya(7, 8); break;
                            case 393: Znyattya(7, 9); break;
                        }
                        break;
                    case 259:
                        switch (koordX)
                        {
                            case 186: Znyattya(8, 0); break;
                            case 209: Znyattya(8, 1); break;
                            case 232: Znyattya(8, 2); break;
                            case 255: Znyattya(8, 3); break;
                            case 278: Znyattya(8, 4); break;
                            case 301: Znyattya(8, 5); break;
                            case 324: Znyattya(8, 6); break;
                            case 347: Znyattya(8, 7); break;
                            case 370: Znyattya(8, 8); break;
                            case 393: Znyattya(8, 9); break;
                        }
                        break;
                    case 282:
                        switch (koordX)
                        {
                            case 186: Znyattya(9, 0); break;
                            case 209: Znyattya(9, 1); break;
                            case 232: Znyattya(9, 2); break;
                            case 255: Znyattya(9, 3); break;
                            case 278: Znyattya(9, 4); break;
                            case 301: Znyattya(9, 5); break;
                            case 324: Znyattya(9, 6); break;
                            case 347: Znyattya(9, 7); break;
                            case 370: Znyattya(9, 8); break;
                            case 393: Znyattya(9, 9); break;
                        }
                        break;
                }
            }
        }

        public void Proverka(int provX, int provY)
        {
            if (poleNomer == 1)
            {
                switch (Number)
                {
                    case 1: if (pole1[provX, provY] == 0) { prov = true; } break;
                    case 2: if (pole1[provX, provY] == 0 && pole1[provX, provY + 1] == 0) { prov = true; } break;
                    case 3: if (pole1[provX, provY] == 0 && pole1[provX, provY + 1] == 0 && pole1[provX, provY + 2] == 0) { prov = true; } break;
                    case 4: if (pole1[provX, provY] == 0 && pole1[provX, provY + 1] == 0 && pole1[provX, provY + 2] == 0 && pole1[provX, provY + 3] == 0) { prov = true; } break;
                }
            }
            else
            {
                switch (Number)
                {
                    case 1: if (pole2[provX, provY] == 0) { prov = true; } break;
                    case 2: if (pole2[provX, provY] == 0 && pole2[provX, provY + 1] == 0) { prov = true; } break;
                    case 3: if (pole2[provX, provY] == 0 && pole2[provX, provY + 1] == 0 && pole2[provX, provY + 2] == 0) { prov = true; } break;
                    case 4: if (pole2[provX, provY] == 0 && pole2[provX, provY + 1] == 0 && pole2[provX, provY + 2] == 0 && pole2[provX, provY + 3] == 0) { prov = true; } break;
                }
            }
        }
    }
}