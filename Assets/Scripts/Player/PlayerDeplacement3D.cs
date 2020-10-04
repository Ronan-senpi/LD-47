using Assets.Scripts;
using UnityEngine;

public class PlayerDeplacement3D : MonoBehaviour
{
    //[Header("Keys")]
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    
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
    private float direction  =1;
    Axis moveAxis = Axis.x;
    public bool IsGrounded
    {
        get { return isGrounded; }
        private set { isGrounded = value; }
    }

    private float moveInput;
    private bool facingRight = true;
    private Rigidbody rb;
    private Animator animator;
    private Projectil projectil;

    // Start is called before the first frame update
    void Start()
    {
        extraJumpValue = extraJump;
        if ((projectil = GetComponentInChildren<Projectil>()) == null)
        {
            Debug.LogError("Need an Projectil");
        } 
        if (!TryGetComponent<Animator>(out animator))
        {
            Debug.LogError("Need an Animator");
        }
        if (!TryGetComponent<Rigidbody>(out rb))
        {
            Debug.LogError("Need a Rigidbody");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, checkSize);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="axis"></param>
    /// <param name="direction">1 ou -1</param>
    public void SetMoveAxis(Axis axis, float direction)
    {
        this.direction = direction;
        moveAxis = axis;
    }

    private void FixedUpdate()
    {
        // Check if player is grounded
        isGrounded = Physics.OverlapBox(groundCheck.position, checkSize, transform.rotation, groundLayers)?.Length != 0;
        animator.SetBool("IsJumping", !isGrounded);
        //Move on X (lateral) axis
        moveInput = Input.GetAxisRaw(horizontalAxis);
        //Debug.Log(moveInput);
        if (moveAxis == Axis.x)
            rb.velocity = new Vector3(direction * (moveInput * speed), rb.velocity.y, rb.velocity.z);
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, direction * (moveInput * speed));
            //Debug.Log(new Vector3(rb.velocity.x, rb.velocity.y, direction * (moveInput * speed)));
        }
        if (moveInput != 0)
        {
            AudioManager.Instance.Play("Walk");
        }
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
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

        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            if (extraJumpValue > 0) {
                rb.AddForce(jumpVector, ForceMode.Impulse);
                extraJumpValue--;
            } else if (extraJump == 0 && isGrounded == true) {
                rb.velocity = jumpVector;
            }
        }
    }

    /// <summary>
    /// Inverse x sprite
    /// </summary>
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler;
        scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void Shoot()
    {
        projectil.FireBullet();
    }

}

