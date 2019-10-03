using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightTrackerColider : MonoBehaviour
{
    bool stap = false;
    bool supple = false;
    float zPosition = 0;

    void Start()
    {
        GameObject.Find("rightFootObject").GetComponent<MeshRenderer>().enabled = false;
        GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("rightFootObject").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("rightFootObject").transform.position = new Vector3(GameObject.Find("rightFootObject").transform.position.x, GameObject.Find("rightFootObject").transform.position.y, this.transform.position.z);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Floor")
        {
            GameObject.Find("rightFootObject").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}