using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    public static Action OnFlyPickedUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var isPickable = collision.gameObject.GetComponent<IPickable>();
        if (isPickable != null)
        {
            isPickable.PickUp();

            OnFlyPickedUp?.Invoke();
        }
    }
}
