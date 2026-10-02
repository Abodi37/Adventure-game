using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public AudioSource catchSound;

    void Start()
    {
        // Make sure panels are hidden and game is running
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the maze
    }

    // Change this line
public void PlayerCaught(AudioSource enemyVoice)
{
    if (enemyVoice != null && !enemyVoice.isPlaying) 
        enemyVoice.Play();
        
    losePanel.SetActive(true);
    Time.timeScale = 0f; 
}

    // Assign this to your UI Buttons in the Inspector
    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

