using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveJumpNote : MonoBehaviour
{
    int speed = 8;
    // Start is called before the first frame update
    void Start()
    {

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
        if (!GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap && !GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap)
        {
            GameObject.Find("applause").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
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

}
