using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField]
    private GameObject projectil;

    public Rigidbody rigb;

   
    // Start is called before the first frame update
    void Start()
    {

        //rigb = projectil.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireBullet();
        }
        
    }

    public void FireBullet()
    {
        GameObject clone;

        clone = (Instantiate(projectil, transform.position + 1.0f * transform.forward, transform.rotation)) as GameObject;
        clone.GetComponent<Rigidbody>().AddForce(5000, 0, 0);
    }
}
