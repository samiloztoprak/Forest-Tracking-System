using System;
using System.Data.OleDb;
using System.Windows.Forms;

public class Veritabani
{
    OleDbConnection baglanti;
    OleDbDataAdapter adaptor;
    OleDbCommand komut;
    OleDbDataReader reader;

    public Veritabani()
    {
        baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data\\orman.accdb");
    }

    public string agacsil(string id)
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Delete from orman where id=" + Convert.ToInt32(id), baglanti);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            return "Başarılı";
        }
        catch (Exception ex)
        {
            baglanti.Close();
            return ex.Message;
        }
    }
    public string agacekle(string agacTipi, float agacBoyu, float agacCapi, int agacYasi, string hastaligi, int enlem, int boylam, DateTime tarih, int kisiId, int onaylayanId)
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Insert Into orman(agacTipi,agacBoyu,agacCapi,agacYasi,hastaligi,enlem,boylam,tarih,kisiId,onaylayanId) Values ('" + agacTipi + "','" + agacBoyu + "','" + agacCapi + "','" + agacYasi + "','" + hastaligi + "','" + enlem + "','" + boylam + "','" + tarih.ToShortDateString() + "'," + kisiId + "," + onaylayanId + ")", baglanti);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            return "Başarılı";
        }
        catch (Exception ex)
        {
            baglanti.Close();
            return ex.Message;
        }

    }
    public string agacGuncelle(int id, string agacTipi, int agacBoyu, int agacCapi, int agacYasi, string hastaligi, int enlem, int boylam, string tarih, int kisiId, int onaylayanId)
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Update orman set agacTipi='" + agacTipi + "',agacBoyu=" + agacBoyu + ",agacCapi=" + agacCapi + ",agacYasi=" + agacYasi + ",hastaligi='" + hastaligi + "',enlem=" + enlem + ",boylam=" + boylam + ",tarih='" + tarih + "',kisiId=" + kisiId + ",onaylayanId=" + onaylayanId + " where id=" + id, baglanti);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            return "Başarılı";
        }
        catch (Exception ex)
        {
            baglanti.Close();
            return ex.Message;
        }
    }
    public string agacListele()
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand();
            komut.CommandText = "Select *from orman";
            komut.Connection = baglanti;
            komut.CommandType = System.Data.CommandType.Text;
            reader = komut.ExecuteReader();
            float enlem = 39192251;
            float boylam = 38293015;
            int bolum = 1;
            string islenmisVeri = "";
            while (reader.Read())
            {
                enlem = 39192251;
                boylam = 38293015;
                bolum = 1;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if ((Convert.ToSingle(reader["boylam"]) >= boylam & Convert.ToSingle(reader["boylam"]) < boylam + 215048.5f) && (Convert.ToSingle(reader["enlem"]) <= enlem & Convert.ToSingle(reader["enlem"]) > enlem - 105160.1f))
                        {
                            //MessageBox.Show(reader["boylam"].ToString() + "::::" + boylam.ToString() + "_____" + bolum.ToString());
                            islenmisVeri = islenmisVeri + bolum.ToString() + ":" + reader["id"].ToString() + ":" + reader["agacTipi"].ToString() + ":" + reader["agacBoyu"].ToString() + ":" + reader["agacCapi"].ToString() + ":" + reader["agacYasi"].ToString() + ":" + reader["hastaligi"].ToString() + ":" + reader["enlem"].ToString() + ":" + reader["boylam"].ToString() + ":" + reader["tarih"].ToString() + ":" + reader["kisiId"].ToString() + ":" + reader["onaylayanId"].ToString() + "-";
                        }
                        bolum = bolum + 1;
                        boylam = boylam + 215048.5f;
                    }
                    boylam = 38293015;
                    enlem = enlem - 105160.1f;
                }

            }
            baglanti.Close();
            return islenmisVeri;
        }
        catch (Exception ex)
        {
            baglanti.Close();
            MessageBox.Show(ex.Message);
            return ex.Message;
        }
    }
    public string agacListele(string aramaTipi, string agacBilgisi)
    {
        baglanti.Open();
        //try
        //{
        if (aramaTipi == "agacTipi" || aramaTipi == "hastaligi" || aramaTipi == "tarih")
            komut = new OleDbCommand("Select *from orman where " + aramaTipi + "='" + agacBilgisi + "'", baglanti);
        else
            komut = new OleDbCommand("Select *from orman where " + aramaTipi + "=" + int.Parse(agacBilgisi), baglanti);
        reader = komut.ExecuteReader();
        float enlem = 38245810;
        float boylam = 38293015;
        int bolum = 1;
        string islenmisVeri = "";
        while (reader.Read())
        {
            enlem = 39192251;
            boylam = 38293015;
            bolum = 1;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((Convert.ToSingle(reader["boylam"]) >= boylam & Convert.ToSingle(reader["boylam"]) < boylam + 215048.5f) && (Convert.ToSingle(reader["enlem"]) <= enlem & Convert.ToSingle(reader["enlem"]) > enlem - 105160.1f))
                    {
                        //MessageBox.Show(reader["boylam"].ToString() + "::::" + boylam.ToString() + "_____" + bolum.ToString());
                        islenmisVeri = islenmisVeri + bolum.ToString() + ":" + reader["id"].ToString() + ":" + reader["agacTipi"].ToString() + ":" + reader["agacBoyu"].ToString() + ":" + reader["agacCapi"].ToString() + ":" + reader["agacYasi"].ToString() + ":" + reader["hastaligi"].ToString() + ":" + reader["enlem"].ToString() + ":" + reader["boylam"].ToString() + ":" + reader["tarih"].ToString() + ":" + reader["kisiId"].ToString() + ":" + reader["onaylayanId"].ToString() + "-";
                    }
                    bolum = bolum + 1;
                    boylam = boylam + 215048.5f;
                }
                boylam = 38293015;
                enlem = enlem - 105160.1f;
            }

        }
        baglanti.Close();
        return islenmisVeri;
        //}
        //catch(Exception ex)
        //{
        //    baglanti.Close();
        //    MessageBox.Show(ex.Message);
        //    return ex.Message;          
        //}

    }
    public OleDbDataAdapter agacListeleDataview()
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Select *from orman", baglanti);
            adaptor = new OleDbDataAdapter(komut);
            baglanti.Close();
            return adaptor;
        }
        catch (Exception ex)
        {
            baglanti.Close();
            MessageBox.Show(ex.Message);
        }
        return adaptor;
    }
    public string adminGiris(string aramaTipi, string aramaBilgisi)
    {
        baglanti.Open();
        try
        {
            string a = "";
            komut = new OleDbCommand("Select *from yonetici where " + aramaTipi + "='" + aramaBilgisi + "'", baglanti);
            reader = komut.ExecuteReader();
            while (reader.Read())
            {
                a=reader[2].ToString();
            }
            baglanti.Close();
            return a;
        }
        catch (Exception ex)
        {
            baglanti.Close();
            return ex.Message;
        }
    }
    public void adminIdDegisme(string kullaniciAdi)
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Update yonetici set kullaniciAdi='"+ kullaniciAdi +"' where id=1", baglanti);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show("Kullanici Adınız Değişti");
        }
        catch (Exception ex)
        {
            baglanti.Close();
            MessageBox.Show(ex.Message);
        }
    }
    public void adminSifreDegisme(string kullaniciSifre)
    {
        baglanti.Open();
        try
        {
            komut = new OleDbCommand("Update yonetici set kullaniciSifresi='" + kullaniciSifre + "' where id=1", baglanti);
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            MessageBox.Show("Sifreniz Değişti");
        }
        catch (Exception ex)
        {
            baglanti.Close();
            MessageBox.Show(ex.Message);
        }
    }
}
