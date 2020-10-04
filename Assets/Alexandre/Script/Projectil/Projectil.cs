using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField]
    private GameObject projectil;

    [SerializeField]
    private float force;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private AudioSource preFire;
    [SerializeField]
    private AudioSource fire;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            preFire.Play();
            animator.SetTrigger("Attack");
        }
    }

    public void FireBullet()
    {
        preFire.Stop(); 
        fire.Play();
        float parentScaleX = transform.parent.localScale.x;
        GameObject bullet = Instantiate<GameObject>(projectil, transform.position, transform.rotation);
        bullet.transform.Rotate(Vector3.up * (parentScaleX < 0 ? 180f : 0f));
        bullet.GetComponent<Rigidbody>().AddForce(parentScaleX * force, 0, 0);
    }
}
