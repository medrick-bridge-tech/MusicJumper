using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    
    [SerializeField] Transform targetTransform;
    private float smoothSpeed = 1f;

    private Vector3 _offset;

    private void Start() {

        
    
        
        _offset = transform.position - targetTransform.position;
        
    }

    private void Update()
    {
        if (targetTransform && targetTransform.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            
                Vector3 direction = targetTransform.position + _offset;
                var position = transform.position;
                direction.x = position.x;
                var smoothPosition = Vector3.Lerp(position, direction, smoothSpeed);
                position = smoothPosition;
                transform.position = position;    
            
        }
        
        
    }
}
