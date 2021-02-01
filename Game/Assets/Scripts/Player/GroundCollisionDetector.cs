using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundCollisionDetector : MonoBehaviour
{
    [SerializeField]
    private PlayerManager playerManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerManager.IsGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerManager.IsGrounded = false;
        }
    }
}
