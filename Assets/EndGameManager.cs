using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    string nextLvl;
    [SerializeField]
    LayerMask playerMask;

    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            SceneManager.LoadScene(nextLvl);
        }
    }
}
