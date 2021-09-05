using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Herhangi bir oyun objesine ekli component olarak çalışmıyacak ondan mono behaviourı siliyoruz.
//Class static olduğu için içindeki hiçbir değer değişmeden heryerden erişebiliriz.
public static class Secenekler
{
    //Class static olduğundan değişken ve methodlarda static olacak
    //Burdaki stringler player prefse kayıt girerken key olarak kullanılcak
    public static string kolay = "kolay";
    public static string orta = "orta";
    public static string zor = "zor";
    //PlayerPrefs bool değer desteklemediğinden hangi butonseçilmişse ona göre true false şeklinde bir ayarlama yapamıyoruz.
    //Bunun yerine int değer kullancaz 0 => seçilmemiş 1 => seçilmiş gibi

    //3 farklı zorluk seviyesi için puan ve altın
    public static string kolayPuan = "kolayPuan";
    public static string ortaPuan = "ortaPuan";
    public static string zorPuan = "zorPuan";

    public static string kolayAltin = "kolayAltin";
    public static string ortaAltin = "ortaAltin";
    public static string zorAltin = "zorAltin";

    //Müzik ses tercihi için
    public static string muzikAcik = "muzikAcik";

    public static void KolayDegerAta(int kolay)
    {
        PlayerPrefs.SetInt(Secenekler.kolay, kolay);
        //Unity dosylarının içine kolay =0,1 gibi kayıt girecek
    }

    //Değer okuyacağı için herhangi bir parametra almıyor ama return type var.
    public static int KolayDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolay);
    }

    public static void OrtaDegerAta(int orta)
    {
        PlayerPrefs.SetInt(Secenekler.orta, orta);
    }

    public static int OrtaDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.orta);
    }

    public static void ZorDegerAta(int zor)
    {
        PlayerPrefs.SetInt(Secenekler.zor, zor);
    }

    public static int ZorDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zor);
    }

    //Puanlama sistemi için seviyeye göre farklı methodlar
    public static void KolayPuanDegerAta(int kolayPuan)
    {
        PlayerPrefs.SetInt(Secenekler.kolayPuan, kolayPuan);     
    }

    public static int KolayPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolayPuan);
    }

    public static void OrtaPuanDegerAta(int ortaPuan)
    {
        PlayerPrefs.SetInt(Secenekler.ortaPuan, ortaPuan);
    }

    public static int OrtaPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.ortaPuan);
    }

    public static void ZorPuanDegerAta(int zorPuan)
    {
        PlayerPrefs.SetInt(Secenekler.zorPuan, zorPuan);
    }

    public static int ZorPuanDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zorPuan);
    }

    //Altın sistemi için seviyeye göre farklı methodlar
    public static void KolayAltinDegerAta(int kolayAltin)
    {
        PlayerPrefs.SetInt(Secenekler.kolayAltin, kolayAltin);
    }

    public static int KolayAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.kolayAltin);
    }

    public static void OrtaAltinDegerAta(int ortaAltin)
    {
        PlayerPrefs.SetInt(Secenekler.ortaAltin, ortaAltin);
    }

    public static int OrtaAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.ortaAltin);
    }

    public static void ZorAltinDegerAta(int zorAltin)
    {
        PlayerPrefs.SetInt(Secenekler.zorAltin, zorAltin);
    }

    public static int ZorAltinDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.zorAltin);
    }

    //Muzik ile ilgili methodlar
    public static void MuzikAcikDegerAta(int muzikAcik)
    {
        PlayerPrefs.SetInt(Secenekler.muzikAcik, muzikAcik);
    }

    public static int MuzikAcikDegerOku()
    {
        return PlayerPrefs.GetInt(Secenekler.muzikAcik);
    }

    //Menu ilk açıldığında daha önce kayıt var mı yok mu diye sorgulanmasını istiyoruz.
    //Böylece MenuKontrol üzerinden default zorluk ayarlayabiliriz.
    public static bool KayitVarmi()
    {
        if (PlayerPrefs.HasKey(Secenekler.kolay) || 
            PlayerPrefs.HasKey(Secenekler.orta) || PlayerPrefs.HasKey(Secenekler.zor))
        {
            return true;
        }else
        {
            return false;
        }
    }

    //Müzik tercihi için kayıt sorgulama
    public static bool MuzikAcikKayitVarmi()
    {
        if (PlayerPrefs.HasKey(Secenekler.muzikAcik))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
