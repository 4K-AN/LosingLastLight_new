using UnityEngine;
using UnityEngine.SceneManagement;

public class MENUSETTING : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
