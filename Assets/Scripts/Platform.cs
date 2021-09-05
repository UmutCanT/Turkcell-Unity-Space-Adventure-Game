using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider2D;

    float randomHiz;

    bool hareket;

    float min, max;

    //Hareket değişkenine dışardan erişebilmemiz lazım
    //Bir çeşit kontrolcü platformun hareket etmesini sağlayacak ya da durduracak
    //Bu yüzden PROPERTY yazmaya ihtiyacımız var
    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        
        if (Secenekler.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.8f);
        }

        if (Secenekler.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.5f, 1.0f);
        }

        if (Secenekler.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.5f);
        }

        //Bu genişliğin yarısı ama her seferinde yarısını kullanacağımız için 
        //Tamamını alıp hep ikiye bölmeye gerek yok
        float objeGenislik = polygonCollider2D.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            //Hareket edebilceği min max mesafeyi belirliyoruz.
            min = objeGenislik;
            //Şimdi oluşturduğumuz instancesı kullanıcaz
            //Camera genişliği ekranın orta noktasından değil de tamamından hesaplandığından yarısını kullanmamız lazım
            max = EkranHesaplayicisi.instance.Genislik - objeGenislik;
        }
        else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hareket)
        {
            //Objeler ekranın ortasına doğru soldan ya da sapdan hareket edip geri gelcek 
            //Pingpong gibi dikey çizgiler arasında sağ sol yapacak
            //Mathf kütüphanesinde buna göre fonks var
            // Sonrasında mini eklememizin nedeni minden harekete başlayacak ve min max farkı kadar git gel yapacak       
            float pingPongX = Mathf.PingPong(Time.time * randomHiz, max - min) + min;
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ayaklar")
        {
            //Bizim player objemiz platforma child olsun ki beraber hareket etsinler.
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            //Script ana objede değil child player objesinde
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamayiSifirla();
        }
    }
}
