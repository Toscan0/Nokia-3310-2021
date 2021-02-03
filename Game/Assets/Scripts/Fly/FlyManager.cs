using UnityEngine;

public class FlyManager : MonoBehaviour, IPickable
{
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
