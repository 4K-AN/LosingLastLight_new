using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    public float delayTime = 30f; // Waktu sebelum object dinonaktifkan

    void Start()
    {
        Invoke("DisableObject", delayTime);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
