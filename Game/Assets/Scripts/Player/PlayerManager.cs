using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Animator))]
public class PlayerManager : MonoBehaviour
{
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool isGrounded = false;

    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        GroundCollisionDetector.OnPlayerGrounded += IsPlayerGrounded;
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;

            animator.SetBool("Jump", true);
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move(horizontalMove * Time.fixedDeltaTime);

        if (jump)
        {
            jump = false;
            playerMovement.Jump();   
        }
    }

    private void IsPlayerGrounded(bool b)
    {
        isGrounded = b;
        if (isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }

    private void OnDestroy()
    {
        GroundCollisionDetector.OnPlayerGrounded -= IsPlayerGrounded;
    }
}
