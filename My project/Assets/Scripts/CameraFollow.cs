using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector2 offset;
    [Range(1,10)]   
    public  float smoothFactor;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
        
    }

    void Follow(){
        Vector2 targetPosition;
        targetPosition.x = target.position.x + offset.x;
        targetPosition.y = target.position.y + offset.y;
        // Vector2 smoothPosition = Vector2.Lerp(transform.position, targetPosition, smoothFactor*Time.fixedDeltaTime);
        transform.position = new Vector3(targetPosition.x, targetPosition.y, -10);
        // transform.position
        // transform.position.y = targetPosition.y;
        // transform.position.z = -10;
    }
}
