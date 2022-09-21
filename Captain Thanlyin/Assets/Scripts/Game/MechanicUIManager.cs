using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MechanicUIManager : MonoBehaviour
{
    public static MechanicUIManager instance;

    public GameObject DashButton;
    public GameObject DashButtonCD;
    public GameObject GodModeButton;

    public GameObject ReviveButton;
    public GameObject WatchAd;

    public GameObject IngameScore;
    public GameObject GameOverPanel;

    public int CurrentIndex;

    public Transform playSpawner;
    public GameObject[] cats;

    string confirmation = "Yes";

    public void Awake()
    {
        instance = this;

        CurrentIndex = PlayerPrefs.GetInt("skin");

        Instantiate(cats[CurrentIndex]).transform.position = playSpawner.position;

        if (PlayerPrefs.GetString("Dash") == confirmation)
        {
            DashButton.SetActive(true);
            DashButtonCD.SetActive(true);
        }
        else
        {
            DashButton.SetActive(false);
            DashButtonCD.SetActive(false);
        }

        if (PlayerPrefs.GetString("God") == confirmation)
        {
            GodModeButton.SetActive(true);
        }
        else
        {
            GodModeButton.SetActive(false);
        }
        if (PlayerPrefs.GetString("Revive") == confirmation)
        {
            ReviveButton.SetActive(true);
        }
        else
        {
            ReviveButton.SetActive(false);
        }

    }

    public void DashB()
    {
        if (Player.Instance.isGrounded == false && !Player.Instance.isGodMode && !Player.Instance.Die)
        {
            Player.Instance.DashButton();
            DashButton.SetActive(false);
            DashButtonCD.SetActive(true);
            StartCoroutine(AppearDashB());
        }
    }

    public void GodModeB()
    {
        if (!Player.Instance.Die && Player.Instance.permission)
        {
            Player.Instance.GodModeButton();
            GodModeButton.SetActive(false);
            //StartCoroutine(BubbleDisappear(Player.Instance.GodModeEffectTime + 2f));
        }
    }

    public void Revive()
    {
        if (Player.Instance.Die)
        {
            AdmobManager.instance.ShowRewardAd();


            GameOverPanel.SetActive(false);
            Player.Instance.ReviveButton();
            //StartCoroutine(BubbleDisappear(Player.Instance.ReviveEffectTime + 2f));
            DashButton.SetActive(true);
            DashButtonCD.SetActive(true);
            IngameScore.SetActive(true);
            
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void FD()
    {
        StartCoroutine(FirstDie());
    }

    public void LD()
    {
        StartCoroutine(LastDie());
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator AppearDashB()
    {
        yield return new WaitForSeconds(6.5f - PointSystem.DashSecond);
        DashButton.SetActive(true);
        DashButtonCD.SetActive(false);
    }

    IEnumerator FirstDie()
    {
        yield return new WaitForSeconds(2f);
        ReviveButton.SetActive(true);
        WatchAd.SetActive(true);
        GameOverPanel.SetActive(true);
        DashButton.SetActive(false);
        DashButtonCD.SetActive(false);
        GodModeButton.SetActive(false);
        IngameScore.SetActive(false);

    }

    IEnumerator LastDie()
    {
        yield return new WaitForSeconds(1f);
        ReviveButton.SetActive(false);
        WatchAd.SetActive(false);
        GameOverPanel.SetActive(true);
        DashButton.SetActive(false);
        DashButtonCD.SetActive(false);
        GodModeButton.SetActive(false);
        IngameScore.SetActive(false);

    }

}
