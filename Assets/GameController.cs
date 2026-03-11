using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    public GameObject GameOverCanvas;  // now GameObject
    public TMP_Text TimerText;
    public TMP_Text CoinText;
    public GameObject PauseCanvas;     // now GameObject

    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (player != null)
        {
            player.PlayerDied += WhenPlayerDies;
        }

        if (GameOverCanvas != null && GameOverCanvas.activeSelf)
        {
            GameOverCanvas.SetActive(false);
        }

        if (PauseCanvas != null && PauseCanvas.activeSelf)
        {
            PauseCanvas.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (GameOverCanvas == null || !GameOverCanvas.activeSelf))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (PauseCanvas != null)
        {
            PauseCanvas.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (PauseCanvas != null)
        {
            PauseCanvas.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void WhenPlayerDies()
    {
        if (GameOverCanvas != null)
            GameOverCanvas.SetActive(true);

        if (TimerText != null)
            TimerText.text = "Timer: " + Time.timeSinceLevelLoad.ToString("F2");

        if (CoinText != null && player != null)
            CoinText.text = "Coins Collected: " + player.CoinsCollected;

        if (player != null)
            player.PlayerDied -= WhenPlayerDies;
    }

    public void RetryClicked()
    {
        RestartGame();
    }
}

