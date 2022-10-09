using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PointSystem.AdsPoints += 1;
            PointSystem.UpdateAdsPoints();

            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
