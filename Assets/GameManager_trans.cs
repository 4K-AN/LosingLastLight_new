using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startingSceneTransition;
    [SerializeField] private GameObject endingSceneTransition;

    private void Start()
    {
        if (startingSceneTransition != null)
        {
            startingSceneTransition.SetActive(true);
            StartCoroutine(DisableStartingSceneTransition());
        }
    }

    private IEnumerator DisableStartingSceneTransition()
    {
        yield return new WaitForSeconds(5f); // Tunggu 5 detik sebelum menghilangkan transisi awal
        startingSceneTransition.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadSceneWithTransition(sceneIndex));
    }

    private IEnumerator LoadSceneWithTransition(int sceneIndex)
    {
        if (endingSceneTransition != null)
        {
            endingSceneTransition.SetActive(true);
            yield return new WaitForSeconds(2f); // Durasi transisi keluar sebelum pindah scene
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
