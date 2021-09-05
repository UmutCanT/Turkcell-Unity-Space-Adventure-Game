using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamEkran : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Bu script ile arkaplan görselimize müdahale edeceksek bu bileşene ihtiyacımız var
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        //Değişkene aldığımız scale x,y değerlerini kameranın boyutuna göre ayarlamak istiyoruz.
        Vector2 tempScale = transform.localScale;

        //Oyunun çalışcağı cihazın ekran oranına göre bir x ve y değeri elde etmek istiyoruz.
        float spriteGenislik = spriteRenderer.size.x;
        //Camera menüsündeki size cameranın y eksenindeki büyüklüğünün yarısı 
        float ekranYukseklik = Camera.main.orthographicSize * 2.0f;
        //Screen classı oyunumuzun çalıştığı cihaza göre ekran oranlarını alabileceğimiz class
        float ekranGenislik = ekranYukseklik / Screen.height * Screen.width;

        tempScale.x = ekranGenislik / spriteGenislik;
        transform.localScale = tempScale;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
