using UnityEngine;
using System.Collections;

internal enum GunPosition
{
    none,
    one,
    two,
    three,
    four,
    five,
    six,
    seven,
    all
}

public class WeaponController : MonoBehaviour {

    public Color[] color;

    [SerializeField] private GunPosition gunPosition = GunPosition.all;
    public GameObject [] gameObjectMissile;
    public Transform [] spawnMissile;
    public float fireRate;
    public float delay;

	// Use this for initialization
    public AudioClip audioClip;
    private AudioSource audioSource;

    public int numberMissile ;

    public void setNumberMissile(int numberMissile)
    {
        this.numberMissile = numberMissile;
    }

    public int getNumberMissile()
    {
        return this.numberMissile;
    }

	void Start () 
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("ShotFire", delay, fireRate);
        //InvokeRepeating("Fire", delay, fireRate);
	}

    
    void ShotFire()
    {
        switch (gunPosition)
        {
            case GunPosition.none:
                break;
            case GunPosition.one:
                FireMissile(0, 0);
                break;
            case GunPosition.two:
                FireMissile(0, 0);
                FireMissile(1, 1);
                break;
            case GunPosition.three:
                FireMissile(0, 0);
                FireMissile(1, 1);
                FireMissile(2, 2);
                break;
            case GunPosition.four:
                FireMissile(0, 0);
                FireMissile(1, 1);
                FireMissile(2, 2);
                FireMissile(3, 3);
                break;
            case GunPosition.five:
                FireMissile(0, 0);
                FireMissile(1, 1);
                FireMissile(2, 2);
                FireMissile(3, 3);
                FireMissile(4, 4);
                break;
            case GunPosition.six:
                FireMissile(0, 0);
                FireMissile(1, 1);
                FireMissile(2, 2);
                FireMissile(3, 3);
                FireMissile(4, 4);
                FireMissile(5, 5);
                break;
            case GunPosition.seven:
                FireMissile(0, 0);
                FireMissile(1, 1);
                FireMissile(2, 2);
                FireMissile(3, 3);
                FireMissile(4, 4);
                FireMissile(5, 5);
                FireMissile(6, 6);
                break;
            case GunPosition.all:
                for (int i = 0; i < spawnMissile.Length; i++)
                {
                    FireMissile(0, i);
                }
                break;
        }
    }


    void FireMissile(int numberWeapons , int numberPosition)
    {
        
        GameObject instantiate = Instantiate(gameObjectMissile[numberWeapons], spawnMissile[numberPosition].position, spawnMissile[numberPosition].rotation) as GameObject;
        
        IdNumberColor idNumberColor = instantiate.GetComponent<IdNumberColor>();
        idNumberColor.setIdColor(getNumberMissile());

        MeshRenderer[] meshRender = instantiate.GetComponentsInChildren<MeshRenderer>();
        meshRender[0].material.color = color[getNumberMissile()];
        if (instantiate.CompareTag("EnemyBomb2") ||  instantiate.CompareTag("MinaEnemy"))
        {
            if (getNumberMissile() == 2)
            {
                Move move = instantiate.GetComponent<Move>();
                move.speed = move.speed * 1.2f;
            }
        }

        audioSource.clip = audioClip;
        audioSource.Play();
        //Debug.Log("Number Missile : " + getNumberMissile());

    }
}
