using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LakoparkProjekt
{
    public partial class Form1 : Form
    {
        HappyLiving happyLiving = new HappyLiving(new List<Lakopark>());
        int page = 0;
        string kepek = @"..//../Kepek/";



        public Form1()
        {
            InitializeComponent();
        }

        //Ha egy házra bal egérgombbal rákattintunk, akkor az adatszerkezetben tárolt szintszáma növekedjen eggyel, és jelenjen meg az ennek megfelelő kép!
        //A nyilakat csak akkor jeleníti meg, ha valóban lehet az adott irányban lapozni!
        private void pages()
        {
            //Bal nyíl
            if (page > 0)
            {
                btnbalnyil.ImageLocation = kepek + "balnyil.jpg";
                btnbalnyil.Enabled = true;

            }
            else
            {
                btnbalnyil.ImageLocation = "";
                btnbalnyil.Enabled = false;

            }
            //Jobb nyíl
            if (page < 2)
            {
                btnjobbnyil.ImageLocation = kepek + "jobbnyil.jpg";
                btnjobbnyil.Enabled = true;
            }
            else
            {
                btnjobbnyil.ImageLocation = "";
                btnjobbnyil.Enabled = false;
            }
        }

        //Pictureboxok létrehozása
        private void hazakLoad(Lakopark lp)
        {
            panel1.Controls.Clear();
            namePic.ImageLocation = kepek + happyLiving.Lakoparkok[page].Nev + ".jpg";
            namePic.SizeMode = PictureBoxSizeMode.Zoom;
            int size = 60;
            for (int i = 0; i < lp.UtcakSzama; i++)
            {
                for (int j = 0; j < lp.MaxHazSzam; j++)
                {
                    PictureBox PB = new PictureBox();
                    PB.SizeMode = PictureBoxSizeMode.Zoom;
                    PB.BorderStyle = BorderStyle.FixedSingle;
                    PB.SetBounds(i * size, j * size, size, size);
                    PB.Name = $"{i};{j}";
                    pbLoad(PB, i, j);
                    PB.Click += (o, oe) =>
                    {
                        int[,] hazak = happyLiving.Lakoparkok[page].Hazak;
                        PictureBox bpb = (PictureBox)o;
                        int[] tmp = Array.ConvertAll(bpb.Name.Split(';'), int.Parse);
                        int a = tmp[0];
                        int b = tmp[1];
                        if (hazak[a, b] + 1 > 3)
                        {
                            hazak[a, b] = 0;
                        }
                        else
                        {
                            hazak[a, b] = hazak[a, b] += 1;
                        }
                        pbLoad(bpb, a, b);
                    };
                    panel1.Controls.Add(PB);
                }
            }
        }

        //Házak betöltése
        private void pbLoad(PictureBox pb, int a, int b)
        {
            string hazak = kepek + @"Haz" + happyLiving.Lakoparkok[page].Hazak[a, b] + ".jpg";
            string kereszt = kepek + @"kereszt.jpg";
            if (File.Exists(hazak))
            {
                pb.ImageLocation = hazak;
            }
            else
            {
                pb.ImageLocation = kereszt;
            }
        }

        //lakoparkok.txt file kezelése
        private Lakopark lpLoad(string txt)
        {
            string[] splitted = txt.Split('\n');
            int[] tmp = Array.ConvertAll(splitted[1].Split(';'), int.Parse);
            int[,] pbs = new int[tmp[1], tmp[0]];
            for (int i = 2; i < splitted.Length; i++)
            {
                int[] haz = Array.ConvertAll(splitted[i].Split(';'), int.Parse);
                pbs[haz[1] - 1, haz[0] - 1] = haz[2];
            }
            return new Lakopark(pbs, tmp[0], splitted[0].Replace("\r", ""), tmp[1]);
        }

        //lakoparkok.txt file betöltése
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lakoparktxt = Regex.Split(File.ReadAllText(@"..//../lakoparkok.txt"), Environment.NewLine + Environment.NewLine);
            for (int i = 0; i < lakoparktxt.Length - 1; i++)
            {
                happyLiving.Lakoparkok.Add(lpLoad(lakoparktxt[i]));
            }
            hazakLoad(happyLiving.Lakoparkok[page]);
            pages();
        }

        //mentés
        private void save_Click(object sender, EventArgs e)
        {
            string[] date = Regex.Split(DateTime.Now.ToString(), ". ");

            //A mentés előtt biztonsági másolatot készít a fájlról, amelynek nevében szerepel az aktuális dátum és időpont 
            File.Move(@"..//../lakoparkok.txt", $"..//../lakoparkok_{date[0]}{date[1]}{date[2]}_{date[3].Replace(":", "")}.txt");
            string lpSave = "";
            foreach (Lakopark lp in happyLiving.Lakoparkok)
            {
                lpSave += $"{lp.Nev}{Environment.NewLine}{lp.MaxHazSzam};{lp.UtcakSzama}{Environment.NewLine}";
                for (int x = 0; x < lp.Hazak.GetLength(0); x++)
                {
                    for (int y = 0; y < lp.Hazak.GetLength(1); y++)
                    {
                        if (lp.Hazak[x, y] == 0)
                        {
                            lpSave += "";
                        }
                        else
                        {
                            lpSave += $"{y + 1};{x + 1};{lp.Hazak[x, y]}{Environment.NewLine}";
                        }
                    }
                }
                lpSave += Environment.NewLine;
            }
            File.WriteAllText(@"..//../lakoparkok.txt", lpSave);

            //A sikeres/sikertelen mentésről a program visszajelzést ad!
            if (File.Exists($"..//../lakoparkok_{date[0]}{date[1]}{date[2]}_{date[3].Replace(":", "")}.txt"))
            {
                MessageBox.Show("Sikeres Mentés");
            }
            else
            {
                MessageBox.Show("Sikertelen Mentés");

            }

        }

        //Bal nyíl
        private void btnjobbnyil_Click(object sender, EventArgs e)
        {
            page++;
            hazakLoad(happyLiving.Lakoparkok[page]);
            pages();
        }
        //Jobb nyíl
        private void btnbalnyil_Click(object sender, EventArgs e)
        {
            page--;
            hazakLoad(happyLiving.Lakoparkok[page]);
            pages();
        }
    }
}