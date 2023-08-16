using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed;

    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - target.position;
    }

    private void Update()
    {
        Vector3 direction = target.position + _offset;
        var position = transform.position;
        direction.x = position.x;
        var smoothPosition = Vector3.Lerp(position, direction, smoothSpeed);
        position = smoothPosition;
        transform.position = position;
    }
}
