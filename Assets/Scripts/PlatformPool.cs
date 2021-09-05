using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField]
    GameObject platformPrefab = default;

    [SerializeField]
    GameObject olumculPlatformPrefab = default;

    [SerializeField]
    GameObject playerPrefab = default;

    List<GameObject> platforms = new List<GameObject>();

    Vector2 platformPozisyon;

    Vector2 playerPozisyon;

    [SerializeField]
    float platformArasiMesafe = default;

    // Start is called before the first frame update
    void Start()
    {
        PlatformUret(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Ekran hep yukarı doğru hareket ettiğinden
        //Ekran hesaplayıcısındaki yüksekliği ekliyoruz çünkü ilki orta noktasını verir
        if (platforms[platforms.Count - 1].transform.position.y < 
            Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }
    //İki farklı method düşünmemiz lazım
    //1. Oyun çalıştığında tüm platformları bizim için üretecek
    //2. Yeri geldikçe bu platformların yerlerini değiştircek 

    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        //Platformun üstünde görünmesini istiyoruz.
        playerPozisyon = new Vector2(0, 0.5f);

        GameObject player = Instantiate(playerPrefab, playerPozisyon, Quaternion.identity);
        GameObject ilkPLatform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
        //Oyun başlar başlamaz player platform arasında parent child ilişkisi kurulmuş oldu.
        player.transform.parent = ilkPLatform.transform;
        platforms.Add(ilkPLatform);
        SonrakiPLatformPozisyon();
        ilkPLatform.GetComponent<Platform>().Hareket = true;

        //Döngüyü orjinal hesaplamamızdan bir düşürebiliriz çünkü bata bir platform ekledik
        //Ölümcül platfrom da ekleyeceğimizden bir daha düşüyoruz
        for (int i = 0; i < 8; i++)
        {
            GameObject platform = Instantiate(platformPrefab, platformPozisyon, Quaternion.identity);
            platforms.Add(platform);
            //Platform.cs deki hareket değişkenine Property yardımıyla eriştik
            platform.GetComponent<Platform>().Hareket = true;
            //Burdaki 8 platform içinde, her iki platformdan birinin altınlı olmasını istiyoruz.
            if(i % 2 == 0)
            {
                platform.GetComponent<Altin>().AltınAc();
            }
            SonrakiPLatformPozisyon();
        }

        GameObject olumculPlatform = Instantiate(olumculPlatformPrefab, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiPLatformPozisyon();
    }
    //Üstteki döngü tüm platformları üst üste üretecek
    //Bu yüzden ilk platform üretildekten sonra diğerlerine müdahale etmemiz lazım

    //Bir önceki platforma göre uygun bir şekilde konum belirlenmesini istiyoruz.
    void SonrakiPLatformPozisyon()
    {
        platformPozisyon.y += platformArasiMesafe;
        SiraliPozisyon();
    }

    //İlk tasarladığımız random pozisyon
    void KarmaPozisyon()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (random < 0.5f)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }
    }

    //Sonradaki tasarladığımız bir sağ bir sol pozisyon
    bool yon = true;
    void SiraliPozisyon()
    {
        if (yon)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;
            yon = false;
        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
            yon = true;
        }
    }

    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            //5. elemanan ve sonrasını bir geçici objeye alıyorum
            temp = platforms[i + 5];
            //Sonrasında ise ilk 5 elemanı listenin son 5ine taşıyorum
            platforms[i + 5] = platforms[i];
            //Sonra tempde duran elemanları listenin başına taşıyorum
            platforms[i] = temp;
            // Şimdi ekranda aşağıda kalan elemanların yerini değiştirebiliriz
            platforms[i + 5].transform.position = platformPozisyon;
            if(platforms[i + 5].gameObject.tag == "Platform")
            {
                //Öncelikle platforms[i + 5]'de bir altın varsa ve oyuncu onu daha önce toplamadıysa
                //Aşağıdan gelen platformda hali hazırda bir altın olabilir. Önce onu kapatalım.
                platforms[i + 5].GetComponent<Altin>().AltınKapat();
                float rastGeleAltin = Random.Range(0.0f, 1.0f);
                if(rastGeleAltin > 0.5)
                {
                    platforms[i + 5].GetComponent<Altin>().AltınAc();
                }
            }
            SonrakiPLatformPozisyon();
        }
    }
}
