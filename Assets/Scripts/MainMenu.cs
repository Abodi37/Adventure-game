using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        // Resets time just in case it was paused from a previous game over
        Time.timeScale = 1f; 
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited"); // This helps you see it works in the editor
        Application.Quit();
    }
}

