using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float delay = 0.5f;

    public void LoadMainMenu()
    {
        StartCoroutine(LoadMain());
    }
    private IEnumerator LoadMain()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadLevel1()
    {
        StartCoroutine(LoadLevel());
    }
    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level 1");
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadNext());
    }
    private IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadOptionsMenu()
    {
        StartCoroutine(LoadOptions());
    }
    private IEnumerator LoadOptions()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Options Menu");
    }

    public void LoadCreditsScreen()
    {
        SceneManager.LoadScene("Credits Screen");
    }
}
