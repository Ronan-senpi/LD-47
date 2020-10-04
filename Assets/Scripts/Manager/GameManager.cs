using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform player;
    PlayerDeplacement3D playerDeplacement;
    public static GameManager Instance { get; set; }

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
        if (!player.gameObject.TryGetComponent<PlayerDeplacement3D>(out playerDeplacement))
        {
            Debug.LogError("Need PlayerDeplacement3D");
        }
    }

    public Transform GetPlayer()
    {
        return player.transform;
    }

    public float GetPlayerZ()
    {
        return player.position.z;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="direction">1 ou -1</param>
    public void SetMoveAxis(Axis axis, float direction = 1)
    {
        playerDeplacement.SetMoveAxis(axis, direction);
    }
}
