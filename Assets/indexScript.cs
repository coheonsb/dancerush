using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class indexScript : MonoBehaviour
{
    // Start is called before the first frame update

    long startTime;
    long musicStartTime;
    bool isMusicPlay = false;

    [System.Serializable]
    class NoteData
    {
        public int type;
        public long time;
        public float position;
        public float size;
        public float rotation;
        public bool isLeft;
        public bool isLast;
    };
    TextAsset textData;

    [System.Serializable]
    class NoteArray
    {
        public List<NoteData> data;
        public long musicStartTime;
    };
    NoteArray noteArray;

    void Start()
    {

        SteamVR_Render.pauseRendering = false;
        Debug.Log("시작!");
        startTime = DateNow();
        StartCoroutine(Example());
        textData = (Resources.Load("crazyShuffle") as TextAsset);
        noteArray = JsonUtility.FromJson<NoteArray>(textData.ToString());
        musicStartTime = noteArray.musicStartTime;
    }



    IEnumerator Example()
    {

        while (true)
        {
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
                    float position = noteArray.data[i].position - 0.5f;
                    position = GameObject.Find("noteDispenser").transform.localScale.z * -position;
                    note = Instantiate(GameObject.Find(noteName),
                        new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + position),
                        Quaternion.Euler(new Vector3(0, noteArray.data[i].rotation, 0))) as GameObject;
                    note.transform.localScale = new Vector3(noteArray.data[i].size, 1, 1.2f);
                    note.GetComponent<defualtLongNote>().isLast = noteArray.data[i].isLast;

                }
                else if (randNote == 5)
                {
                    float position = noteArray.data[i].position - 0.5f;
                    position = GameObject.Find("noteDispenser").transform.localScale.z * -position;
                    note = Instantiate(GameObject.Find(noteName),
                        new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y - (0.01f), GameObject.Find("noteDispenser").transform.position.z + position),
                        Quaternion.Euler(new Vector3(0, noteArray.data[i].isLeft == true ? 90: -90, 0))) as GameObject;
                    note.GetComponent<shuffleLongNote>().isLeft = noteArray.data[i].isLeft;
                }
                else
                {
                    float position = noteArray.data[i].position - 0.5f;
                    position = GameObject.Find("noteDispenser").transform.localScale.z * -position;

                    note = Instantiate(GameObject.Find(noteName),
                    new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y + (0.05f), GameObject.Find("noteDispenser").transform.position.z + position),
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
        if (!isMusicPlay) {
            if (DateNow() > musicStartTime + startTime) {
                isMusicPlay = true;
                GameObject.Find("CrazyShuffle").GetComponent<AudioSource>().Play();
            }
        }

        makeNote();
    }

    public static long DateNow()
    {
        return DateTimeOffset.Now.ToUnixTimeMilliseconds();
    }
}
