using UnityEngine;

public class DestroyAndRespawn : MonoBehaviour
{
    public float respawnTime = 5f; // Waktu sebelum objek muncul kembali

    void Start()
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        gameObject.SetActive(false); // Nonaktifkan objek
        Invoke(nameof(RespawnObject), respawnTime); // Panggil RespawnObject() setelah beberapa detik
    }

    void RespawnObject()
    {
        gameObject.SetActive(true); // Munculkan kembali objek
    }
}
