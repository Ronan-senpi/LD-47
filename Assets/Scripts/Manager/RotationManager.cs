using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    bool inRotation;
    [SerializeField]
    Camera cam;
    private void start()
    {
        GameEvents.Instance.onFreeCam += FreeCam;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && CanRotatate())
        {
            Rotation(90f);
            GameEvents.Instance.RotateCamera();
        }
    }

    void Rotation(float ry)
    {
        //inRotation = true;
        //GameEvents.Instance.ResetPostion();
        Transform player = GameManager.Instance.GetPlayer();
        cam.transform.parent = player;
        LerpRotation lerp;
        if (!player.TryGetComponent<LerpRotation>(out lerp))
            return;
        lerp.SetAngle(ry);
    }

    void FreeCam()
    {
        cam.transform.parent = null;
        //inRotation = false;

    }

    bool CanRotatate()
    {
        return !inRotation;
    }
}
