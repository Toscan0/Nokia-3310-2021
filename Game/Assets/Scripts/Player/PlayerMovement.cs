using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movSpeed = 50f;
    [Range(0, .3f)]
    [SerializeField]
    private float movFriction = .05f;
    [SerializeField]
    private float jumpForce = 5f;
    
    private Vector3 auxVel = Vector3.zero;

    private new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    internal void Move(float move)
    {
        move *= movSpeed;

        Vector3 newVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);

        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity,
            newVelocity, ref auxVel, movFriction);
    }

    internal void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}