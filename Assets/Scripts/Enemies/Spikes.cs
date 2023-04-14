using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Animator anim;
    public GameObject Poof;
    public Transform SelfTransform;

    private void Update()
    {
        anim = GetComponent<Animator>();
    }

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
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("Grounded", true);
        }
    }
}
