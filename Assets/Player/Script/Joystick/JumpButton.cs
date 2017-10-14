using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler{

    public static bool isJump = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isJump = true;
    }
}
