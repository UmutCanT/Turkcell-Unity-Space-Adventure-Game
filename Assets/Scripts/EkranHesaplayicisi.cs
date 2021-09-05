using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkranHesaplayicisi : MonoBehaviour
{
    //Diğer tüm classlar içinde kullanabileceğimiz bir instance olacak
    public static EkranHesaplayicisi instance;

    float yukseklik;
    float genislik;

    //Değerlere ulaşabilmek için property yazıyoruz
    public float Yukseklik
    {
        get
        {
            return yukseklik;
        }
    }

    public float Genislik
    {
        get
        {
            return genislik;
        }
    }

    void Awake()
    {
        //Tekil yapmak için
        if(instance == null)
        {
            //Herhangi bir değer atanmamışsa burdaki değeri kullan
            instance = this;
        }else if(instance != this)
        {
            //Burdakinden başka bir değer atanmışsa yoket
            Destroy(gameObject);
        }

        yukseklik = Camera.main.orthographicSize;
        genislik = yukseklik * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
