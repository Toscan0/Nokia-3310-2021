using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerCollisionManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var isPickable = collision.gameObject.GetComponent<IPickable>();
        if (isPickable != null)
        {
            isPickable.PickUp();
        }
    }
}
