using UnityEngine;

public class CameraController : MonoBehaviour
{

    // public declarations come first
    public GameObject followTarget;
    public float moveSpeed;

    // then private
    private Vector3 targetPosition;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // keeping the update function readable and puting logic in a method.
        // May be a good Idea to never have the logic directly in the update function. 
        ChangeCameraPosition();
    }

    /// <summary>
    /// Follow Target specified in the component
    /// </summary>
    private void ChangeCameraPosition()
    {
        // Variable used twice so declaring it locally
        Vector3 followTargetPosition = followTarget.transform.position;

        targetPosition = new Vector3(followTargetPosition.x, followTargetPosition.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
