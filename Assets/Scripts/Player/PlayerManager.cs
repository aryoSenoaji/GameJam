using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;

    public static Vector2 lastCheckPointPos = new Vector2(0, 0);

    public static int numberOfNuts;
    public TextMeshProUGUI nutsText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        nutsText.text = numberOfNuts.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
            ResetScore(); // Call ResetScore when the game is over
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        // Additional actions when the game is over
        // You can add more actions or UI updates here
        Debug.Log("Game Over");

        // Stop the countdown timer
        CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
        if (countdownTimer != null)
        {
            countdownTimer.StopCountdown();
        }
    }

    // Method to reset the score
    private void ResetScore()
    {
        numberOfNuts = 0; // Set the score back to its initial state
    }
}
