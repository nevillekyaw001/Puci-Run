using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BGM : MonoBehaviour
{
    private Sprite soundOn;
    public Sprite soundOff;
    public Button button;
    public AudioSource audioScource;
    bool isOn = true;


    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("BGM");

        if (musicObj.Length > 1 )
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        soundOn = button.image.sprite;
    }

    public void click()
    {
        if (isOn)
        {
            button.image.sprite = soundOff;
            isOn = false;
            audioScource.mute = true;
        }

        else
        {
            button.image.sprite = soundOn;
            isOn = true;
            audioScource.mute = false;
        }
    }
}
