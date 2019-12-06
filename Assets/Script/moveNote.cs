using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNote : MonoBehaviour
{
    int speed = 8;
    // Start is called before the first frame update
    void Start()
    {

    }

    bool isReady = false;
    bool isCol = false;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            isReady = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "leftFootObject" && isReady && GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap)
        {
            if (DateNow() - GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stapTime < 200) {
                GameObject.Find("applause").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }

            //Instantiate(GameObject.Find("leftparticle"),
               // new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);


        }
        if (col.tag == "rightFootObject" && isReady && GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap)
        {
            if (DateNow() - GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stapTime < 200)
            {
                GameObject.Find("applause").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
           // Instantiate(GameObject.Find("rightparticle"),
                //new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);

  
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
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
