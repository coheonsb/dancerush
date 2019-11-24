using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDownNote : MonoBehaviour
{
    int speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("moveDownNote");
    }

    bool isReady = false;
    bool isCol = false;
    float headY = 0;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            isReady = true;
            headY = GameObject.Find("Camera").transform.position.y;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (headY - GameObject.Find("Camera").transform.position.y > 0.02) {
            GameObject.Find("applause").GetComponent<AudioSource>().Play();
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
