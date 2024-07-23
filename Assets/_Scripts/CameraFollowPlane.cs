using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlane : MonoBehaviour
{
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector2.zero;
    private Transform planePos;
    private void Start()
    {
        planePos = FindObjectOfType<PlaneControll>().transform;
    }
    private void LateUpdate()
    {
        Vector3 targetPos = new Vector3(planePos.position.x, planePos.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0.0f, 10000.0f), Mathf.Clamp(transform.position.y, 0.0f, 100.0f), transform.position.z);
    }
}
