using UnityEngine;
using System.Collections;


public class WeaponControllerBoss : MonoBehaviour {

    public GameObject[] gameObjectFire;
    public Transform[] spawnMissile;
    public Transform[] spawnBomb;
    public Transform[] spawnLaser;
    public Transform[] spawnSphere;
    public Transform[] spawnFlame;
    public Transform[] spawnRocket;
    public Transform[] spawnMin;

    public bool isActiveMissile;
    public float fireRateForMissile;
    public float delayMissile;

    public bool isActiveBomb;
    public float fireRateForBomb;
    public float delayBomb;

    public bool isActiveLaser;
    public float fireRateForLaser;
    public float delayLaser;

    public bool isActiveSphere;
    public float fireRateForSphere;
    public float delaySphere;

    public bool isActiveFlame;
    public float fireRateForFlame;
    public float delayFlame;

    public bool isActiveRocket;
    public float fireRateForRocket;
    public float delayRocket;

    public bool isActiveMin;
    public float fireRateForMin;
    public float delayMin;

    // Use this for initialization
    public AudioClip audioClip;
    private AudioSource audioSource;

    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //InvokeRepeating("ShotFire", delay, fireRate);
        //InvokeRepeating("Fire", delay, fireRate);
        InvokeRepeating("shotFireMissile", delayMissile, fireRateForMissile);
        InvokeRepeating("shotFireBomb", delayBomb, fireRateForBomb);
        InvokeRepeating("shotFireLaser", delayLaser, fireRateForLaser);
        InvokeRepeating("shotFireSphere", delaySphere, fireRateForSphere);
        InvokeRepeating("shotFireFlame", delayFlame, fireRateForFlame);
        InvokeRepeating("shotFireRocket", delayRocket, fireRateForRocket);
        InvokeRepeating("shotFireMin", delayMin, fireRateForMin);
    }
      
    void shotFireMissile()
    {
        if (isActiveMissile)
        {
            for (int i = 0; i < spawnMissile.Length; i++)
            {
                Fire(gameObjectFire[0], spawnMissile[i].position, spawnMissile[i].rotation);
            }
        }

    }

    void shotFireBomb(){
        if (isActiveBomb)
        {
            for (int i = 0; i < spawnBomb.Length; i++)
            {
                Fire(gameObjectFire[1], spawnBomb[i].position, spawnBomb[i].rotation);
            }
        }
    }
    void shotFireLaser(){
        if (isActiveLaser)
        {
            for (int i = 0; i < spawnLaser.Length; i++)
            {
                Fire(gameObjectFire[2], spawnLaser[i].position, spawnLaser[i].rotation);
            }

        }
    }

    void shotFireSphere(){
        if (isActiveSphere)
        {
            for (int i = 0; i < spawnSphere.Length; i++)
            {
                Fire(gameObjectFire[3], spawnSphere[i].position, spawnSphere[i].rotation);
            }
        }
    }

    void shotFireFlame(){
        if (isActiveFlame){
            for (int i = 0; i < spawnFlame.Length; i++)
            {
                Fire(gameObjectFire[4], spawnFlame[i].position, spawnFlame[i].rotation);
            }
        }
    
    }

    void shotFireRocket()
    {
        if (isActiveRocket)
        {
            for (int i = 0; i < spawnRocket.Length; i++)
            {
                Fire(gameObjectFire[5], spawnRocket[i].position, spawnRocket[i].rotation);
            }
        }

    }

    void shotFireMin()
    {
        if (isActiveMin)
        {
            for (int i = 0; i < spawnMin.Length; i++)
            {
                Fire(gameObjectFire[6], spawnMin[i].position,
                    Quaternion.Euler(spawnMin[i].rotation.x, Random.Range(90 , 270), spawnMin[i].rotation.z));
                //Fire(gameObjectFire[6], spawnMin[i].position, RandomRotator.);
            }
        }
    
    }



    
    void Fire(GameObject objectFire, Vector3 position, Quaternion rotation){

        Instantiate( objectFire, position, rotation);
        audioSource.clip = audioClip;
        audioSource.Play();

    }
}
