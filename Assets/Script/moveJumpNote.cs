﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveJumpNote : MonoBehaviour
{
    int speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("moveJumpNote");
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
        if (col.tag == "NoteColider" && !GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap && !GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap)
        {
            GameObject.Find("jumpNoteSound").GetComponent<AudioSource>().Play();
            GameObject perfect = Instantiate(GameObject.Find("perfect"), new Vector3(1.572f, -0.166f, -0.055f), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            perfect.GetComponent<perfectUp>().awake = true;
            Destroy(gameObject);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            GameObject perfect = Instantiate(GameObject.Find("fail"), new Vector3(1.572f, -0.166f, -0.055f), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            perfect.GetComponent<failUp>().awake = true;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
