using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Printing;

namespace Orman_Takip_Programı
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
        }
        Form kucukHarita = new Form();
        object pbAgacName = null;
        bool grsControl = false;
        string[] hamAgacVeri;
        string[] grublanmisAgacVeri;
        string hangiAgac="";
        Giris grs = new Giris();
        private void pnlYeniClick(object sender, EventArgs e)
        {
            MessageBox.Show("çalıştı");
        }
        private void mainForm_Load(object sender, EventArgs e)
        {
            //Panel pnlyeni = new Panel();
            ////pnlyeni.Dock = DockStyle.Fill;
            //pnlyeni.Click += new EventHandler(pnlYeniClick);
            //pnlyeni.BackColor = Color.Firebrick;
            //this.Controls.Add(pnlyeni);
            
            if (grsControl == false)
            {
                grsControl = true;
                grs.ShowDialog();
                if (grs.control == false)
                {
                    grpBoxAgacIslem.Enabled = false;
                    grpBoxKIslem.Enabled = false;
                    grpBoxAgacList.BackColor = Color.ForestGreen;
                }
            }
            bool control = false;
            grublanmisAgacVeri = new string[90];
            int cHeight = 650, cWidth = 905;
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.Height = 650;
                this.Width= 905;
                control = true;
            }
            else if (this.Width != 905 || this.Height != 650)
            {
                cHeight = this.Height;
                cWidth = this.Width;
                this.Height = 650;
                this.Width = 905;
            }
            Veritabani veritabani = new Veritabani();
            string gelenHamAgacVeri=veritabani.agacListele();
            pnlAna.Size = new Size(Convert.ToInt32(this.Width * 0.95f), Convert.ToInt32(this.Height * 0.90f));
            pnlAna.Location = new Point(Convert.ToInt32((this.Width * 0.02f)), Convert.ToInt32((this.Height * 0.02f)));
            hamAgacVeri = gelenHamAgacVeri.Split('-');
            haritaIslemleri();
            if (control == true)
            {
                this.WindowState = FormWindowState.Maximized;
                control = false;
            }
            this.Height = cHeight;
            this.Width = cWidth;
            
        }

        public void haritaIslemleri()
        {

            int wboyut = (pnlHarita.Width / 100) * 20;
            int hboyut = (pnlHarita.Height / 100) * 20;
            int xkonum = 0;
            int ykonum = 0;
            int[] sayi = new int[90];
            for(int i = 0; i < 90; i++)
            {
                sayi[0] = 0;
            }
            #region Agac_VeriSaymaveVeriGrublama
            
            foreach (string veri in hamAgacVeri)
            {
                string[] islenmisVeri = veri.Split(':');
                if (islenmisVeri[0] == "1")
                {
                    grublanmisAgacVeri[0] = grublanmisAgacVeri[0] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[0] = sayi[0] + 1;
                }
                else if (islenmisVeri[0] == "2")
                {
                    grublanmisAgacVeri[1] = grublanmisAgacVeri[1] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[1] = sayi[1] + 1;
                }
                else if (islenmisVeri[0] == "3")
                {
                    grublanmisAgacVeri[2] = grublanmisAgacVeri[2] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[2] = sayi[2] + 1;
                }
                else if (islenmisVeri[0] == "4")
                {
                    grublanmisAgacVeri[3] = grublanmisAgacVeri[3] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[3] = sayi[3] + 1;
                }
                else if (islenmisVeri[0] == "5")
                {
                    grublanmisAgacVeri[4] = grublanmisAgacVeri[4] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[4] = sayi[4] + 1;
                }
                else if (islenmisVeri[0] == "6")
                {
                    grublanmisAgacVeri[5] = grublanmisAgacVeri[5] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[5] = sayi[5] + 1;
                }
                else if (islenmisVeri[0] == "7")
                {
                    grublanmisAgacVeri[6] = grublanmisAgacVeri[6] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[6] = sayi[6] + 1;
                }
                else if (islenmisVeri[0] == "8")
                {
                    grublanmisAgacVeri[7] = grublanmisAgacVeri[7] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[7] = sayi[7] + 1;
                }
                else if (islenmisVeri[0] == "9")
                {
                    grublanmisAgacVeri[8] = grublanmisAgacVeri[8] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[8] = sayi[8] + 1;
                }
                else if (islenmisVeri[0] == "10")
                {
                    grublanmisAgacVeri[9] = grublanmisAgacVeri[9] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[9] = sayi[9] + 1;
                }
                else if (islenmisVeri[0] == "11")
                {
                    grublanmisAgacVeri[10] = grublanmisAgacVeri[10] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[10] = sayi[10] + 1;
                }
                else if (islenmisVeri[0] == "12")
                {
                    grublanmisAgacVeri[11] = grublanmisAgacVeri[11] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[11] = sayi[11] + 1;
                }
                else if (islenmisVeri[0] == "13")
                {
                    grublanmisAgacVeri[12] = grublanmisAgacVeri[12] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[12] = sayi[12] + 1;
                }
                else if (islenmisVeri[0] == "14")
                {
                    grublanmisAgacVeri[13] = grublanmisAgacVeri[13] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[13] = sayi[13] + 1;
                }
                else if (islenmisVeri[0] == "15")
                {
                    grublanmisAgacVeri[14] = grublanmisAgacVeri[14] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[14] = sayi[14] + 1;
                }
                else if (islenmisVeri[0] == "16")
                {
                    grublanmisAgacVeri[15] = grublanmisAgacVeri[15] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[15] = sayi[15] + 1;
                }
                else if (islenmisVeri[0] == "17")
                {
                    grublanmisAgacVeri[16] = grublanmisAgacVeri[16] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[16] = sayi[16] + 1;
                }
                else if (islenmisVeri[0] == "18")
                {
                    grublanmisAgacVeri[17] = grublanmisAgacVeri[17] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[17] = sayi[17] + 1;
                }
                else if (islenmisVeri[0] == "19")
                {
                    grublanmisAgacVeri[18] = grublanmisAgacVeri[18] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[18] = sayi[18] + 1;
                }
                else if (islenmisVeri[0] == "20")
                {
                    grublanmisAgacVeri[19] = grublanmisAgacVeri[19] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[19] = sayi[19] + 1;
                }
                else if (islenmisVeri[0] == "21")
                {
                    grublanmisAgacVeri[20] = grublanmisAgacVeri[20] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[20] = sayi[20] + 1;
                }
                else if (islenmisVeri[0] == "22")
                {
                    grublanmisAgacVeri[21] = grublanmisAgacVeri[21] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[21] = sayi[21] + 1;
                }
                else if (islenmisVeri[0] == "23")
                {
                    grublanmisAgacVeri[22] = grublanmisAgacVeri[22] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[22] = sayi[22] + 1;
                }
                else if (islenmisVeri[0] == "24")
                {
                    grublanmisAgacVeri[23] = grublanmisAgacVeri[23] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[23] = sayi[23] + 1;
                }
                else if (islenmisVeri[0] == "25")
                {
                    grublanmisAgacVeri[24] = grublanmisAgacVeri[24] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[24] = sayi[24] + 1;
                }
                else if (islenmisVeri[0] == "26")
                {
                    grublanmisAgacVeri[25] = grublanmisAgacVeri[25] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[25] = sayi[25] + 1;
                }
                else if (islenmisVeri[0] == "27")
                {
                    grublanmisAgacVeri[26] = grublanmisAgacVeri[26] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[26] = sayi[26] + 1;
                }
                else if (islenmisVeri[0] == "28")
                {
                    grublanmisAgacVeri[27] = grublanmisAgacVeri[27] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[27] = sayi[27] + 1;
                }
                else if (islenmisVeri[0] == "29")
                {
                    grublanmisAgacVeri[28] = grublanmisAgacVeri[28] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[28] = sayi[28] + 1;
                }
                else if (islenmisVeri[0] == "30")
                {
                    grublanmisAgacVeri[29] = grublanmisAgacVeri[29] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[29] = sayi[29] + 1;
                }
                else if (islenmisVeri[0] == "31")
                {
                    grublanmisAgacVeri[30] = grublanmisAgacVeri[30] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[30] = sayi[30] + 1;
                }
                else if (islenmisVeri[0] == "32")
                {
                    grublanmisAgacVeri[31] = grublanmisAgacVeri[31] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[31] = sayi[31] + 1;
                }
                else if (islenmisVeri[0] == "33")
                {
                    grublanmisAgacVeri[32] = grublanmisAgacVeri[32] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[32] = sayi[32] + 1;
                }
                else if (islenmisVeri[0] == "34")
                {
                    grublanmisAgacVeri[33] = grublanmisAgacVeri[33] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[33] = sayi[33] + 1;
                }
                else if (islenmisVeri[0] == "35")
                {
                    grublanmisAgacVeri[34] = grublanmisAgacVeri[34] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[34] = sayi[34] + 1;
                }
                else if (islenmisVeri[0] == "36")
                {
                    grublanmisAgacVeri[35] = grublanmisAgacVeri[35] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[35] = sayi[35] + 1;
                }
                else if (islenmisVeri[0] == "37")
                {
                    grublanmisAgacVeri[36] = grublanmisAgacVeri[36] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[36] = sayi[36] + 1;
                }
                else if (islenmisVeri[0] == "38")
                {
                    grublanmisAgacVeri[37] = grublanmisAgacVeri[37] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[37] = sayi[37] + 1;
                }
                else if (islenmisVeri[0] == "39")
                {
                    grublanmisAgacVeri[38] = grublanmisAgacVeri[38] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[38] = sayi[38] + 1;
                }
                else if (islenmisVeri[0] == "40")
                {
                    grublanmisAgacVeri[39] = grublanmisAgacVeri[39] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[39] = sayi[39] + 1;
                }
                else if (islenmisVeri[0] == "41")
                {
                    grublanmisAgacVeri[40] = grublanmisAgacVeri[40] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[40] = sayi[40] + 1;
                }
                else if (islenmisVeri[0] == "42")
                {
                    grublanmisAgacVeri[41] = grublanmisAgacVeri[41] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[41] = sayi[41] + 1;
                }
                else if (islenmisVeri[0] == "43")
                {
                    grublanmisAgacVeri[42] = grublanmisAgacVeri[42] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[42] = sayi[42] + 1;
                }
                else if (islenmisVeri[0] == "44")
                {
                    grublanmisAgacVeri[43] = grublanmisAgacVeri[43] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[43] = sayi[43] + 1;
                }
                else if (islenmisVeri[0] == "45")
                {
                    grublanmisAgacVeri[44] = grublanmisAgacVeri[44] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[44] = sayi[44] + 1;
                }
                else if (islenmisVeri[0] == "46")
                {
                    grublanmisAgacVeri[45] = grublanmisAgacVeri[45] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[45] = sayi[45] + 1;
                }
                else if (islenmisVeri[0] == "47")
                {
                    grublanmisAgacVeri[46] = grublanmisAgacVeri[46] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[46] = sayi[46] + 1;
                }
                else if (islenmisVeri[0] == "48")
                {
                    grublanmisAgacVeri[47] = grublanmisAgacVeri[47] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[47] = sayi[47] + 1;
                }
                else if (islenmisVeri[0] == "49")
                {
                    grublanmisAgacVeri[48] = grublanmisAgacVeri[48] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[48] = sayi[48] + 1;
                }
                else if (islenmisVeri[0] == "50")
                {
                    grublanmisAgacVeri[49] = grublanmisAgacVeri[49] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[49] = sayi[49] + 1;
                }
                else if (islenmisVeri[0] == "51")
                {
                    grublanmisAgacVeri[50] = grublanmisAgacVeri[50] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[50] = sayi[50] + 1;
                }
                else if (islenmisVeri[0] == "52")
                {
                    grublanmisAgacVeri[51] = grublanmisAgacVeri[51] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[51] = sayi[51] + 1;
                }
                else if (islenmisVeri[0] == "53")
                {
                    grublanmisAgacVeri[52] = grublanmisAgacVeri[52] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[52] = sayi[52] + 1;
                }
                else if (islenmisVeri[0] == "54")
                {
                    grublanmisAgacVeri[53] = grublanmisAgacVeri[53] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[53] = sayi[53] + 1;
                }
                else if (islenmisVeri[0] == "55")
                {
                    grublanmisAgacVeri[54] = grublanmisAgacVeri[54] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[54] = sayi[54] + 1;
                }
                else if (islenmisVeri[0] == "56")
                {
                    grublanmisAgacVeri[55] = grublanmisAgacVeri[55] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[55] = sayi[55] + 1;
                }
                else if (islenmisVeri[0] == "57")
                {
                    grublanmisAgacVeri[56] = grublanmisAgacVeri[56] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[56] = sayi[56] + 1;
                }
                else if (islenmisVeri[0] == "58")
                {
                    grublanmisAgacVeri[57] = grublanmisAgacVeri[57] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[57] = sayi[57] + 1;
                }
                else if (islenmisVeri[0] == "59")
                {
                    grublanmisAgacVeri[58] = grublanmisAgacVeri[58] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[58] = sayi[58] + 1;
                }
                else if (islenmisVeri[0] == "60")
                {
                    grublanmisAgacVeri[59] = grublanmisAgacVeri[59] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[59] = sayi[59] + 1;
                }
                else if (islenmisVeri[0] == "61")
                {
                    grublanmisAgacVeri[60] = grublanmisAgacVeri[60] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[60] = sayi[60] + 1;
                }
                else if (islenmisVeri[0] == "62")
                {
                    grublanmisAgacVeri[61] = grublanmisAgacVeri[61] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[61] = sayi[61] + 1;
                }
                else if (islenmisVeri[0] == "63")
                {
                    grublanmisAgacVeri[62] = grublanmisAgacVeri[62] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[62] = sayi[62] + 1;
                }
                else if (islenmisVeri[0] == "64")
                {
                    grublanmisAgacVeri[63] = grublanmisAgacVeri[63] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[63] = sayi[63] + 1;
                }
                else if (islenmisVeri[0] == "65")
                {
                    grublanmisAgacVeri[64] = grublanmisAgacVeri[64] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[64] = sayi[64] + 1;
                }
                else if (islenmisVeri[0] == "66")
                {
                    grublanmisAgacVeri[65] = grublanmisAgacVeri[65] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[65] = sayi[65] + 1;
                }
                else if (islenmisVeri[0] == "67")
                {
                    grublanmisAgacVeri[66] = grublanmisAgacVeri[66] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[66] = sayi[66] + 1;
                }
                else if (islenmisVeri[0] == "68")
                {
                    grublanmisAgacVeri[67] = grublanmisAgacVeri[67] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[67] = sayi[67] + 1;
                }
                else if (islenmisVeri[0] == "69")
                {
                    grublanmisAgacVeri[68] = grublanmisAgacVeri[68] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[68] = sayi[68] + 1;
                }
                else if (islenmisVeri[0] == "70")
                {
                    grublanmisAgacVeri[69] = grublanmisAgacVeri[69] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[69] = sayi[69] + 1;
                }
                else if (islenmisVeri[0] == "71")
                {
                    grublanmisAgacVeri[70] = grublanmisAgacVeri[70] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[70] = sayi[70] + 1;
                }
                else if (islenmisVeri[0] == "72")
                {
                    grublanmisAgacVeri[71] = grublanmisAgacVeri[71] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[71] = sayi[71] + 1;
                }
                else if (islenmisVeri[0] == "73")
                {
                    grublanmisAgacVeri[72] = grublanmisAgacVeri[72] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[72] = sayi[72] + 1;
                }
                else if (islenmisVeri[0] == "74")
                {
                    grublanmisAgacVeri[73] = grublanmisAgacVeri[73] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[73] = sayi[73] + 1;
                }
                else if (islenmisVeri[0] == "75")
                {
                    grublanmisAgacVeri[74] = grublanmisAgacVeri[74] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[74] = sayi[74] + 1;
                }
                else if (islenmisVeri[0] == "76")
                {
                    grublanmisAgacVeri[75] = grublanmisAgacVeri[75] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[75] = sayi[75] + 1;
                }
                else if (islenmisVeri[0] == "77")
                {
                    grublanmisAgacVeri[76] = grublanmisAgacVeri[76] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[76] = sayi[76] + 1;
                }
                else if (islenmisVeri[0] == "78")
                {
                    grublanmisAgacVeri[77] = grublanmisAgacVeri[77] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[77] = sayi[77] + 1;
                }
                else if (islenmisVeri[0] == "79")
                {
                    grublanmisAgacVeri[78] = grublanmisAgacVeri[78] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[78] = sayi[78] + 1;
                }
                else if (islenmisVeri[0] == "80")
                {
                    grublanmisAgacVeri[79] = grublanmisAgacVeri[79] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[79] = sayi[79] + 1;
                }
                else if (islenmisVeri[0] == "81")
                {
                    grublanmisAgacVeri[80] = grublanmisAgacVeri[80] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[80] = sayi[80] + 1;
                }
                else if (islenmisVeri[0] == "82")
                {
                    grublanmisAgacVeri[81] = grublanmisAgacVeri[81] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[81] = sayi[81] + 1;
                }
                else if (islenmisVeri[0] == "83")
                {
                    grublanmisAgacVeri[82] = grublanmisAgacVeri[82] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[82] = sayi[82] + 1;
                }
                else if (islenmisVeri[0] == "84")
                {
                    grublanmisAgacVeri[83] = grublanmisAgacVeri[83] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[83] = sayi[83] + 1;
                }
                else if (islenmisVeri[0] == "85")
                {
                    grublanmisAgacVeri[84] = grublanmisAgacVeri[84] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[84] = sayi[84] + 1;
                }
                else if (islenmisVeri[0] == "86")
                {
                    grublanmisAgacVeri[85] = grublanmisAgacVeri[85] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[85] = sayi[85] + 1;
                }
                else if (islenmisVeri[0] == "87")
                {
                    grublanmisAgacVeri[86] = grublanmisAgacVeri[86] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[86] = sayi[86] + 1;
                }
                else if (islenmisVeri[0] == "88")
                {
                    grublanmisAgacVeri[87] = grublanmisAgacVeri[87] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[87] = sayi[87] + 1;
                }
                else if (islenmisVeri[0] == "89")
                {
                    grublanmisAgacVeri[88] = grublanmisAgacVeri[88] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[88] = sayi[88] + 1;
                }
                else if (islenmisVeri[0] == "90")
                {
                    grublanmisAgacVeri[89] = grublanmisAgacVeri[89] + "-" + islenmisVeri[0] + ":" + islenmisVeri[1] + ":" + islenmisVeri[2] + ":" + islenmisVeri[3] + ":" + islenmisVeri[4] + ":" + islenmisVeri[5] + ":" + islenmisVeri[6] + ":" + islenmisVeri[7] + ":" + islenmisVeri[8] + ":" + islenmisVeri[9] + ":" + islenmisVeri[10] + ":" + islenmisVeri[11];
                    sayi[89] = sayi[89] + 1;
                }
            }
            lblSayi1.Text = sayi[0].ToString();
            lblSayi2.Text = sayi[1].ToString();
            lblSayi3.Text = sayi[2].ToString();
            lblSayi4.Text = sayi[3].ToString();
            lblSayi5.Text = sayi[4].ToString();
            lblSayi6.Text = sayi[5].ToString();
            lblSayi7.Text = sayi[6].ToString();
            lblSayi8.Text = sayi[7].ToString();
            lblSayi9.Text = sayi[8].ToString();
            lblSayi10.Text = sayi[9].ToString();
            lblSayi11.Text = sayi[10].ToString();
            lblSayi12.Text = sayi[11].ToString();
            lblSayi13.Text = sayi[12].ToString();
            lblSayi14.Text = sayi[13].ToString();
            lblSayi15.Text = sayi[14].ToString();
            lblSayi16.Text = sayi[15].ToString();
            lblSayi17.Text = sayi[16].ToString();
            lblSayi18.Text = sayi[17].ToString();
            lblSayi19.Text = sayi[18].ToString();
            lblSayi20.Text = sayi[19].ToString();
            lblSayi21.Text = sayi[20].ToString();
            lblSayi22.Text = sayi[21].ToString();
            lblSayi23.Text = sayi[22].ToString();
            lblSayi24.Text = sayi[23].ToString();
            lblSayi25.Text = sayi[24].ToString();
            lblSayi26.Text = sayi[25].ToString();
            lblSayi27.Text = sayi[26].ToString();
            lblSayi28.Text = sayi[27].ToString();
            lblSayi29.Text = sayi[28].ToString();
            lblSayi30.Text = sayi[29].ToString();
            lblSayi31.Text = sayi[30].ToString();
            lblSayi32.Text = sayi[31].ToString();
            lblSayi33.Text = sayi[32].ToString();
            lblSayi34.Text = sayi[33].ToString();
            lblSayi35.Text = sayi[34].ToString();
            lblSayi36.Text = sayi[35].ToString();
            lblSayi37.Text = sayi[36].ToString();
            lblSayi38.Text = sayi[37].ToString();
            lblSayi39.Text = sayi[38].ToString();
            lblSayi40.Text = sayi[39].ToString();
            lblSayi41.Text = sayi[40].ToString();
            lblSayi42.Text = sayi[41].ToString();
            lblSayi43.Text = sayi[42].ToString();
            lblSayi44.Text = sayi[43].ToString();
            lblSayi45.Text = sayi[44].ToString();
            lblSayi46.Text = sayi[45].ToString();
            lblSayi47.Text = sayi[46].ToString();
            lblSayi48.Text = sayi[47].ToString();
            lblSayi49.Text = sayi[48].ToString();
            lblSayi50.Text = sayi[49].ToString();
            lblSayi51.Text = sayi[50].ToString();
            lblSayi52.Text = sayi[51].ToString();
            lblSayi53.Text = sayi[52].ToString();
            lblSayi54.Text = sayi[53].ToString();
            lblSayi55.Text = sayi[54].ToString();
            lblSayi56.Text = sayi[55].ToString();
            lblSayi57.Text = sayi[56].ToString();
            lblSayi58.Text = sayi[57].ToString();
            lblSayi59.Text = sayi[58].ToString();
            lblSayi60.Text = sayi[59].ToString();
            lblSayi61.Text = sayi[60].ToString();
            lblSayi62.Text = sayi[61].ToString();
            lblSayi63.Text = sayi[62].ToString();
            lblSayi64.Text = sayi[63].ToString();
            lblSayi65.Text = sayi[64].ToString();
            lblSayi66.Text = sayi[65].ToString();
            lblSayi67.Text = sayi[66].ToString();
            lblSayi68.Text = sayi[67].ToString();
            lblSayi69.Text = sayi[68].ToString();
            lblSayi70.Text = sayi[69].ToString();
            lblSayi71.Text = sayi[70].ToString();
            lblSayi72.Text = sayi[71].ToString();
            lblSayi73.Text = sayi[72].ToString();
            lblSayi74.Text = sayi[73].ToString();
            lblSayi75.Text = sayi[74].ToString();
            lblSayi76.Text = sayi[75].ToString();
            lblSayi77.Text = sayi[76].ToString();
            lblSayi78.Text = sayi[77].ToString();
            lblSayi79.Text = sayi[78].ToString();
            lblSayi80.Text = sayi[79].ToString();
            lblSayi81.Text = sayi[80].ToString();
            lblSayi82.Text = sayi[81].ToString();
            lblSayi83.Text = sayi[82].ToString();
            lblSayi84.Text = sayi[83].ToString();
            lblSayi85.Text = sayi[84].ToString();
            lblSayi86.Text = sayi[85].ToString();
            lblSayi87.Text = sayi[86].ToString();
            lblSayi88.Text = sayi[87].ToString();
            lblSayi89.Text = sayi[88].ToString();
            lblSayi90.Text = sayi[89].ToString();

            #endregion
            #region lblSayiRenklendirme
            //6,7,15,16,17,18,35,37
            lblSayi1.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi2.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi3.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi4.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi5.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi6.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi7.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi8.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi9.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi10.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi11.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi12.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi13.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi14.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi15.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi16.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi17.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi18.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi19.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi20.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi21.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi22.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi23.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi24.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi25.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi26.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi27.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi28.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi29.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi30.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi31.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi32.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi33.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi34.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi35.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi36.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi37.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi38.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi39.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi40.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi41.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi42.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi43.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi44.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi45.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi46.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi47.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi48.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi49.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi50.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi51.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi52.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi53.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi54.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi55.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi56.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi57.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi58.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi59.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi60.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi61.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi62.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi63.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi64.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi65.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi66.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi67.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi68.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi69.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi70.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi71.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi72.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi73.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi74.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi75.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi76.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi77.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi78.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi79.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi80.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi81.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi82.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi83.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi84.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi85.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi86.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi87.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi88.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi89.BackColor = Color.FromArgb(248, 246, 243);
            lblSayi90.BackColor = Color.FromArgb(248, 246, 243);
            #endregion
            #region Harita_PictureBoxlarıBoyutlandırma

            pbHarita1.Width = wboyut;
            pbHarita1.Height = hboyut;
            pbHarita2.Width = wboyut;
            pbHarita2.Height = hboyut;
            pbHarita3.Width = wboyut;
            pbHarita3.Height = hboyut;
            pbHarita4.Width = wboyut;
            pbHarita4.Height = hboyut;
            pbHarita5.Width = wboyut;
            pbHarita5.Height = hboyut;
            pbHarita6.Width = wboyut;
            pbHarita6.Height = hboyut;
            pbHarita7.Width = wboyut;
            pbHarita7.Height = hboyut;
            pbHarita8.Width = wboyut;
            pbHarita8.Height = hboyut;
            pbHarita9.Width = wboyut;
            pbHarita9.Height = hboyut;
            pbHarita10.Width = wboyut;
            pbHarita10.Height = hboyut;
            pbHarita11.Width = wboyut;
            pbHarita11.Height = hboyut;
            pbHarita12.Width = wboyut;
            pbHarita12.Height = hboyut;
            pbHarita13.Width = wboyut;
            pbHarita13.Height = hboyut;
            pbHarita14.Width = wboyut;
            pbHarita14.Height = hboyut;
            pbHarita15.Width = wboyut;
            pbHarita15.Height = hboyut;
            pbHarita16.Width = wboyut;
            pbHarita16.Height = hboyut;
            pbHarita17.Width = wboyut;
            pbHarita17.Height = hboyut;
            pbHarita18.Width = wboyut;
            pbHarita18.Height = hboyut;
            pbHarita19.Width = wboyut;
            pbHarita19.Height = hboyut;
            pbHarita20.Width = wboyut;
            pbHarita20.Height = hboyut;
            pbHarita21.Width = wboyut;
            pbHarita21.Height = hboyut;
            pbHarita22.Width = wboyut;
            pbHarita22.Height = hboyut;
            pbHarita23.Width = wboyut;
            pbHarita23.Height = hboyut;
            pbHarita24.Width = wboyut;
            pbHarita24.Height = hboyut;
            pbHarita25.Width = wboyut;
            pbHarita25.Height = hboyut;
            pbHarita26.Width = wboyut;
            pbHarita26.Height = hboyut;
            pbHarita27.Width = wboyut;
            pbHarita27.Height = hboyut;
            pbHarita28.Width = wboyut;
            pbHarita28.Height = hboyut;
            pbHarita29.Width = wboyut;
            pbHarita29.Height = hboyut;
            pbHarita30.Width = wboyut;
            pbHarita30.Height = hboyut;
            pbHarita31.Width = wboyut;
            pbHarita31.Height = hboyut;
            pbHarita32.Width = wboyut;
            pbHarita32.Height = hboyut;
            pbHarita33.Width = wboyut;
            pbHarita33.Height = hboyut;
            pbHarita34.Width = wboyut;
            pbHarita34.Height = hboyut;
            pbHarita35.Width = wboyut;
            pbHarita35.Height = hboyut;
            pbHarita36.Width = wboyut;
            pbHarita36.Height = hboyut;
            pbHarita37.Width = wboyut;
            pbHarita37.Height = hboyut;
            pbHarita38.Width = wboyut;
            pbHarita38.Height = hboyut;
            pbHarita39.Width = wboyut;
            pbHarita39.Height = hboyut;
            pbHarita40.Width = wboyut;
            pbHarita40.Height = hboyut;
            pbHarita41.Width = wboyut;
            pbHarita41.Height = hboyut;
            pbHarita42.Width = wboyut;
            pbHarita42.Height = hboyut;
            pbHarita43.Width = wboyut;
            pbHarita43.Height = hboyut;
            pbHarita44.Width = wboyut;
            pbHarita44.Height = hboyut;
            pbHarita45.Width = wboyut;
            pbHarita45.Height = hboyut;
            pbHarita46.Width = wboyut;
            pbHarita46.Height = hboyut;
            pbHarita47.Width = wboyut;
            pbHarita47.Height = hboyut;
            pbHarita48.Width = wboyut;
            pbHarita48.Height = hboyut;
            pbHarita49.Width = wboyut;
            pbHarita49.Height = hboyut;
            pbHarita50.Width = wboyut;
            pbHarita50.Height = hboyut;
            pbHarita51.Width = wboyut;
            pbHarita51.Height = hboyut;
            pbHarita52.Width = wboyut;
            pbHarita52.Height = hboyut;
            pbHarita53.Width = wboyut;
            pbHarita53.Height = hboyut;
            pbHarita54.Width = wboyut;
            pbHarita54.Height = hboyut;
            pbHarita55.Width = wboyut;
            pbHarita55.Height = hboyut;
            pbHarita56.Width = wboyut;
            pbHarita56.Height = hboyut;
            pbHarita57.Width = wboyut;
            pbHarita57.Height = hboyut;
            pbHarita58.Width = wboyut;
            pbHarita58.Height = hboyut;
            pbHarita59.Width = wboyut;
            pbHarita59.Height = hboyut;
            pbHarita60.Width = wboyut;
            pbHarita60.Height = hboyut;
            pbHarita61.Width = wboyut;
            pbHarita61.Height = hboyut;
            pbHarita62.Width = wboyut;
            pbHarita62.Height = hboyut;
            pbHarita63.Width = wboyut;
            pbHarita63.Height = hboyut;
            pbHarita64.Width = wboyut;
            pbHarita64.Height = hboyut;
            pbHarita65.Width = wboyut;
            pbHarita65.Height = hboyut;
            pbHarita66.Width = wboyut;
            pbHarita66.Height = hboyut;
            pbHarita67.Width = wboyut;
            pbHarita67.Height = hboyut;
            pbHarita68.Width = wboyut;
            pbHarita68.Height = hboyut;
            pbHarita69.Width = wboyut;
            pbHarita69.Height = hboyut;
            pbHarita70.Width = wboyut;
            pbHarita70.Height = hboyut;
            pbHarita71.Width = wboyut;
            pbHarita71.Height = hboyut;
            pbHarita72.Width = wboyut;
            pbHarita72.Height = hboyut;
            pbHarita73.Width = wboyut;
            pbHarita73.Height = hboyut;
            pbHarita74.Width = wboyut;
            pbHarita74.Height = hboyut;
            pbHarita75.Width = wboyut;
            pbHarita75.Height = hboyut;
            pbHarita76.Width = wboyut;
            pbHarita76.Height = hboyut;
            pbHarita77.Width = wboyut;
            pbHarita77.Height = hboyut;
            pbHarita78.Width = wboyut;
            pbHarita78.Height = hboyut;
            pbHarita79.Width = wboyut;
            pbHarita79.Height = hboyut;
            pbHarita80.Width = wboyut;
            pbHarita80.Height = hboyut;
            pbHarita81.Width = wboyut;
            pbHarita81.Height = hboyut;
            pbHarita82.Width = wboyut;
            pbHarita82.Height = hboyut;
            pbHarita83.Width = wboyut;
            pbHarita83.Height = hboyut;
            pbHarita84.Width = wboyut;
            pbHarita84.Height = hboyut;
            pbHarita85.Width = wboyut;
            pbHarita85.Height = hboyut;
            pbHarita86.Width = wboyut;
            pbHarita86.Height = hboyut;
            pbHarita87.Width = wboyut;
            pbHarita87.Height = hboyut;
            pbHarita88.Width = wboyut;
            pbHarita88.Height = hboyut;
            pbHarita89.Width = wboyut;
            pbHarita89.Height = hboyut;
            pbHarita90.Width = wboyut;
            pbHarita90.Height = hboyut;
            pbHarita91.Width = wboyut;
            pbHarita91.Height = hboyut;
            pbHarita92.Width = wboyut;
            pbHarita92.Height = hboyut;
            pbHarita93.Width = wboyut;
            pbHarita93.Height = hboyut;
            pbHarita94.Width = wboyut;
            pbHarita94.Height = hboyut;
            pbHarita95.Width = wboyut;
            pbHarita95.Height = hboyut;
            pbHarita96.Width = wboyut;
            pbHarita96.Height = hboyut;
            pbHarita97.Width = wboyut;
            pbHarita97.Height = hboyut;
            pbHarita98.Width = wboyut;
            pbHarita98.Height = hboyut;
            pbHarita99.Width = wboyut;
            pbHarita99.Height = hboyut;
            pbHarita100.Width = wboyut;
            pbHarita100.Height = hboyut;
            #endregion
            #region Harita_PictureBoxlarıKonumlandırma
            pbHarita1.Top = xkonum;
            pbHarita1.Left = ykonum;
            lblSayi1.Top = xkonum+35;
            lblSayi1.Left = ykonum+45;
            ykonum = wboyut + ykonum;
            pbHarita2.Top = xkonum;
            pbHarita2.Left = ykonum;
            lblSayi2.Top = xkonum + 35;
            lblSayi2.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita3.Top = xkonum;
            pbHarita3.Left = ykonum;
            lblSayi3.Top = xkonum + 35;
            lblSayi3.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita4.Top = xkonum;
            pbHarita4.Left = ykonum;
            lblSayi4.Top = xkonum + 35;
            lblSayi4.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita5.Top = xkonum;
            pbHarita5.Left = ykonum;
            lblSayi5.Top = xkonum + 35;
            lblSayi5.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita6.Top = xkonum;
            pbHarita6.Left = ykonum;
            lblSayi6.Top = xkonum + 35;
            lblSayi6.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita7.Top = xkonum;
            pbHarita7.Left = ykonum;
            lblSayi7.Top = xkonum + 35;
            lblSayi7.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita8.Top = xkonum;
            pbHarita8.Left = ykonum;
            lblSayi8.Top = xkonum + 35;
            lblSayi8.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita9.Top = xkonum;
            pbHarita9.Left = ykonum;
            lblSayi9.Top = xkonum + 35;
            lblSayi9.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita10.Top = xkonum;
            pbHarita10.Left = ykonum;
            lblSayi10.Top = xkonum + 35;
            lblSayi10.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita11.Top = xkonum;
            pbHarita11.Left = ykonum;
            lblSayi11.Top = xkonum + 35;
            lblSayi11.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita12.Top = xkonum;
            pbHarita12.Left = ykonum;
            lblSayi12.Top = xkonum + 35;
            lblSayi12.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita13.Top = xkonum;
            pbHarita13.Left = ykonum;
            lblSayi13.Top = xkonum + 35;
            lblSayi13.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita14.Top = xkonum;
            pbHarita14.Left = ykonum;
            lblSayi14.Top = xkonum + 35;
            lblSayi14.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita15.Top = xkonum;
            pbHarita15.Left = ykonum;
            lblSayi15.Top = xkonum + 35;
            lblSayi15.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita16.Top = xkonum;
            pbHarita16.Left = ykonum;
            lblSayi16.Top = xkonum + 35;
            lblSayi16.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita17.Top = xkonum;
            pbHarita17.Left = ykonum;
            lblSayi17.Top = xkonum + 35;
            lblSayi17.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita18.Top = xkonum;
            pbHarita18.Left = ykonum;
            lblSayi18.Top = xkonum + 35;
            lblSayi18.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita19.Top = xkonum;
            pbHarita19.Left = ykonum;
            lblSayi19.Top = xkonum + 35;
            lblSayi19.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita20.Top = xkonum;
            pbHarita20.Left = ykonum;
            lblSayi20.Top = xkonum + 35;
            lblSayi20.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita21.Top = xkonum;
            pbHarita21.Left = ykonum;
            lblSayi21.Top = xkonum + 35;
            lblSayi21.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita22.Top = xkonum;
            pbHarita22.Left = ykonum;
            lblSayi22.Top = xkonum + 35;
            lblSayi22.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita23.Top = xkonum;
            pbHarita23.Left = ykonum;
            lblSayi23.Top = xkonum + 35;
            lblSayi23.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita24.Top = xkonum;
            pbHarita24.Left = ykonum;
            lblSayi24.Top = xkonum + 35;
            lblSayi24.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita25.Top = xkonum;
            pbHarita25.Left = ykonum;
            lblSayi25.Top = xkonum + 35;
            lblSayi25.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita26.Top = xkonum;
            pbHarita26.Left = ykonum;
            lblSayi26.Top = xkonum + 35;
            lblSayi26.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita27.Top = xkonum;
            pbHarita27.Left = ykonum;
            lblSayi27.Top = xkonum + 35;
            lblSayi27.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita28.Top = xkonum;
            pbHarita28.Left = ykonum;
            lblSayi28.Top = xkonum + 35;
            lblSayi28.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita29.Top = xkonum;
            pbHarita29.Left = ykonum;
            lblSayi29.Top = xkonum + 35;
            lblSayi29.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita30.Top = xkonum;
            pbHarita30.Left = ykonum;
            lblSayi30.Top = xkonum + 35;
            lblSayi30.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita31.Top = xkonum;
            pbHarita31.Left = ykonum;
            lblSayi31.Top = xkonum + 35;
            lblSayi31.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita32.Top = xkonum;
            pbHarita32.Left = ykonum;
            lblSayi32.Top = xkonum + 35;
            lblSayi32.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita33.Top = xkonum;
            pbHarita33.Left = ykonum;
            lblSayi33.Top = xkonum + 35;
            lblSayi33.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita34.Top = xkonum;
            pbHarita34.Left = ykonum;
            lblSayi34.Top = xkonum + 35;
            lblSayi34.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita35.Top = xkonum;
            pbHarita35.Left = ykonum;
            lblSayi35.Top = xkonum + 35;
            lblSayi35.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita36.Top = xkonum;
            pbHarita36.Left = ykonum;
            lblSayi36.Top = xkonum + 35;
            lblSayi36.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita37.Top = xkonum;
            pbHarita37.Left = ykonum;
            lblSayi37.Top = xkonum + 35;
            lblSayi37.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita38.Top = xkonum;
            pbHarita38.Left = ykonum;
            lblSayi38.Top = xkonum + 35;
            lblSayi38.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita39.Top = xkonum;
            pbHarita39.Left = ykonum;
            lblSayi39.Top = xkonum + 35;
            lblSayi39.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita40.Top = xkonum;
            pbHarita40.Left = ykonum;
            lblSayi40.Top = xkonum + 35;
            lblSayi40.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita41.Top = xkonum;
            pbHarita41.Left = ykonum;
            lblSayi41.Top = xkonum + 35;
            lblSayi41.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita42.Top = xkonum;
            pbHarita42.Left = ykonum;
            lblSayi42.Top = xkonum + 35;
            lblSayi42.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita43.Top = xkonum;
            pbHarita43.Left = ykonum;
            lblSayi43.Top = xkonum + 35;
            lblSayi43.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita44.Top = xkonum;
            pbHarita44.Left = ykonum;
            lblSayi44.Top = xkonum + 35;
            lblSayi44.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita45.Top = xkonum;
            pbHarita45.Left = ykonum;
            lblSayi45.Top = xkonum + 35;
            lblSayi45.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita46.Top = xkonum;
            pbHarita46.Left = ykonum;
            lblSayi46.Top = xkonum + 35;
            lblSayi46.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita47.Top = xkonum;
            pbHarita47.Left = ykonum;
            lblSayi47.Top = xkonum + 35;
            lblSayi47.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita48.Top = xkonum;
            pbHarita48.Left = ykonum;
            lblSayi48.Top = xkonum + 35;
            lblSayi48.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita49.Top = xkonum;
            pbHarita49.Left = ykonum;
            lblSayi49.Top = xkonum + 35;
            lblSayi49.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita50.Top = xkonum;
            pbHarita50.Left = ykonum;
            lblSayi50.Top = xkonum + 35;
            lblSayi50.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita51.Top = xkonum;
            pbHarita51.Left = ykonum;
            lblSayi51.Top = xkonum + 35;
            lblSayi51.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita52.Top = xkonum;
            pbHarita52.Left = ykonum;
            lblSayi52.Top = xkonum + 35;
            lblSayi52.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita53.Top = xkonum;
            pbHarita53.Left = ykonum;
            lblSayi53.Top = xkonum + 35;
            lblSayi53.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita54.Top = xkonum;
            pbHarita54.Left = ykonum;
            lblSayi54.Top = xkonum + 35;
            lblSayi54.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita55.Top = xkonum;
            pbHarita55.Left = ykonum;
            lblSayi55.Top = xkonum + 35;
            lblSayi55.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita56.Top = xkonum;
            pbHarita56.Left = ykonum;
            lblSayi56.Top = xkonum + 35;
            lblSayi56.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita57.Top = xkonum;
            pbHarita57.Left = ykonum;
            lblSayi57.Top = xkonum + 35;
            lblSayi57.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita58.Top = xkonum;
            pbHarita58.Left = ykonum;
            lblSayi58.Top = xkonum + 35;
            lblSayi58.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita59.Top = xkonum;
            pbHarita59.Left = ykonum;
            lblSayi59.Top = xkonum + 35;
            lblSayi59.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita60.Top = xkonum;
            pbHarita60.Left = ykonum;
            lblSayi60.Top = xkonum + 35;
            lblSayi60.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita61.Top = xkonum;
            pbHarita61.Left = ykonum;
            lblSayi61.Top = xkonum + 35;
            lblSayi61.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita62.Top = xkonum;
            pbHarita62.Left = ykonum;
            lblSayi62.Top = xkonum + 35;
            lblSayi62.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita63.Top = xkonum;
            pbHarita63.Left = ykonum;
            lblSayi63.Top = xkonum + 35;
            lblSayi63.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita64.Top = xkonum;
            pbHarita64.Left = ykonum;
            lblSayi64.Top = xkonum + 35;
            lblSayi64.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita65.Top = xkonum;
            pbHarita65.Left = ykonum;
            lblSayi65.Top = xkonum + 35;
            lblSayi65.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita66.Top = xkonum;
            pbHarita66.Left = ykonum;
            lblSayi66.Top = xkonum + 35;
            lblSayi66.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita67.Top = xkonum;
            pbHarita67.Left = ykonum;
            lblSayi67.Top = xkonum + 35;
            lblSayi67.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita68.Top = xkonum;
            pbHarita68.Left = ykonum;
            lblSayi68.Top = xkonum + 35;
            lblSayi68.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita69.Top = xkonum;
            pbHarita69.Left = ykonum;
            lblSayi69.Top = xkonum + 35;
            lblSayi69.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita70.Top = xkonum;
            pbHarita70.Left = ykonum;
            lblSayi70.Top = xkonum + 35;
            lblSayi70.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita71.Top = xkonum;
            pbHarita71.Left = ykonum;
            lblSayi71.Top = xkonum + 35;
            lblSayi71.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita72.Top = xkonum;
            pbHarita72.Left = ykonum;
            lblSayi72.Top = xkonum + 35;
            lblSayi72.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita73.Top = xkonum;
            pbHarita73.Left = ykonum;
            lblSayi73.Top = xkonum + 35;
            lblSayi73.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita74.Top = xkonum;
            pbHarita74.Left = ykonum;
            lblSayi74.Top = xkonum + 35;
            lblSayi74.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita75.Top = xkonum;
            pbHarita75.Left = ykonum;
            lblSayi75.Top = xkonum + 35;
            lblSayi75.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita76.Top = xkonum;
            pbHarita76.Left = ykonum;
            lblSayi76.Top = xkonum + 35;
            lblSayi76.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita77.Top = xkonum;
            pbHarita77.Left = ykonum;
            lblSayi77.Top = xkonum + 35;
            lblSayi77.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita78.Top = xkonum;
            pbHarita78.Left = ykonum;
            lblSayi78.Top = xkonum + 35;
            lblSayi78.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita79.Top = xkonum;
            pbHarita79.Left = ykonum;
            lblSayi79.Top = xkonum + 35;
            lblSayi79.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita80.Top = xkonum;
            pbHarita80.Left = ykonum;
            lblSayi80.Top = xkonum + 35;
            lblSayi80.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita81.Top = xkonum;
            pbHarita81.Left = ykonum;
            lblSayi81.Top = xkonum + 35;
            lblSayi81.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita82.Top = xkonum;
            pbHarita82.Left = ykonum;
            lblSayi82.Top = xkonum + 35;
            lblSayi82.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita83.Top = xkonum;
            pbHarita83.Left = ykonum;
            lblSayi83.Top = xkonum + 35;
            lblSayi83.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita84.Top = xkonum;
            pbHarita84.Left = ykonum;
            lblSayi84.Top = xkonum + 35;
            lblSayi84.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita85.Top = xkonum;
            pbHarita85.Left = ykonum;
            lblSayi85.Top = xkonum + 35;
            lblSayi85.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita86.Top = xkonum;
            pbHarita86.Left = ykonum;
            lblSayi86.Top = xkonum + 35;
            lblSayi86.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita87.Top = xkonum;
            pbHarita87.Left = ykonum;
            lblSayi87.Top = xkonum + 35;
            lblSayi87.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita88.Top = xkonum;
            pbHarita88.Left = ykonum;
            lblSayi88.Top = xkonum + 35;
            lblSayi88.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita89.Top = xkonum;
            pbHarita89.Left = ykonum;
            lblSayi89.Top = xkonum + 35;
            lblSayi89.Left = ykonum + 45;
            ykonum = wboyut + ykonum;
            pbHarita90.Top = xkonum;
            pbHarita90.Left = ykonum;
            lblSayi90.Top = xkonum + 35;
            lblSayi90.Left = ykonum + 45;
            ykonum = 0;
            xkonum = hboyut + xkonum;
            pbHarita91.Top = xkonum;
            pbHarita91.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita92.Top = xkonum;
            pbHarita92.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita93.Top = xkonum;
            pbHarita93.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita94.Top = xkonum;
            pbHarita94.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita95.Top = xkonum;
            pbHarita95.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita96.Top = xkonum;
            pbHarita96.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita97.Top = xkonum;
            pbHarita97.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita98.Top = xkonum;
            pbHarita98.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita99.Top = xkonum;
            pbHarita99.Left = ykonum;
            ykonum = wboyut + ykonum;
            pbHarita100.Top = xkonum;
            pbHarita100.Left = ykonum;
            #endregion
            
            cropImage();
        }
        void cropImage()
        {
            var imgarray = new Image[100];
            var img = Image.FromFile("img//harita.png");
            //Bitmap yeniBoyut = new Bitmap(img, new Size((img.Width / 4) + img.Width, (img.Height / 4) + img.Height));
            Bitmap yeniBoyut = new Bitmap(img, new Size((pnlHarita.Height / 10) + (pnlHarita.Width / 2) + pnlHarita.Width, (pnlHarita.Height / 10) + (pnlHarita.Height / 2) + pnlHarita.Height));
            img = yeniBoyut;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var index = i * 10 + j;
                    imgarray[index] = new Bitmap(pbHarita1.Width, pbHarita1.Height);
                    var graphics = Graphics.FromImage(imgarray[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, pbHarita1.Width, pbHarita1.Height), new Rectangle(i * 104, j * 104, 104, 104), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
            #region Haritayı Yerleştirme
            pbHarita1.BackgroundImage = imgarray[0];
            pbHarita11.BackgroundImage = imgarray[1];
            pbHarita21.BackgroundImage = imgarray[2];
            pbHarita31.BackgroundImage = imgarray[3];
            pbHarita41.BackgroundImage = imgarray[4];
            pbHarita51.BackgroundImage = imgarray[5];
            pbHarita61.BackgroundImage = imgarray[6];
            pbHarita71.BackgroundImage = imgarray[7];
            pbHarita81.BackgroundImage = imgarray[8];
            pbHarita91.BackgroundImage = imgarray[9];
            pbHarita2.BackgroundImage = imgarray[10];
            pbHarita12.BackgroundImage = imgarray[11];
            pbHarita22.BackgroundImage = imgarray[12];
            pbHarita32.BackgroundImage = imgarray[13];
            pbHarita42.BackgroundImage = imgarray[14];
            pbHarita52.BackgroundImage = imgarray[15];
            pbHarita62.BackgroundImage = imgarray[16];
            pbHarita72.BackgroundImage = imgarray[17];
            pbHarita82.BackgroundImage = imgarray[18];
            pbHarita92.BackgroundImage = imgarray[19];
            pbHarita3.BackgroundImage = imgarray[20];
            pbHarita13.BackgroundImage = imgarray[21];
            pbHarita23.BackgroundImage = imgarray[22];
            pbHarita33.BackgroundImage = imgarray[23];
            pbHarita43.BackgroundImage = imgarray[24];
            pbHarita53.BackgroundImage = imgarray[25];
            pbHarita63.BackgroundImage = imgarray[26];
            pbHarita73.BackgroundImage = imgarray[27];
            pbHarita83.BackgroundImage = imgarray[28];
            pbHarita93.BackgroundImage = imgarray[29];
            pbHarita4.BackgroundImage = imgarray[30];
            pbHarita14.BackgroundImage = imgarray[31];
            pbHarita24.BackgroundImage = imgarray[32];
            pbHarita34.BackgroundImage = imgarray[33];
            pbHarita44.BackgroundImage = imgarray[34];
            pbHarita54.BackgroundImage = imgarray[35];
            pbHarita64.BackgroundImage = imgarray[36];
            pbHarita74.BackgroundImage = imgarray[37];
            pbHarita84.BackgroundImage = imgarray[38];
            pbHarita94.BackgroundImage = imgarray[39];
            pbHarita5.BackgroundImage = imgarray[40];
            pbHarita15.BackgroundImage = imgarray[41];
            pbHarita25.BackgroundImage = imgarray[42];
            pbHarita35.BackgroundImage = imgarray[43];
            pbHarita45.BackgroundImage = imgarray[44];
            pbHarita55.BackgroundImage = imgarray[45];
            pbHarita65.BackgroundImage = imgarray[46];
            pbHarita75.BackgroundImage = imgarray[47];
            pbHarita85.BackgroundImage = imgarray[48];
            pbHarita95.BackgroundImage = imgarray[49];
            pbHarita6.BackgroundImage = imgarray[50];
            pbHarita16.BackgroundImage = imgarray[51];
            pbHarita26.BackgroundImage = imgarray[52];
            pbHarita36.BackgroundImage = imgarray[53];
            pbHarita46.BackgroundImage = imgarray[54];
            pbHarita56.BackgroundImage = imgarray[55];
            pbHarita66.BackgroundImage = imgarray[56];
            pbHarita76.BackgroundImage = imgarray[57];
            pbHarita86.BackgroundImage = imgarray[58];
            pbHarita96.BackgroundImage = imgarray[59];
            pbHarita7.BackgroundImage = imgarray[60];
            pbHarita17.BackgroundImage = imgarray[61];
            pbHarita27.BackgroundImage = imgarray[62];
            pbHarita37.BackgroundImage = imgarray[63];
            pbHarita47.BackgroundImage = imgarray[64];
            pbHarita57.BackgroundImage = imgarray[65];
            pbHarita67.BackgroundImage = imgarray[66];
            pbHarita77.BackgroundImage = imgarray[67];
            pbHarita87.BackgroundImage = imgarray[68];
            pbHarita97.BackgroundImage = imgarray[69];
            pbHarita8.BackgroundImage = imgarray[70];
            pbHarita18.BackgroundImage = imgarray[71];
            pbHarita28.BackgroundImage = imgarray[72];
            pbHarita38.BackgroundImage = imgarray[73];
            pbHarita48.BackgroundImage = imgarray[74];
            pbHarita58.BackgroundImage = imgarray[75];
            pbHarita68.BackgroundImage = imgarray[76];
            pbHarita78.BackgroundImage = imgarray[77];
            pbHarita88.BackgroundImage = imgarray[78];
            pbHarita98.BackgroundImage = imgarray[79];
            pbHarita9.BackgroundImage = imgarray[80];
            pbHarita19.BackgroundImage = imgarray[81];
            pbHarita29.BackgroundImage = imgarray[82];
            pbHarita39.BackgroundImage = imgarray[83];
            pbHarita49.BackgroundImage = imgarray[84];
            pbHarita59.BackgroundImage = imgarray[85];
            pbHarita69.BackgroundImage = imgarray[86];
            pbHarita79.BackgroundImage = imgarray[87];
            pbHarita89.BackgroundImage = imgarray[88];
            pbHarita99.BackgroundImage = imgarray[89];
            pbHarita10.BackgroundImage = imgarray[90];
            pbHarita20.BackgroundImage = imgarray[91];
            pbHarita30.BackgroundImage = imgarray[92];
            pbHarita40.BackgroundImage = imgarray[93];
            pbHarita50.BackgroundImage = imgarray[94];
            pbHarita60.BackgroundImage = imgarray[95];
            pbHarita70.BackgroundImage = imgarray[96];
            pbHarita80.BackgroundImage = imgarray[97];
            pbHarita90.BackgroundImage = imgarray[98];
            pbHarita100.BackgroundImage = imgarray[99];
            #endregion
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            pnlAna.Size = new Size(Convert.ToInt32(this.Width * 0.95f), Convert.ToInt32(this.Height * 0.90f));
            pnlAna.Location = new Point(Convert.ToInt32((this.Width * 0.02f)), Convert.ToInt32((this.Height * 0.02f)));
        }
        private PictureBox mouseUstundePb(PictureBox picturebox)
        {
            var img = Image.FromFile("img//select.png");
            Bitmap yeniBoyut = new Bitmap(img, new Size(pbHarita1.Width, pbHarita1.Height));
            picturebox.Image = yeniBoyut;
            return picturebox;
        }
        public void menuHaritaItemAdd(int id)
        {
            
            id -= 1;
            //MessageBox.Show(id.ToString());
            if (grublanmisAgacVeri[id] != null)
            {
                int enuzun = 0;
                string[] parcalanmisVeri = grublanmisAgacVeri[id].Split('-');
                //MessageBox.Show(grublanmisAgacVeri[id]);
                for (int i = 1; i < parcalanmisVeri.Length; i++)
                {
                    string[] islenmisVeri = parcalanmisVeri[i].Split(':');
                    if((islenmisVeri[1] + " : " + islenmisVeri[2] + "  [ " + islenmisVeri[9] + " ]").Length>enuzun)
                    {
                        enuzun = (islenmisVeri[1] + " : " + islenmisVeri[2] + "  [ " + islenmisVeri[9] + " ]").Length;
                    }
                }
                for (int i = 1; i < parcalanmisVeri.Length; i++)
                {
                    int kactane = 0;
                    string[] islenmisVeri = parcalanmisVeri[i].Split(':');
                    //if (islenmisVeri[0] != "")
                    //{
                    //MessageBox.Show(i.ToString());
                    kactane = enuzun - (islenmisVeri[1] + ": " + islenmisVeri[2] + "  [ " + islenmisVeri[9] + " ]").Length;
                    string a = "";
                    for (int j = 0; j < kactane; j++)
                    {
                        a = a + "-";
                    }
                    menuHarita.Items.Add(islenmisVeri[1] + ": " + islenmisVeri[2] + a + "  [ " + islenmisVeri[9] + " ]",null,menuHaritaClick);
                    if (grs.control == true)
                    {
                        (menuHarita.Items[i - 1] as ToolStripMenuItem).DropDownItems.Add("Düzenle", null, altDüzenleToolStripMenuItem3_Click);
                        (menuHarita.Items[i - 1] as ToolStripMenuItem).DropDownItems[0].Name = islenmisVeri[1];
                        (menuHarita.Items[i - 1] as ToolStripMenuItem).DropDownItems.Add("Sil", null, altSilToolStripMenuItem3_Click);
                        (menuHarita.Items[i - 1] as ToolStripMenuItem).DropDownItems[1].Name = islenmisVeri[1];
                    }
                    //}
                }
                //for(int i = 0; i < menuHarita.Items.Count; i++)
                //{
                    

                //}
                //menuHarita.Items.Add("Çoklu Seçim");
            }
        }
        private void altSilToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show("Bu ağacı sistemden silmek istermisiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sil == DialogResult.Yes)
            {
                ToolStripMenuItem a;
                a = (ToolStripMenuItem)sender;
                int c = int.Parse(a.Name);
                Veritabani veritabani = new Veritabani();
                MessageBox.Show(veritabani.agacsil(c.ToString()));
                menuHarita.Items.Clear();
                mainForm mF = new mainForm();
                mainForm_Load(mF, EventArgs.Empty);
                
            }

        }

        private void altDüzenleToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem a;
            a = (ToolStripMenuItem)sender;
            Veritabani veritabani = new Veritabani();
            int c = int.Parse(a.Name);

            string[] parcalanmisVeri = veritabani.agacListele("id", c.ToString()).Split(':');
            lbld.Text = parcalanmisVeri[1];
            cmBoxAgacTipi.Text = parcalanmisVeri[2];
            txtBoxAgacBoyu.Text = parcalanmisVeri[3];
            txtBoxAgacCapi.Text = parcalanmisVeri[4];
            txtBoxAgacYasi.Text = parcalanmisVeri[5];
            txtBoxHastaligi.Text = parcalanmisVeri[6];
            tBarEnlem.Value = int.Parse(parcalanmisVeri[7]);
            txtBoxEnlem.Text = tBarEnlem.Value.ToString().Substring(0, 2) + "." + tBarEnlem.Value.ToString().Substring(2);
            tBarBoylam.Value = int.Parse(parcalanmisVeri[8]);
            txtBoxBoylam.Text = tBarBoylam.Value.ToString().Substring(0, 2) + "." + tBarBoylam.Value.ToString().Substring(2);
            dtPickerTarih.Value = DateTime.Parse(parcalanmisVeri[9]);
            textBox9.Text = parcalanmisVeri[10];
            //menuHarita.Items.Clear();
            //mainForm mF = new mainForm();
            //mainForm_Load(mF, EventArgs.Empty);
        }
        public void menuHaritaClick(object sender,EventArgs e)
        {
           hangiAgac=sender.ToString().Split(':')[0]+":";

        }
        private void pbHarita1_MouseMove(object sender, MouseEventArgs e)
        {
            menuHarita.Items.Clear();
            #region Hangi Picturenin Üstünde
            if (sender == pbHarita1)
            {
                menuHaritaItemAdd(1);
                pbHarita1 = mouseUstundePb(pbHarita1);
            }
            else if (sender == pbHarita2)
            {
                menuHaritaItemAdd(2);
                pbHarita2 = mouseUstundePb(pbHarita2);
            }
            else if (sender == pbHarita3)
            {
                menuHaritaItemAdd(3);
                pbHarita3 = mouseUstundePb(pbHarita3);
            }
            else if (sender == pbHarita4)
            {
                menuHaritaItemAdd(4);
                pbHarita4 = mouseUstundePb(pbHarita4);
            }
            else if (sender == pbHarita5)
            {
                menuHaritaItemAdd(5);
                pbHarita5 = mouseUstundePb(pbHarita5);
            }
            else if (sender == pbHarita6)
            {
                menuHaritaItemAdd(6);
                pbHarita6 = mouseUstundePb(pbHarita6);
            }
            else if (sender == pbHarita7)
            {
                menuHaritaItemAdd(7);
                pbHarita7 = mouseUstundePb(pbHarita7);
            }
            else if (sender == pbHarita8)
            {
                menuHaritaItemAdd(8);
                pbHarita8 = mouseUstundePb(pbHarita8);
            }
            else if (sender == pbHarita9)
            {
                menuHaritaItemAdd(9);
                pbHarita9 = mouseUstundePb(pbHarita9);
            }
            else if (sender == pbHarita10)
            {
                menuHaritaItemAdd(10);
                pbHarita10 = mouseUstundePb(pbHarita10);
            }
            else if (sender == pbHarita11)
            {
                menuHaritaItemAdd(11);
                pbHarita11 = mouseUstundePb(pbHarita11);
            }
            else if (sender == pbHarita12)
            {
                menuHaritaItemAdd(12);
                pbHarita12 = mouseUstundePb(pbHarita12);
            }
            else if (sender == pbHarita13)
            {
                menuHaritaItemAdd(13);
                pbHarita13 = mouseUstundePb(pbHarita13);
            }
            else if (sender == pbHarita14)
            {
                menuHaritaItemAdd(14);
                pbHarita14 = mouseUstundePb(pbHarita14);
            }
            else if (sender == pbHarita15)
            {
                menuHaritaItemAdd(15);
                pbHarita15 = mouseUstundePb(pbHarita15);
            }
            else if (sender == pbHarita16)
            {
                menuHaritaItemAdd(16);
                pbHarita16 = mouseUstundePb(pbHarita16);
            }
            else if (sender == pbHarita17)
            {
                menuHaritaItemAdd(17);
                pbHarita17 = mouseUstundePb(pbHarita17);
            }
            else if (sender == pbHarita18)
            {
                menuHaritaItemAdd(18);
                pbHarita18 = mouseUstundePb(pbHarita18);
            }
            else if (sender == pbHarita19)
            {
                menuHaritaItemAdd(19);
                pbHarita19 = mouseUstundePb(pbHarita19);
            }
            else if (sender == pbHarita20)
            {
                menuHaritaItemAdd(20);
                pbHarita20 = mouseUstundePb(pbHarita20);
            }
            else if (sender == pbHarita21)
            {
                menuHaritaItemAdd(21);
                pbHarita21 = mouseUstundePb(pbHarita21);
            }
            else if (sender == pbHarita22)
            {
                menuHaritaItemAdd(22);
                pbHarita22 = mouseUstundePb(pbHarita22);
            }
            else if (sender == pbHarita23)
            {
                menuHaritaItemAdd(23);
                pbHarita23 = mouseUstundePb(pbHarita23);
            }
            else if (sender == pbHarita24)
            {
                menuHaritaItemAdd(24);
                pbHarita24 = mouseUstundePb(pbHarita24);
            }
            else if (sender == pbHarita25)
            {
                menuHaritaItemAdd(25);
                pbHarita25 = mouseUstundePb(pbHarita25);
            }
            else if (sender == pbHarita26)
            {
                menuHaritaItemAdd(26);
                pbHarita26 = mouseUstundePb(pbHarita26);
            }
            else if (sender == pbHarita27)
            {
                menuHaritaItemAdd(27);
                pbHarita27 = mouseUstundePb(pbHarita27);
            }
            else if (sender == pbHarita28)
            {
                menuHaritaItemAdd(28);
                pbHarita28 = mouseUstundePb(pbHarita28);
            }
            else if (sender == pbHarita29)
            {
                menuHaritaItemAdd(29);
                pbHarita29 = mouseUstundePb(pbHarita29);
            }
            else if (sender == pbHarita30)
            {
                menuHaritaItemAdd(30);
                pbHarita30 = mouseUstundePb(pbHarita30);
            }
            else if (sender == pbHarita31)
            {
                menuHaritaItemAdd(31);
                pbHarita31 = mouseUstundePb(pbHarita31);
            }
            else if (sender == pbHarita32)
            {
                menuHaritaItemAdd(32);
                pbHarita32 = mouseUstundePb(pbHarita32);
            }
            else if (sender == pbHarita33)
            {
                menuHaritaItemAdd(33);
                pbHarita33 = mouseUstundePb(pbHarita33);
            }
            else if (sender == pbHarita34)
            {
                menuHaritaItemAdd(34);
                pbHarita34 = mouseUstundePb(pbHarita34);
            }
            else if (sender == pbHarita35)
            {
                menuHaritaItemAdd(35);
                pbHarita35 = mouseUstundePb(pbHarita35);
            }
            else if (sender == pbHarita36)
            {
                menuHaritaItemAdd(36);
                pbHarita36 = mouseUstundePb(pbHarita36);
            }
            else if (sender == pbHarita37)
            {
                menuHaritaItemAdd(37);
                pbHarita37 = mouseUstundePb(pbHarita37);
            }
            else if (sender == pbHarita38)
            {
                menuHaritaItemAdd(38);
                pbHarita38 = mouseUstundePb(pbHarita38);
            }
            else if (sender == pbHarita39)
            {
                menuHaritaItemAdd(39);
                pbHarita39 = mouseUstundePb(pbHarita39);
            }
            else if (sender == pbHarita40)
            {
                menuHaritaItemAdd(40);
                pbHarita40 = mouseUstundePb(pbHarita40);
            }
            else if (sender == pbHarita41)
            {
                menuHaritaItemAdd(41);
                pbHarita41 = mouseUstundePb(pbHarita41);
            }
            else if (sender == pbHarita42)
            {
                menuHaritaItemAdd(42);
                pbHarita42 = mouseUstundePb(pbHarita42);
            }
            else if (sender == pbHarita43)
            {
                menuHaritaItemAdd(43);
                pbHarita43 = mouseUstundePb(pbHarita43);
            }
            else if (sender == pbHarita44)
            {
                menuHaritaItemAdd(44);
                pbHarita44 = mouseUstundePb(pbHarita44);
            }
            else if (sender == pbHarita45)
            {
                menuHaritaItemAdd(45);
                pbHarita45 = mouseUstundePb(pbHarita45);
            }
            else if (sender == pbHarita46)
            {
                menuHaritaItemAdd(46);
                pbHarita46 = mouseUstundePb(pbHarita46);
            }
            else if (sender == pbHarita47)
            {
                menuHaritaItemAdd(47);
                pbHarita47 = mouseUstundePb(pbHarita47);
            }
            else if (sender == pbHarita48)
            {
                menuHaritaItemAdd(48);
                pbHarita48 = mouseUstundePb(pbHarita48);
            }
            else if (sender == pbHarita49)
            {
                menuHaritaItemAdd(49);
                pbHarita49 = mouseUstundePb(pbHarita49);
            }
            else if (sender == pbHarita50)
            {
                menuHaritaItemAdd(50);
                pbHarita50 = mouseUstundePb(pbHarita50);
            }
            else if (sender == pbHarita51)
            {
                menuHaritaItemAdd(51);
                pbHarita51 = mouseUstundePb(pbHarita51);
            }
            else if (sender == pbHarita52)
            {
                menuHaritaItemAdd(52);
                pbHarita52 = mouseUstundePb(pbHarita52);
            }
            else if (sender == pbHarita53)
            {
                menuHaritaItemAdd(53);
                pbHarita53 = mouseUstundePb(pbHarita53);
            }
            else if (sender == pbHarita54)
            {
                menuHaritaItemAdd(54);
                pbHarita54 = mouseUstundePb(pbHarita54);
            }
            else if (sender == pbHarita55)
            {
                menuHaritaItemAdd(55);
                pbHarita55 = mouseUstundePb(pbHarita55);
            }
            else if (sender == pbHarita56)
            {
                menuHaritaItemAdd(56);
                pbHarita56 = mouseUstundePb(pbHarita56);
            }
            else if (sender == pbHarita57)
            {
                menuHaritaItemAdd(57);
                pbHarita57 = mouseUstundePb(pbHarita57);
            }
            else if (sender == pbHarita58)
            {
                menuHaritaItemAdd(58);
                pbHarita58 = mouseUstundePb(pbHarita58);
            }
            else if (sender == pbHarita59)
            {
                menuHaritaItemAdd(59);
                pbHarita59 = mouseUstundePb(pbHarita59);
            }
            else if (sender == pbHarita60)
            {
                menuHaritaItemAdd(60);
                pbHarita60 = mouseUstundePb(pbHarita60);
            }
            else if (sender == pbHarita61)
            {
                menuHaritaItemAdd(61);
                pbHarita61 = mouseUstundePb(pbHarita61);
            }
            else if (sender == pbHarita62)
            {
                menuHaritaItemAdd(62);
                pbHarita62 = mouseUstundePb(pbHarita62);
            }
            else if (sender == pbHarita63)
            {
                menuHaritaItemAdd(63);
                pbHarita63 = mouseUstundePb(pbHarita63);
            }
            else if (sender == pbHarita64)
            {
                menuHaritaItemAdd(64);
                pbHarita64 = mouseUstundePb(pbHarita64);
            }
            else if (sender == pbHarita65)
            {
                menuHaritaItemAdd(65);
                pbHarita65 = mouseUstundePb(pbHarita65);
            }
            else if (sender == pbHarita66)
            {
                menuHaritaItemAdd(66);
                pbHarita66 = mouseUstundePb(pbHarita66);
            }
            else if (sender == pbHarita67)
            {
                menuHaritaItemAdd(67);
                pbHarita67 = mouseUstundePb(pbHarita67);
            }
            else if (sender == pbHarita68)
            {
                menuHaritaItemAdd(68);
                pbHarita68 = mouseUstundePb(pbHarita68);
            }
            else if (sender == pbHarita69)
            {
                menuHaritaItemAdd(69);
                pbHarita69 = mouseUstundePb(pbHarita69);
            }
            else if (sender == pbHarita70)
            {
                menuHaritaItemAdd(70);
                pbHarita70 = mouseUstundePb(pbHarita70);
            }
            else if (sender == pbHarita71)
            {
                menuHaritaItemAdd(71);
                pbHarita71 = mouseUstundePb(pbHarita71);
            }
            else if (sender == pbHarita72)
            {
                menuHaritaItemAdd(72);
                pbHarita72 = mouseUstundePb(pbHarita72);
            }
            else if (sender == pbHarita73)
            {
                menuHaritaItemAdd(73);
                pbHarita73 = mouseUstundePb(pbHarita73);
            }
            else if (sender == pbHarita74)
            {
                menuHaritaItemAdd(74);
                pbHarita74 = mouseUstundePb(pbHarita74);
            }
            else if (sender == pbHarita75)
            {
                menuHaritaItemAdd(75);
                pbHarita75 = mouseUstundePb(pbHarita75);
            }
            else if (sender == pbHarita76)
            {
                menuHaritaItemAdd(76);
                pbHarita76 = mouseUstundePb(pbHarita76);
            }
            else if (sender == pbHarita77)
            {
                menuHaritaItemAdd(77);
                pbHarita77 = mouseUstundePb(pbHarita77);
            }
            else if (sender == pbHarita78)
            {
                menuHaritaItemAdd(78);
                pbHarita78 = mouseUstundePb(pbHarita78);
            }
            else if (sender == pbHarita79)
            {
                menuHaritaItemAdd(79);
                pbHarita79 = mouseUstundePb(pbHarita79);
            }
            else if (sender == pbHarita80)
            {
                menuHaritaItemAdd(80);
                pbHarita80 = mouseUstundePb(pbHarita80);
            }
            else if (sender == pbHarita81)
            {
                menuHaritaItemAdd(81);
                pbHarita81 = mouseUstundePb(pbHarita81);
            }
            else if (sender == pbHarita82)
            {
                menuHaritaItemAdd(82);
                pbHarita82 = mouseUstundePb(pbHarita82);
            }
            else if (sender == pbHarita83)
            {
                menuHaritaItemAdd(83);
                pbHarita83 = mouseUstundePb(pbHarita83);
            }
            else if (sender == pbHarita84)
            {
                menuHaritaItemAdd(84);
                pbHarita84 = mouseUstundePb(pbHarita84);
            }
            else if (sender == pbHarita85)
            {
                menuHaritaItemAdd(85);
                pbHarita85 = mouseUstundePb(pbHarita85);
            }
            else if (sender == pbHarita86)
            {
                menuHaritaItemAdd(86);
                pbHarita86 = mouseUstundePb(pbHarita86);
            }
            else if (sender == pbHarita87)
            {
                menuHaritaItemAdd(87);
                pbHarita87 = mouseUstundePb(pbHarita87);
            }
            else if (sender == pbHarita88)
            {
                menuHaritaItemAdd(88);
                pbHarita88 = mouseUstundePb(pbHarita88);
            }
            else if (sender == pbHarita89)
            {
                menuHaritaItemAdd(89);
                pbHarita89 = mouseUstundePb(pbHarita89);
            }
            else if (sender == pbHarita90)
            {
                menuHaritaItemAdd(90);
                pbHarita90 = mouseUstundePb(pbHarita90);
            }
            //else if (sender == pbHarita91)
            //{
            //    menuHaritaItemAdd(91);
            //    pbHarita91 = mouseUstundePb(pbHarita91);
            //}
            //else if (sender == pbHarita92)
            //{
            //    menuHaritaItemAdd(92);
            //    pbHarita92 = mouseUstundePb(pbHarita92);
            //}
            //else if (sender == pbHarita93)
            //{
            //    menuHaritaItemAdd(93);
            //    pbHarita93 = mouseUstundePb(pbHarita93);
            //}
            //else if (sender == pbHarita94)
            //{
            //    menuHaritaItemAdd(94);
            //    pbHarita94 = mouseUstundePb(pbHarita94);
            //}
            //else if (sender == pbHarita95)
            //{
            //    menuHaritaItemAdd(95);
            //    pbHarita95 = mouseUstundePb(pbHarita95);
            //}
            //else if (sender == pbHarita96)
            //{
            //    menuHaritaItemAdd(96);
            //    pbHarita96 = mouseUstundePb(pbHarita96);
            //}
            //else if (sender == pbHarita97)
            //{
            //    menuHaritaItemAdd(97);
            //    pbHarita97 = mouseUstundePb(pbHarita97);
            //}
            //else if (sender == pbHarita98)
            //{
            //    menuHaritaItemAdd(98);
            //    pbHarita98 = mouseUstundePb(pbHarita98);
            //}
            //else if (sender == pbHarita99)
            //{
            //    menuHaritaItemAdd(99);
            //    pbHarita99 = mouseUstundePb(pbHarita99);
            //}
            #endregion
        }

        private void pbHarita1_MouseLeave(object sender, EventArgs e)
        {
            #region Hangi Pictureden Ayrıldı
            if (sender == pbHarita1)
            {
                pbHarita1.Image = null;
            }
            else if (sender == pbHarita2)
            {
                pbHarita2.Image = null;
            }
            else if (sender == pbHarita3)
            {
                pbHarita3.Image = null;
            }
            else if (sender == pbHarita4)
            {
                pbHarita4.Image = null;
            }
            else if (sender == pbHarita5)
            {
                pbHarita5.Image = null;
            }
            else if (sender == pbHarita6)
            {
                pbHarita6.Image = null;
            }
            else if (sender == pbHarita7)
            {
                pbHarita7.Image = null;
            }
            else if (sender == pbHarita8)
            {
                pbHarita8.Image = null;
            }
            else if (sender == pbHarita9)
            {
                pbHarita9.Image = null;
            }
            else if (sender == pbHarita10)
            {
                pbHarita10.Image = null;
            }
            else if (sender == pbHarita11)
            {
                pbHarita11.Image = null;
            }
            else if (sender == pbHarita12)
            {
                pbHarita12.Image = null;
            }
            else if (sender == pbHarita13)
            {
                pbHarita13.Image = null;
            }
            else if (sender == pbHarita14)
            {
                pbHarita14.Image = null;
            }
            else if (sender == pbHarita15)
            {
                pbHarita15.Image = null;
            }
            else if (sender == pbHarita16)
            {
                pbHarita16.Image = null;
            }
            else if (sender == pbHarita17)
            {
                pbHarita17.Image = null;
            }
            else if (sender == pbHarita18)
            {
                pbHarita18.Image = null;
            }
            else if (sender == pbHarita19)
            {
                pbHarita19.Image = null;
            }
            else if (sender == pbHarita20)
            {
                pbHarita20.Image = null;
            }
            else if (sender == pbHarita21)
            {
                pbHarita21.Image = null;
            }
            else if (sender == pbHarita22)
            {
                pbHarita22.Image = null;
            }
            else if (sender == pbHarita23)
            {
                pbHarita23.Image = null;
            }
            else if (sender == pbHarita24)
            {
                pbHarita24.Image = null;
            }
            else if (sender == pbHarita25)
            {
                pbHarita25.Image = null;
            }
            else if (sender == pbHarita26)
            {
                pbHarita26.Image = null;
            }
            else if (sender == pbHarita27)
            {
                pbHarita27.Image = null;
            }
            else if (sender == pbHarita28)
            {
                pbHarita28.Image = null;
            }
            else if (sender == pbHarita29)
            {
                pbHarita29.Image = null;
            }
            else if (sender == pbHarita30)
            {
                pbHarita30.Image = null;
            }
            else if (sender == pbHarita31)
            {
                pbHarita31.Image = null;
            }
            else if (sender == pbHarita32)
            {
                pbHarita32.Image = null;
            }
            else if (sender == pbHarita33)
            {
                pbHarita33.Image = null;
            }
            else if (sender == pbHarita34)
            {
                pbHarita34.Image = null;
            }
            else if (sender == pbHarita35)
            {
                pbHarita35.Image = null;
            }
            else if (sender == pbHarita36)
            {
                pbHarita36.Image = null;
            }
            else if (sender == pbHarita37)
            {
                pbHarita37.Image = null;
            }
            else if (sender == pbHarita38)
            {
                pbHarita38.Image = null;
            }
            else if (sender == pbHarita39)
            {
                pbHarita39.Image = null;
            }
            else if (sender == pbHarita40)
            {
                pbHarita40.Image = null;
            }
            else if (sender == pbHarita41)
            {
                pbHarita41.Image = null;
            }
            else if (sender == pbHarita42)
            {
                pbHarita42.Image = null;
            }
            else if (sender == pbHarita43)
            {
                pbHarita43.Image = null;
            }
            else if (sender == pbHarita44)
            {
                pbHarita44.Image = null;
            }
            else if (sender == pbHarita45)
            {
                pbHarita45.Image = null;
            }
            else if (sender == pbHarita46)
            {
                pbHarita46.Image = null;
            }
            else if (sender == pbHarita47)
            {
                pbHarita47.Image = null;
            }
            else if (sender == pbHarita48)
            {
                pbHarita48.Image = null;
            }
            else if (sender == pbHarita49)
            {
                pbHarita49.Image = null;
            }
            else if (sender == pbHarita50)
            {
                pbHarita50.Image = null;
            }
            else if (sender == pbHarita51)
            {
                pbHarita51.Image = null;
            }
            else if (sender == pbHarita52)
            {
                pbHarita52.Image = null;
            }
            else if (sender == pbHarita53)
            {
                pbHarita53.Image = null;
            }
            else if (sender == pbHarita54)
            {
                pbHarita54.Image = null;
            }
            else if (sender == pbHarita55)
            {
                pbHarita55.Image = null;
            }
            else if (sender == pbHarita56)
            {
                pbHarita56.Image = null;
            }
            else if (sender == pbHarita57)
            {
                pbHarita57.Image = null;
            }
            else if (sender == pbHarita58)
            {
                pbHarita58.Image = null;
            }
            else if (sender == pbHarita59)
            {
                pbHarita59.Image = null;
            }
            else if (sender == pbHarita60)
            {
                pbHarita60.Image = null;
            }
            else if (sender == pbHarita61)
            {
                pbHarita61.Image = null;
            }
            else if (sender == pbHarita62)
            {
                pbHarita62.Image = null;
            }
            else if (sender == pbHarita63)
            {
                pbHarita63.Image = null;
            }
            else if (sender == pbHarita64)
            {
                pbHarita64.Image = null;
            }
            else if (sender == pbHarita65)
            {
                pbHarita65.Image = null;
            }
            else if (sender == pbHarita66)
            {
                pbHarita66.Image = null;
            }
            else if (sender == pbHarita67)
            {
                pbHarita67.Image = null;
            }
            else if (sender == pbHarita68)
            {
                pbHarita68.Image = null;
            }
            else if (sender == pbHarita69)
            {
                pbHarita69.Image = null;
            }
            else if (sender == pbHarita70)
            {
                pbHarita70.Image = null;
            }
            else if (sender == pbHarita71)
            {
                pbHarita71.Image = null;
            }
            else if (sender == pbHarita72)
            {
                pbHarita72.Image = null;
            }
            else if (sender == pbHarita73)
            {
                pbHarita73.Image = null;
            }
            else if (sender == pbHarita74)
            {
                pbHarita74.Image = null;
            }
            else if (sender == pbHarita75)
            {
                pbHarita75.Image = null;
            }
            else if (sender == pbHarita76)
            {
                pbHarita76.Image = null;
            }
            else if (sender == pbHarita77)
            {
                pbHarita77.Image = null;
            }
            else if (sender == pbHarita78)
            {
                pbHarita78.Image = null;
            }
            else if (sender == pbHarita79)
            {
                pbHarita79.Image = null;
            }
            else if (sender == pbHarita80)
            {
                pbHarita80.Image = null;
            }
            else if (sender == pbHarita81)
            {
                pbHarita81.Image = null;
            }
            else if (sender == pbHarita82)
            {
                pbHarita82.Image = null;
            }
            else if (sender == pbHarita83)
            {
                pbHarita83.Image = null;
            }
            else if (sender == pbHarita84)
            {
                pbHarita84.Image = null;
            }
            else if (sender == pbHarita85)
            {
                pbHarita85.Image = null;
            }
            else if (sender == pbHarita86)
            {
                pbHarita86.Image = null;
            }
            else if (sender == pbHarita87)
            {
                pbHarita87.Image = null;
            }
            else if (sender == pbHarita88)
            {
                pbHarita88.Image = null;
            }
            else if (sender == pbHarita89)
            {
                pbHarita89.Image = null;
            }
            else if (sender == pbHarita90)
            {
                pbHarita90.Image = null;
            }
            else if (sender == pbHarita91)
            {
                pbHarita91.Image = null;
            }
            else if (sender == pbHarita92)
            {
                pbHarita92.Image = null;
            }
            else if (sender == pbHarita93)
            {
                pbHarita93.Image = null;
            }
            else if (sender == pbHarita94)
            {
                pbHarita94.Image = null;
            }
            else if (sender == pbHarita95)
            {
                pbHarita95.Image = null;
            }
            else if (sender == pbHarita96)
            {
                pbHarita96.Image = null;
            }
            else if (sender == pbHarita97)
            {
                pbHarita97.Image = null;
            }
            else if (sender == pbHarita98)
            {
                pbHarita98.Image = null;
            }
            else if (sender == pbHarita99)
            {
                pbHarita99.Image = null;
            }
            #endregion
        }
        private void kucukHarita_Click(object sender, EventArgs e)
        {

        }
        int mouseX, mouseY;
        public void pnlHarita_Click(object sender, EventArgs e)
        {
            mouseX=mouseX * 100 / kucukHarita.Width;
            mouseY = mouseY * 100 / kucukHarita.Height;
            tBarEnlem.Value = 39192251 - Convert.ToInt32(((Convert.ToInt32(kucukHarita.Text)-(Convert.ToInt32(kucukHarita.Text)%10))/10)* 105160.1f) - Convert.ToInt32(mouseX * 105160.1f / 100);
            txtBoxEnlem.Text = tBarEnlem.Value.ToString().Substring(0, 2) + "." + tBarEnlem.Value.ToString().Substring(2);
            tBarBoylam.Value = 38293015 + Convert.ToInt32((Convert.ToSingle(kucukHarita.Text) % 10) * 215048.5f) + Convert.ToInt32(mouseY * 215048.5f / 100);
            txtBoxBoylam.Text = tBarBoylam.Value.ToString().Substring(0, 2) + "." + tBarBoylam.Value.ToString().Substring(2);
        }
        public void pnlHarita_Move(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
        public void kucukHaritaAgacYerlestirme(int index)
        {
            float boylamBaslangic = 38293015 + ((index%10) * 215048.5f); ;
            float enlemBaslangic = 39192251 - (((index-(index%10))/10) * 105160.1f);
            Panel pnl = new Panel();
            pnl.Dock = DockStyle.Fill;
            pnl.AutoScroll = true;
            kucukHarita.Controls.Add(pnl);
            pnl.Click += new EventHandler(pnlHarita_Click);
            pnl.MouseMove += new MouseEventHandler(pnlHarita_Move);
            pnl.BackgroundImage = kucukHarita.BackgroundImage;
            pnl.BackgroundImageLayout = ImageLayout.Stretch;
            if (grublanmisAgacVeri[index] != null)
            {
                string[] listelenmisAgacVeri = grublanmisAgacVeri[index].Split('-');
                for (int i = 0; i < listelenmisAgacVeri.Length; i++)
                {
                    string[] parcalanmisAgacVeri = listelenmisAgacVeri[i].Split(':');

                    if (parcalanmisAgacVeri[0] == (index + 1).ToString())
                    {
                        float yatay = float.Parse(parcalanmisAgacVeri[8]);
                        yatay = yatay - boylamBaslangic;
                        //MessageBox.Show(yatay.ToString());
                        int Yyuzde = Convert.ToInt32(yatay * 100 / 215048.5f);

                        float dikey = float.Parse(parcalanmisAgacVeri[7]);
                        dikey = enlemBaslangic - dikey;
                        //MessageBox.Show(dikey.ToString());
                        int Dyuzde = Convert.ToInt32(dikey * 100 / 105160.1f);
                        pnl.Controls.Add(pbAgac(("id:" + parcalanmisAgacVeri[1]).ToString(), Convert.ToInt32(Convert.ToSingle(kucukHarita.Width) * Yyuzde / 100), Convert.ToInt32(Convert.ToSingle(kucukHarita.Height) * Dyuzde / 100)));
                        
                    }
                }
            }
        }
        private void pbHarita_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                kucukHarita.Controls.Clear();
                kucukHarita.BackgroundImageLayout = ImageLayout.Stretch;
                kucukHarita.StartPosition = FormStartPosition.CenterScreen;
                kucukHarita.Width = pbHarita1.Width * 3;
                kucukHarita.Height = pbHarita1.Height * 3;
                kucukHarita.FormBorderStyle = FormBorderStyle.Fixed3D;
                kucukHarita.Cursor = Cursors.Cross;
                kucukHarita.TopMost = true;
                //kucukHarita.ContextMenuStrip = icMenu2;
                kucukHarita.Name = "kucukHarita";
                int a = 0;
                #region Hangi Picture Açıldı
                if (sender == pbHarita1)
                {
                    kucukHarita.BackgroundImage = pbHarita1.BackgroundImage;
                    kucukHarita.Text = a.ToString();
                    kucukHaritaAgacYerlestirme(0);
                }
                a++;
                if (sender == pbHarita2)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita2.BackgroundImage;
                    kucukHaritaAgacYerlestirme(1);
                }
                a++;
                if (sender == pbHarita3)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita3.BackgroundImage;
                    kucukHaritaAgacYerlestirme(2);
                }
                a++;
                if (sender == pbHarita4)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita4.BackgroundImage;
                    kucukHaritaAgacYerlestirme(3);
                    //Label lbl = new Label();
                    //lbl.Text = grublanmisAgacVeri[3];
                    //lbl.Top = 0;
                    //lbl.Left = 0;
                    //lbl.Width = 999;
                    //kucukHarita.Controls.Add(lbl);
                }
                a++;
                if (sender == pbHarita5)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita5.BackgroundImage;
                    kucukHaritaAgacYerlestirme(4);
                }
                a++;
                if (sender == pbHarita6)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita6.BackgroundImage;
                    kucukHaritaAgacYerlestirme(5);
                }
                a++;
                if (sender == pbHarita7)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita7.BackgroundImage;
                    kucukHaritaAgacYerlestirme(6);
                }
                a++;
                if (sender == pbHarita8)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita8.BackgroundImage;
                    kucukHaritaAgacYerlestirme(7);
                }
                a++;
                if (sender == pbHarita9)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita9.BackgroundImage;
                    kucukHaritaAgacYerlestirme(8);
                }
                a++;
                if (sender == pbHarita10)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita10.BackgroundImage;
                    kucukHaritaAgacYerlestirme(9);
                }
                a++;
                if (sender == pbHarita11)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita11.BackgroundImage;
                    kucukHaritaAgacYerlestirme(10);
                }
                a++;
                if (sender == pbHarita12)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita12.BackgroundImage;
                    kucukHaritaAgacYerlestirme(11);
                }
                a++;
                if (sender == pbHarita13)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita13.BackgroundImage;
                    kucukHaritaAgacYerlestirme(12);
                }
                a++;
                if (sender == pbHarita14)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita14.BackgroundImage;
                    kucukHaritaAgacYerlestirme(13);
                }
                a++;
                if (sender == pbHarita15)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita15.BackgroundImage;
                    kucukHaritaAgacYerlestirme(14);
                }
                a++;
                if (sender == pbHarita16)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita16.BackgroundImage;
                    kucukHaritaAgacYerlestirme(15);
                }
                a++;
                if (sender == pbHarita17)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita17.BackgroundImage;
                    kucukHaritaAgacYerlestirme(16);
                }
                a++;
                if (sender == pbHarita18)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita18.BackgroundImage;
                    kucukHaritaAgacYerlestirme(17);
                }
                a++;
                if (sender == pbHarita19)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita19.BackgroundImage;
                    kucukHaritaAgacYerlestirme(18);
                }
                a++;
                if (sender == pbHarita20)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita20.BackgroundImage;
                    kucukHaritaAgacYerlestirme(19);
                }
                a++;
                if (sender == pbHarita21)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita21.BackgroundImage;
                    kucukHaritaAgacYerlestirme(20);
                }
                a++;
                if (sender == pbHarita22)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita22.BackgroundImage;
                    kucukHaritaAgacYerlestirme(21);
                }
                a++;
                if (sender == pbHarita23)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita23.BackgroundImage;
                    kucukHaritaAgacYerlestirme(22);
                }
                a++;
                if (sender == pbHarita24)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita24.BackgroundImage;
                    kucukHaritaAgacYerlestirme(23);
                }
                a++;
                if (sender == pbHarita25)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita25.BackgroundImage;
                    kucukHaritaAgacYerlestirme(24);
                }
                a++;
                if (sender == pbHarita26)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita26.BackgroundImage;
                    kucukHaritaAgacYerlestirme(25);
                }
                a++;
                if (sender == pbHarita27)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita27.BackgroundImage;
                    kucukHaritaAgacYerlestirme(26);
                }
                a++;
                if (sender == pbHarita28)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita28.BackgroundImage;
                    kucukHaritaAgacYerlestirme(27);
                }
                a++;
                if (sender == pbHarita29)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita29.BackgroundImage;
                    kucukHaritaAgacYerlestirme(28);
                }
                a++;
                if (sender == pbHarita30)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita30.BackgroundImage;
                    kucukHaritaAgacYerlestirme(29);
                }
                a++;
                if (sender == pbHarita31)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita31.BackgroundImage;
                    kucukHaritaAgacYerlestirme(30);
                }
                a++;
                if (sender == pbHarita32)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita32.BackgroundImage;
                    kucukHaritaAgacYerlestirme(31);
                }
                a++;
                if (sender == pbHarita33)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita33.BackgroundImage;
                    kucukHaritaAgacYerlestirme(32);
                }
                a++;
                if (sender == pbHarita34)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita34.BackgroundImage;
                    kucukHaritaAgacYerlestirme(33);
                }
                a++;
                if (sender == pbHarita35)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita35.BackgroundImage;
                    kucukHaritaAgacYerlestirme(34);
                }
                a++;
                if (sender == pbHarita36)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita36.BackgroundImage;
                    kucukHaritaAgacYerlestirme(35);
                }
                a++;
                if (sender == pbHarita37)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita37.BackgroundImage;
                    kucukHaritaAgacYerlestirme(36);
                }
                a++;
                if (sender == pbHarita38)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita38.BackgroundImage;
                    kucukHaritaAgacYerlestirme(37);
                }
                a++;
                if (sender == pbHarita39)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita39.BackgroundImage;
                    kucukHaritaAgacYerlestirme(38);
                }
                a++;
                if (sender == pbHarita40)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita40.BackgroundImage;
                    kucukHaritaAgacYerlestirme(39);
                }
                a++;
                if (sender == pbHarita41)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita41.BackgroundImage;
                    kucukHaritaAgacYerlestirme(40);
                }
                a++;
                if (sender == pbHarita42)
                {
                    kucukHarita.BackgroundImage = pbHarita42.BackgroundImage;
                    kucukHaritaAgacYerlestirme(41);
                    kucukHarita.Text = a.ToString();
                }
                a++;
                if (sender == pbHarita43)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita43.BackgroundImage;
                    kucukHaritaAgacYerlestirme(42);
                }
                a++;
                if (sender == pbHarita44)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita44.BackgroundImage;
                    kucukHaritaAgacYerlestirme(43);
                }
                a++;
                if (sender == pbHarita45)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita45.BackgroundImage;
                    kucukHaritaAgacYerlestirme(44);
                }
                a++;
                if (sender == pbHarita46)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita46.BackgroundImage;
                    kucukHaritaAgacYerlestirme(45);
                }
                a++;
                if (sender == pbHarita47)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita47.BackgroundImage;
                    kucukHaritaAgacYerlestirme(46);
                }
                a++;
                if (sender == pbHarita48)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita48.BackgroundImage;
                    kucukHaritaAgacYerlestirme(47);
                }
                a++;
                if (sender == pbHarita49)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita49.BackgroundImage;
                    kucukHaritaAgacYerlestirme(48);
                }
                a++;
                if (sender == pbHarita50)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita50.BackgroundImage;
                    kucukHaritaAgacYerlestirme(49);
                }
                a++;
                if (sender == pbHarita51)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita51.BackgroundImage;
                    kucukHaritaAgacYerlestirme(50);
                }
                a++;
                if (sender == pbHarita52)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita52.BackgroundImage;
                    kucukHaritaAgacYerlestirme(51);
                }
                a++;
                if (sender == pbHarita53)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita53.BackgroundImage;
                    kucukHaritaAgacYerlestirme(52);
                }
                a++;
                if (sender == pbHarita54)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita54.BackgroundImage;
                    kucukHaritaAgacYerlestirme(53);
                }
                a++;
                if (sender == pbHarita55)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita55.BackgroundImage;
                    kucukHaritaAgacYerlestirme(54);
                }
                a++;
                if (sender == pbHarita56)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita56.BackgroundImage;
                    kucukHaritaAgacYerlestirme(55);
                }
                a++;
                if (sender == pbHarita57)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita57.BackgroundImage;
                    kucukHaritaAgacYerlestirme(56);
                }
                a++;
                if (sender == pbHarita58)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita58.BackgroundImage;
                    kucukHaritaAgacYerlestirme(57);
                }
                a++;
                if (sender == pbHarita59)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita59.BackgroundImage;
                    kucukHaritaAgacYerlestirme(58);
                }
                a++;
                if (sender == pbHarita60)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita60.BackgroundImage;
                    kucukHaritaAgacYerlestirme(59);
                }
                a++;
                if (sender == pbHarita61)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita61.BackgroundImage;
                    kucukHaritaAgacYerlestirme(60);
                }
                a++;
                if (sender == pbHarita62)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita62.BackgroundImage;
                    kucukHaritaAgacYerlestirme(61);
                }
                a++;
                if (sender == pbHarita63)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita63.BackgroundImage;
                    kucukHaritaAgacYerlestirme(62);
                }
                a++;
                if (sender == pbHarita64)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita64.BackgroundImage;
                    kucukHaritaAgacYerlestirme(63);
                }
                a++;
                if (sender == pbHarita65)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita65.BackgroundImage;
                    kucukHaritaAgacYerlestirme(64);
                }
                a++;
                if (sender == pbHarita66)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita66.BackgroundImage;
                    kucukHaritaAgacYerlestirme(65);
                }
                a++;
                if (sender == pbHarita67)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita67.BackgroundImage;
                    kucukHaritaAgacYerlestirme(66);
                }
                a++;
                if (sender == pbHarita68)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita68.BackgroundImage;
                    kucukHaritaAgacYerlestirme(67);
                }
                a++;
                if (sender == pbHarita69)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita69.BackgroundImage;
                    kucukHaritaAgacYerlestirme(68);
                }
                a++;
                if (sender == pbHarita70)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita70.BackgroundImage;
                    kucukHaritaAgacYerlestirme(69);
                }
                a++;
                if (sender == pbHarita71)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita71.BackgroundImage;
                    kucukHaritaAgacYerlestirme(70);
                }
                a++;
                if (sender == pbHarita72)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita72.BackgroundImage;
                    kucukHaritaAgacYerlestirme(71);
                }
                a++;
                if (sender == pbHarita73)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita73.BackgroundImage;
                    kucukHaritaAgacYerlestirme(72);
                }
                a++;
                if (sender == pbHarita74)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita74.BackgroundImage;
                    kucukHaritaAgacYerlestirme(73);
                }
                a++;
                if (sender == pbHarita75)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita75.BackgroundImage;
                    kucukHaritaAgacYerlestirme(74);
                }
                a++;
                if (sender == pbHarita76)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita76.BackgroundImage;
                    kucukHaritaAgacYerlestirme(75);
                }
                a++;
                if (sender == pbHarita77)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita77.BackgroundImage;
                    kucukHaritaAgacYerlestirme(76);
                }
                a++;
                if (sender == pbHarita78)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita78.BackgroundImage;
                    kucukHaritaAgacYerlestirme(77);
                }
                a++;
                if (sender == pbHarita79)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita79.BackgroundImage;
                    kucukHaritaAgacYerlestirme(78);
                }
                a++;
                if (sender == pbHarita80)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita80.BackgroundImage;
                    kucukHaritaAgacYerlestirme(79);
                }
                a++;
                if (sender == pbHarita81)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita81.BackgroundImage;
                    kucukHaritaAgacYerlestirme(80);
                }
                a++;
                if (sender == pbHarita82)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita82.BackgroundImage;
                    kucukHaritaAgacYerlestirme(81);
                }
                a++;
                if (sender == pbHarita83)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita83.BackgroundImage;
                    kucukHaritaAgacYerlestirme(82);
                }
                a++;
                if (sender == pbHarita84)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita84.BackgroundImage;
                    kucukHaritaAgacYerlestirme(83);
                }
                a++;
                if (sender == pbHarita85)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita85.BackgroundImage;
                    kucukHaritaAgacYerlestirme(84);
                }
                a++;
                if (sender == pbHarita86)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita86.BackgroundImage;
                    kucukHaritaAgacYerlestirme(85);
                }
                a++;
                if (sender == pbHarita87)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita87.BackgroundImage;
                    kucukHaritaAgacYerlestirme(86);
                }
                a++;
                if (sender == pbHarita88)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita88.BackgroundImage;
                    kucukHaritaAgacYerlestirme(87);
                }
                a++;
                if (sender == pbHarita89)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita89.BackgroundImage;
                    kucukHaritaAgacYerlestirme(88);
                }
                a++;
                if (sender == pbHarita90)
                {
                    kucukHarita.Text = a.ToString();
                    kucukHarita.BackgroundImage = pbHarita90.BackgroundImage;
                    kucukHaritaAgacYerlestirme(89);
                }
                //if (sender == pbHarita91)
                //{
                //    kucukHarita.BackgroundImage = pbHarita91.BackgroundImage;
                //}
                //else if (sender == pbHarita92)
                //{
                //    kucukHarita.BackgroundImage = pbHarita92.BackgroundImage;
                //}
                //else if (sender == pbHarita93)
                //{
                //    kucukHarita.BackgroundImage = pbHarita93.BackgroundImage;
                //}
                //else if (sender == pbHarita94)
                //{
                //    kucukHarita.BackgroundImage = pbHarita94.BackgroundImage;
                //}
                //else if (sender == pbHarita95)
                //{
                //    kucukHarita.BackgroundImage = pbHarita95.BackgroundImage;
                //}
                //else if (sender == pbHarita96)
                //{
                //    kucukHarita.BackgroundImage = pbHarita96.BackgroundImage;
                //}
                //else if (sender == pbHarita97)
                //{
                //    kucukHarita.BackgroundImage = pbHarita97.BackgroundImage;
                //}
                //else if (sender == pbHarita98)
                //{
                //    kucukHarita.BackgroundImage = pbHarita98.BackgroundImage;
                //}
                //else if (sender == pbHarita99)
                //{
                //    kucukHarita.BackgroundImage = pbHarita99.BackgroundImage;
                //}
                #endregion
                //kucukHarita.Controls.RemoveByKey("agac1");
                kucukHarita.FormClosing += new FormClosingEventHandler(kucukHaritaGizleme);
                kucukHarita.Show();
            }
            
        }

        public void pbAgacNameYakalama(object sender, MouseEventArgs e)
        {
            pbAgacName = sender;
            if (e.Button == MouseButtons.Right)
            {
                DialogResult sil = MessageBox.Show("Bu ağacı sistemden silmek istermisiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sil == DialogResult.Yes)
                {
                    kucukHarita.Controls.Remove((PictureBox)pbAgacName);
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                DialogResult sil = MessageBox.Show("Bu ağacın bilgilerini düzenlemek istermisiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (sil == DialogResult.Yes)
                {
                    //kucukHarita.Controls.Remove((PictureBox)pbAgacName);
                }
            }

        }
        public void agacIdYakala_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb =(PictureBox)sender;
            //MessageBox.Show(pb.Name);
            hangiAgac = (string)(pb.Name.Split(':')[1]);
        }

        public PictureBox pbAgac(string pbname, int top = 0, int left = 0)
        {
            var pb = new PictureBox();
            pb.Image = Image.FromFile("img//tree-icon.png");
            pb.Name = pbname;
            pb.Width = 24;
            pb.Height = 24;
            
            pb.Top = top - (pb.Height) / 2;
            pb.Left = left - (pb.Width) / 2;
            pb.Cursor = Cursors.Hand;
            pb.BackColor = Color.Transparent;
            pb.MouseEnter += new EventHandler(agacIdYakala_MouseEnter);
            //pb.MouseClick += new MouseEventHandler(pbAgacNameYakalama);
            if(grs.control==true)
                pb.ContextMenuStrip = icMenu;
            Veritabani veritabani = new Veritabani();
            string islenmisVeri=veritabani.agacListele("id", pbname.Split(':')[1]);
            string[] parcalanmisVeri = islenmisVeri.Split(':');
            if(islenmisVeri!="")
                bilgiKutusu.SetToolTip(pb, "id: "+parcalanmisVeri[1]+ "\nTuru: " + parcalanmisVeri[2] + "\nBoyu: " + parcalanmisVeri[3] + "\nÇapı: " + parcalanmisVeri[4] + "\nYaşı: " + parcalanmisVeri[5] + "\nHastalığı: " + parcalanmisVeri[6] + "\nEnlem: " + parcalanmisVeri[7] + "\nBoylam: " + parcalanmisVeri[8] + "\nTarih: " + parcalanmisVeri[9]);
            return pb;
        }
        private void kucukHaritaGizleme(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            kucukHarita.Controls.Clear();
            kucukHarita.Hide();
        }
        private void silToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult sil = MessageBox.Show("Bu ağacı sistemden silmek istermisiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sil == DialogResult.Yes)
            {
                Veritabani veritabani = new Veritabani();
                MessageBox.Show(veritabani.agacsil(hangiAgac));
                menuHarita.Items.Clear();
                mainForm mF = new mainForm();
                mainForm_Load(mF, EventArgs.Empty);
            }
            
        }



        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Veritabani veritabani = new Veritabani();
            string[] a = txtBoxEnlem.Text.Split('.');
            string[] b = txtBoxBoylam.Text.Split('.');
            int enlem = int.Parse(a[0] + a[1]);
            int boylam = int.Parse(b[0] + b[1]);
            if (lbld.Text == "")
            {
                MessageBox.Show(veritabani.agacekle(cmBoxAgacTipi.Text, Convert.ToSingle(txtBoxAgacBoyu.Text), Convert.ToSingle(txtBoxAgacCapi.Text), Convert.ToInt32(txtBoxAgacYasi.Text), txtBoxHastaligi.Text, enlem, boylam, dtPickerTarih.Value.Date, 0, 0));
            }
            else
            {
                MessageBox.Show(veritabani.agacGuncelle(int.Parse(hangiAgac), cmBoxAgacTipi.Text, int.Parse(txtBoxAgacBoyu.Text), int.Parse(txtBoxAgacCapi.Text), int.Parse(txtBoxAgacYasi.Text), txtBoxHastaligi.Text, enlem, boylam, dtPickerTarih.Value.Date.ToString(), 0, 0));
            }
            lbld.Text = "";
            menuHarita.Items.Clear();
            mainForm mF = new mainForm();
            mainForm_Load(mF, EventArgs.Empty);
        }

        private void tBarEnlem_Scroll(object sender, EventArgs e)
        {
            txtBoxEnlem.Text = tBarEnlem.Value.ToString().Substring(0, 2) + "." + tBarEnlem.Value.ToString().Substring(2);
        }

        private void txtBoxEnlem_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] a = txtBoxEnlem.Text.Split('.');
                int c = int.Parse(a[0] + a[1]);
                if (c > 38245810 && c < 39192251)
                {
                    tBarEnlem.Value = c;
                }
                else
                {
                    tBarEnlem.Value = tBarEnlem.Minimum;
                    txtBoxEnlem.Text = "38.245810";
                }
            }
            catch
            {
                tBarEnlem.Value = tBarEnlem.Minimum;
                txtBoxEnlem.Text = "38.245810";
            }

        }

        private void txtBoxEnlem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string[] a = txtBoxEnlem.Text.Split('.');
                    int c = int.Parse(a[0] + a[1]);
                    if (c > 38245810 && c < 39192251)
                    {
                        tBarEnlem.Value = c;
                    }
                    else
                    {
                        tBarEnlem.Value = tBarEnlem.Minimum;
                        txtBoxEnlem.Text = "38.245810";
                    }
                }
                catch
                {
                    tBarEnlem.Value = tBarEnlem.Minimum;
                    txtBoxEnlem.Text = "38.245810";
                }

            }
        }

        private void tBarBoylam_Scroll(object sender, EventArgs e)
        {
            txtBoxBoylam.Text = tBarBoylam.Value.ToString().Substring(0, 2) + "." + tBarBoylam.Value.ToString().Substring(2);
        }

        private void txtBoxBoylam_Leave(object sender, EventArgs e)
        {
            try
            {
                string[] a = txtBoxBoylam.Text.Split('.');
                int c = int.Parse(a[0] + a[1]);
                if (c > 38293015 && c < 40443500)
                {
                    tBarBoylam.Value = c;
                }
                else
                {
                    tBarBoylam.Value = tBarBoylam.Minimum;
                    txtBoxBoylam.Text = "38.293015";
                }
            }
            catch
            {
                tBarBoylam.Value = tBarBoylam.Minimum;
                txtBoxBoylam.Text = "38.2930150";
            }
        }

        private void txtBoxBoylam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    string[] a = txtBoxBoylam.Text.Split('.');
                    int c = int.Parse(a[0] + a[1]);
                    if (c > 38293015 && c < 40443500)
                    {
                        tBarBoylam.Value = c;
                    }
                    else
                    {
                        tBarBoylam.Value = tBarBoylam.Minimum;
                        txtBoxBoylam.Text = "38293015";
                    }
                }
                catch
                {
                    tBarBoylam.Value = tBarBoylam.Minimum;
                    txtBoxBoylam.Text = "382930150";
                }
            }
        }

        private void düzenleToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Veritabani veritabani = new Veritabani();
            string[] parcalanmisVeri = veritabani.agacListele("id", hangiAgac).Split(':');
            lbld.Text = parcalanmisVeri[1];
            cmBoxAgacTipi.Text = parcalanmisVeri[2];
            txtBoxAgacBoyu.Text = parcalanmisVeri[3];
            txtBoxAgacCapi.Text = parcalanmisVeri[4];
            txtBoxAgacYasi.Text = parcalanmisVeri[5];
            txtBoxHastaligi.Text = parcalanmisVeri[6];
            tBarEnlem.Value = int.Parse(parcalanmisVeri[7]);
            txtBoxEnlem.Text = tBarEnlem.Value.ToString().Substring(0, 2) + "." + tBarEnlem.Value.ToString().Substring(2);
            tBarBoylam.Value = int.Parse(parcalanmisVeri[8]);
            txtBoxBoylam.Text = tBarBoylam.Value.ToString().Substring(0, 2) + "." + tBarBoylam.Value.ToString().Substring(2);
            dtPickerTarih.Value = DateTime.Parse(parcalanmisVeri[9]);
            textBox9.Text = parcalanmisVeri[10];
            //menuHarita.Items.Clear();
            //mainForm mF = new mainForm();
            //mainForm_Load(mF, EventArgs.Empty);
        }

        private void btnHepListele_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            frm.Height = 500;
            frm.Width = 500;
            frm.TopMost = true;
            DataTable dt = new DataTable();
            Veritabani veritabani = new Veritabani();
            OleDbDataAdapter adaptor = veritabani.agacListeleDataview();
            adaptor.Fill(dt);
            dgv.DataSource = dt;
            frm.Controls.Add(dgv);
            frm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbld.Text = "";
        }

        private void menuHarita_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Veritabani vrtn = new Veritabani();
            vrtn.adminIdDegisme(txtBoxKadiDegistir.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtBoxSifreDegistir2.Text == txtBoxSifreDegistir.Text)
            {
                Veritabani vrtbn = new Veritabani();
                vrtbn.adminSifreDegisme(txtBoxSifreDegistir.Text);
            }
            else
            {
                MessageBox.Show("Lütfen İki Kutuyada Aynı Şifreyi Giriniz!");
            }
        }

        private void btnHastalikList_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            TreeView trv = new TreeView();
            for (int i = 0; i < 90; i++)
            {
                //MessageBox.Show(grublanmisAgacVeri[i]);
                if (grublanmisAgacVeri[i] != null)
                {
                    string[] listelenmisAgacVeri = grublanmisAgacVeri[i].Split('-');
                    trv.Nodes.Add((i+1).ToString() + ". Bölge");
                    
                    foreach (string c in listelenmisAgacVeri)
                    {
                        if (c != "")
                        {
                            trv.Nodes[trv.Nodes.Count-1].Nodes.Add(c.Split(':')[1]+ " : "+c.Split(':')[2]);
                        }
                    }
                }
            }
            trv.Dock = DockStyle.Fill;
            frm.Controls.Add(trv);
            frm.Show();
        }
    }
}
