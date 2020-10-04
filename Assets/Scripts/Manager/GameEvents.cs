using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents Instance { get; set; }

    // Awake est appelé quand l'instance de script est chargée
    private void Awake()
    {
        //Begin: Singleton
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        //End: Singleton

    }

    public event Action onRotateCamera;
    public void RotateCamera()
    {
        if (onRotateCamera != null)
        {
            onRotateCamera();
        }
    }
    public event Action onResetPostion;
    public void ResetPostion()
    {
        if (onResetPostion != null)
        {
            onResetPostion();
        }
    }
    public event Action onFreeCam;
    public void FreeCam()
    {
        if (onFreeCam != null)
        {
            onFreeCam();
        }
    }
}
