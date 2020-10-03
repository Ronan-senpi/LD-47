using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerPosition : MonoBehaviour
{
    public int layerPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.layer = layerPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
