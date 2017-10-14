using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{

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
