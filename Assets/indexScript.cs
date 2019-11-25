using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class indexScript : MonoBehaviour
{
    // Start is called before the first frame update

    long startTime;

    [System.Serializable]
    class NoteData
    {
        public int type;
        public long time;
        public float potition;
        public int size;
        public float rotation;
        public bool isLeft;
    };
    TextAsset textData;

    [System.Serializable]
    class NoteArray
    {
        public List<NoteData> data;
    };
    NoteArray noteArray;

    void Start()
    {

        SteamVR_Render.pauseRendering = false;
        Debug.Log("시작!");
        startTime = DateNow();
        StartCoroutine(Example());
        textData = (Resources.Load("test") as TextAsset);
        noteArray = JsonUtility.FromJson<NoteArray>(textData.ToString());
    }



    IEnumerator Example()
    {

        while (true)
        {
            Debug.Log("카운트");
            yield return new WaitForSeconds(1);
        }

    }

    void makeNote()
    {
        for (var i = 0; i < noteArray.data.Count; i++)
        {
            GameObject note;
            if (DateNow() > noteArray.data[i].time + startTime)
            {
                int randNote = noteArray.data[i].type;
                string noteName = "";
                switch (randNote)
                {
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
                if (randNote == 2 || randNote == 3)
                {
                    note = Instantiate(GameObject.Find(noteName),
                       new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y, GameObject.Find("noteDispenser").transform.position.z),
                          Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                }
                else if (randNote == 4)
                {
                    note = Instantiate(GameObject.Find(noteName),
                        new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + (UnityEngine.Random.Range(0.0f, 0.9f) - 0.5f)),
                        Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
                    note.transform.localScale = new Vector3(UnityEngine.Random.Range(1, 10), 1, 1);

                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        note.GetComponent<defualtLongNote>().isLast = true;
                    }
                    else
                    {
                        note.GetComponent<defualtLongNote>().isLast = false;
                    }

                }
                else if (randNote == 5)
                {
                    note = Instantiate(GameObject.Find(noteName),
                        new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + (UnityEngine.Random.Range(0.0f, 0.9f))),
                        Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                }
                else
                {
                    note = Instantiate(GameObject.Find(noteName),
                    new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y + (0.05f), GameObject.Find("noteDispenser").transform.position.z + (UnityEngine.Random.Range(0.0f, 0.9f) - 0.5f)),
                       Quaternion.Euler(new Vector3(0, 90, 0))) as GameObject;
                }
                noteArray.data.RemoveAt(i);
                break;
            }

        }

    }

    void Update()
    {
        if (Time.timeScale != 1) {
          Time.timeScale = 1;
        }

        makeNote();
    }

    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
