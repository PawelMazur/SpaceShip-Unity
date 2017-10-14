using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Boundary
{
    public float xMin;
    public float xMax;

    public float zMin;
    public float zMax;

    
}

public class PlayerController : MonoBehaviour {

    private bool IsSlow = false;
    
    public Boundary boundary;

    
    public GameObject []imageBombs;
    
    public Slider sliderTimeBomb;
    public Slider sliderTimeMissile;

    public Image imageTimeBomb;
    public Image imageTimeMissile;

    

    public Transform[] spawnMissile;
    public GameObject[] ObjectWeaponMissile;
    public GameObject[] ObjectWeaponBomb;

	// Use this for initialization
    Rigidbody rigidbody;

    public float speed;
    public float tilt;

    

    //-------------------------------------------------

    private float nextMissile = 0.0f;
    public float timeRespMissile = 0.2f;
    
    public float timeActiveMissile = 0;

    public float getTimeActiveMissile()
    {
        return timeActiveMissile;
    }

    public void setTimeActiveMissile(float timeActiveMissile)
    {
        this.timeActiveMissile = timeActiveMissile;
    }

    private float timeMissile = 0;

    //---------------------------------------------------
    

    private float nextBomb = 0.0f;
    public float timeRespBomb = 1;

    public float timeActiveBomb = 0;
    
    public float getTimeActiveBomb()
    {
        return timeActiveBomb;
    }


    public void setTimeActiveBomb(float timeActiveBomb)
    {
        this.timeActiveBomb = timeActiveBomb;
    }

    private float timeBomb = 0;
    
    //----------------------------------------------------


    //public int numberMissile = 1;

    public int colorMissile = 1;

    

    private GameController gameController;

    public AudioClip audioClipMissile;
    private AudioSource audioSource;

    public AudioClip audioClipBomb;

    public GameObject MudEffect;


	void Start () {

        MudEffect.SetActive(false);

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Can not find 'GameController' script");
        }

        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        gameController.setBomb(gameController.bomb);
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        #if UNITY_STANDALONE || UNITY_WEBPLAYER
            
            if (Input.GetButton("Fire1") && Time.time > nextMissile){
                Fire();
            }
        
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        if (FireButton.isFire)
        {
            //Debug.Log("IsFire");
            if (Time.time > nextMissile)
            {
                Fire();
            }
        }

        if (FireButton2.isFire)
        {
            if (gameController.getBomb() > 0)
            {
                //Debug.Log("IsFire");
                if (Time.time > nextBomb)
                {
                    FireBomb();
                }
            }
        }
        #endif

        sliderTimeBomb.maxValue = timeRespBomb;
        sliderTimeMissile.maxValue = timeRespMissile;

        sliderTimeBomb.value = getTimeActiveBomb() - Time.time;
        sliderTimeMissile.value = getTimeActiveMissile() - Time.time;
        //sliderTimeBomb.value =  Time.fixedTime - nextBomb;
        //sliderTimeMissile.value = Time.fixedTime - nextMissile;
        //sliderTimeBomb.value = getTimeActiveBomb() + Time.time - timeBomb;
        //sliderTimeMissile.value = getTimeActiveMissile() + Time.time - timeMissile;

        //Debug.Log("Activate Player : " + gameController.getActivePlayer());
        if (gameController.getActivePlayer() == false)
        {
            gameController.setNumberMissile(1);
            gameController.bomb = 5;
            displayActiveBomb();
            colorMissile = 0;
        }
    }

    public void displayActiveBomb()
    {
        for (int i = 0; i < gameController.bomb; i++)
        {
            
            imageBombs[i].SetActive(true);
        }
    }

    

    void FixedUpdate()
    {
        DisplayImageTime();
        
        float horizontal;
        float vertical;

        //horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        //vertical = CrossPlatformInputManager.GetAxis("Vertical");
        
        #if UNITY_STANDALONE || UNITY_WEBPLAYER
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");    
  
        #elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE 
            horizontal = VirtualJoystick.Horizontal();
            vertical = VirtualJoystick.Vertical();
        

        #endif
          

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        if (IsSlow){
            rigidbody.velocity = movement * speed * 0.1f;
        } else {
            rigidbody.velocity = movement * speed;
        }
        
        float maxMovmentX = Mathf.Clamp(transform.position.x ,boundary.xMin, boundary.xMax);
        float maxMovmentY = Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax);

        rigidbody.position = new Vector3(maxMovmentX, 0.0f, maxMovmentY);

        //rigidbody.position = new Vector3(Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax, movement,)

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    
    }

    public void Fire()
    {

        nextMissile = Time.time + timeRespMissile;
        setTimeActiveMissile(Time.time + timeRespMissile);
        timeMissile = Time.time;
        switch (gameController.getNumberMissile())
        {

            case 1:
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[0].position, spawnMissile[0].rotation);
                break;
            case 2:
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[1].position, spawnMissile[1].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[2].position, spawnMissile[2].rotation);
                break;
            case 3:
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[0].position, spawnMissile[0].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[1].position, spawnMissile[1].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[2].position, spawnMissile[2].rotation);
                break;
            case 4:
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[0].position, spawnMissile[0].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[1].position, spawnMissile[1].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[2].position, spawnMissile[2].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[3].position, spawnMissile[3].rotation);
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[4].position, spawnMissile[4].rotation);
                break;
            default:
                Instantiate(ObjectWeaponMissile[colorMissile], spawnMissile[0].position, spawnMissile[0].rotation);
                break;

        }

        audioSource.clip = audioClipMissile;
        audioSource.Play();
        
            

    }

    public void FireBomb()
    {
        nextBomb = Time.time + timeRespBomb;
        setTimeActiveBomb(Time.time + timeRespBomb);
        timeBomb = Time.time;

        Instantiate(ObjectWeaponBomb[0], spawnMissile[0].position, spawnMissile[0].rotation);
        if (gameController.bomb > 0) {
            imageBombs[gameController.bomb - 1].SetActive(false);
            gameController.bomb--;
        }

        audioSource.clip = audioClipBomb;
        audioSource.Play();
    }

    public void OnTriggerEnter(Collider coll)
    {

        // || coll.CompareTag("EnemyMissileGreen"))
        if (coll.CompareTag("EnemyBomb") || coll.CompareTag("EnemyBomb2")
            || coll.CompareTag("MinaEnemy"))
            
        {
            Rigidbody rigidbody = coll.attachedRigidbody;
            IdNumberColor id = rigidbody.GetComponent<IdNumberColor>();
            if (id.getIdColor() == 1)
            {
                IsSlow = true;
                //Instantiate(MudEffect, coll.transform.position, coll.transform.rotation);
                MudEffect.SetActive(true);
            }
        }

        if (coll.CompareTag("AsteroidGreen"))
        {
           
            IsSlow = true;
            MudEffect.SetActive(true);
            //Instantiate(MudEffect, coll.transform.position, coll.transform.rotation);
        }

        
        Invoke("NormalMove", 2);

        if (coll.CompareTag("RocketBox"))
        {
            if (gameController.bomb < 5)
            {
                gameController.bomb++;
                imageBombs[gameController.bomb - 1].SetActive(true);
                
            }
            Destroy(coll.gameObject);
        }

        if (coll.CompareTag("AmmoBox"))
        {
            if (gameController.numberMissile < 4)
            {
                gameController.numberMissile++;
                Destroy(coll.gameObject);
            }
        }

        if (coll.CompareTag("AmmoBoxRed"))
        {
            if (gameController.numberMissile < 4)
            {
                gameController.numberMissile++;
                colorMissile = 1;
                Destroy(coll.gameObject);
            }
        }

        if (coll.CompareTag("AmmoBoxBlue"))
        {
            if (gameController.numberMissile < 4)
            {
                gameController.numberMissile++;
                colorMissile = 2;
                Destroy(coll.gameObject);
            }
        }

    }

    public void NormalMove()
    {
        IsSlow = false;
        MudEffect.SetActive(false);
    }

    void DisplayImageTime()
    {
        if (Time.time < nextBomb)
        {
            imageTimeBomb.color = Color.red;
        }
        

        if (Time.time < nextMissile)
        {
            imageTimeMissile.color = Color.red;
        }
        
    }
    
}
