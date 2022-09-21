using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FollowNLookAt : MonoBehaviour
{
    public GameObject Guider;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    public bool StartShake;
    public float duration = 1f;

    private void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Guider = GameObject.FindWithTag("PlayerGuide");
        if (Guider != null)
        {
            tFollowTarget = Guider.transform;
            vcam.LookAt = tFollowTarget;
            vcam.Follow = tFollowTarget;
        }

    }
    
}
