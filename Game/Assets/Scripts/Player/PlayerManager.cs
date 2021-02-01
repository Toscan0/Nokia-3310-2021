using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{
    public bool IsGrounded { private get; set; } = true;

    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private float horizontalMove = 0f;
    private bool jump = false;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // move player
        horizontalMove = Input.GetAxis("Horizontal");
        playerMovement.Move(transform.right * horizontalMove *
            Time.deltaTime * movementSpeed);

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("DDDD");
            jump = true;
        }

    }

    void FixedUpdate()
    {
        if (jump)
        {
            jump = false;

            playerMovement.Jump(jumpForce);
        }
    }
}
