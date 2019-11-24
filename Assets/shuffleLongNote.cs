using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuffleLongNote : MonoBehaviour
{
    // Start is called before the first frame update

    int speed = 8;
    public bool isLeft = true;
    void Start()
    {
        Debug.Log("shuffleLongNote");
        isLeft = true;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
