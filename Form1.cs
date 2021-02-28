using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CoronaProject
{


    public partial class Form1 : Form
    {
        public static int NormalPopulation = 4050;
        public static int SickNumber = 0;
        public static int VaccineNumber = 0;
        public static int ClickCounter = 0;
        public Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void ClickB(object sender, EventArgs e)
        {
            mybutton b = (mybutton)sender;
            if (b.IsAlive == 0)
            {
                b.IsAlive = 1;
                b.IsVaccine = 0;
                b.IsInfected = 0;
                b.BackColor = System.Drawing.Color.White;
            }
            else
            {
                if (b.IsInfected == 0 && b.IsVaccine == 0)
                {
                    b.IsInfected = 1;
                    SickNumber++;
                    b.BackColor = System.Drawing.Color.Red;
                    b.ClickCountStat = ClickCounter;
                }
                else
                {
                    if (b.IsInfected == 1)
                    {
                        SickNumber--;
                        NormalPopulation++;
                        VaccineNumber++;
                        b.IsInfected = 0;
                        b.IsVaccine = 1;
                        b.BackColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        if (b.IsVaccine == 1)
                        {
                            NormalPopulation++;
                            VaccineNumber--;
                            b.IsVaccine = 0;
                            b.IsInfected = 0;
                            b.IsAlive = 1;
                            b.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }


        }
        private void resetBClick(object sender, EventArgs e)
        {
            VaccineNumber = 0;
            NormalPopulation = 4050;
            SickNumber = 0;
            ClickCounter = 0;
            for (int i = 0; i < 90; i++)
                for (int j = 0; j < 45; j++)
                {
                    AllMyButtns[i, j].IsInfected = 0;
                    AllMyButtns[i, j].IsVaccine = 0;
                    AllMyButtns[i, j].IsAlive = 1;
                    AllMyButtns[i, j].BackColor = System.Drawing.Color.White;
                    AllMyButtns[i, j].ClickCountStat = 0;

                }
        }
        private void startBClick(object sender, EventArgs e)
        {
            ClickCounter++;

            point[,] points = new point[90, 45];

            for (int i = 0; i < 90; i++)
                for (int j = 0; j < 45; j++)
                {
                    points[i, j] = new point();
                    points[i, j].X = i;
                    points[i, j].Y = j;
                }


            for (int i = 0; i < 90; i++)
                for (int j = 0; j < 45; j++)
                {
                    int x = rnd.Next(0, 89);
                    int y = rnd.Next(0, 44);

                    point temp = new point();

                    temp.X = points[i, j].X;
                    temp.Y = points[i, j].Y;

                    points[i, j].X = points[x, y].X;
                    points[i, j].Y = points[x, y].Y;

                    points[x, y].X = temp.X;
                    points[x, y].Y = temp.Y;
                }


            for (int i = 0; i < 90; i++)
                for (int j = 0; j < 45; j++)
                {
                    InfactionFunction(AllMyButtns[points[i, j].X, points[i, j].Y]);
                }

        }

        public void Sick(mybutton b, int NOS)
        {
            double NotInfectionRatio = 1 - float.Parse(this.diseaseNUM.Text.ToString());
            int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, NOS) * 100);

            if (rnd.Next(0, 100) >= sickchan)
            {
                SickNumber++;
                b.BackColor = System.Drawing.Color.Red;
                b.ClickCountStat = ClickCounter;
                b.IsInfected = 1;
            }
        }

        public void InfactionFunction(object O)
        {

            mybutton b = (mybutton)O;

            double NotInfectionRatio = 1 - float.Parse(this.diseaseNUM.Text.ToString());
            if (b.IsAlive == 1)
            {
                if (b.IsInfected == 0)
                {
                    if (b.IsVaccine == 0)
                    {
                        if (b.Y > 0 && b.Y < 44)
                        {
                            if (b.X > 0 && b.X < 89)
                            {
                                int numOfSICKS = AllMyButtns[b.X - 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y + 1].IsInfected;


                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);


                            }
                            else if (b.X == 0)
                            {
                                int numOfSICKS = AllMyButtns[b.X, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y + 1].IsInfected;

                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }

                            else if (b.X == 89)
                            {
                                int numOfSICKS = AllMyButtns[b.X - 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);


                            }
                        }
                        else if (b.Y == 0)
                        {
                            if (b.X > 0 && b.X < 89)
                            {
                                int numOfSICKS =
                                                 AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y + 1].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                            else if (b.X == 0)
                            {
                                int numOfSICKS = AllMyButtns[b.X + 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y + 1].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                            else if (b.X == 89)
                            {
                                int numOfSICKS = AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y + 1].IsInfected +
                                                 AllMyButtns[b.X, b.Y + 1].IsInfected;

                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                        }
                        else if (b.Y == 44)
                        {
                            if (b.X > 0 && b.X < 89)
                            {
                                int numOfSICKS = AllMyButtns[b.X - 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                            else if (b.X == 0)
                            {
                                int numOfSICKS = AllMyButtns[b.X, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X + 1, b.Y].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                            else if (b.X == 89)
                            {
                                int numOfSICKS = AllMyButtns[b.X - 1, b.Y - 1].IsInfected +
                                                 AllMyButtns[b.X - 1, b.Y].IsInfected +
                                                 AllMyButtns[b.X, b.Y - 1].IsInfected;
                                int sickchan = Convert.ToInt32(Math.Pow(NotInfectionRatio, numOfSICKS) * 100);

                                Sick(b, numOfSICKS);
                            }
                        }
                    }

                }
                else
                {


                    if (ClickCounter >= (b.ClickCountStat + 4))
                    {
                        if (rnd.Next(0, 100) <=  Lethality.Value)
                        {
                            NormalPopulation--;
                            b.IsAlive = 0;
                            b.BackColor = System.Drawing.Color.Black;
                            b.IsInfected = 0;
                        }
                        else
                        {
                            NormalPopulation--;
                            b.IsInfected = 0;
                            b.IsVaccine = 1;
                            b.BackColor = System.Drawing.Color.Blue;
                        }
                    }
                }
            }

        }



    }
}

