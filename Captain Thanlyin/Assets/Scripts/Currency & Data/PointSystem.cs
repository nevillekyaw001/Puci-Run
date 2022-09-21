using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;
    public static int AdsPoints = 0;
    public static float DashSecond = 0;
    public static float GodSecond = 0;
    public static float ReviveSecond = 0;
    public static string map = "1";


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        AdsPoints = PlayerPrefs.GetInt("AdsPoints");
        map = PlayerPrefs.GetString("map");
        DashSecond = PlayerPrefs.GetFloat("DashSecond");
        GodSecond = PlayerPrefs.GetFloat("GodSecond");
        ReviveSecond = PlayerPrefs.GetFloat("ReviveSecond");


    }

    private void Update()
    {
        AdsPoints = PlayerPrefs.GetInt("AdsPoints");
        DashSecond = PlayerPrefs.GetFloat("DashSecond");
        GodSecond = PlayerPrefs.GetFloat("GodSecond");
        ReviveSecond = PlayerPrefs.GetFloat("ReviveSecond");

    }

    public static void UpdateAdsPoints()
    {
        PlayerPrefs.SetInt("AdsPoints", AdsPoints);
        AdsPoints = PlayerPrefs.GetInt("AdsPoints");
        PlayerPrefs.Save();
    }

    public static void UpdateDashSecond()
    {
        PlayerPrefs.SetFloat("DashSecond", DashSecond);
        DashSecond = PlayerPrefs.GetFloat("DashSecond");
        PlayerPrefs.Save();
    }

    public static void UpdateGodSecond()
    {
        PlayerPrefs.SetFloat("GodSecond", GodSecond);
        GodSecond = PlayerPrefs.GetFloat("GodSecond");
        PlayerPrefs.Save();
    }

    public static void UpdateReviveSecond()
    {
        PlayerPrefs.SetFloat("ReviveSecond", ReviveSecond);
        ReviveSecond = PlayerPrefs.GetFloat("ReviveSecond");
        PlayerPrefs.Save();
    }

    //public static void UpdateMapName()
    //{
    //    PlayerPrefs.SetString("Map", MapName);
    //    MapName = PlayerPrefs.GetString("Map");
    //    PlayerPrefs.Save();
    //}
    public static void UpdateMap()
    {
        PlayerPrefs.SetString("map", map);
        map = PlayerPrefs.GetString("map");
        PlayerPrefs.Save();
    }


}
