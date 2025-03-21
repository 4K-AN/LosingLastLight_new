using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 0.125f;

    public float zoomSpeed = 10f; // Meningkatkan kecepatan zoom
    public float minZoom = 2f;
    public float maxZoom = 20f;

    private float currentZoom;
    private Vector3 initialOffsetDirection; // Menyimpan arah offset awal

    void Start()
    {
        currentZoom = offset.magnitude;
        initialOffsetDirection = offset.normalized; // Menghitung arah sekali di awal
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Handle zoom input
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            currentZoom -= scrollInput * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            // Hitung posisi yang diinginkan dengan zoom
            Vector3 desiredPosition = player.position + initialOffsetDirection * currentZoom;

            // Smoothing pergerakan kamera
            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                smoothSpeed * Time.deltaTime * 60 // Menyesuaikan dengan frame rate
            );

            transform.LookAt(player);
        }
    }
}