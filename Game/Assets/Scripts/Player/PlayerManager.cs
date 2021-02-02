using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private Sprite iddleSprite;
    [SerializeField]
    private Sprite jumpSprite;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool isGrounded = false;

    private PlayerMovement playerMovement;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GroundCollisionDetector.OnPlayerGrounded += IsPlayerGrounded;
        
    }

    private void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move(horizontalMove * Time.fixedDeltaTime);

        if (jump)
        {
            jump = false;
            playerMovement.Jump();

            spriteRenderer.sprite = jumpSprite;
        }
    }

    private void IsPlayerGrounded(bool b)
    {
        isGrounded = b;

        if (isGrounded)
        {
            spriteRenderer.sprite = iddleSprite;
        }
    }

    private void OnDestroy()
    {
        GroundCollisionDetector.OnPlayerGrounded -= IsPlayerGrounded;

    }
}
