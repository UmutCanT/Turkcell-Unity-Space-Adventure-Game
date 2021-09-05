using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    //Oyun bitince açılan panelde UI normal ekrandaki UI elementlerini kaybetmemiz lazım
    //Bu yüzden UI elementlerinin hepsini tanıtalım
    public GameObject ziplamaButonu;
    public GameObject joystick;
    public GameObject tabela;
    public GameObject oyunBittiPanel;
    public GameObject slider;
    public GameObject menuButonu;


    // Start is called before the first frame update
    void Start()
    {
        oyunBittiPanel.SetActive(false);
        UIAc();
    }

    public void OyunuBitir()
    {
        FindObjectOfType<SesKontrol>().OyunBittiSes();
        oyunBittiPanel.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        FindObjectOfType<KameraHareket>().OyunBitti();
        UIKapat();
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }

    //Hiyerarşide bunların hepsini tek bir boş obje altında toplayıp onu açıp kapamak daha doğru olacaktır
    //Şimdilik böyle ayrı ayrı müdahale ediyoruz.
    void UIAc()
    {
        ziplamaButonu.SetActive(true);
        joystick.SetActive(true);
        tabela.SetActive(true);
        slider.SetActive(true);
        menuButonu.SetActive(true);
    }

    void UIKapat()
    {
        ziplamaButonu.SetActive(false);
        joystick.SetActive(false);
        tabela.SetActive(false);
        slider.SetActive(false);
        menuButonu.SetActive(false);
    }
}
