using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol instance;

    AudioSource audioSource;

    void Awake()
    {
        Singleton();
        audioSource = GetComponent<AudioSource>();
    }

    void Singleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //Sahneler arası geçişte bu instance ı yoketme
            DontDestroyOnLoad(instance);
        }
    }

    public void MuzikCal(bool play)
    {
        if (play)
        {
            //Ve şimdi çalan bir müzik yoksa
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {        
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
