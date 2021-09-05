using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraHareket : MonoBehaviour
{
    float hiz;
    float hizlanma;
    float maksimumHiz;

    bool hareket;

    // Start is called before the first frame update
    void Start()
    {
        //Hareket değşkeninin atmasını startın içine aldık
        //Bu şekilde her oyun sahnesi açıldığında true olcak
        hareket = true;

        //Zorluk değerine göre hız değerlerini ayarlama
        if(Secenekler.KolayDegerOku() == 1)
        {
            hiz = 0.3f;
            hizlanma = 0.03f;
            maksimumHiz = 1.5f;
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            hiz = 0.5f;
            hizlanma = 0.05f;
            maksimumHiz = 2.0f;
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            hiz = 0.8f;
            hizlanma = 0.08f;
            maksimumHiz = 2.5f;
        }
        //Kurduğumuz sistemden dolayı bu değerlerden birisinin her türlü 1 olacağına eminiz
        //Ondan başka bir kontrole gerek yok.
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            KamerayiHareketEttir();
        }   
    }

    void KamerayiHareketEttir()
    {
        //Up direk y ekseninde yukarı doğru hareketi sağlar
        transform.position += transform.up * hiz * Time.deltaTime;
        hiz += hizlanma * Time.deltaTime;
        if(hiz > maksimumHiz)
        {
            hiz = maksimumHiz;
        }
    }

    public void OyunBitti()
    {
        hareket = false;
    }
}
