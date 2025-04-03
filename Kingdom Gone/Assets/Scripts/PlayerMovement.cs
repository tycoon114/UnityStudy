using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 2.0f;
    public LayerMask groundLayer;

    private PlayerAnimation playerAnimation;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }


    public async void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector3(moveInput * moveSpeed, rb.linearVelocity.y);


        if (playerAnimation != null)
        {
            playerAnimation.SetWalking(moveInput != 0);
        }

        if (moveInput != 0)
        {
            GetComponent<SpriteRenderer>().flipX = moveInput < 0;
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            SoundManager.Instance.PlaySFX(SFXType.SFX_Jump);
            playerAnimation.SetJumping(true);
            Debug.Log("점프 시작");
        }

        else if (!isGrounded)
        {
            playerAnimation?.SetFalling(true);
            Debug.Log("Falling");
        }

        else if (isGrounded) //착지상태
        {
            playerAnimation?.PlayLanding();
            Debug.Log("Grounded");
        }

    }

    public void WalkSound()
    {
        //만약 닿는 위치마다 소리를 다르게 넣고 싶다면 조건문과 RayCast 사용
        SoundManager.Instance.PlaySFX(SFXType.SFX_Walk);

    }
}
