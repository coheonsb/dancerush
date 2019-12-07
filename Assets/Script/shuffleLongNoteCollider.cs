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
    public bool isLeft;
    float firstLeftZ;
    float firsRightZ;
    void Start()
    {
        isLeft = transform.parent.gameObject.GetComponent<shuffleLongNote>().isLeft;
        Debug.Log(isLeft);
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
                    if (firstLeftZ - 0.015 > GameObject.Find("leftFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }
                else {
                    if (firstLeftZ + 0.015 < GameObject.Find("leftFootObject").transform.position.z)
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
                    if (firsRightZ - 0.015 > GameObject.Find("rightFootObject").transform.position.z)
                    {
                        isSuccess = true;
                    }
                }
                else
                {
                    if (firsRightZ + 0.015 < GameObject.Find("rightFootObject").transform.position.z)
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
                GameObject.Find("longNoteSound").GetComponent<AudioSource>().Play();
                GameObject perfect = Instantiate(GameObject.Find("perfect"), new Vector3(1.572f, -0.166f, -0.055f), Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                perfect.GetComponent<perfectUp>().awake = true;
                Destroy(transform.parent.gameObject);
                Destroy(gameObject);
            }
            else {
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
