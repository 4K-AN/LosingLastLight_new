using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;

    public float zoomSpeed = 10f; 
    public float minZoom = 2f;
    public float maxZoom = 20f;

    private float currentZoom;
    private Vector3 initialOffsetDirection; 

    void Start()
    {
        currentZoom = offset.magnitude;
        initialOffsetDirection = offset.normalized; 
    }

    void LateUpdate()
    {
        if (player != null)
        {
          
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            currentZoom -= scrollInput * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            
            Vector3 desiredPosition = player.position + initialOffsetDirection * currentZoom;

            
            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                smoothSpeed * Time.deltaTime * 60 
            );

            transform.LookAt(player);
        }
    }
}