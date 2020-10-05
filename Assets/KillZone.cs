using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField]
    LayerMask playerMask;
    [SerializeField]
    Transform startZone;
    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask.value & (1 << other.gameObject.layer)) > 0)
        {
            other.transform.position = startZone.position;
        }
        else
        {
            Destroy(other);
        }

    }
}
