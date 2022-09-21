using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(PlayerPrefs.GetString("map", "1"));
        FindObjectOfType<AudioManager>().StopPlaying("BGM Menu");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
    public void Credit()
    {
        SceneManager.LoadScene("Credit");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
    public void Info()
    {
        SceneManager.LoadScene("Info");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
    public void Score()
    {
        SceneManager.LoadScene("Score");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }

  
}
