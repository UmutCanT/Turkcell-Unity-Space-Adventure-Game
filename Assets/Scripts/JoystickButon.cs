using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //HareketKontrol scriptinden erişeceğimiz için public
    //ama inspectorda gözükmesini istemiyoruz.
    [HideInInspector]
    public bool tusaBasildi;

    //Bu method parametre olarak pointer event data alacak
    //Bunun için önce EventSystemi içeri almamız lazım
    public void OnPointerDown(PointerEventData eventData)
    {
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tusaBasildi = false;
    }
}
