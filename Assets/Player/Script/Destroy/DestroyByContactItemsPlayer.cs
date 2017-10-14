using UnityEngine;
using System.Collections;

public class DestroyByContactItemsPlayer : MonoBehaviour {

    private GameController gameController;

    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue;
    public int lifeValue;
    public int damageByContact;

    // Use this for initialization
    void Start()
    {


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



    public void OnTriggerEnter(Collider coll)
    {
        //Debug.Log("is colision with Player");

        if (coll.CompareTag("EnemyShip") || coll.CompareTag("Asteroid"))
        {
            return;
        }

        if (coll.CompareTag("PlayerMissile"))
        {

            lifeValue -= 10;
            Instantiate(explosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            if (lifeValue == 0)
            {
                gameController.AddScore(scoreValue);
                Destroy(gameObject);

            }

        }

        if (coll.CompareTag("PlayerMissileRed") || coll.CompareTag("PlayerMissileBlue"))
        {

            lifeValue -= 20;
            Instantiate(explosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            if (lifeValue == 0)
            {
                gameController.AddScore(scoreValue);
                Destroy(gameObject);

            }

        }



        if (coll.CompareTag("PlayerShip"))
        {
            gameController.AddScore(scoreValue);
            gameController.AddLife(damageByContact);
            Debug.Log("is colision with Player");
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (playerExplosion != null)
            {
                Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
            }
            Destroy(gameObject);
            //Destroy(coll.gameObject);
        }

    }
}
