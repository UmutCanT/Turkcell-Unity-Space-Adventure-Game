using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    int puan;
    int enYuksekPuan;
    int altin;
    int enYuksekAltin;

    //Kamera harekete devam ettiğinden puan artmaya devam edecek ondan bunun kontrolünü yapmamız lazım
    bool puanTopla = true;

    [SerializeField]
    Text puanText = default;

    [SerializeField]
    Text altinText = default;

    //Oyun Bitiş panelinde gözükecek skorlar
    [SerializeField]
    Text oyunBittiPuanText = default;

    [SerializeField]
    Text oyunBittiAltinText = default;

    // Start is called before the first frame update
    void Start()
    {
        //En başta startın içinde altın değerini sıfırlıyoruz.
        altinText.text = "X " + altin;
    }

    // Update is called once per frame
    void Update()
    {
        //Kontrolü yaptığımız yer
        if (puanTopla)
        {
            //Yukarı çıktıkça puan artacağından kameranın y eksenindeki konumunu kullanacağız.
            //Kamera konum bilgileri float olarak gelmektedir. Bu yüzden biz sadece tam sayı basamağını almak istiyoruz.
            puan = (int)Camera.main.transform.position.y; //Bu işleme  "CAST" işlemi denir.
            puanText.text = "SCORE: " + puan;
        }      
    }

    // Altın kazandıkça çağıralacak method
    public void AltinKazan()
    {
        FindObjectOfType<SesKontrol>().AltinSes();
        altin++;
        altinText.text = "X " + altin;
    }

    public void OyunBitti()
    {
        if(Secenekler.KolayDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.KolayPuanDegerOku();
            enYuksekAltin = Secenekler.KolayAltinDegerOku();
            if(puan > enYuksekPuan)
            {
                Secenekler.KolayPuanDegerAta(puan);
            }
            if(altin > enYuksekAltin)
            {
                Secenekler.KolayAltinDegerAta(altin);
            }
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.OrtaPuanDegerOku();
            enYuksekAltin = Secenekler.OrtaAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.OrtaAltinDegerAta(altin);
            }
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.ZorPuanDegerOku();
            enYuksekAltin = Secenekler.ZorAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.ZorPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.ZorAltinDegerAta(altin);
            }
        }

        puanTopla = false;
        oyunBittiPuanText.text = "SCORE: " + puan;
        oyunBittiAltinText.text = "X " + altin;
    }
}
