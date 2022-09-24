using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public GameObject MainShop;
    public GameObject Skins;
    public GameObject Abilities;
    public GameObject Maps;

    //Skin
    public GameObject MeowstronautBuy;
    public GameObject PrincessBuy;

    public GameObject PucyEquip;
    public GameObject MSEquip;
    public GameObject PEquip;

    public GameObject PucyEquipped;
    public GameObject MSEquipped;
    public GameObject PEquipped;

    int MSInt;
    int PInt;
    int skin;

    //Abilities
    public GameObject BuyDashB;
    public GameObject BuyGodB;

    public GameObject UpgradeDashB;
    public GameObject UpgradeGodB;
    public GameObject UpgradeReviveB;

    public GameObject DashPrice;
    public GameObject GodPrice;
    public GameObject RevivePrice;

    public Slider DashProgress;
    public Slider GodProgress;
    public Slider ReviveProgress;

    string BoughtDash;
    string BoughtGod;

    public TMP_Text DashText;
    public TMP_Text GodText;
    public TMP_Text ReviveText;

    //Maps
    public GameObject BuySpaceB;
    public GameObject BuyMap3B;

    public GameObject EquipCandyB;
    public GameObject EquipSpaceB;
    public GameObject EquipMap3B;

    public GameObject EquippedCandyB;
    public GameObject EquippedSpaceB;
    public GameObject EquippedMap3B;

    int SpaceInt;
    int Map3Int;
    string Map;

    //Money
    int ads;
    public Text AdPoint;

    void awake()
    {
        
        //Skin
        MSInt = PlayerPrefs.GetInt("BoughtMS");
        PInt = PlayerPrefs.GetInt("BoughtP");
        skin = PlayerPrefs.GetInt("skin");

        //Maps
        SpaceInt = PlayerPrefs.GetInt("BoughtSpace");
        Map3Int = PlayerPrefs.GetInt("BoughtMap3");
        Map = PlayerPrefs.GetString("map");

        ads = PlayerPrefs.GetInt("AdsPoints");
    }
    private void Start()
    {
        AdmobManager.instance.ShowInterAd();
        
    }

    void Update()
    {
        //Money
        ads = PlayerPrefs.GetInt("AdsPoints");
        AdPoint.text = PointSystem.AdsPoints.ToString();

        //Skin
        MSInt = PlayerPrefs.GetInt("BoughtMS");
        PInt = PlayerPrefs.GetInt("BoughtP");

        skin = PlayerPrefs.GetInt("skin", 0);

        if (MSInt == 1)
        {
            MeowstronautBuy.SetActive(false);
        }

        if (PInt == 1)
        {
            PrincessBuy.SetActive(false);
        }

        if (skin == 0)
        {
            PucyEquip.SetActive(false);
            MSEquip.SetActive(true);
            PEquip.SetActive(true);
        }

        if (skin == 1)
        {
            PucyEquip.SetActive(true);
            MSEquip.SetActive(false);
            PEquip.SetActive(true);
        }

        if (skin == 2)
        {
            PucyEquip.SetActive(true);
            MSEquip.SetActive(true);
            PEquip.SetActive(false);
        }

        //Abilities Tab

        DashText.SetText("Move Faster for a period. ( -" + PointSystem.DashSecond.ToString() + " s)");
        GodText.SetText("Move Faster for a period. ( +" + PointSystem.GodSecond.ToString() + " s)");
        ReviveText.SetText("Move Faster for a period. ( +" + PointSystem.ReviveSecond.ToString() + " s)");


        BoughtDash = PlayerPrefs.GetString("Dash", "No");
        BoughtGod = PlayerPrefs.GetString("God", "No");

        if (BoughtDash == "Yes")
        {
            BuyDashB.SetActive(false);
        }
        if (BoughtGod == "Yes")
        {
            BuyGodB.SetActive(false);
        }
        

        //Dash
        if (PointSystem.DashSecond == 0.7f)
        {
            DashProgress.value = 0.2f;
        }
        if (PointSystem.DashSecond == 1.4f)
        {
            DashProgress.value = 0.4f;
        }
        if (PointSystem.DashSecond == 2.1f)
        {
            DashProgress.value = 0.6f;
        }
        if (PointSystem.DashSecond == 2.8f)
        {
            DashProgress.value = 0.8f;
        }
        if (PointSystem.DashSecond == 3.5f)
        {
            DashProgress.value = 1;
            UpgradeDashB.SetActive(false);
            DashPrice.SetActive(false);
        }

        //GodMode
        if (PointSystem.GodSecond == 1)
        {
            GodProgress.value = 0.2f;
        }
        if (PointSystem.GodSecond == 2)
        {
            GodProgress.value = 0.4f;
        }
        if (PointSystem.GodSecond == 3)
        {
            GodProgress.value = 0.6f;
        }
        if (PointSystem.GodSecond == 4)
        {
            GodProgress.value = 0.8f;
        }
        if (PointSystem.GodSecond == 5)
        {
            GodProgress.value = 1;
            UpgradeGodB.SetActive(false);
            GodPrice.SetActive(false);
        }

        //Revive
        if (PointSystem.ReviveSecond == 1)
        {
            ReviveProgress.value = 0.2f;
        }
        if (PointSystem.ReviveSecond == 2)
        {
            ReviveProgress.value = 0.4f;
        }
        if (PointSystem.ReviveSecond == 3)
        {
            ReviveProgress.value = 0.6f;
        }
        if (PointSystem.ReviveSecond == 4)
        {
            ReviveProgress.value = 0.8f;
        }
        if (PointSystem.ReviveSecond == 5)
        {
            ReviveProgress.value = 1;
            UpgradeReviveB.SetActive(false);
            RevivePrice.SetActive(false);
        }

        //Maps Tab
        SpaceInt = PlayerPrefs.GetInt("BoughtSpace");
        Map3Int = PlayerPrefs.GetInt("BoughtMap3");
        Map = PlayerPrefs.GetString("map");

        if (SpaceInt == 1)
        {
            BuySpaceB.SetActive(false);
        }

        if ( Map3Int == 1)
        {
            BuyMap3B.SetActive(false);
        }

        if (Map == "1")
        {
            EquipCandyB.SetActive(false);
            EquipSpaceB.SetActive(true);
            EquipMap3B.SetActive(true);
        }

        if (Map == "2")
        {
            EquipCandyB.SetActive(true);
            EquipSpaceB.SetActive(false);
            EquipMap3B.SetActive(true);
        }

        if (Map == "3")
        {
            EquipCandyB.SetActive(true);
            EquipSpaceB.SetActive(true);
            EquipMap3B.SetActive(false);
        }
    }

    #region Main Panel
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<AudioManager>().Play("Buttons");
    }

    public void Back()
    {
        MainShop.SetActive(true);
        Skins.SetActive(false);
        Abilities.SetActive(false);
        Maps.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Buttons");
    }

    public void SkinButton()
    {
        MainShop.SetActive(false);
        Skins.SetActive(true);
        Abilities.SetActive(false);
        Maps.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Buttons");

        
    }

    public void AbilitiesButton()
    {
        MainShop.SetActive(false);
        Skins.SetActive(false);
        Abilities.SetActive(true);
        Maps.SetActive(false);
        FindObjectOfType<AudioManager>().Play("Buttons");
    }

    public void MapButton()
    {
        MainShop.SetActive(false);
        Skins.SetActive(false);
        Abilities.SetActive(false);
        Maps.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Buttons");
    }
#endregion

    #region Skin
    public void BuyMeowtronaut()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 3000)
        {
            PlayerPrefs.SetInt("BoughtMS", 1);
            PointSystem.AdsPoints -= 3000;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void BuyPrincess()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 3000)
        {
            PlayerPrefs.SetInt("BoughtP", 1);
            PointSystem.AdsPoints -= 3000;
            PointSystem.UpdateAdsPoints();
        }

    }

    public void EquipPucy()
    {
        PlayerPrefs.SetInt("skin", 0);
    }

    public void EquipMS()
    {
        PlayerPrefs.SetInt("skin", 1);
    }

    public void EquipP()
    {
        PlayerPrefs.SetInt("skin", 2);
    }

    public void ResetAllBuy()
    {
        PlayerPrefs.SetInt("skin", 0);
        PlayerPrefs.SetInt("BoughtMS", 0);
        PlayerPrefs.SetInt("BoughtP", 0);

        PlayerPrefs.SetString("Dash", "No");
        PlayerPrefs.SetString("God", "No");
        PlayerPrefs.SetString("Revive", "No");

        PlayerPrefs.SetFloat("DashSecond", 0);
        PlayerPrefs.SetFloat("GodSecond", 0);
        PlayerPrefs.SetFloat("ReviveSecond", 0);

        PlayerPrefs.SetInt("BoughtSpace", 0);
        PlayerPrefs.SetInt("BoughtMap3", 0);
        PlayerPrefs.SetInt("map", 0);

        PlayerPrefs.SetInt("AdsPoints", 0);
    }

    public void addmoney()
    {
        PointSystem.AdsPoints += 5000;
        PointSystem.UpdateAdsPoints();
    }
    #endregion

    #region Abilities
    public void BuyDash()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 300)
        {
            BuyDashB.SetActive(false);
            PlayerPrefs.SetString("Dash", "Yes");
            PointSystem.AdsPoints -= 300;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void BuyGodMode()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 300)
        {
            BuyGodB.SetActive(false);
            PlayerPrefs.SetString("God", "Yes");
            PointSystem.AdsPoints -= 300;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void DashUpgrade()
    {

        if (PointSystem.DashSecond < 3.5f && PlayerPrefs.GetInt("AdsPoints") >= 300)
        {
            PointSystem.DashSecond += 0.7f;
            PointSystem.UpdateDashSecond();
            Debug.Log(PointSystem.DashSecond);

            PointSystem.AdsPoints -= 300;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void GodUpgrade()
    {
        if(PointSystem.GodSecond < 5f && PlayerPrefs.GetInt("AdsPoints") >= 300)
        {
            PointSystem.GodSecond += 1f;
            PointSystem.UpdateGodSecond();
            Debug.Log(PointSystem.GodSecond);

            PointSystem.AdsPoints -= 300;
            PointSystem.UpdateAdsPoints();
        }
    }

    public void ReviveUpgrade()
    {
        if (PointSystem.ReviveSecond < 10f && PlayerPrefs.GetInt("AdsPoints") >= 300)
        {
            PointSystem.ReviveSecond += 1f;
            PointSystem.UpdateReviveSecond();
            Debug.Log(PointSystem.ReviveSecond);

            PointSystem.AdsPoints -= 300;
            PointSystem.UpdateAdsPoints();
        }
        
    }
    #endregion

    #region Maps
    public void BuySpace()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 5000)
        {
            PlayerPrefs.SetInt("BoughtSpace", 1);

            PointSystem.AdsPoints -= 5000;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void BuyMap3()
    {
        if (PlayerPrefs.GetInt("AdsPoints") >= 5000)
        {
            PlayerPrefs.SetInt("BoughtMap3", 1);

            PointSystem.AdsPoints -= 5000;
            PointSystem.UpdateAdsPoints();
        }
        
    }

    public void EquipCandy()
    {
        PlayerPrefs.SetString("map", "1");
    }

    public void EquipSpace()
    {
        PlayerPrefs.SetString("map", "2");
    }

    public void EquipMap3()
    {
        PlayerPrefs.SetString("map", "3");
    }
    #endregion
}
