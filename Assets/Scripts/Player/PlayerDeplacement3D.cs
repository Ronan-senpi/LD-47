using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacement3D : MonoBehaviour
{
    //[Header("Keys")]
    private string horizontalAxis = "Horizontal";
    private string VerticalAxis = "Vertical";
    [Header("Walk")]
    [SerializeField]
    private float speed;

    [Header("Jump")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private Vector3 checkSize;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundLayers;
    [SerializeField]
    private float extraJump;

    private float extraJumpValue;

    private bool isGrounded;

    public bool IsGrounded
    {
        get { return isGrounded; }
        private set { isGrounded = value; }
    }

    private float moveInput;
    private bool facingRight = true;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        extraJumpValue = extraJump;
        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.LogError("Need a Rigidbody");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, checkSize);

    }
    private void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics.OverlapBox(groundCheck.position, checkSize, transform.rotation, groundLayers)?.Length != 0;
        //Move on X (lateral) axis
        moveInput = Input.GetAxisRaw(horizontalAxis);
        rb.velocity = new Vector3(moveInput * speed, rb.velocity.y);
        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        if (isGrounded)
            extraJumpValue = extraJump;

        if (Input.GetButtonDown(VerticalAxis) && extraJumpValue > 0)
        {
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            extraJumpValue--;
        }
        else if (Input.GetButtonDown(VerticalAxis) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }

    /// <summary>
    /// Inverse x sprite
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}

