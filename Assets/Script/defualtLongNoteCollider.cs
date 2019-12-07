using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defualtLongNoteCollider : MonoBehaviour
{
    // Start is called before the first frame update
    bool isReady = false;
    bool isLeftStap = false;
    bool isRightStap = false;
    bool isSuccess = false;
    bool soundPlayed = false;
    bool isLast = true;
    void Start()
    {
        Debug.Log("defualtLongNoteCollider");
        isLast = transform.parent.gameObject.GetComponent<defualtLongNote>().isLast;
    }

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
            if (!isLeftStap && !isRightStap)
            {
                isLeftStap = true;
                isSuccess = true;
            }
        }
        else if (col.tag == "rightFootObject" && isReady && GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap)
        {
            if (!isRightStap && !isLeftStap) {
                isRightStap = true;
                isSuccess = true;
            }  
        }
        if (isRightStap && !GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap)
        {
            if (!soundPlayed && isLast)
            {
                //GameObject.Find("applause").GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }
        }
        else if (isLeftStap && !GameObject.Find("leftFootObject").GetComponent<leftFootObjectScript>().stap)
        {
            if (!soundPlayed && isLast) {
                //GameObject.Find("applause").GetComponent<AudioSource>().Play();
                soundPlayed = true;
            }

        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            if (isSuccess && !soundPlayed)
            {
                GameObject perfect = Instantiate(GameObject.Find("perfect"), new Vector3(1.572f, -0.166f, -0.055f), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                perfect.GetComponent<perfectUp>().awake = true;
                GameObject.Find("longNoteSound").GetComponent<AudioSource>().Play();
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            } else
            {
                GameObject perfect = Instantiate(GameObject.Find("fail"), new Vector3(1.572f, -0.166f, -0.055f), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                perfect.GetComponent<failUp>().awake = true;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
