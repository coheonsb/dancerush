using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defualtLongNote : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 8;
    public bool isLast;
    void Start()
    {
        Debug.Log("defualtLongNote");
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
