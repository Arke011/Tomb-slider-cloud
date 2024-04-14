using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(0.01f, 0.99f)] public float smoothness;

    void LateUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
    }
}

