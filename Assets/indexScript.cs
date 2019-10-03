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
            int randNote = Random.Range(0, 2);
            string noteName = "";

            switch (randNote) {
                case 0:
                    noteName = "leftNote";
                    break;
                case 1:
                    noteName = "rightNote";
                    break;
            }


            note = Instantiate(GameObject.Find(noteName),
                new Vector3(GameObject.Find("noteDispenser").transform.position.x, GameObject.Find("noteDispenser").transform.position.y, GameObject.Find("noteDispenser").transform.position.z + (Random.Range(0.0f, 0.9f) - 0.5f)),
                Quaternion.identity) as GameObject;
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
