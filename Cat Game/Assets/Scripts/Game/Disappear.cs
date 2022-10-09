using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Invoke("Die", 1);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
