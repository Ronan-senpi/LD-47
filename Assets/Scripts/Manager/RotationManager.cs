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
            Rotation(90f);
            GameEvents.Instance.RotateCamera();
        }
    }

    void Rotation(float ry)
    {
        GameEvents.Instance.ResetPostion();
        Transform player = GameManager.Instance.GetPlayer();
        Camera.main.transform.parent = player;
        LerpRotation lerp;
        if (!player.TryGetComponent<LerpRotation>(out lerp))
            return;
        lerp.SetAngle(ry);
        Camera.main.transform.parent = null;
    }

    bool CanRotatate()
    {
        return !inRotation;
    }
}
