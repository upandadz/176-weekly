using UnityEngine;

public class CannonController : MonoBehaviour
{
    public Transform cannonTransform;
    public Transform cannonFirePoint;
    public GameObject cannonBallPrefab; // the thing to shoot

    public float projectileSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        RotateCannonWithMouse();

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void RotateCannonWithMouse()
    {
        // grabs current mouse pos in screen space
        Vector3 mousePos = Input.mousePosition;
        
        // convert the mouse position to a point world space
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.nearClipPlane));
        
        // calculate the direction from the cannon to the mouse position
        Vector3 directionToMouse = worldMousePosition - cannonTransform.position;
        
        // calculate launch angle in radians
        float launchAngleInRadians = Mathf.Atan2(directionToMouse.y, directionToMouse.x);
        
        // converting my radians to degrees -- 1 radian is equal to roughly 57 degrees
        float launchAngleInDegrees = launchAngleInRadians * Mathf.Rad2Deg;
        
        // rotate the cannon to face the mouse cursor
        cannonTransform.rotation = Quaternion.Euler(0, 0, launchAngleInDegrees);
    }

    public void Fire()
    {
        GameObject clone = Instantiate(cannonBallPrefab, cannonFirePoint.position, Quaternion.identity);
        
        clone.GetComponent<Rigidbody>().linearVelocity = cannonTransform.forward * projectileSpeed;
    }
}
