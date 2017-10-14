using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FireButton3: MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public static bool isFire = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isFire = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        isFire = false;
    }
}
