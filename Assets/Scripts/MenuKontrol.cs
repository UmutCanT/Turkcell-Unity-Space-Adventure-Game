using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sahneler arası işlemler için
using UnityEngine.SceneManagement;
//Müzik butonun simgesini değiştirebilmek içink için bu classın butonu da tanıması lazım
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField]
    Sprite[] muzikIkonlar = default;

    [SerializeField]
    Button muzikButon = default;

    // Start is called before the first frame update
    void Start()
    {
        //Default zorluk seviyesi atamak için
        if(Secenekler.KayitVarmi() == false)
        {
            Secenekler.OrtaDegerAta(1);
        }
        //Default müzik ayarı için 
        if (Secenekler.MuzikAcikKayitVarmi() == false)
        {
            Secenekler.MuzikAcikDegerAta(1);
        }
        //Önceden varolan bool muzikAcik = true; silindi artık playerprefs kullanıyoruz
        //Burda da start olduğunda ikonun nasıl gözükceği ayarlanıyor
        MuzikAyarlariniDenetle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }

    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }

    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    //PlayerPrefs e göre düzenlenmiş hali buton tarafından çalıştırılan method
    public void Muzik()
    {
        if (Secenekler.MuzikAcikDegerOku() == 1)
        {
            Secenekler.MuzikAcikDegerAta(0);
            MuzikKontrol.instance.MuzikCal(false);
            muzikButon.image.sprite = muzikIkonlar[0];
        }
        else
        {
            Secenekler.MuzikAcikDegerAta(1);
            MuzikKontrol.instance.MuzikCal(true);
            muzikButon.image.sprite = muzikIkonlar[1];
        }
    }

    void MuzikAyarlariniDenetle()
    {
        if(Secenekler.MuzikAcikDegerOku() == 1)
        {
            muzikButon.image.sprite = muzikIkonlar[1];
            MuzikKontrol.instance.MuzikCal(true);
        }
        else
        {
            muzikButon.image.sprite = muzikIkonlar[0];
            MuzikKontrol.instance.MuzikCal(false);
        }
    }
}
