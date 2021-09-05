using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altin : MonoBehaviour
{
    [SerializeField]
    GameObject altin = default;

    public void AltınAc()
    {
        altin.SetActive(true);
    }

    public void AltınKapat()
    {
        altin.SetActive(false);
    }
}
