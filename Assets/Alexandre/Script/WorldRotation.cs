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
                StartCoroutine(RotateMe(Vector3.up * -90, 0.3f));
               enablekey = true;
            }

        }
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = theWorld.transform.rotation;
        var toAngle = Quaternion.Euler(theWorld.transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            theWorld.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        enablekey = false;

    }
}
