using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] float smoothSpeed;

    private Vector3 Offset;

    private void Start()
    {
        Offset = transform.position - Target.position;
    }

    private void Update()
    {
        Vector3 Direction = Target.position + Offset;
        Direction.x = transform.position.x;
        Vector3 smoothPositin = Vector3.Lerp(transform.position, Direction, smoothSpeed);
        transform.position = smoothPositin;
    }
}
