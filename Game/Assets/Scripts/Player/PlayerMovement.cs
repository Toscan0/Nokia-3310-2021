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

    private new Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    internal void Move(float move)
    {
        move *= movSpeed;

        Vector3 newVelocity = new Vector2(move * 10f, rigidbody.velocity.y);

        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity,
            newVelocity, ref auxVel, movFriction);
    }

    internal void Jump()
    {
        rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}