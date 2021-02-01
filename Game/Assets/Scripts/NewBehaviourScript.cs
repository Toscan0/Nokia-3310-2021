using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();

        Debug.Log("cam width: " + cam.pixelWidth);
        Debug.Log("cam height: " + cam.pixelHeight);
        Debug.Log("cam pixel rect: " + cam.pixelRect);
        Debug.Log("cam rect: " + cam.rect);
    }

    void Update()
    {
        Vector3 screenPos = cam.WorldToScreenPoint(target.position);
        Debug.Log(screenPos.x + " " + screenPos.y);

        Vector3 aux = cam.WorldToViewportPoint(target.position);
        Debug.Log(aux.x + " " + aux.y);
    }
}
