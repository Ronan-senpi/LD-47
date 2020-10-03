using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakableItem : MonoBehaviour
{
    [SerializeField]
    protected RigidbodyConstraints2D rigidbodyConstraints;
    Rigidbody2D rb;
    private void Awake()
    {
        if (gameObject.TryGetComponent<Rigidbody2D>(out rb))
        {
            rb.constraints = rigidbodyConstraints;
        }
        else
        {
            Debug.LogError("Need Rigibody2D");
        }
    }
    public void ToggleRigidbody2D(bool activate)
    {
        if (activate)
        {
            rb.constraints = rigidbodyConstraints;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
}
