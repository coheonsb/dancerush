using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class perfectUp : MonoBehaviour
{
    long startTime;
    long musicStartTime;
    public bool awake = false;
    int speed = 3;
    void Start()
    {
        startTime = DateNow();
    }

    // Update is called once per frame
    void Update()
    {
        if (awake) {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (DateNow() > startTime + 250) {
                Destroy(gameObject);
            }
        }
    }

    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
