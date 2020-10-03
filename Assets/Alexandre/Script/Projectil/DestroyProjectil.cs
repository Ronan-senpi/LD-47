using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectil : MonoBehaviour
{
    [SerializeField]
    private float timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer <=0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Ennemis")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if(collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
