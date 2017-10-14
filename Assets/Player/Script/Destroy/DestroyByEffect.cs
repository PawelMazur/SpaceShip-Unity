using UnityEngine;
using System.Collections;

public class DestroyByEffect : MonoBehaviour {

	// Use this for initialization
    private GameController gameController;

    public int time;
    public GameObject explosionEffect;
    public GameObject explosionEnemyEffect;
    
    public float explosionRadius;

    public LayerMask layerMask;

    


	void Start () {

        Invoke("DestroyInTime", time);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Can not find 'GameController' script");
        }
	}    


    public void DestroyInTime()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, layerMask);
        
        for (int i = 0; i < colliders.Length; i++)
        {
            Destroy(colliders[i].gameObject);
            Rigidbody rigidbody = colliders[i].attachedRigidbody;
            Instantiate(explosionEnemyEffect, rigidbody.position, rigidbody.rotation);

            if (colliders[i].CompareTag("EnemyShip"))
            {
                //gameController.AddLife(-10);
                gameController.AddScore(100);
            }

            if (colliders[i].CompareTag("Asteroid"))
            {

                //gameController.AddLife(-15);
                gameController.AddScore(15);
            }

            if (colliders[i].CompareTag("AsteroidComet"))
            {
                //gameController.AddLife(-25);
                gameController.AddScore(25);   
            }

            if (colliders[i].CompareTag("EnemySatelite"))
            {
                gameController.AddScore(50);
                //gameController.AddLife(-5);
            }

            if (colliders[i].CompareTag("EnemyBomb"))
            {
                gameController.AddScore(20);
                //gameController.AddLife(-10);
            }

            if (colliders[i].CompareTag("EnemyBomb2"))
            {
                gameController.AddScore(20);
                //gameController.AddLife(-20);
            }

            if (colliders[i].CompareTag("EnemyMissile"))
            {
                gameController.AddScore(5);
                //gameController.AddLife(-2);

            }

            if (colliders[i].CompareTag("MinaEnemy"))
            {
                gameController.AddScore(15);
                //gameController.AddLife(-15);
            }

        }
    }

}
