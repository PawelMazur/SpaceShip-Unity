using UnityEngine;
using System.Collections;

[System.Serializable]
public class BoundaryForEnemyBossShip
{

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
}

[System.Serializable]
public class BoundaryCenter
{

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
} 

public class EnemyBossController : MonoBehaviour {

    // Use this for initialization
    private Transform playerTransform;
    Rigidbody rigidbody;
    public BoundaryForEnemyBossShip boundary;
    public BoundaryCenter boundaryCenter;

    //public float dodge;
    public float speedBalance;
    public float titl;
    public Vector2 dodgeX;


    public Vector2 startWaitX;
    public Vector2 maneuverTimeX;
    public Vector2 maneuverWaitX;

    public Vector2 dodgeZ;
    public Vector2 startWaitZ;
    public Vector2 maneuverTimeZ;
    public Vector2 maneuverWaitZ;


    private float currentSpeed;
    private float targetManeuverX;
    private float targetManeuverZ;


    void Start()
    {

        rigidbody = GetComponent<Rigidbody>();
        GameObject player = GameObject.FindGameObjectWithTag("PlayerShip") as GameObject;
        if (player != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("PlayerShip").transform;
            StartCoroutine(EvadeX());
            StartCoroutine(EvadeZ());
        }
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        

    }

    IEnumerator EvadeX()
    {
        yield return new WaitForSeconds(Random.Range(startWaitX.x, startWaitX.y));
        while (true)
        {
            //targetManeuver = playerTransform.position.x;
            targetManeuverX = Random.Range(dodgeX.x, dodgeX.y) * playerTransform.position.x;
            //Debug.Log("playerTransform : " + playerTransform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTimeX.x, maneuverTimeX.y));
            targetManeuverX = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWaitX.x, maneuverWaitX.y));
        }
    }

    IEnumerator EvadeZ()
    {
        yield return new WaitForSeconds(Random.Range(startWaitZ.x, startWaitZ.y));
        while (true)
        {
            //targetManeuver = playerTransform.position.x;
            targetManeuverZ = Random.Range(dodgeZ.x, dodgeZ.y) * playerTransform.position.x;
            //Debug.Log("playerTransform : " + playerTransform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTimeZ.x, maneuverTimeZ.y));
            targetManeuverZ = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWaitZ.x, maneuverWaitZ.y));
        }
    }



    void FixedUpdate()
    {

        float newManeuverX = Mathf.MoveTowards(rigidbody.velocity.x, targetManeuverX, Time.deltaTime * speedBalance);
        float newManeuverZ = Mathf.MoveTowards(rigidbody.velocity.x, targetManeuverZ, Time.deltaTime * speedBalance);


        //Debug.Log("currentSpeed : " + GetComponent<Rigidbody>().velocity.z);
        //Debug.Log("newManeuver : " + newManeuverX);

        if (rigidbody.velocity.x > 8)
        {
            rigidbody.velocity = new Vector3(newManeuverX, 0.0f, currentSpeed);
        }
        else if (rigidbody.velocity.x < 8)
        {
            rigidbody.velocity = new Vector3(newManeuverX, 0.0f, newManeuverZ);
        }

        float movePositionX = Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax);
        float movePositionZ = Mathf.Clamp(rigidbody.position.z, boundary.zMin, boundary.zMax);
        rigidbody.position = new Vector3(movePositionX, 0.0f, movePositionZ);
        /*
        if (rigidbody.position.z >= 6)
        {
            stayInCenter();
        }*/

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -titl);

    }

    void stayInCenter()
    {
        float movePositionX = Mathf.Clamp(rigidbody.position.x, boundaryCenter.xMin, boundaryCenter.xMax);
        float movePositionZ = Mathf.Clamp(rigidbody.position.z, boundaryCenter.zMin, boundaryCenter.zMax);
        rigidbody.position = new Vector3(movePositionX, 0.0f, movePositionZ);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
