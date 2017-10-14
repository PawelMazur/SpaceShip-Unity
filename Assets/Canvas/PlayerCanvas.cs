using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerCanvas : MonoBehaviour {

    public static PlayerCanvas canvas;
	// Use this for initialization
    public Text scoreText;
    public Text lifeText;
    public Text logText;
    public Text shipText;
    public Text shieldText;
    public Text missileText;
    public Text rocketText;

    public Text sceneText;
    public Text levelText;
    public Text timeText;

	void Awake () {
        if (canvas == null)
        {
            canvas = this;
        } if (canvas != this)
        {
            Destroy(gameObject);
        }
	}

    void Reset()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        logText = GameObject.Find("LogText").GetComponent<Text>();
        lifeText = GameObject.Find("LifeText").GetComponent<Text>();
        shipText = GameObject.Find("ShipText").GetComponent<Text>();
        shieldText = GameObject.Find("ShieldText").GetComponent<Text>();
        missileText = GameObject.Find("MissileText").GetComponent<Text>();
        rocketText = GameObject.Find("RocketText").GetComponent<Text>();
        sceneText = GameObject.Find("SceneText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
    }

    public void setScoreText(string amount)
    {
        scoreText.text = amount.ToString();
    }

    public void setLogText(string amount)
    {
        logText.text = amount.ToString();
    }

    public void setLifeText(string amount)
    {
        lifeText.text = amount.ToString();
    }
    public void setShipText(string amount)
    {
        shipText.text = amount.ToString();
    }

    public void setShieldText(string amount)
    {
        shieldText.text = amount.ToString();
    }

    public void setMissileText(string amount)
    {
        missileText.text = amount.ToString();
    }

    public void setRocketText(string amount)
    {
        rocketText.text = amount.ToString();
    }

    public void setLevelText(string amount)
    {
        levelText.text = amount.ToString();
    }

    public void setSceneText(string amount)
    {
        sceneText.text = amount.ToString();
    }

    public void setTimeText(string amount)
    {
        timeText.text = amount.ToString();
    }

}
