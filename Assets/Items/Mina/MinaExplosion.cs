using UnityEngine;
using System.Collections;

public class MinaExplosion : MonoBehaviour {

    public GameObject explosion;
    public float time = 10;

    void Start()
    {
        Invoke("AutoDestroy", time);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShip") || (other.CompareTag("PlayerMissile")))
        {
            Instantiate(explosion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }
    
}
