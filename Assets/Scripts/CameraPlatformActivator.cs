using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlatformActivator : MonoBehaviour
{
    [SerializeField]
    LayerMask groundLayer;
    private void OnTriggerEnter(Collider other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            PlatfomPositionController ppc;
            if (other.TryGetComponent<PlatfomPositionController>(out ppc))
            {
                ppc.enabled = true;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            PlatfomPositionController ppc;
            if (other.TryGetComponent<PlatfomPositionController>(out ppc))
            {
                ppc.enabled = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if ((groundLayer.value & (1 << other.gameObject.layer)) > 0)
        {
            PlatfomPositionController ppc;
            if (other.TryGetComponent<PlatfomPositionController>(out ppc))
            {
                ppc.enabled = false;
            }
        }
    }
}
