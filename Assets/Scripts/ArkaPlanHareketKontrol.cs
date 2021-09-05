using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketKontrol : MonoBehaviour
{
    float arkaPlanKonum;
    //Scene penceresinden snapping tool ve hareket ile trabsform y değerine bakıp yazıldı.
    float mesafe = 10.24f;

    // Start is called before the first frame update
    void Start()
    {
        arkaPlanKonum = transform.position.y;
        //ihtiyacımız olan y değeri arkaplanın konum değeri ile aynı
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }

    // Update is called once per frame
    void Update()
    {
        if (arkaPlanKonum + mesafe < Camera.main.transform.position.y)
        {
            ArkaplanYerlestir();
        }
    }

    void ArkaplanYerlestir()
    {
        arkaPlanKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
        Vector2 yemiPozisyon = new Vector2(0, arkaPlanKonum);
        transform.position = yemiPozisyon;
    }
}
