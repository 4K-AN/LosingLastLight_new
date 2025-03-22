using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Debug.Log("Memuat Scene: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
