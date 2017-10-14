using UnityEngine;
using System.Collections;

public class DestroyByTimeEffect : MonoBehaviour {

    public int time;
    public GameObject explosionEffect;

    void Start(){

        Invoke("DestroyInTime", time);
    }

    public void DestroyInTime()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
