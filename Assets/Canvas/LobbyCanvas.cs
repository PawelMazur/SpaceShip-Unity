using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LobbyCanvas : MonoBehaviour {

	// Use this for initialization
    public static LobbyCanvas canvas;

    public Text firstText;
    public Text secondText;
    public Text thirdText;

    void Awake()
    {
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
        firstText = GameObject.Find("FirstText").GetComponent<Text>();
        secondText = GameObject.Find("SecondText").GetComponent<Text>();
        thirdText = GameObject.Find("ThirdText").GetComponent<Text>();

    }

    public void setFirstText(string amount)
    {
        firstText.text = amount.ToString();
    }

    public void setSecondText(string amount)
    {
        secondText.text = amount.ToString();
    }

    public void setThirdText(string amount)
    {
        thirdText.text = amount.ToString();
    }
}
