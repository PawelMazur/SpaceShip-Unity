using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyByContactBoss : MonoBehaviour {


    private GameController gameController;

    public GameObject playerExplosion;
    public GameObject explosion;
    public int scoreValue;
    public int lifeValue;
    public int damageByContact;

    public int numberBoss {set; get;} 

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

        gameController.sliderLife.SetActive(true);
        gameController.sliderBoss.maxValue = lifeValue;

    }

    void Update()
    {
        gameController.sliderBoss.value = lifeValue;
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
            //gameController.slider.value = lifeValue;


            Instantiate(explosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            if (lifeValue == 0)
            {
                //gameController.EnemyBoss[0].SetActive(false);
                //Destroy(gameController.EnemyBoss[0]);
                //gameObject.SetActive(false);

                //gameController.EnemyBossIsActive[numberBoss] = false;

                gameController.EnemyBossIsActive[gameController.getNumberBoss()] = false;
                Debug.Log("getnumberEnemny in  : " + gameController.getNumberBoss());
                /*
                for (int i = 0; i < gameController.EnemyBossIsActive.Length; i++)
                {
                    gameController.EnemyBossIsActive[i] = false;
                }*/

                gameController.AddScore(scoreValue);
                Destroy(gameObject);
                gameController.sliderLife.SetActive(false);

            }

            if (lifeValue > lifeValue * 0.6f)
            {
                gameController.imageBoss.color = Color.green;
            }
            else if (lifeValue * 0.3 < lifeValue && lifeValue < lifeValue * 0.6f)
            {
                gameController.imageBoss.color = Color.yellow;
            }
            else if (lifeValue < lifeValue * 0.3f)
            {
                gameController.imageBoss.color = Color.red;
            }
            



        }

        if (coll.CompareTag("PlayerMissileRed") || coll.CompareTag("PlayerMissileBlue"))
        {

            lifeValue -= 20;
            //gameController.slider.value = lifeValue;


            Instantiate(explosion, coll.transform.position, coll.transform.rotation);
            Destroy(coll.gameObject);
            if (lifeValue == 0)
            {

                gameController.EnemyBossIsActive[gameController.getNumberBoss()] = false;
                Debug.Log("getnumberEnemny in  : " + gameController.getNumberBoss());
                gameController.AddScore(scoreValue);
                Destroy(gameObject);
                gameController.sliderLife.SetActive(false);

            }


        }



        if (coll.CompareTag("PlayerShip"))
        {
            gameController.AddScore(scoreValue);
            gameController.AddLife(damageByContact);
            Debug.Log("is colision with Player");
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(playerExplosion, coll.transform.position, coll.transform.rotation);
            //Destroy(gameObject);
            //Destroy(coll.gameObject);
        }
        /*
        
        */

    }

}
