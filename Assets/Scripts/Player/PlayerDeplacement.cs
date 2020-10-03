using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacement : MonoBehaviour
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
    private Vector2 checkSize;
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundLayers;
    [SerializeField]
    private float extraJump;

    private float extraJumpValue;

    private bool isGrounded;
    private float moveInput;
    private bool facingRight = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        extraJumpValue = extraJump;
        if (!TryGetComponent<Rigidbody2D>(out rb))
        {
            Debug.LogError("Need a Rigidbody2D");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, new Vector3(checkSize.x, checkSize.y));

    }
    private void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics2D.OverlapBox(groundCheck.position, checkSize, 0, groundLayers);
        //Move on X (lateral) axis
        moveInput = Input.GetAxisRaw(horizontalAxis);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
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
            rb.velocity = Vector2.up * jumpForce;
            extraJumpValue--;
        }
        else if (Input.GetButtonDown(VerticalAxis) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
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

