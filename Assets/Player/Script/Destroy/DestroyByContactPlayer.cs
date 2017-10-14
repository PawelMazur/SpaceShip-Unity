using UnityEngine;
using System.Collections;

public class DestroyByContactPlayer : MonoBehaviour {

    private PlayerController playerController;
    private GameController gameController;

	// Use this for initialization
    public GameObject playerExplosion;
    public GameObject MissileExplosion;
    public GameObject AsteroidExplosion;
    public GameObject EnemyShipExplosion;
    public GameObject BombExplosion;
    public GameObject Bomb2Explosion;
    public GameObject FireExplosion;


	void Start () {
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
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("is colision with Player");
                                                                                   
        if (coll.CompareTag("EnemyShip"))
        {
            Instantiate(EnemyShipExplosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-10);
        }

        if (coll.CompareTag("Asteroid"))
        {
            Instantiate(AsteroidExplosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-15);
        }

        if (coll.CompareTag("AsteroidGreen"))
        {
            Instantiate(AsteroidExplosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-15);
        }

        if (coll.CompareTag("AsteroidComet"))
        {
            Instantiate(AsteroidExplosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-25);
        }

        if (coll.CompareTag("EnemySatelite"))
        {
            Instantiate(AsteroidExplosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-5);
        }

        if (coll.CompareTag("EnemyBomb"))
        {
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-10);
        }

        if (coll.CompareTag("EnemyBomb2"))
        {
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-20);
        }

        if (coll.CompareTag("EnemyMissile"))
        {
            Instantiate(MissileExplosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-2);

        }

        if (coll.CompareTag("MissileSphere"))
        {
            Instantiate(FireExplosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-20);
        }

        if (coll.CompareTag("MinaEnemy"))
        {
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-15);
        }

        if (coll.CompareTag("PlayerMissile") && coll.CompareTag("PlayerBomb"))
        {
            //return;
        }

        //-- fix-----------------

        if (coll.CompareTag("EnemyBomb"))
        {
            Rigidbody rb = coll.attachedRigidbody;
            IdNumberColor idNumberColor = rb.GetComponent<IdNumberColor>();
            if (idNumberColor.getIdColor() == 4)
            {
                gameController.AddLife(-10);
            }
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-10);
        }

        if (coll.CompareTag("EnemyBomb2"))
        {
            Rigidbody rb = coll.attachedRigidbody;
            IdNumberColor idNumberColor = rb.GetComponent<IdNumberColor>();
            if (idNumberColor.getIdColor() == 4)
            {
                gameController.AddLife(-20);
            }
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-20);
        }
        
        if (coll.CompareTag("EnemyMissile"))
        {
            Rigidbody rb = coll.attachedRigidbody;
            IdNumberColor idNumberColor = rb.GetComponent<IdNumberColor>();
            if (idNumberColor.getIdColor() == 4)
            {
                gameController.AddLife(-2);
            }
            Instantiate(MissileExplosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-2);

        }
        //add ============================================
        if (coll.CompareTag("EnemyMissileRed"))
        {
            Instantiate(MissileExplosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-4);

        }
        //-------------------------
        if (coll.CompareTag("MinaEnemy"))
        {
            Rigidbody rb = coll.attachedRigidbody;
            IdNumberColor idNumberColor = rb.GetComponent<IdNumberColor>();
            if (idNumberColor.getIdColor() == 4)
            {
                gameController.AddLife(-15);
            }
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-15);
        }

        /*
        if (coll.CompareTag("MissileSphere"))
        {
            Instantiate(Bomb2Explosion, transform.position, transform.rotation);
            Destroy(coll.gameObject);
            gameController.AddLife(-20);
        }*/
        
        //-------------------------------
        

        //----------------items--------------------------------------
        if (coll.CompareTag("LifeBox"))
        {
            gameController.AddLife(50);
            Destroy(coll.gameObject);
        }
        if (coll.CompareTag("ShieldBox"))
        {
            gameController.AddShield(30);
            //gameController.AddLife(30);
            Destroy(coll.gameObject);
        }
        if (coll.CompareTag("AmmoBox"))
        {
            Destroy(coll.gameObject);
        }
        /*
        if (coll.CompareTag("RocketBox"))
        {
            Rigidbody rb = coll.attachedRigidbody;
            PlayerController playerController = rb.GetComponent<PlayerController>();
            playerController.setNumberMissile(gameController.rocketPlayer);
            Destroy(coll.gameObject);
        }*/

        if (coll.CompareTag("LifeShip"))
        {
            Debug.Log("Ship add");
            gameController.AddShip(1);
            Destroy(coll.gameObject);
        }

        if (coll.CompareTag("EnemyBoss"))
        {
            gameController.AddLife(-50);
            Instantiate(EnemyShipExplosion, coll.transform.position, coll.transform.rotation);

        }

       


        /*
        
        */

    }
}
