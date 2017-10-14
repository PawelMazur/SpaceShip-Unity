using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization
    public float tumble;
    Rigidbody rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
