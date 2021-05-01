using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orman_Takip_Programı
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        public bool control = false;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBoxKAdi.Text != "" && txtBoxSifre.Text != "")
                {
                    Veritabani vrtbn = new Veritabani();
                    string veri = vrtbn.adminGiris("kullaniciAdi", txtBoxKAdi.Text);
                    if (txtBoxSifre.Text == veri)
                    {
                        control = true;
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Bilgilerinizi Kontrol Ediniz!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgilerinizi Kontrol Ediniz!");
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            control = false;
            this.Hide();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
