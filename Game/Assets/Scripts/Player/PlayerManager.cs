using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{
    public bool IsGrounded { private get; set; } = false;

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
        

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {
        playerMovement.Move(horizontalMove * Time.fixedDeltaTime);


        if (jump)
        {
            jump = false;

            playerMovement.Jump();
        }
    }
}
