using UnityEngine;
using UnityEngine.Video;

public class DungeonIntro : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

       
        Invoke("DestroyVideo", 10f); 
    }

    void DestroyVideo()
    {
        Destroy(gameObject); 
    }
}
