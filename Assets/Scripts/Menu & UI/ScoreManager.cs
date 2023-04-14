using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text HighScore;

    // Start is called before the first frame update
    void Start()
    {
        GoogleAdMobController.instance.ShowRewardedAd();
    }

    // Update is called once per frame
    void Update()
    {
        HighScore.SetText(PlayerPrefs.GetFloat("highScore").ToString("f2") + " m");
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
}
