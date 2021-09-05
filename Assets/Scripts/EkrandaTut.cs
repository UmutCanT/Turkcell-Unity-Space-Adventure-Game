using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkrandaTut : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Singleton design patternle oluşturduğumuz ekran hesaplayicisini kullanıyoruz.
        //Ekranın sol tarafı için
        if(transform.position.x < -EkranHesaplayicisi.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = -EkranHesaplayicisi.instance.Genislik;
            transform.position = temp;
        }
        //Ekranın sag tarafı için
        if (transform.position.x > EkranHesaplayicisi.instance.Genislik)
        {
            Vector2 temp = transform.position;
            temp.x = EkranHesaplayicisi.instance.Genislik;
            transform.position = temp;
        }
    }
}
