using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosting : MonoBehaviour
{
    public static Ghosting instance;

    public GameObject Ghost;
    public float ghostDelay;
    private float ghostDelaySecond;
    public bool makeGhost = false;

    void Start()
    {
        instance = this;
        ghostDelaySecond = ghostDelay;
    }

    void Update()
    {
        if (makeGhost)
        {
            if (ghostDelaySecond > 0)
            {
                ghostDelaySecond -= Time.deltaTime;
            }
            else
            {
                GameObject currentGhost = Instantiate(Ghost, transform.position, transform.rotation);
                ghostDelaySecond = ghostDelay;
            }
        }
    }
}
