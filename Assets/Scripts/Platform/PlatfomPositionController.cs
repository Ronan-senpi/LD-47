using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfomPositionController : MonoBehaviour
{
    private Vector3 initialPosition;
    public MeshRenderer renderer;
    private void Awake()
    {
        initialPosition = transform.position;
    }
    // Start est appelé juste avant qu'une méthode Update soit appelée pour la première fois
    private void Start()
    {
        GameEvents.Instance.onRotateCamera += OnRotateCamera;
        GameEvents.Instance.onResetPostion += ResetPostion;
        if(TryGetComponent<MeshRenderer>(out renderer))
        {
            Debug.LogError("Need renderer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer.isVisible)
            Debug.Log(renderer.transform.name);
    }

    private void OnRotateCamera()
    {
        //Si visible dans l'ecran scene alors TRUE
        if (!renderer.isVisible)
            return;
        
        ResetPostion();
        Vector3 v = transform.position;

        int ry = (int)Camera.main.transform.eulerAngles.y;
        switch (ry)
        {
            case 180:
            case 0:
                v.z = GameManager.Instance.GetPlayer().transform.position.z;
                GameManager.Instance.SetMoveAxis(Axis.y);
                break;
            case 90:
            case 270:
                v.x = GameManager.Instance.GetPlayer().transform.position.x;
                GameManager.Instance.SetMoveAxis(Axis.x);
                break;

            default:
                break;
        }
        transform.position = v;
    }

    private void ResetPostion()
    {
        transform.position = initialPosition;
    }

    // Cette fonction est appelée quand le MonoBehaviour est détruit
    private void OnDestroy()
    {
        GameEvents.Instance.onRotateCamera -= OnRotateCamera;
        GameEvents.Instance.onResetPostion -= ResetPostion;

    }



}
