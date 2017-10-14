using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    Rigidbody rigidbody;
    public float speed;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        //rigidbody.velocity = transform.forward * speed;
	}
}
