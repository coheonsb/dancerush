using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class leftTrackerColider : MonoBehaviour
{
    public bool stap = false;
    bool supple = false;
    float zPosition = 0;


    void Start()
    {
        GameObject.Find("leftFootObject").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("leftFootObject").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap = true;
            GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stapTime = DateNow();
            Debug.Log(GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stapTime);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("leftFootObject").transform.position = new Vector3(GameObject.Find("leftFootObject").transform.position.x, GameObject.Find("leftFootObject").transform.position.y, this.transform.position.z);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("leftFootObject").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
   
            //GameObject.Find("erro").GetComponent<AudioSource>().Play();

    }
    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
