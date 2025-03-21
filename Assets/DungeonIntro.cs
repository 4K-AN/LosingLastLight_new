using UnityEngine;
using UnityEngine.Video;

public class DungeonIntro : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Mulai video dan hapus gameobject setelah durasi video selesai
        Invoke("DestroyVideo", 10f); // Ganti 10f sesuai durasi video
    }

    void DestroyVideo()
    {
        Destroy(gameObject); // Hapus Video Player setelah 10 detik
    }
}
