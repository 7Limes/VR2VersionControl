using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen; 

    private bool hasWon = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasWon)
            return;

        if (other.CompareTag("Player"))
        {
            hasWon = true;
            ShowWinScreen();
        }
    }

    void ShowWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }


    public void ExitGame()
    {
        Time.timeScale = 1f;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
