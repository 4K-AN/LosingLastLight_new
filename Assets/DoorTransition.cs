using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Perjalanan"; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
