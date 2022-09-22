using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;
    public Button button;
    private bool mute;
    private AudioSource[] AS;

    void Start()
    {
        AS = FindObjectOfType<AudioManager>().GetComponents<AudioSource>();
        Debug.Log(mute);
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioManager.instance.muted)
        {
            button.image.sprite = soundOff;
        }
        else
        {
            button.image.sprite = soundOn;
        }
    }

    public void ButtonClicked()
    {
        if (mute)
        {
            mute = false;
            AudioManager.instance.muted = false;
        }
        else
        {
            mute = true;
            AudioManager.instance.muted = true;
        }
    }
}
