using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gezegenler : MonoBehaviour
{
    //Bu spriteları bir game objesinin içinde tutmak istiyoruz.
    List<GameObject> gezegenler = new List<GameObject>();
    //Ekranda gözüken gezegenlerin yer değiştirmemesi lazım
    List<GameObject> kullanilanGezegenler = new List<GameObject>();
    //Her gezegen yerleştirdiğimizde birinci listden alıp ikinci liste yerleştircez
    //Birinci listdeki tüm gezegenler bitince, ikinci listdeki altta kalanları alıp
    //Birincisinin içine yerleştireceğiz

    //Kaynaklar en başta yüklensin diye awake methodunu kullanıyoruz.
    void Awake()
    {
        //Png dosyasında kesilmiş tüm spriteları yüklenecek
        //Ama unity bunların hangi tipte olduğunu bilemez ondan object kabul ediyoruz.
        Object[] sprites = Resources.LoadAll("Gezegenler");

        //i yi birden başlattık çünkü ilk eleman olarak pngnin kendisini çağırıyor içindeki bölünmüş parçacıklar
        //ikinci elemandan itibaren başlıyor. Bu yüzden de 16 gezegenimiz olmasına rağmen i<17 yaptık
        for (int i = 1; i < 17; i++)
        {
            GameObject gezegen = new GameObject();
            //Adım adım gezegen haline getireceğiz ama arayüzden değil de script aracılığı ile yapıyoruz.
            SpriteRenderer sRenderer = gezegen.AddComponent<SpriteRenderer>();
            sRenderer.sprite = (Sprite)sprites[i];
            //Parlaklık renk değerlerinin alfası
            Color spriteColor = sRenderer.color;
            spriteColor.a = 0.5f;
            sRenderer.color = spriteColor;
            //Unity için hala bir obje sprite olduğunu bilemez bu yüzden CAST işlemi uyguladık
            gezegen.name = sprites[i].name;
            //Sorting layer ayarlama
            sRenderer.sortingLayerName = "Gezegen";
            Vector2 pozisyon = gezegen.transform.position;
            pozisyon.x = -10;
            gezegen.transform.position = pozisyon;
            gezegenler.Add(gezegen);
        }
    }
    
    public void GezegenYerlestir(float refY)
    {
        float yukseklik = EkranHesaplayicisi.instance.Yukseklik;
        float genislik = EkranHesaplayicisi.instance.Genislik;
        //1.Bölge x ve y pozitif
        float xDeger1 = Random.Range(0.0f, genislik);
        //Bu oyun boyun boynca çalışcak ve statik bir değeri olmayacak
        //Bu rangein içine parametre olarak gelmesini istiyoruz.
        float yDeger1 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen1 = RandomGezegen();
        gezegen1.transform.position = new Vector2(xDeger1, yDeger1);

        //2.Bölge x-,y+
        float xDeger2 = Random.Range(-genislik, 0.0f);
        float yDeger2 = Random.Range(refY, refY + yukseklik);
        GameObject gezegen2 = RandomGezegen();
        gezegen2.transform.position = new Vector2(xDeger2, yDeger2);

        //3.Bölge x-,y-
        float xDeger3 = Random.Range(-genislik, 0.0f);
        float yDeger3 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen3 = RandomGezegen();
        gezegen3.transform.position = new Vector2(xDeger3, yDeger3);

        //4.Bölge x+,y-
        float xDeger4 = Random.Range(0.0f, genislik);
        float yDeger4 = Random.Range(refY - yukseklik, refY);
        GameObject gezegen4 = RandomGezegen();
        gezegen4.transform.position = new Vector2(xDeger4, yDeger4);
    }

    //Bize rastgele istdeiğimiz standartlara göre gezegen dönen method
    GameObject RandomGezegen()
    {
        if(gezegenler.Count > 0)
        {
            int random;
            //İçerde sadece 1 eleman varsa ve onun da indexi 0 olacağından buna önlem almamız lazım
            if(gezegenler.Count == 1)
            {
                random = 0;
            }
            else
            {
                random = Random.Range(0, gezegenler.Count - 1);
            }
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                gezegenler.Add(kullanilanGezegenler[i]);
            }
            //Döngünün içinde kaldırmamamızın nedeni göndünün içindeki bir sonraki elemanın indexi değişiyor
            kullanilanGezegenler.RemoveRange(0, 8);
            int random = Random.Range(0, 8);
            GameObject gezegen = gezegenler[random];
            gezegenler.Remove(gezegen);
            kullanilanGezegenler.Add(gezegen);
            return gezegen;
        }
    }
}
