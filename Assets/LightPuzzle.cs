using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject door; // Pintu yang akan terbuka
    [SerializeField] private float openDelay = 1.3f; // Waktu tunda sebelum pintu terbuka
    [SerializeField] private float closeDelay = 10f; // Waktu sebelum pintu menutup kembali (10 detik)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Cek apakah yang menginjak adalah Player
        {
            StartCoroutine(OpenDoorWithDelay()); // Mulai proses pembukaan pintu setelah delay
        }
    }

    private IEnumerator OpenDoorWithDelay()
    {
        yield return new WaitForSeconds(openDelay); // Tunggu 1,3 detik sebelum pintu terbuka
        door.SetActive(false); // Buka pintu (menghilangkan objek)
        StartCoroutine(CloseDoorAfterDelay()); // Mulai countdown untuk menutup pintu
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay); // Tunggu 10 detik
        door.SetActive(true); // Tutup pintu kembali
    }
}
