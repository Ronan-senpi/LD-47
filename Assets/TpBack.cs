using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpBack : MonoBehaviour
{
    [SerializeField]
    bool exitLoop = false;
    [SerializeField]
    private Transform tpBackPosition;
    [SerializeField]
    private LayerMask WhoIsTP;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private CinemachineBrain brainCam;
    [SerializeField]
    private CinemachineVirtualCamera VMcam;
    private void OnTriggerEnter(Collider other)
    {
        if ((WhoIsTP.value & (1 << other.gameObject.layer)) > 0)
        {
            if (exitLoop)
            {

                brainCam.enabled = true;
                VMcam.enabled = true;
                cam.transform.parent = null;
                return;
            }
            brainCam.enabled = false;
            VMcam.enabled = false;
            cam.transform.parent = other.transform;
            Vector3 v = other.transform.position;
            v.x = tpBackPosition.position.x;
            v.z = tpBackPosition.position.y;
            other.transform.position = v;

        }
    }
}
