using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieGrid : MonoBehaviour
{
    [SerializeField]
    LayerMask layer;
    [SerializeField]
    Transform player;
    private void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, player.position, Color.red);
        if (Physics.Raycast(transform.position, player.position, out hit, 100.0f, layer.value, QueryTriggerInteraction.Collide))
        {
            hit.transform.gameObject.SetActive(false);
        }
    }
}
