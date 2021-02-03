using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerGroundCollisionDetector : MonoBehaviour
{
    public static  Action<bool> OnPlayerGrounded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnPlayerGrounded?.Invoke(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            OnPlayerGrounded?.Invoke(false);
        }
    }
}
