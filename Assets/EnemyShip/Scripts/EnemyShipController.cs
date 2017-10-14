using UnityEngine;
using System.Collections;

[System.Serializable]
public class BoundaryForEnemyShip
{

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

public class EnemyShipController : MonoBehaviour {

	// Use this for initialization
    private Transform playerTransform;
    Rigidbody rigidbody;
    public BoundaryForEnemyShip boundary;
    
    //public float dodge;
    public float speedBalance;
    public float titl;
    public Vector2 dodge;
    

    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;


    private float currentSpeed;
    private float targetManeuver;


	void Start () {

        rigidbody = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip") as GameObject;
        if (player != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("PlayerShip").transform;
            StartCoroutine(Evade());
        }
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        
         
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            //targetManeuver = playerTransform.position.x;
            targetManeuver = Random.Range(dodge.x, dodge.y) * playerTransform.position.x;
            //Debug.Log( "playerTransform : " + playerTransform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        
        float newManeuver = Mathf.MoveTowards(rigidbody.velocity.x, targetManeuver, Time.deltaTime * speedBalance);
        //Debug.Log("currentSpeed : " + GetComponent<Rigidbody>().velocity.z);
        //Debug.Log("newManeuver : " + newManeuver);
        rigidbody.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);

        float movePositionX = Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax);
        float movePositionZ = Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax);
        rigidbody.position = new Vector3(movePositionX, 0.0f, movePositionZ);

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -titl);
        
    }
	
	// Update is called once per frame
	void Update () {
	    

	}
}
