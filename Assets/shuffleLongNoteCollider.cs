using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuffleLongNoteCollider : MonoBehaviour
{
    // Start is called before the first frame update
    bool isReady = false;
    bool isLeftStap = false;
    bool isRightStap = false;
    bool isSuccess = false;
    bool soundPlayed = false;
    bool isLeft = true;
    float firstLeftZ;
    float firsRightZ;
    void Start()
    {
        isLeft = transform.parent.gameObject.GetComponent<shuffleLongNote>().isLeft;
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
            if (!isLeftStap)
            {
                isLeftStap = true;
                firstLeftZ = GameObject.Find("leftFootObject").transform.position.z;
            }
            else if (isLeftStap) {
                if (isLeft)
                {
                    if (firstLeftZ - 0.02 > GameObject.Find("leftFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }
                else {
                    if (firstLeftZ + 0.02 < GameObject.Find("leftFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }
               
            }
        }
        else if (col.tag == "rightFootObject" && isReady && GameObject.Find("rightFootObject").GetComponent<rightFootObjectScript>().stap)
        {
            if (!isRightStap)
            {
                isRightStap = true;
                firsRightZ = GameObject.Find("rightFootObject").transform.position.z;
            }
            else if (isRightStap)
            {
                if (isLeft)
                {
                    if (firsRightZ - 0.02 > GameObject.Find("rightFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    if (firsRightZ + 0.02 < GameObject.Find("rightFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }

            }
        }
       

    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "NoteColider")
        {
            if (isSuccess && !soundPlayed)
            {
                GameObject.Find("applause").GetComponent<AudioSource>().Play();
            }
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
