using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float time;

    void Start()
    {

        Invoke("DestroyInTime", time);
    }

    public void DestroyInTime()
    {
        Destroy(gameObject);
    }
}
