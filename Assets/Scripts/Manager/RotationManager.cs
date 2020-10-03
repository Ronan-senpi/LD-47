using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour
{
    bool inRotation;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && CanRotatate())
        {
            Rotation(90);
            GameEvents.Instance.RotateCamera();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && CanRotatate())
        {
            Rotation(-90);
            GameEvents.Instance.RotateCamera();
        }
    }

    void Rotation(float ry)
    {
        GameEvents.Instance.ResetPostion();
        Transform player = GameManager.Instance.GetPlayer();
        Camera.main.transform.parent = player;
        player.Rotate(0, ry, 0);
        Camera.main.transform.parent = null;

    }

    bool CanRotatate()
    {
        return !inRotation;
    }
}
