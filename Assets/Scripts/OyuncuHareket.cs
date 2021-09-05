using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    //Speedden farkı yönü var
    Vector2 velocity;

    [SerializeField]
    float hiz = default;

    [SerializeField]
    float hizlanma = default;

    [SerializeField]
    float yavaslama = default;

    [SerializeField]
    float ziplamaGucu = default;

    [SerializeField]
    int ziplamaLimiti = 3;
    
    int ziplamaSayisi;

    bool zipliyor;

    Joystick joystick;

    JoystickButon joystickButon;

    // Start is called before the first frame update
    void Start()
    {
        joystickButon = FindObjectOfType<JoystickButon>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Sahnede joystick tipinde bileşeni olan objeyi bul
        //ve onu buradaki değişkene ata
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        KlavyeKontrol();
#else
        JoystickKontrol();
#endif
    }

    //IOS için geliştirilmesine karşın geliştirme sırasında tüm kontroller klavyeden yapılacağı için
    void KlavyeKontrol()
    {
        float hareketInput = Input.GetAxisRaw("Horizontal");
        Vector2 scale = transform.localScale;
        if(hareketInput > 0)
        {
            //Unity sık kullanılan matematik fonksiyonlarını Mathf classında toplamıştır.
            //Önceden gidilmek istenen yönde güç ekleyerek hareket sağlamıştık şimdi başka bir fonks. kullanacağız.
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            //Walk animasyonunu aktive etkmek için
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }else if(hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if (Input.GetKeyDown("space"))
        {
            ZiplamayiBaslat();
        }

        if (Input.GetKeyUp("space"))
        {
            ZiplamayiDurdur();
        }
    }

    void JoystickKontrol()
    {
        //Joyistick asseti aynı klavyede olduğu gibi -1 ile 1 arasında horizantal değer sağlıyor
        float hareketInput = joystick.Horizontal;
        // Değişken, aynı klavyedki gibi davrnadığından klavyedeki yönlendirmeyi buraya kopyalıyoruz
        Vector2 scale = transform.localScale;
        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }
        else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, hareketInput * hiz, hizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }

        transform.localScale = scale;
        transform.Translate(velocity * Time.deltaTime);

        if(joystickButon.tusaBasildi == true && zipliyor == false)
        {
            zipliyor = true;
            ZiplamayiBaslat();
        }

        if (joystickButon.tusaBasildi == false && zipliyor == true)
        {
            zipliyor = false;
            ZiplamayiDurdur();
        }
    }

    void ZiplamayiBaslat()
    {
        //Zıplamayı başlatmadan önce bir kontrol yapmamız gerekmektedir.
        //ZıplamaSayısı 0dan başlıyacağı için <= yapmamıza gerek yok
        if(ziplamaSayisi < ziplamaLimiti)
        {
            FindObjectOfType<SesKontrol>().ZiplamaSes();
            rb2d.AddForce(new Vector2(0, ziplamaGucu), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        } 
    }

    void ZiplamayiDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    //Oyuncunun ayağındaki colliderlar platforma temas edince zıplama sayısı sıfırlanmalı
    //Public yapıyoruz ki platform classından erişebilelim
    public void ZiplamayiSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Olum")
        {
            FindObjectOfType<OyunKontrol>().OyunuBitir();
        }
    }

    // Oyun Bitti methodunu bu şekilde ayırmak ilerde oyun bitmesi için başka sebepler eklediğimizde işimizi kolaylaştırcaktır.
    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
