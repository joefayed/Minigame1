using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigame1
{
    public class stage1balls
    {
        public int posx, posy;
        public int iconnect;
    }
    public class enemy
    {
        public int x, y;
    }
    public class person
    {
        public int x, y;
    }
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        Bitmap bg, start, options, highscores, account, cbg, back, music, mon, moff, arrow;
        Random r = new Random();
        Color bgc;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        int counttick = 0;
        int stage = 0, oah = 0, mf = 0, ex = 0, ey = 0, isup = 0;
        //stage 1 Variables
        List<stage1balls> st1b = new List<stage1balls>();
        int lines = 600, lines2 = 210, s1t1 = 600, s1t2 = 210, bn = 0, boxx = 0, boxy = 0, endx = 0, endy = 60, startx = 0, starty = 0;
        //-------------------------------------------------------------
        //Stage 2 variables
        int[] pattern = { -1, -1, -1, -1 };
        int[] patternuser = { -1, -1, -1, -1 };
        int b = 0, re = 0, gr = 0, y = 0, fstart = 0, ctwin = 0, win2 = 0;
        Bitmap startst2;
        System.Media.SoundPlayer sndPlayer = new System.Media.SoundPlayer();
        //-------------------------------------------------------------
        //Stage 3 variables
        int win3 = 0;
        int shipx = 630, shipy = 600, putx = 645, putx2 = 810, nop = 0, left = 0, right = 0, putx3 = 1250, putx4 = 1400, nopl = 3, noel = 3, nopr = 0, noer = 0;
        int[] pn = { -1, -1 };
        int[] en = { -1, -1 };
        List<enemy> enem = new List<enemy>();
        List<person> pers = new List<person>();
        Bitmap back2,ship, enemy, person;
        //-------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
            this.MouseMove += Form1_MouseMove;
            this.Paint += new PaintEventHandler(Form1_Paint);
            t.Interval = 5;
            t.Tick += t_Tick;
            t.Start();
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawbuffer(e.Graphics);
        }

        bool lose()
        {
            if ((nopl < noel && shipx > 700 && nopl != 0) || (nopr < noer && shipx < 700 && nopr != 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (stage==3)
            {
                if (counttick % 3 == 0)
                {
                    if (left == 1)
                    {
                        shipx -= 50;
                        putx -= 50;
                        putx2 -= 50;
                        for (int i = 0; i < 2; i++)
                        {
                            if (pn[i] > -1)
                            {
                                pers[pn[i]].x -= 50;
                            }
                            if (en[i] > -1)
                            {
                                enem[en[i]].x -= 50;
                            }
                        }
                        if (shipx <= 630)
                        {
                            left = 0;
                        }
                    }
                    if (right == 1)
                    {
                        shipx += 50;
                        putx += 50;
                        putx2 += 50;
                        for (int i = 0; i < 2; i++)
                        {
                            if (pn[i] > -1)
                            {
                                pers[pn[i]].x += 50;
                            }
                            if (en[i] > -1)
                            {
                                enem[en[i]].x += 50;
                            }
                        }
                        if (shipx + ship.Width >= 1230)
                        {
                            right = 0;
                        }
                    }
                }
                if (lose())
                {
                    this.Text = "you lose";
                }
            }
            if (stage==2)
            {
                if (patternuser[3] != -1)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        ctwin++;
                        if (pattern[i] != patternuser[i])
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                patternuser[j] = -1;
                                pattern[j] = -1;
                                fstart = 0;
                                ctwin = 0;
                            }
                            MessageBox.Show("You Didin't answer correct Please Press start again");
                            break;
                        }
                    }
                    if (ctwin == 4)
                    {
                        win2 = 1;
                        MessageBox.Show("Congrats You Won");
                    }
                }
            }
            lines = 600;
            lines2 = 210;
            counttick++;
            drawbuffer(this.CreateGraphics());
        }

        void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //-------------------------------------------------------------------------
            //Stage 0
            if (stage == 0)
            {
                if (oah == 0)
                {
                    if (e.X >= 850 && e.Y >= 500 && e.X <= 850 + start.Width && e.Y <= 500 + start.Height / 2)
                    {
                        start = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Startg.bmp");
                        start.MakeTransparent(Color.White);
                    }
                    else
                    {
                        start = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Start.bmp");
                        start.MakeTransparent(Color.White);
                    }
                    if (e.X >= 850 && e.Y >= 600 && e.X <= 850 + options.Width && e.Y <= 600 + options.Height)
                    {
                        options = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Optionsg.bmp");
                        options.MakeTransparent(Color.White);
                    }
                    else
                    {
                        options = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Options.bmp");
                        options.MakeTransparent(Color.White);
                    }
                    if (e.X >= 850 && e.Y >= 800 && e.X <= 850 + account.Width && e.Y <= 800 + account.Height)
                    {
                        account = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Accountg.bmp");
                        account.MakeTransparent(Color.White);
                    }
                    else
                    {
                        account = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Account.bmp");
                        account.MakeTransparent(Color.White);
                    }
                    if (e.X >= 850 && e.Y >= 700 && e.X <= 850 + highscores.Width && e.Y <= 700 + highscores.Height)
                    {
                        highscores = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Highscoresg.bmp");
                        highscores.MakeTransparent(Color.White);
                    }
                    else
                    {
                        highscores = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Highscores.bmp");
                        highscores.MakeTransparent(Color.White);
                    }
                }
                if (oah==1)
                {
                    if (e.X>=600&&e.Y>=500&&e.X<=900&&e.Y<=560)
                    {
                        music = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Musicg.bmp");
                        music.MakeTransparent(Color.White);
                    }
                    else
                    {
                        music = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Music.bmp");
                        music.MakeTransparent(Color.White);
                    }
                    if (e.X>=1100&&e.Y>=this.ClientSize.Height - 100&&e.X<=1200&&e.Y<=this.ClientSize.Height-40)
                    {
                        back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Backg.bmp");
                        back.MakeTransparent(Color.White);
                    }
                    else
                    {
                        back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Back.bmp");
                        back.MakeTransparent(Color.White);
                    }
                }
            }
            //-------------------------------------------------------------------------
            //stage 1
            //-------------------------------------------------------------------------
            if (stage==1)
            {
                if (bn>-1&&isup==1)
                {
                    /*con0 = 1;
                    if (con1 > 0&&bn!=con1)
                    {
                        con2 = bn;
                        b2x = e.X;
                        b2y = e.Y;
                    }
                    else
                    {
                        con1 = bn;
                        b1x = e.X;
                        b1y = e.Y;
                    }*/
                    if (e.X > ex + 20 && (e.Y >= ey - 20 || e.Y <= ey + 20))
                    {
                        if (e.X>=(boxx+1 * 100 + s1t1 + 20))
                        {
                            if (startx == 0)
                            {
                                startx = st1b[bn].posx + 50;
                            }
                            endx += 60;
                            boxy++;
                        }
                    }
                    else if (e.X < ex - 20 && (e.Y >= ey - 20 || e.Y <= ey + 20))
                    {
                        if (e.X <= (boxx - 1 * 100 + s1t1 + 20))
                        {
                            if (endx>60)
                            {
                                endx -= 60;
                            }
                            else
                            {
                                startx -= 60;
                            }
                            boxy--;
                        }

                    }
                    else if (e.Y > ey + 20 && (e.X >= ex - 20 || e.X <= ex + 20))
                    {
                        this.Text = "true3";
                    }
                    else if (e.Y < ey - 20 && (e.X >= ex - 20 || e.X <= ex + 20))
                    {
                        this.Text = "true4";
                    }
                    ex = e.X;
                    ey = e.Y;
                }
                if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Backg.bmp");
                    back.MakeTransparent(Color.White);
                }
                else
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Back.bmp");
                    back.MakeTransparent(Color.White);
                }
                if (e.X >= 1300 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1450 && e.Y <= this.ClientSize.Height - 60)
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrowg.bmp");
                    arrow.MakeTransparent(Color.White);
                }
                else
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrow.bmp");
                    arrow.MakeTransparent(Color.White);
                }
            }
            //--------------------------------------------------------------------------
            //Stage 2
            //--------------------------------------------------------------------------
            if (stage==2)
            {
                if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Backg.bmp");
                    back.MakeTransparent(Color.White);
                }
                else
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Back.bmp");
                    back.MakeTransparent(Color.White);
                }
                if (e.X >= 1300 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1450 && e.Y <= this.ClientSize.Height - 60)
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrowg.bmp");
                    arrow.MakeTransparent(Color.White);
                }
                else
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrow.bmp");
                    arrow.MakeTransparent(Color.White);
                }
                if (e.X >= 50 && e.Y >= 50 && e.X <= 150 && e.Y <= 150 && fstart == 0)
                {
                    startst2 = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//startg stage 2.bmp");
                    startst2.MakeTransparent(Color.White);
                }
                else
                {
                    startst2 = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//start stage 2.bmp");
                    startst2.MakeTransparent(Color.White);
                }
            }
            if (stage==3)
            {
                if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Backg.bmp");
                    back.MakeTransparent(Color.White);
                }
                else
                {
                    back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Back.bmp");
                    back.MakeTransparent(Color.White);
                }
                if (e.X >= 1300 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1450 && e.Y <= this.ClientSize.Height - 60)
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrowg.bmp");
                    arrow.MakeTransparent(Color.White);
                }
                else
                {
                    arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrow.bmp");
                    arrow.MakeTransparent(Color.White);
                }
            }
        }

        void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isup = 0;
            ////Stage 1
            ////-------------------------------
            //if (stage == 1)
            //{
            //    bn = -1;
            //}
            //--------------------------------
            //Stage 2
            //--------------------------------
            if (stage == 2)
            {
                if (e.X >= 600 && e.Y >= 250 && e.X <= 850 && e.Y <= 500)
                {
                    b = 0;
                }
                if (e.X >= 860 && e.Y >= 250 && e.X <= 1110 && e.Y <= 500)
                {
                    re = 0;
                }
                if (e.X >= 600 && e.Y >= 510 && e.X <= 850 && e.Y <= 760)
                {
                    gr = 0;
                }
                if (e.X >= 860 && e.Y >= 510 && e.X <= 1110 && e.Y <= 760)
                {
                    y = 0;
                }
            }
            //---------------------------------
        }

        bool ishit(int x, int y, int posx, int posy)
        {
            if (x >= posx && x <= posx + 30 && y >= posy && y <= posy + 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isup = 1;
            //stage 0
            //------------------------------------------------------------------
            if (stage == 0)
            {
                if (oah == 0)
                {
                    if (e.X >= 850 && e.Y >= 500 && e.X <= 850 + start.Width && e.Y <= 500 + start.Height / 2)
                    {
                        stage = 2;
                        this.Text = "Level 1";
                    }
                    if (e.X >= 850 && e.Y >= 600 && e.X <= 850 + options.Width && e.Y <= 600 + options.Height)
                    {
                        oah = 1;
                    }
                    /*if (e.X >= 850 && e.Y >= 800 && e.X <= 850 + account.Width && e.Y <= 800 + account.Height)
                    {
                        oah = 2;
                    }
                    if (e.X >= 850 && e.Y >= 700 && e.X <= 850 + highscores.Width && e.Y <= 700 + highscores.Height)
                    {
                        oah = 3;
                    }*/
                }
                if (oah == 1)
                {
                    if (e.X >= 600 && e.Y >= 500 && e.X <= 900 && e.Y <= 560)
                    {
                        if (mf==0)
                        {
                            mon = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//On.bmp");
                            mon.MakeTransparent(Color.White);
                            moff = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Offg.bmp");
                            moff.MakeTransparent(Color.White);
                            mf = 1;
                            player.Stop();
                        }
                        else if(mf==1)
                        {
                            mon = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Ong.bmp");
                            mon.MakeTransparent(Color.White);
                            moff = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Off.bmp");
                            moff.MakeTransparent(Color.White);
                            mf = 0;
                            player.Play();
                        }
                    }
                    if (e.X>=600&&e.Y>=700&&e.X<=700&&e.Y<=760)
                    {
                        bgc = Color.White;
                    }
                    if (e.X >= 750 && e.Y >= 700 && e.X <= 850 && e.Y <= 760)
                    {
                        bgc = Color.Black;
                    }
                    if (e.X >= 900 && e.Y >= 700 && e.X <= 1000 && e.Y <= 760)
                    {
                        bgc = Color.Blue;
                    }
                    if (e.X >= 1050 && e.Y >= 700 && e.X <= 1150 && e.Y <= 760)
                    {
                        bgc = Color.Brown;
                    }
                    if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                    {
                        oah = 0;
                    }
                }
                //------------------------------------------------------------------
            }
            //Stage 1
            //----------------------------------------------------------------------
            if (stage == 1)
            {
                //Balls
                for (int i = 0; i < 4;i++)
                {
                    if (e.X >= st1b[i].posx && e.Y >= st1b[i].posy && e.X <= st1b[i].posx + 50 && e.Y <= st1b[i].posy + 50)
                    {
                        ex = e.X;
                        ey = e.Y;
                        bn = i;
                        boxx = (st1b[bn].posx - 20 - s1t1) / 100;
                        boxy = (st1b[bn].posy - 10 - s1t2) / 70;
                        break;
                    }
                }
              //Back
              if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
              {
                  string message = "Do You Really Want To Exit And Remove All Progress";
                  string caption = "You Will Lose";
                  MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                  DialogResult result;
                  result = MessageBox.Show(message, caption, buttons);
                  if (result == System.Windows.Forms.DialogResult.Yes)
                  {
                      stage = 0;
                      oah = 0;
                      for (int i = 0; i < st1b.Count; i++)
                      {
                          st1b.RemoveAt(i);
                      }
                      int[] s1posx = { -1, -1, -1, -1 };
                      int[] s1posy = { -1, -1, -1, -1 };
                      int a, b;
                      for (int z = 0; z < 4; z++)
                      {
                          for (; ; )
                          {
                              a = r.Next(6);
                              b = r.Next(6);
                              if (!isExist(a, b, s1posx, s1posy))
                              {
                                  s1posx[z] = a;
                                  s1posy[z] = b;
                                  break;
                              }
                          }
                      }
                      int k = 0;
                      for (int i = 0; i < 4; i++)
                      {
                          stage1balls pnn = new stage1balls();
                          pnn.posx = s1posx[k] * 100 + s1t1 + 20;
                          pnn.posy = s1posy[k] * 70 + s1t2 + 10;
                          if (i == 0)
                          {
                              pnn.iconnect = 2;
                          }
                          if (i == 1)
                          {
                              pnn.iconnect = 3;
                          }
                          if (i == 2)
                          {
                              pnn.iconnect = 0;
                          }
                          if (i == 3)
                          {
                              pnn.iconnect = 1;
                          }
                          st1b.Add(pnn);
                          k++;
                      }
                  }
              }
                //next
                if (e.X >= 1300 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1500 && e.Y <= this.ClientSize.Height - 40)
                {
                    stage = 2;
                }
            }
            //----------------------------------------------------------------------
            //Stage 2
            //----------------------------------------------------------------------
            //back
            if (stage == 2)
            {
                if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                {
                    string message = "Do You Really Want To Exit And Remove All Progress";
                    string caption = "You Will Lose";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        stage = 0;
                        oah = 0;
                    }
                }
                if (e.X >= 600 && e.Y >= 250 && e.X <= 850 && e.Y <= 500)
                {
                    b = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//1.wav";
                    sndPlayer.PlaySync();
                    if (fstart == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (patternuser[i] == -1)
                            {
                                patternuser[i] = 0;
                                break;
                            }
                        }
                    }
                }
                if (e.X >= 860 && e.Y >= 250 && e.X <= 1110 && e.Y <= 500)
                {
                    re = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//2.wav";
                    sndPlayer.PlaySync();
                    if (fstart == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (patternuser[i] == -1)
                            {
                                patternuser[i] = 1;
                                break;
                            }
                        }
                    }
                }
                if (e.X >= 600 && e.Y >= 510 && e.X <= 850 && e.Y <= 760)
                {
                    gr = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//3.wav";
                    sndPlayer.PlaySync();
                    if (fstart == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (patternuser[i] == -1)
                            {
                                patternuser[i] = 2;
                                break;
                            }
                        }
                    }
                }
                if (e.X >= 860 && e.Y >= 510 && e.X <= 1110 && e.Y <= 760)
                {
                    y = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//4.wav";
                    sndPlayer.PlaySync();
                    if (fstart == 1)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (patternuser[i] == -1)
                            {
                                patternuser[i] = 3;
                                break;
                            }
                        }
                    }
                }
                if (e.X >= 50 && e.Y >= 50 && e.X <= 150 && e.Y <= 150 && fstart == 0)
                {
                    stage2music();
                    fstart = 1;
                }
                if (win2 == 1)
                {
                    if (e.X >= 1300 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1500 && e.Y <= this.ClientSize.Height - 40)
                    {
                        stage = 3;
                    }
                }
            }
            //-------------------------------------------------------------------------------------------
            //Stage 3
            //-------------------------------------------------------------------------------------------
            if (stage == 3)
            {
                if (e.X >= 1100 && e.Y >= this.ClientSize.Height - 100 && e.X <= 1200 && e.Y <= this.ClientSize.Height - 40)
                {
                    string message = "Do You Really Want To Exit And Remove All Progress";
                    string caption = "You Will Lose";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        stage = 0;
                        oah = 0;
                    }
                }
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < pers.Count; i++)
                    {
                        if (ishit(e.X, e.Y, pers[i].x, pers[i].y))
                        {
                            if (pers[i].x > 700 && pers[i].y == 630)
                            {
                                pers[i].x = putx3;
                                pers[i].y = 640;
                                putx3 += 15;
                                nop--;
                                nopr++;
                                for (int k = 0; i < 2; i++)
                                {
                                    if (pn[k] == i)
                                    {
                                        pn[k] = -1;
                                    }
                                }
                                putx -= 15;
                            }
                            else if (nop < 2 && ((shipx < 700 && pers[i].x < 700) || (shipx > 700 && pers[i].x > 700)))
                            {
                                if (shipx > 700 && pers[i].x > 700)
                                {
                                    putx3 -= 15;
                                    nopr--;
                                }
                                else
                                {
                                    nopl--;
                                }
                                putx += 15;
                                pers[i].x = putx;
                                pers[i].y = 630;
                                pn[nop] = i;
                                nop++;
                            }
                            break;
                        }
                    }
                    for (int i = 0; i < enem.Count; i++)
                    {
                        if (ishit(e.X, e.Y, enem[i].x, enem[i].y))
                        {
                            if (enem[i].x > 700 && enem[i].y == 630)
                            {
                                enem[i].x = putx4;
                                enem[i].y = 640;
                                putx4 -= 30;
                                nop--;
                                noer++;
                                for (int k = 0; k < 2; k++)
                                {
                                    if (en[k] == i)
                                    {
                                        en[k] = -1;
                                    }
                                }
                                putx2 += 30;
                            }
                            else if (nop < 2 && ((enem[i].x < 700 && shipx < 700) || (enem[i].x > 700 && shipx > 700)))
                            {
                                if (shipx > 700 && enem[i].x > 700)
                                {
                                    putx4 += 30;
                                    noer--;
                                }
                                else
                                {
                                    noel--;
                                }
                                putx2 -= 30;
                                enem[i].x = putx2;
                                enem[i].y = 630;
                                en[nop] = i;
                                nop++;
                            }
                            break;
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (e.X >= 1250)
                    {
                        right = 1;
                    }
                    else if (e.X <= 630)
                    {
                        left = 1;
                    }
                }
            }
        }

        void stage2music()
        {
            for (int i = 0; i < 4; i++)
            {
                pattern[i] = r.Next(4);
            }
            this.Text = "1-->(" + pattern[0] + ")<--2-->(" + pattern[1] + ")<--3-->(" + pattern[2] + ")<--4-->(" + pattern[3] + ")";
            for (int i = 0; i < 4; i++)
            {
                b = 0;
                re = 0;
                gr = 0;
                y = 0;
                if (pattern[i] == 0)
                {
                    b = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//1.wav";
                    sndPlayer.PlaySync();
                }
                if (pattern[i] == 1)
                {
                    re = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//2.wav";
                    sndPlayer.PlaySync();
                }
                if (pattern[i] == 2)
                {
                    gr = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//3.wav";
                    sndPlayer.PlaySync();
                }
                if (pattern[i] == 3)
                {
                    y = 1;
                    drawbuffer(this.CreateGraphics());
                    sndPlayer.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//4.wav";
                    sndPlayer.PlaySync();
                }
            }
            b = 0;
            re = 0;
            gr = 0;
            y = 0;
        }

        bool isExist(int a, int b, int[] s1posx, int[] s1posy)
        {
            for (int i = 0; i < 4; i++)
            {
                if (s1posx[i] == a && s1posy[i] == b)
                {
                    return true;
                }
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgc = Color.Black;
            bg = new Bitmap(ClientSize.Width, ClientSize.Height);
            player.SoundLocation = "D://Cs//CS 232//Assignments//Minigame1//Sources//Melody.wav";
            player.Play();
            start=new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Start.bmp");
            start.MakeTransparent(Color.White);
            options = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Options.bmp");
            options.MakeTransparent(Color.White);
            account = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Account.bmp");
            account.MakeTransparent(Color.White);
            highscores = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Highscores.bmp");
            highscores.MakeTransparent(Color.White);
            mon = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Ong.bmp");
            mon.MakeTransparent(Color.White);
            moff = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Off.bmp");
            moff.MakeTransparent(Color.White);
            back = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Back.bmp");
            back.MakeTransparent(Color.White);
            cbg = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Cbg.bmp");
            cbg.MakeTransparent(Color.White);
            music = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Music.bmp");
            music.MakeTransparent(Color.White);
            startst2 = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//start stage 2.bmp");
            startst2.MakeTransparent(Color.White);
            arrow = new Bitmap("D://Cs//CS 232//Assignments//Minigame1//Sources//Arrow.bmp");
            arrow.MakeTransparent(Color.White);
            int[] s1posx = { -1, -1, -1, -1 };
            int[] s1posy = { -1, -1, -1, -1 };
            int a, b;
            for (int z = 0; z < 4; z++)
            {
                for (; ; )
                {
                    a = r.Next(6);
                    b = r.Next(6);
                    if (!isExist(a, b, s1posx, s1posy))
                    {
                        s1posx[z] = a;
                        s1posy[z] = b;
                        break;
                    }
                }
            }
            bg = new Bitmap(ClientSize.Width, ClientSize.Height);
            back2 = new Bitmap("back.bmp");
            ship = new Bitmap("boat.bmp");
            ship.MakeTransparent(Color.White);
            enemy = new Bitmap("enemy.bmp");
            enemy.MakeTransparent(Color.White);
            person = new Bitmap("actor1.bmp");
            person.MakeTransparent(Color.White);
            person pnn = new person();
            pnn.x = 540;
            pnn.y = 640;
            pers.Add(pnn);
            pnn = new person();
            pnn.x = 520;
            pnn.y = 640;
            pers.Add(pnn);
            pnn = new person();
            pnn.x = 500;
            pnn.y = 640;
            pers.Add(pnn);
            enemy pnn2 = new enemy();
            pnn2.x = 460;
            pnn2.y = 640;
            enem.Add(pnn2);
            pnn2 = new enemy();
            pnn2.x = 440;
            pnn2.y = 640;
            enem.Add(pnn2);
            pnn2 = new enemy();
            pnn2.x = 420;
            pnn2.y = 640;
            enem.Add(pnn2);
            /*MessageBox.Show("--<st-->" + s1posx[0] + "<---->" + s1posy[0]);
            MessageBox.Show("--<st-->" + s1posx[1] + "<---->" + s1posy[1]);
            MessageBox.Show("--<st-->" + s1posx[2] + "<---->" + s1posy[2]);
            MessageBox.Show("--<st-->" + s1posx[3] + "<---->" + s1posy[3]);*/
            int k = 0;
            for (int i=0;i<4;i++)
            {
                stage1balls pnn4 = new stage1balls();
                pnn4.posx = s1posx[k]*100+s1t1+20;
                pnn4.posy = s1posy[k] * 70 + s1t2+10;
                if (i == 0)
                {
                    pnn4.iconnect = 2;
                }
                if (i == 1)
                {
                    pnn4.iconnect = 3;
                }
                if (i == 2)
                {
                    pnn4.iconnect = 0;
                }
                if (i == 3)
                {
                    pnn4.iconnect = 1;
                }
                st1b.Add(pnn4);
                k++;
            }
        }

        void drawbuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(bg);
            drawscene(g2);
            g.DrawImage(bg, 0, 0);
        }

        void drawscene(Graphics g)
        {
            g.Clear(bgc);
            //Stage 0
            //------------------------------------------------------------------------------------------------------------------------------- 0S
            if (stage==0)
            {
                if (oah == 0)
                {
                    g.DrawRectangle(Pens.Aqua, this.ClientSize.Width / 2 - 450, 10, 800, this.ClientSize.Height - 20);
                    g.DrawRectangle(Pens.Blue, this.ClientSize.Width / 2 - 440, 20, 780, this.ClientSize.Height - 40);
                    Font drawFont = new Font("Algerian", 40);
                    SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
                    PointF drawPoint = new PointF(this.ClientSize.Width / 2 - 250, 50.0F);
                    g.DrawString("The Mind Games", drawFont, drawBrush, drawPoint);
                    g.DrawImage(start, 850, 500, 100, 60);
                    g.DrawImage(options, 850, 600, 100, 40);
                    g.DrawImage(highscores, 850, 700, 100, 40);
                    g.DrawImage(account, 850, 800, 100, 40);
                }
                if (oah==1)
                {
                    g.DrawRectangle(Pens.Aqua, this.ClientSize.Width / 2 - 450, 10, 800, this.ClientSize.Height - 20);
                    g.DrawRectangle(Pens.Blue, this.ClientSize.Width / 2 - 440, 20, 780, this.ClientSize.Height - 40);
                    Font drawFont = new Font("Algerian", 40);
                    SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
                    PointF drawPoint = new PointF(this.ClientSize.Width / 2 - 250, 50.0F);
                    g.DrawString("The Mind Games", drawFont, drawBrush, drawPoint);
                    drawFont = new Font("Arial", 40);
                    drawBrush = new SolidBrush(Color.Red);
                    drawPoint = new PointF(this.ClientSize.Width / 2 - 150, 150.0F);
                    g.DrawString("Options", drawFont, drawBrush, drawPoint);
                    g.DrawImage(music, 600, 500, 100, 60);
                    g.DrawImage(mon, 700, 500, 80, 40);
                    g.DrawImage(moff, 800, 500, 100, 60);
                    g.DrawImage(back, 1100, this.ClientSize.Height - 100, 100, 60);
                    g.DrawImage(cbg, 800, 600, 200, 60);
                    g.FillRectangle(Brushes.White, 600, 700, 100, 60);
                    g.FillRectangle(Brushes.Black, 750, 700, 100, 60);
                    g.FillRectangle(Brushes.Blue, 900, 700, 100, 60);
                    g.FillRectangle(Brushes.Brown, 1050, 700, 100, 60);
                }
                if (oah == 2)
                {
                    g.DrawRectangle(Pens.Aqua, this.ClientSize.Width / 2 - 450, 10, 800, this.ClientSize.Height - 20);
                    g.DrawRectangle(Pens.Blue, this.ClientSize.Width / 2 - 440, 20, 780, this.ClientSize.Height - 40);
                    Font drawFont = new Font("Algerian", 40);
                    SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
                    PointF drawPoint = new PointF(this.ClientSize.Width / 2 - 250, 50.0F);
                    g.DrawString("The Mind Games", drawFont, drawBrush, drawPoint);
                    drawFont = new Font("Arial", 40);
                    drawBrush = new SolidBrush(Color.Blue);
                    drawPoint = new PointF(this.ClientSize.Width / 2 - 150, 150.0F);
                    g.DrawString("Account", drawFont, drawBrush, drawPoint);
                }
                if (oah == 3)
                {
                    g.DrawRectangle(Pens.Aqua, this.ClientSize.Width / 2 - 450, 10, 800, this.ClientSize.Height - 20);
                    g.DrawRectangle(Pens.Blue, this.ClientSize.Width / 2 - 440, 20, 780, this.ClientSize.Height - 40);
                    Font drawFont = new Font("Algerian", 40);
                    SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
                    PointF drawPoint = new PointF(this.ClientSize.Width / 2 - 250, 50.0F);
                    g.DrawString("The Mind Games", drawFont, drawBrush, drawPoint);
                    drawFont = new Font("Arial", 40);
                    drawBrush = new SolidBrush(Color.Green);
                    drawPoint = new PointF(this.ClientSize.Width / 2 - 200, 150.0F);
                    g.DrawString("High Scores", drawFont, drawBrush, drawPoint);
                }
            }
            //------------------------------------------------------------------------------------------------------------------------------- 0E
            //Stage 1
            //------------------------------------------------------------------------------------------------------------------------------- 1S
            if (stage==1)
            {
                g.DrawRectangle(Pens.Green, this.ClientSize.Width / 2 - 450, 150, 800, 600);
                g.DrawRectangle(Pens.LawnGreen, this.ClientSize.Width / 2 - 440, 160, 780, 580);
                for (int i=0;i<7;i++)
                {
                    g.DrawLine(Pens.Red, lines, 160, lines, 740);
                    g.DrawLine(Pens.Red, this.ClientSize.Width / 2 - 440, lines2, 1300, lines2);
                    lines += 100;
                    lines2 += 70;
                }
                for (int i=0;i<4;i++)
                {
                    if (i == 0 || i == 2)
                    {
                        g.FillEllipse(Brushes.Gold, st1b[i].posx, st1b[i].posy, 50, 50);
                    }
                    else
                    {
                        g.FillEllipse(Brushes.Green, st1b[i].posx, st1b[i].posy, 50, 50);
                    }
                    g.DrawImage(back, 1100, this.ClientSize.Height - 100, 100, 60);
                    g.DrawImage(arrow, 1300, this.ClientSize.Height - 100, 100, 80);
                }
                if (bn > -1 && isup == 1)
                {
                    g.FillRectangle(Brushes.Yellow, startx, st1b[bn].posy, endx, endy);
                }
                Font drawFont = new Font("Algerian", 40);
                SolidBrush drawBrush = new SolidBrush(Color.GreenYellow);
                PointF drawPoint = new PointF(this.ClientSize.Width / 2 - 150, 50.0F);
                g.DrawString("Level 1", drawFont, drawBrush, drawPoint);
            }
            //------------------------------------------------------------------------------------------------------------------------------- 1E
            //Stage 2
            //------------------------------------------------------------------------------------------------------------------------------- 2S
            if (stage == 2)
            {
                g.DrawImage(startst2, 50, 50, 100, 100);
                g.DrawImage(back, 1100, this.ClientSize.Height - 100, 100, 60);
                if (win2 == 1)
                {
                    g.DrawImage(arrow, 1300, this.ClientSize.Height - 100, 100, 80);
                }
                if (b == 0)
                {
                    g.FillRectangle(Brushes.DarkBlue, 600, 250, 250, 250);
                }
                else
                {
                    g.FillRectangle(Brushes.Blue, 600, 250, 250, 250);
                }
                if (re == 0)
                {
                    g.FillRectangle(Brushes.DarkRed, 860, 250, 250, 250);
                }
                else
                {
                    g.FillRectangle(Brushes.Red, 860, 250, 250, 250);
                }
                if (gr == 0)
                {
                    g.FillRectangle(Brushes.DarkGreen, 600, 510, 250, 250);
                }
                else
                {
                    g.FillRectangle(Brushes.LawnGreen, 600, 510, 250, 250);
                }
                if (y == 0)
                {
                    g.FillRectangle(Brushes.DarkGoldenrod, 860, 510, 250, 250);
                }
                else
                {
                    g.FillRectangle(Brushes.Gold, 860, 510, 250, 250);
                }
            }
            //----------------------------------------------------------------------------
            //Stage3
            //----------------------------------------------------------------------------
            if (stage==3)
            {
                g.Clear(Color.Black);
                g.DrawImage(back2, 0, 0, this.ClientSize.Width, this.ClientSize.Height);
                g.DrawImage(ship, shipx, shipy);
                for (int i = 0; i < pers.Count; i++)
                {
                    g.DrawImage(person, pers[i].x, pers[i].y);
                }
                for (int i = 0; i < enem.Count; i++)
                {
                    g.DrawImage(enemy, enem[i].x, enem[i].y);
                }
                g.DrawImage(back, 1400, this.ClientSize.Height - 100, 100, 60);
                if (win3 == 1)
                {
                    g.DrawImage(arrow, 1300, this.ClientSize.Height - 100, 100, 80);
                }
            }
        }
    }
}
