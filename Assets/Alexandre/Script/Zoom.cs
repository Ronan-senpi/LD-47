using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public float minFOV = 20f;
    public float maxFOV = 80f;

    public float sensibility = 10f;

    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * sensibility;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }
}
