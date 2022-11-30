using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadNextLevel()
    {
        StartCoroutine(DelayLoadNextLevel());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayGameOver());
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
    }

    private IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator DelayLoadNextLevel()
    {
        yield return new WaitForSeconds(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
