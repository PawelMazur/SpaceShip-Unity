using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;


[System.Serializable]
class PlayerData
{
    // for game
    public int level;
    public int scene;
    // for player
    public int score = 0;
    public int life = 100;
    public int ship = 3;
    public int shield = 100;
    public int missilePlayer = 50;
    public int rocketPlayer = 5;
    public int numberMissile = 1;
    public int bomb = 5;
   
    
}

[System.Serializable]
class PlayerScoreData
{
    //public ArrayList bestScore = new ArrayList();
    public int firstBestScore = 0;
    public int secondBestScore = 0;
    public int thirdBestScore = 0;
}

public class GameController : MonoBehaviour {

    public AudioClip buttonClip;
    //public AudioClip backgroundClip;
    private AudioSource audioSource;

    public Transform spawnPlayer;
    public GameObject PlayerObject;
    public GameObject ObjectShieldBarier;
    public GameObject ObjectFlame;

    public Slider sliderPlayerHealth;
    public Image imagePlayerHealth;
    public Slider sliderPlayerShield;
    public Image imagePlayerShield;
    public GameObject sliderLife;
   

    public GameObject mobileVirtualJoystick;
    public GameObject lobbyCanvas;
    public GameObject optionsCanvas;
    public GameObject exitCanvas;
    public GameObject bestResultCanvas;
    public GameObject gameoverCanvas;
    
    
    


    public Slider sliderBoss;
    public Image imageBoss;
    public Slider sliderTime;

    public GameObject HealthCanvasBoss;

    public static GameController gameControl;

    public Color[] EnemyColors;

	// Use this for initialization
    public GameObject[] Asteroids;
    public GameObject[] EnemyShips;
    public GameObject[] EnemySatelites;
    public GameObject[] EnemyBoss;
    public GameObject[] Itmes;
    public GameObject[] Mins;

    public bool[] EnemyBossIsActive;
    


    public Vector3 spawnAsteroids;
    public Vector3 spawnEnemyShips;
    public Vector3 spawnEnemySatelites;
    public Vector3 spawnPositionEnemyBoss;
    public Vector3 spawnItmes;
    public Vector3 spawnMins;

    /*
    private int score = 0;
    private int life = 100;
    private int ship = 3;
    private int shield = 50;
    private int missilePlayer = 50;
    private int rocketPlayer = 30;
    */

    public int level;
    public int scene = 0;
    public float time;
    public int levelTime = 60;
    // for player
    public int score = 0;
    public int life = 100;
    public int ship = 3;
    public int shield = 50;
    public int missilePlayer = 1;
    public int rocketPlayer = 10;

    private bool gameOver = false;
    private bool restart;
     

    //for scene
    private int NumberScene = 0;

    private bool startLevel { get ; set ; }
    //private bool startScene;
    private bool startGame;

    public int numberBoss = 0;
    
    public void setNumberBoss(int numberBoss){
        this.numberBoss = numberBoss;
    }

    public int getNumberBoss(){
        return this.numberBoss;
    }

    public int timeNextLevel = 0;
    public int getTimeNextLevel()
    {
        return this.timeNextLevel;
    }

    public void setTimeNextLevel(int timeNextLevel)
    {
        this.timeNextLevel = timeNextLevel;
    }


    private bool activePlayer = true;

    public void setActivePlayer(bool activePlayer)
    {
        this.activePlayer = activePlayer;
    }

    public bool getActivePlayer()
    {
        return this.activePlayer;
    }

    //items for player 
    public int numberMissile = 1;

    public void setNumberMissile(int numberMissile)
    {
        this.numberMissile = numberMissile;
    }

    public int getNumberMissile()
    {
        return numberMissile;
    }

    public int bomb = 5;

    public void setBomb(int bomb)
    {
        this.bomb = bomb;
    }

    public int getBomb()
    {
        return this.bomb;
    }

    int tempSaveFirstScore = 0;
    int tempSaveSecondScore = 0;
    int tempSaveThirdScore = 0;

    

    // Update is called once per frame
    void Update()
    {
        sliderTime.maxValue = levelTime;

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        if (getTimeNextLevel() > 0)
        {
            PlayerCanvas.canvas.setTimeText("Next Level : " + (getTimeNextLevel() - Time.fixedTime + time));
        }
        if (getTimeNextLevel() < 0)
        {
            PlayerCanvas.canvas.setTimeText("Next level : " + 0);
        }


        //----- for items------------
        if (shield > 0)
        {
            ObjectShieldBarier.SetActive(true);
        }

        if (life > 50)
        {
            ObjectFlame.SetActive(false);
        }

        if (life <= 50)
        {
            ObjectFlame.SetActive(true);
        }

        if (startGame == true)
        {
            DisplayOptionCanvas();
        }
        
        
    }

    public void DisplayOptionCanvas()
    {
        
        PlayerCanvas.canvas.setLevelText("Level : " + level);
        PlayerCanvas.canvas.setSceneText("Scene : " + scene);
        PlayerCanvas.canvas.setScoreText("Score : " + score);
        PlayerCanvas.canvas.setLifeText("Life : " + life);
        PlayerCanvas.canvas.setShieldText("Shied : " + shield);
        //PlayerCanvas.canvas.setShipText("Ship : " + ship);
        PlayerCanvas.canvas.setShipText(" " +  ship);
        PlayerCanvas.canvas.setMissileText("Missile : " + missilePlayer);
        PlayerCanvas.canvas.setRocketText("Rocket : " + rocketPlayer);
       
        sliderTime.value = getTimeNextLevel() - Time.fixedTime + time;

        sliderPlayerHealth.value = life;
        sliderPlayerShield.value = shield;

        if (life > life * 0.6f)
        {
            imagePlayerHealth.color = Color.green;
        }
        else if (life * 0.3 < life && life < life * 0.6f)
        {
            imagePlayerHealth.color = Color.yellow;
        }
        else if (life < life * 0.3f)
        {
            imagePlayerHealth.color = Color.red;
        }
    }
    

	void Start () {

        audioSource = GetComponent<AudioSource>();

        lobbyCanvas.SetActive(true);
        mobileVirtualJoystick.SetActive(false);
        optionsCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        bestResultCanvas.SetActive(false);
        gameoverCanvas.SetActive(false);

        PlayerObject.SetActive(false);
       
       
	}

    void initCanvasSetup()
    {
        PlayerCanvas.canvas.setScoreText("Score : " + score);
        PlayerCanvas.canvas.setLifeText("Life : " + life);
        PlayerCanvas.canvas.setShipText("Ship : " + ship);
        PlayerCanvas.canvas.setShieldText("Shield : " + shield);
        PlayerCanvas.canvas.setLogText("");
        PlayerCanvas.canvas.setMissileText("Missile : " + missilePlayer);
        PlayerCanvas.canvas.setRocketText("Rocket : " + rocketPlayer);

    }

    

    IEnumerator SetupScene()
    {
        while(true)
        {
            if (scene == 1)
            {
                IEnumerator firstScene = loadScene(1, 0, 0);
                yield return StartCoroutine(firstScene);
            }
            
            if (scene == 2)
            {
                IEnumerator secondScene = loadScene(1, 1, 1);
                yield return StartCoroutine(secondScene);
            }
            if (scene == 3)
            {
                IEnumerator thirdScene = loadScene(1, 2, 2);
                yield return StartCoroutine(thirdScene);
            }
            if (scene == 4)
            {
                IEnumerator fourthScene = loadScene(1, 3, 3);
                yield return StartCoroutine(fourthScene);
                //PlayerCanvas.canvas.setSceneText("Scene : " + scene);
            }

            if (scene == 5)
            {
                IEnumerator fifthScene = loadScene(1, 4, 4);
                yield return StartCoroutine(fifthScene);
                //PlayerCanvas.canvas.setSceneText("Scene : " + scene);
            }
        }
                    
        
    }

    IEnumerator loadScene(int level, int numberColor, int numberBoss)
    {

        Debug.Log("Color : " + numberColor);
        yield return StartCoroutine(RoundWaiting());
        IEnumerator fLevel = firstLevel(numberColor, 5, 10);
        yield return StartCoroutine(fLevel);

        yield return StartCoroutine(RoundWaiting());
        IEnumerator sLevel = secondLevel(numberColor, 0, 5);
        yield return StartCoroutine(sLevel);

        yield return StartCoroutine(RoundWaiting());
        IEnumerator tLevel = thirdLevel(numberColor, 10, 15);
        yield return StartCoroutine(tLevel);

        yield return StartCoroutine(RoundWaiting());
        IEnumerator foLevel = fourthLevel(numberColor, 15, 20);
        yield return StartCoroutine(foLevel);

        yield return StartCoroutine(RoundWaiting());
        IEnumerator sBoss = spawnBoss(numberColor, numberBoss);
        yield return StartCoroutine(sBoss);
        IEnumerator fiLevel = bossMatch();
        yield return StartCoroutine(fiLevel);
        yield return StartCoroutine(RoundNext());        
        

           

        
        
    }

    IEnumerator RoundWaiting()
    {
        level++;
        yield return new WaitForSecondsRealtime(5);
        PlayerCanvas.canvas.setLogText("Level : " + level);
        setTimeNextLevel(0);
        yield return new WaitForSecondsRealtime(5);
        PlayerCanvas.canvas.setLogText("");
        
    }

    IEnumerator firstLevel( int numberColor, int minLength, int maxLength)
    {
        bool startLevel1 = true;
        while (startLevel1)
        {

            time = Time.fixedTime;
            setTimeNextLevel(levelTime);
            StartCoroutine(spawnPositionAsteroids(2, 0, 10));
            StartCoroutine(spawnPositionEnemyShip(numberColor, minLength, maxLength, 2, 5, 3));
            StartCoroutine(SpawnPositionItems(0, 3, 5, 30));
            

            yield return new WaitForSeconds(levelTime);
            setTimeNextLevel(-1);
            startLevel1 = false;

            
        }
        
        while (gameOver)
        {
            gameoverCanvas.SetActive(true);
            yield return null;
        }
    }

    IEnumerator secondLevel(int numberColor, int minLength, int maxLength)
    {
        bool startLevel2 = true;
        while (startLevel2)
        {

            time = Time.fixedTime;
            setTimeNextLevel(levelTime);
            StartCoroutine(spawnPositionAsteroids(8, 0, 10));
            StartCoroutine(spawnPositionEnemyShip(numberColor, minLength, maxLength, 2, 5, 3));
            StartCoroutine(SpawnPositionItems(0, 4, 5, 25));
            StartCoroutine(SpawnPositionItems(4, 5, 5, 25));
            yield return new WaitForSecondsRealtime(levelTime);
            setTimeNextLevel(-1);
            startLevel2 = false;
            
        }

        while (gameOver)
        {
            gameoverCanvas.SetActive(true);
            yield return null;
        }
    }



    IEnumerator thirdLevel( int numberColor, int minLength, int maxLength)
    {
        bool startLevel3 = true;

        while (startLevel3)
        {

            time = Time.fixedTime;
            setTimeNextLevel(levelTime);
            StartCoroutine(spawnPositionAsteroids(11, 0, 10));
            StartCoroutine(spawnPositionEnemyShip(numberColor, minLength, maxLength, 2, 5, 3));
            StartCoroutine(SpawnPositionItems(0, 6, 5, 15));
            yield return new WaitForSecondsRealtime(levelTime);
            setTimeNextLevel(-1);
            startLevel3 = false;

        }

        while (gameOver)
        {
            Debug.Log("Game over : " + gameOver);
            gameoverCanvas.SetActive(true);
            yield return null;
        }
    }

    IEnumerator fourthLevel(int numberColor, int minLength, int maxLength)
    {
        bool startLevel4 = true;

        while (startLevel4)
        {

            time = Time.fixedTime;
            setTimeNextLevel(levelTime);
            StartCoroutine(spawnPositionAsteroids(11, 0, 10));
            StartCoroutine(spawnPositionEnemyShip(numberColor, minLength, maxLength, 2, 5, 2));
            StartCoroutine(SpawnPositionItems(0, 6, 5, 10));
            yield return new WaitForSecondsRealtime(levelTime);
            setTimeNextLevel(-1);
            startLevel4 = false;

        }

        while (gameOver)
        {
            Debug.Log("Game over : " + gameOver);
            gameoverCanvas.SetActive(true);
            yield return null;
        }
    }
        
    IEnumerator spawnBoss(int colorNumber, int numberBoss)
    {
        setNumberBoss(numberBoss);
        spawnEnemyBoss(colorNumber, numberBoss);
       
        yield return new WaitForSecondsRealtime(5);
    }

    IEnumerator bossMatch()
    {
        Debug.Log("number boss : " + getNumberBoss());

        while (EnemyBossIsActive[getNumberBoss()])
        {
            yield return null;
        }
    }

    IEnumerator RoundNext()
    {

        yield return new WaitForSecondsRealtime(5);
        scene++;
        //numberBoss++;
        if (scene == 6)
        {
            level = 0;
            scene = 1;
            //setNumberBoss(0);
        }
        SaveBestScore();
    }



    void spawnEnemyBoss( int numberColor, int numberBoss)
    {
        Debug.Log("Tworzenie Bossa");
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnPositionEnemyBoss.x, spawnPositionEnemyBoss.x),
            spawnPositionEnemyBoss.y, spawnPositionEnemyBoss.z);
        Quaternion spawnRotation = Quaternion.identity;
        //EnemyBoss[numberColor].SetActive(true);
        GameObject instatiateBoss = Instantiate(EnemyBoss[numberBoss], spawnPosition, spawnRotation) as GameObject;
        //instatiate.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        MeshRenderer[] meshRenderer = instatiateBoss.GetComponentsInChildren<MeshRenderer>();
        meshRenderer[0].material.color = EnemyColors[numberColor];
        EnemyBossIsActive[numberBoss] = true;
        setNumberBoss(numberBoss);
        HealthCanvasBoss.SetActive(true);

    }



    IEnumerator spawnPositionEnemyShip(int numberColor, int minLength,int maxLength,float spawnWait, float startSpawn, float endSpawn)
    {
        
        //yield return new WaitForSeconds(spawnWait);
        yield return new WaitForSecondsRealtime(spawnWait);
        //while (startLevel)
        //while (true) 
        {
            for (int i = 0; i < EnemyShips.Length; i++)
            {
                //yield return new WaitForSeconds(startSpawn);
                yield return new WaitForSecondsRealtime(startSpawn);
                GameObject EnemyShip = EnemyShips[Random.Range(minLength, maxLength)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnEnemyShips.x, spawnEnemyShips.x),
                    spawnEnemyShips.y, spawnEnemyShips.z);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject instatiate = Instantiate(EnemyShip, spawnPosition, spawnRotation) as GameObject;
                MeshRenderer [] meshRenderers = instatiate.GetComponentsInChildren<MeshRenderer>();
                meshRenderers[0].material.color = EnemyColors[numberColor];

                WeaponController wc = EnemyShip.GetComponent<WeaponController>();
                wc.setNumberMissile(numberColor);



                //yield return new WaitForSeconds(endSpawn);
                yield return new WaitForSecondsRealtime(endSpawn);
            }
            //yield return new WaitForSeconds(endWaitEnemyShip);
        }
        while (gameOver)
        {
            Debug.Log("Game over : " + gameOver);
            gameoverCanvas.SetActive(true);
            yield return null;
        }
    }

    IEnumerator SpawnPositionItems(int min, int max, float startWait, float spawnWait)
    {
        //yield return new WaitForSeconds(startWait);
        yield return new WaitForSecondsRealtime(startWait);
        //while (true){
            for (int i = 0; i < Itmes.Length; i++)
            {
                //yield return new WaitForSeconds(spawnWait);
                yield return new WaitForSecondsRealtime(spawnWait);
                GameObject Item = Itmes[Random.Range(min, max)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnItmes.x, spawnItmes.x),
                    spawnItmes.y, spawnItmes.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Item, spawnPosition, spawnRotation);

            }
        //}

    }

    IEnumerator spawnPositionAsteroids(int length, float startWait, float spawnWait)
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < length; i++)
            {
                yield return new WaitForSeconds(spawnWait);
                GameObject Asteroid = Asteroids[Random.Range(0, length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnAsteroids.x, spawnAsteroids.x), 
                    spawnAsteroids.y, spawnAsteroids.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(Asteroid, spawnPosition, spawnRotation);
                

                    
            }
        }
        
    }

    IEnumerator spawnPositionEnemySatelies(int length, float spawnWait, float startWait)
    {
        yield return new WaitForSeconds(spawnWait);
        for (int i = 0; i < EnemySatelites.Length; i++)
        {
            yield return new WaitForSeconds(startWait);
            GameObject EnemySatelite = EnemySatelites[Random.Range(0, length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnAsteroids.x, spawnAsteroids.x), 
                spawnAsteroids.y, spawnAsteroids.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(EnemySatelite, spawnPosition, spawnRotation);

        }
        //yield return new WaitForSeconds(endWaitEnemySatelite);
    }

    

    public void AddScore(int newValues)
    {
        score += newValues;
    }

    public void AddLife(int newValues)
    {
        
        if (newValues > 0)
        {
            if (life < 100)
            {
                int tempLife = life + newValues;
                if (tempLife >= 100)
                {
                    life = 100;
                }
                if (tempLife < 100)
                {
                    life += newValues;
                }
            }
            else
            {
                AddShield(newValues);
            }
        }
        if (newValues < 0)
        {
            if (shield >= 0)
            {
                AddShield(newValues);
            }

            if (shield <= 0)
            {
                int tempLife = life + newValues;
                if (tempLife >= 100)
                {
                    life = 100;
                }
                if (tempLife < 100)
                {
                    life += newValues;
                }
            }
        }
        

        
        if (life <= 0)
        {
            PlayerObject.SetActive(false);
            if (ship > 0)
            {
                ship -= 1;

                Invoke("newPlayerShip", 3);
            }
            else
            {
                SaveBestScore();
                gameOver = true;
                Debug.Log("GameOver : " + gameOver);
            }
        }
    
    }

    public void newPlayerShip()
    {
        PlayerObject.transform.position = new Vector3(spawnPlayer.position.x, spawnPlayer.position.y, spawnPlayer.position.z);
        PlayerObject.SetActive(true);
        setActivePlayer(false);
        life = 100;
        shield = 100;
        rocketPlayer = 10;
        
        Invoke("invokeActivePlayer", 1);
        
    }

    public void invokeActivePlayer()
    {
        setActivePlayer(true);
    }

    public int AddShield(int newShieldValue)
    {
        int tempShield = shield + newShieldValue;
        if (tempShield >= 100)
        {
            shield = 100;
        }
        if (tempShield < 100)
        {
            shield += newShieldValue;
        }
        if (tempShield <= 0)
        {
            ObjectShieldBarier.SetActive(false);
            shield = 0;
        }

        //PlayerCanvas.canvas.setShieldText("Shield : " + shield);
        return shield;
    }

    public void AddShip(int newShipValue)
    {
        ship = ship + newShipValue;
    }


    //---------------------------------------------------------------------------------
    

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Create);

        PlayerData playerData = new PlayerData();
        playerData.scene = scene;
        playerData.level = level;

        playerData.score = score;
        playerData.life = life;
        playerData.ship = ship;
        playerData.shield = shield;
        playerData.missilePlayer = missilePlayer;
        playerData.rocketPlayer = rocketPlayer;
        playerData.numberMissile = numberMissile;
        playerData.bomb = bomb;

        bf.Serialize(file, playerData);
        file.Close();
        /*
        Debug.Log("Scene: " + playerData.scene);
        Debug.Log("Level: " + playerData.level);
        Debug.Log("score : " + playerData.score);
        Debug.Log("life : " + playerData.life);
        Debug.Log("shield : " + playerData.shield);
        Debug.Log("missile : " + playerData.missilePlayer);
        Debug.Log("rocketPlayer : " + playerData.rocketPlayer);
        */

    }

    public int CheckSaveScore(int score)
    {
        int tempScore = 0;
        if (File.Exists(Application.persistentDataPath + "/playerBestScoreInfo.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerBestScoreInfo.dat", FileMode.Open);
            PlayerScoreData playerScoreOpen = (PlayerScoreData)(bf.Deserialize(file));
            file.Close();

            tempSaveFirstScore = playerScoreOpen.firstBestScore;
            tempSaveSecondScore = playerScoreOpen.secondBestScore;
            tempSaveThirdScore = playerScoreOpen.thirdBestScore;
            Debug.Log("FirstBestScore 1 : " + tempSaveFirstScore);
            Debug.Log("SecondBestScore 2 : " + tempSaveSecondScore);
            Debug.Log("ThirdBestScore 3 : " + tempSaveSecondScore);

            if (score >= playerScoreOpen.firstBestScore ){
                tempScore = 1;
            } else if (score >= playerScoreOpen.secondBestScore){
                tempScore = 2;
            } else if (score >= playerScoreOpen.thirdBestScore){
                tempScore = 3;
            }
        }
        return tempScore;
        
    }

    public void SaveBestScore()
    {
        
        int numberbestScore = CheckSaveScore(score);
        Debug.Log("Best Score Number : " + numberbestScore);
        Debug.Log("Score  : " + score);

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerBestScoreInfo.dat", FileMode.Create);

        PlayerScoreData playerScore = new PlayerScoreData();

        int temp1 = tempSaveFirstScore;
        int temp2 = tempSaveSecondScore;
        int temp3 = tempSaveThirdScore;
        //Debug.Log("FirstBestScore 1 : " + temp1);
        //Debug.Log("SecondBestScore 2 : " + temp2);
        //Debug.Log("ThirdBestScore 3 : " + temp3);

        if (numberbestScore == 1)
        {
            //Debug.Log("numberBestScore : " + 1);
            playerScore.firstBestScore = score;
            playerScore.secondBestScore = temp1;
            playerScore.thirdBestScore = temp2;
        }

        if (numberbestScore == 2)
        {
            //Debug.Log("numberBestScore : " + 2);
            playerScore.firstBestScore = temp1;
            playerScore.secondBestScore = score;
            playerScore.thirdBestScore = temp2;

        }

        if (numberbestScore == 3)
        {
            //Debug.Log("numberBestScore : " + 3);
            playerScore.firstBestScore = temp1;
            playerScore.secondBestScore = temp2;
            playerScore.thirdBestScore = score;
        }
        bf.Serialize(file, playerScore);
        file.Close();
    }

    public void LoadBestScore()
    {
        if (File.Exists(Application.persistentDataPath + "/playerBestScoreInfo.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerBestScoreInfo.dat", FileMode.Open);
            PlayerScoreData playerScore = (PlayerScoreData)(bf.Deserialize(file));
            file.Close();

            Debug.Log("Lobby Canvas : " + LobbyCanvas.canvas);
            LobbyCanvas.canvas.setFirstText(playerScore.firstBestScore.ToString());
            LobbyCanvas.canvas.setSecondText(playerScore.secondBestScore.ToString());
            LobbyCanvas.canvas.setThirdText(playerScore.thirdBestScore.ToString());
            /*
            if (playerScore.firstBestScore != 0)
            {
                LobbyCanvas.canvas.setFirstText(playerScore.firstBestScore.ToString());
            }

            if (playerScore.secondBestScore != 0)
            {
                LobbyCanvas.canvas.setSecondText(playerScore.secondBestScore.ToString());
            }

            if (playerScore.thirdBestScore != 0)
            {
                LobbyCanvas.canvas.setThirdText(playerScore.thirdBestScore.ToString());
            }*/
        
        }


    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)(bf.Deserialize(file));
            file.Close();

            scene = playerData.scene;
            //setScene(scene);

            if (playerData.level > 1)
            {
                level = playerData.level - 1;
            }
            else
            {
                level = 0;
            }
            

            score = playerData.score;
            life = playerData.life;
            ship = playerData.ship;
            shield = playerData.shield;
            missilePlayer = playerData.missilePlayer;
            rocketPlayer = playerData.rocketPlayer;
            numberMissile = playerData.numberMissile;
            bomb = playerData.bomb;
            /*
            Debug.Log("Scene: " + playerData.scene);
            Debug.Log("Level: " + playerData.level);
            Debug.Log("score : " + playerData.score);
            Debug.Log("life : " + playerData.life);
            Debug.Log("shield : " + playerData.shield);
            Debug.Log("missile : " + playerData.missilePlayer);
            Debug.Log("rocketPlayer : " + playerData.rocketPlayer);
             */
        }
        //return scene;
    }



    /// <summary>
    /// ---------------------------------
    /// </summary>
    /// 
    public void RestartGame()
    {
        SoundButtonPlay();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void GameOverExit()
    {
        SoundButtonPlay();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void StartGame()
    {
        PlayerObject.SetActive(true);
        SoundButtonPlay();

        startGame = true;
        ObjectShieldBarier.SetActive(true);


        bestResultCanvas.SetActive(false);
        lobbyCanvas.SetActive(false);
        gameoverCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        mobileVirtualJoystick.SetActive(true);


        scene = 1;
        level = 0;

        HealthCanvasBoss.SetActive(false);

        for (int i = 0; i < EnemyBoss.Length; i++)
        {
            EnemyBossIsActive[i] = false;
        }

        initCanvasSetup();
        gameOver = false;
        restart = false;
        StartCoroutine(SetupScene());
    }

    public void AgainGame()
    {
        
        RestartGame();
        
    }

    public void ContinueGame()
    {
        //scene = Load();
        PlayerObject.SetActive(true);
        SoundButtonPlay();
        Load();

        startGame = true;

        bestResultCanvas.SetActive(false);
        lobbyCanvas.SetActive(false);
        gameoverCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
        mobileVirtualJoystick.SetActive(true);

        HealthCanvasBoss.SetActive(false);
        
        for (int i = 0; i < EnemyBoss.Length; i++)
        {
            EnemyBossIsActive[i] = false;
        }

        initCanvasSetup();
        gameOver = false;
        restart = false;
        StartCoroutine(SetupScene());

    }

    public void BestResult()
    {
        SoundButtonPlay();
        bestResultCanvas.SetActive(true);
        lobbyCanvas.SetActive(false);
        Debug.Log("Wywolanie metody LoadBestScore : ");
        LoadBestScore();
            
    }

    public void Exit()
    {
        Application.Quit();                   
    }

    public void ExitCanvas()
    {
        SoundButtonPlay();
        exitCanvas.SetActive(true);
    }

    public void SaveAndExit()
    {
        SoundButtonPlay();
        Save();
        RestartGame();
        SaveBestScore();
    }

    public void Back()
    {
        SoundButtonPlay();
        exitCanvas.SetActive(false);
    }

    public void BackToLobby()
    {
        SoundButtonPlay();
        lobbyCanvas.SetActive(true);
        bestResultCanvas.SetActive(false);
    }

    public void SoundButtonPlay()
    {
        audioSource.clip = buttonClip;
        audioSource.Play();
    }
    
}
