using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRotation : MonoBehaviour
{

    public GameObject theWorld;

    public bool  enablekey = false;

    public Transform rotationWorld;
   // Start is called before the first frame update
    void Start()
    {
        theWorld = GameObject.FindGameObjectWithTag("theWorld");
    }

    // Update is called once per frame
    void Update()
    {
        if(enablekey == false)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(RotateMe(Vector3.up * 90, 0.3f));
                enablekey = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(RotateMe(Vector3.up * -90, 0.4f));
               enablekey = true;
            }

        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = theWorld.transform.rotation;
        Debug.Log(byAngles);
        var toAngle = Quaternion.Euler(theWorld.transform.eulerAngles + byAngles);
        while (theWorld.transform.eulerAngles.y >= (theWorld.transform.eulerAngles + byAngles).y)
        {
            theWorld.transform.rotation = Quaternion.Slerp(fromAngle, toAngle,.3f);
            yield return null;
        }
        //for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        //{
            
        //}
        enablekey = false;
        Debug.Log(theWorld.transform.eulerAngles + byAngles);
        theWorld.transform.Rotate(theWorld.transform.eulerAngles + byAngles);


    }
}
