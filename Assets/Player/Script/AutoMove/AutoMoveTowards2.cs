using UnityEngine;
using System.Collections;

public class AutoMoveTowards2 : MonoBehaviour {

    public GameObject explosion;
    public float speed = 3f;
    public float spawnWait;
    public float startWait;
    public float timeWait;
    public float tilt = 10;

    Rigidbody rigidbody;

    private float angleRotation;
    private float locationTarget;
    private float locationManeuver;
    private float newManeuver;
    private Transform playerTransform;

    Vector3 vectorPlayer;
    Vector3 vector;
    GameObject player;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("PlayerShip") as GameObject;
        if (player != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("PlayerShip").transform;
        }
        Invoke("DestroyBomb", 15);
    }

    void DestroyBomb()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            transform.rotation = Quaternion.LookRotation(transform.position - playerTransform.position);
            rigidbody.velocity = new Vector3(-transform.forward.x, 0.0f, -transform.forward.z);
        }

    }
}
