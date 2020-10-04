using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool canRotate = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    float speed = 90f;
    float max = 360;
    Vector3 v3;
    // Update is called once per frame
    void Update()
    {
        //if (canRotate)
        //    transform.RotateAround(transform.position, Vector3.up, 90 * Time.deltaTime);
        //if (transform.rotation.eulerAngles.y >= 90f)
        ////    canRotate = false;
        //Debug.Log(Time.deltaTime);
        //transform.Rotate(0,Math.Min(speed*Time.deltaTime,90f),0);

        v3.y += speed * Time.deltaTime;
        if (v3.y <= max)
        {
            transform.eulerAngles = v3;
        }
        else
        {
            v3.y = max;
            transform.eulerAngles = v3;
        }

    }
}
