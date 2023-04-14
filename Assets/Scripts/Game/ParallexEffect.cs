 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexEffect : MonoBehaviour
{
    private float length;
    private float startPos;
    public GameObject Camera;
    public float speed;

    private void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (Camera.transform.position.x * (1 - speed));
        float distance = (Camera.transform.position.x * speed);

        transform.position = new Vector2(startPos + distance, transform.position.y);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;

    }


}
