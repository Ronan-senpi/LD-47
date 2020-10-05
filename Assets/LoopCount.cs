using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopCount : MonoBehaviour
{
    [SerializeField]
    LayerMask playerMask;
    [SerializeField]
    TextMeshPro text;
    [SerializeField]
    int nbLoop;
    int loopCounter = 0;

    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            loopCounter++;
        }
    }

    private void Update()
    {
        Debug.Log(loopCounter);
        if (nbLoop <= loopCounter)
        {
            text.text = "Left arrow";
        }
    }
}
