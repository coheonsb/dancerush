using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class indexScript : MonoBehaviour
{
    // Start is called before the first frame update

    int startTime;

    void Start()
    {
        Debug.Log("시작!");
        startTime = DateNow();
        StartCoroutine(Example());

    }

    void makeNote()
    {
       
        
    }

    IEnumerator Example()
    {
        while (true)
        {
            GameObject note;
            Random rand = new Random();
            int randNote = Random.Range(0, 6);
            string noteName = "";

            switch (randNote) {
                case 0:
                    noteName = "leftNote";
                    break;
                case 1:
                    noteName = "rightNote";
                    break;
                case 2:
                    noteName = "downNote";
                    break;
                case 3:
                    noteName = "jumpNote";
                    break;
                case 4:
                    noteName = "defualtLongNote";
                    break;
                case 5:
                    noteName = "shuffleLongNote";
                    break;
            }
            randNote = 5;
            noteName = "shuffleLongNote";
            if (randNote == 2 || randNote == 3)
            {
                note = Instantiate(GameObject.Find(noteName),
                   new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y, GameObject.Find("noteDispenser").transform.position.z),
                      Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            } else if (randNote == 4) {
                note = Instantiate(GameObject.Find(noteName),
                    new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + (Random.Range(0.0f, 0.9f) - 0.5f)),
                    Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                note.transform.localScale = new Vector3(Random.Range(1, 10), 1, 1);
                if (Random.Range(0, 2) == 0)
                {
                    note.GetComponent<defualtLongNote>().isLast = true;
                }
                else {
                    note.GetComponent<defualtLongNote>().isLast = false;
                }
            
            }
            else if (randNote == 5)
            {
                note = Instantiate(GameObject.Find(noteName),
                    new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + (Random.Range(0.0f, 0.9f) )),
                    Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            }
            else {
                note = Instantiate(GameObject.Find(noteName),
                new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y + (0.05f), GameObject.Find("noteDispenser").transform.position.z + (Random.Range(0.0f, 0.9f) - 0.5f)),
                   Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
            }

            yield return new WaitForSeconds(1);
        }
    }


    void Update()
    {

      //  Debug.Log(System.TimeSpan.FromSeconds(startTime));

    }

    public static int DateNow()
    {

        System.DateTime now = System.DateTime.Now.ToLocalTime();
        System.TimeSpan span = (now - new System.DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        int nowTime = (int)span.TotalSeconds;

        return nowTime;
    }
}
