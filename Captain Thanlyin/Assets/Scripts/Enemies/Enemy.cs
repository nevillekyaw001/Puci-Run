using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Poof;
    public Transform SelfTransform; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Player.Instance.isGodMode)
            {
                Instantiate(Poof).transform.position = SelfTransform.position;
                Destroy(gameObject);
            }
                
            if (Player.Instance.isDashing)
            {
                Instantiate(Poof).transform.position = SelfTransform.position;
                Destroy(gameObject);
            }
        }
    }
}
