using UnityEngine;

public class Angles : MonoBehaviour
{
    public Transform targetObject; // target I will be using for angle detection
    public float rotationalSpeed = 25f;
    
    // Update is called once per frame
    void Update()
    {
        CheckAngle();
        RotationalExample();
    }

    void CheckAngle()
    {
        if (this.targetObject != null)
        {
            // I want to get the direction from this object to my target.
            Vector3 directionToTarget = targetObject.position - transform.position;
            
            // calculate the anlge between my forward direction to my target
            float angle = Vector3.Angle(transform.forward, directionToTarget);
            
            Debug.Log("Angle: " + angle);
        }
    }

    void RotationalExample()
    {
        // this will be between -1 and 1
        float rotationalInput = Input.GetAxis("Horizontal");
        
        // calculate the rotation in radians using Mathf.Deg2Rad
        float rotationInRadians = rotationalInput * Mathf.Deg2Rad;
        
        // apply the rotation
        transform.Rotate(Vector3.up, rotationInRadians * rotationalSpeed);
    }
}
