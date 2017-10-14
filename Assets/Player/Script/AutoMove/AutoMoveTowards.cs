using UnityEngine;
using System.Collections;


public class AutoMoveTowards : MonoBehaviour {


    
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

    // Use this for initialization
    //public Enums.Directions useSide = Enums.Directions.Up;
    Vector3 vectorPlayer;
    Vector3 vector;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("PlayerShip").transform;

        StartCoroutine(Follow());
    }

    IEnumerator Follow()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true)
        {
            //rigidbody.velocity = transform.forward * speed;
            yield return new WaitForSeconds(startWait);
            locationTarget = playerTransform.position.x;
            locationManeuver = -Mathf.Sign(rigidbody.velocity.y);
            
            //vectorPlayer = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
            //vector = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z);

            
            //yield return new WaitForSeconds(timeWait);
            //locationTarget = 0;
        }
    }
	
	// Update is called once per frame

    void Update()
    {
        //rigidbody.velocity = transform.forward * speed;
    }

	void FixedUpdate () {
        vectorPlayer = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
        vector = new Vector3(rigidbody.position.x, rigidbody.position.y, rigidbody.position.z);

        angleRotation = Vector3.Angle(vectorPlayer, vector);
        newManeuver = Mathf.MoveTowards(rigidbody.velocity.x, locationTarget, Time.deltaTime);
        //float newManeuver = Mathf.MoveTowards(rigidbody.velocity.x, locationTarget, Time.deltaTime);
        //float newManeuver = Mathf.MoveTowards(0, locationTarget, Time.deltaTime);

        rigidbody.velocity = new Vector3( newManeuver, 0.0f, rigidbody.velocity.z);
        rigidbody.rotation = Quaternion.Euler(newManeuver, angleRotation * Mathf.Sign(playerTransform.position.x), 0.0f);
        
	}
}
