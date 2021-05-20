using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    public void LoadCreditsScreen()
    {
        SceneManager.LoadScene("Credits Screen");
    }
}
