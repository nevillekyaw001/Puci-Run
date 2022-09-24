using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;

    int coinAmount;
    public Text Coin;

    public TMP_Text ScoreIngame;
    public TMP_Text GoScore;
    public TMP_Text GoHighScore;
    public TMP_Text GoNewHighScore;

    public ParticleSystem DustUI;

    float distance = 0.0f;
    float highScore = 0.0f;
   
    private void Awake()
    {
        instance = this; //reference from Score script for addpoint() in hexagon script
    }

    // Start is called before the first frame update
    public void Start()
    {
        
        
         //announce value of highscore in score gameobject
        //announce value of highscore in Highscore gameobject

    }

    private void Update()
    {
        AddPoint();
        coinAmount = PlayerPrefs.GetInt("AdsPoints");
        Coin.text = coinAmount.ToString();

        ScoreIngame.SetText(distance.ToString("f2") + " m");

        GoScore.SetText(distance.ToString("f2") + " m");
        GoHighScore.SetText("High Score: " + highScore.ToString("f2") + " m");
        highScore = PlayerPrefs.GetFloat("highScore");
    }

    //add point system for destorying enemies
    public void AddPoint() //argument in hexagon script
    {
        if (Player.Instance.permission && !Player.Instance.Die)
        {
            distance = Player.Instance.transform.position.x * 0.01f;
        }

        if (highScore < distance)
        {
            createDust();
            PlayerPrefs.SetFloat("highScore", distance); // save hs vaule to highest in-game score value

        }

    }

    //For Debugging Highscore value to 0
    public void ResetHS()
    {
        PlayerPrefs.SetFloat("highScore", 0);
    }

    void createDust()
    {
        DustUI.Play();
    }
}
