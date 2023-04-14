using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GoogleAdMobController.instance.ShowInterstitialAd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
}
